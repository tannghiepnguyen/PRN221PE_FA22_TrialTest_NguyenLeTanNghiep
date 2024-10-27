using Candidate_BusinessObject;

namespace Candidate_Service
{
	public interface IJobPostingService
	{
		public List<JobPosting> GetJobPostings();
		public JobPosting GetJobPosting(string id);
		public bool DeleteJobPosting(JobPosting jobPosting);
		public bool AddJobPosting(JobPosting jobPosting);
		public bool UpdateJobPostings(JobPosting jobPosting);
		public List<JobPosting> GetJobPostingsJson();
		public JobPosting GetJobPostingJson(string id);
	}
}
