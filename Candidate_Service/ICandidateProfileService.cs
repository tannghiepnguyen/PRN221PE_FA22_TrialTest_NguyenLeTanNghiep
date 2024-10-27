using Candidate_BusinessObject;

namespace Candidate_Service
{
	public interface ICandidateProfileService
	{
		public CandidateProfile GetCandidateProfile(string id);
		public List<CandidateProfile> GetCandidateProfiles();
		public bool AddCandidateProfile(CandidateProfile candidateProfile);
		public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
		public bool DeleteCandidateProfile(CandidateProfile candidateProfile);

		public List<CandidateProfile> GetCandidateProfilesJson();
		public CandidateProfile GetCandidateProfileJson(string id);
		public bool AddCandidateProfileJson(CandidateProfile candidateProfile);
		public bool UpdateCandidateProfileJson(CandidateProfile candidateProfile);
		public bool DeleteCandidateProfileJson(CandidateProfile candidateProfile);
	}
}
