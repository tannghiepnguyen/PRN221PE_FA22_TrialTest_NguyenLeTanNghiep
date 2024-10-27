using Candidate_BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Candidate_DAO
{
	public class CandidateProfileDAO
	{
		private static CandidateProfileDAO instance;
		private ILogger logger;
		private string candidateProfileJsonPath;
		//private CandidateManagementContext context;

		public CandidateProfileDAO()
		{
			//this.context = new CandidateManagementContext();
			logger = new LoggerFactory().CreateLogger<CandidateProfileDAO>();
			candidateProfileJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "CandidateProfile.json");
		}

		public static CandidateProfileDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CandidateProfileDAO();
				}
				return instance;
			}
		}

		public List<CandidateProfile> GetCandidateProfiles()
		{
			using (var context = new CandidateManagementContext())
			{
				return context.CandidateProfiles.Include(a => a.Posting).ToList();
			}
		}

		public List<CandidateProfile> GetCandidateProfilesJson()
		{
			var jsonString = File.ReadAllText(candidateProfileJsonPath);
			var candidateProfiles = JsonSerializer.Deserialize<List<CandidateProfile>>(jsonString);
			return candidateProfiles;
		}

		public CandidateProfile GetCandidateProfile(string id)
		{
			using (var context = new CandidateManagementContext())
			{
				return context.CandidateProfiles.Include(a => a.Posting).FirstOrDefault(a => a.CandidateId.Equals(id));
			}

		}

		public CandidateProfile GetCandidateProfileJson(string id)
		{
			var jsonString = File.ReadAllText(candidateProfileJsonPath);
			var candidateProfiles = JsonSerializer.Deserialize<List<CandidateProfile>>(jsonString);
			return candidateProfiles.FirstOrDefault(c => c.CandidateId == id);

		}

		public bool AddCandidateProfile(CandidateProfile candidateProfile)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				CandidateProfile candidateProfile1 = GetCandidateProfile(candidateProfile.CandidateId);
				try
				{
					if (candidateProfile1 == null)
					{
						context.CandidateProfiles.Add(candidateProfile);
						context.SaveChanges();
						isSuccess = true;
					}
				}
				catch (Exception ex)
				{
					logger.LogError(ex.Message);
				}
				return isSuccess;
			}

		}

		public bool AddCandidateProfileJson(CandidateProfile candidateProfile)
		{
			bool isSuccess = false;
			var jsonString = File.ReadAllText(candidateProfileJsonPath);
			var candidateProfiles = JsonSerializer.Deserialize<List<CandidateProfile>>(jsonString);
			CandidateProfile candidateProfile1 = GetCandidateProfileJson(candidateProfile.CandidateId);
			try
			{
				if (candidateProfile1 == null)
				{
					candidateProfiles.Add(candidateProfile);
					File.WriteAllText(candidateProfileJsonPath, JsonSerializer.Serialize(candidateProfiles));
					isSuccess = true;
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);
			}
			return isSuccess;
		}

		public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				CandidateProfile candidateProfile1 = GetCandidateProfile(candidateProfile.CandidateId);
				try
				{
					if (candidateProfile1 != null)
					{
						context.Entry<CandidateProfile>(candidateProfile).State = EntityState.Modified;
						context.SaveChanges();
						isSuccess = true;
					}
				}
				catch (Exception ex)
				{
					logger.LogError(ex.Message);
				}
				return isSuccess;
			}

		}

		public bool UpdateCandidateProfileJson(CandidateProfile candidateProfile)
		{
			bool isSuccess = false;
			var jsonString = File.ReadAllText(candidateProfileJsonPath);
			var candidateProfiles = JsonSerializer.Deserialize<List<CandidateProfile>>(jsonString);
			var index = candidateProfiles.FindIndex(c => c.CandidateId == candidateProfile.CandidateId);
			try
			{
				if (index != -1)
				{
					candidateProfiles[index] = candidateProfile;
					File.WriteAllText(candidateProfileJsonPath, JsonSerializer.Serialize(candidateProfiles));
					isSuccess = true;
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);
			}
			return isSuccess;
		}

		public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				CandidateProfile candidateProfile1 = GetCandidateProfile(candidateProfile.CandidateId);
				try
				{
					if (candidateProfile1 != null)
					{
						context.CandidateProfiles.Remove(candidateProfile);
						context.SaveChanges();
						isSuccess = true;
					}
				}
				catch (Exception ex)
				{
					logger.LogError(ex.Message);
				}
				return isSuccess;
			}

		}

		public bool DeleteCandidateProfileJson(CandidateProfile candidateProfile)
		{
			bool isSuccess = false;
			var jsonString = File.ReadAllText(candidateProfileJsonPath);
			var candidateProfiles = JsonSerializer.Deserialize<List<CandidateProfile>>(jsonString);
			var index = candidateProfiles.FindIndex(c => c.CandidateId == candidateProfile.CandidateId);
			try
			{
				if (index != -1)
				{
					candidateProfiles.RemoveAt(index);
					File.WriteAllText(candidateProfileJsonPath, JsonSerializer.Serialize(candidateProfiles));
					isSuccess = true;
				}
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);
			}
			return isSuccess;

		}
	}
}
