using Candidate_BusinessObject;
using Candidate_Repository;

namespace Candidate_Service
{
	public class CandidateProfileService : ICandidateProfileService
	{
		private readonly ICandidateProfileRepo candidateRepo;
		public CandidateProfileService()
		{
			this.candidateRepo = new CandidateProfileRepo();
		}

		public CandidateProfileService(ICandidateProfileRepo candidateRepo)
		{
			this.candidateRepo = candidateRepo;
		}

		public bool AddCandidateProfile(CandidateProfile candidateProfile)
		{
			return candidateRepo.AddCandidateProfile(candidateProfile);
		}

		public bool AddCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return candidateRepo.AddCandidateProfileJson(candidateProfile);
		}

		public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
		{
			return candidateRepo.DeleteCandidateProfile(candidateProfile);
		}

		public bool DeleteCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return candidateRepo.DeleteCandidateProfileJson(candidateProfile);
		}

		public CandidateProfile GetCandidateProfile(string id)
		{
			return candidateRepo.GetCandidateProfile(id);
		}

		public CandidateProfile GetCandidateProfileJson(string id)
		{
			return candidateRepo.GetCandidateProfileJson(id);
		}

		public List<CandidateProfile> GetCandidateProfiles()
		{
			return candidateRepo.GetCandidateProfiles();
		}

		public List<CandidateProfile> GetCandidateProfilesJson()
		{
			return candidateRepo.GetCandidateProfilesJson();
		}

		public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
		{
			return candidateRepo.UpdateCandidateProfile(candidateProfile);
		}

		public bool UpdateCandidateProfileJson(CandidateProfile candidateProfile)
		{
			return candidateRepo.UpdateCandidateProfileJson(candidateProfile);
		}
	}
}
