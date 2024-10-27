using Candidate_BusinessObject;

namespace Candidate_Repository
{
	public interface IJobPostingRepo
	{
		public List<JobPosting> GetJobPostings();
		public JobPosting GetJobPosting(string id);
		public List<JobPosting> GetJobPostingsJson();
		public JobPosting GetJobPostingJson(string id);
		public bool DeleteJobPosting(JobPosting jobPosting);
		public bool AddJobPosting(JobPosting jobPosting);
		public bool UpdateJobPostings(JobPosting jobPosting);


	}
}
