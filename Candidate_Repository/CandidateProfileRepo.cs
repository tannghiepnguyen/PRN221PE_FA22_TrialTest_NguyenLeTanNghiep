using Candidate_BusinessObject;
using Candidate_DAO;

namespace Candidate_Repository
{
	public class CandidateProfileRepo : ICandidateProfileRepo
	{
		public bool AddCandidateProfile(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);
		}

		public bool AddCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.AddCandidateProfileJson(candidateProfile);
		}

		public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);
		}

		public bool DeleteCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.DeleteCandidateProfileJson(candidateProfile);
		}

		public CandidateProfile GetCandidateProfile(string id)
		{
			return CandidateProfileDAO.Instance.GetCandidateProfile(id);
		}

		public CandidateProfile GetCandidateProfileJson(string id)
		{
			return CandidateProfileDAO.Instance.GetCandidateProfileJson(id);
		}

		public List<CandidateProfile> GetCandidateProfiles()
		{
			return CandidateProfileDAO.Instance.GetCandidateProfiles();
		}

		public List<CandidateProfile> GetCandidateProfilesJson()
		{
			return CandidateProfileDAO.Instance.GetCandidateProfilesJson();
		}

		public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
		}

		public bool UpdateCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return CandidateProfileDAO.Instance.UpdateCandidateProfileJson(candidateProfile);
		}
	}
}
