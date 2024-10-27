using Candidate_BusinessObject;

namespace Candidate_Repository
{
	public interface ICandidateProfileRepo
	{
		public List<CandidateProfile> GetCandidateProfiles();
		public CandidateProfile GetCandidateProfile(string id);
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
