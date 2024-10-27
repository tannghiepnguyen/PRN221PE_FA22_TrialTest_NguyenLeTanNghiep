using Candidate_BusinessObject;
using Candidate_Repository;

namespace Candidate_Service
{
	public class JobPostingService : IJobPostingService
	{
		private IJobPostingRepo jobPostingRepo;
		public JobPostingService()
		{
			this.jobPostingRepo = new JobPostingRepo();
		}

		public JobPostingService(IJobPostingRepo jobPostingRepo)
		{
			this.jobPostingRepo = jobPostingRepo;
		}
		public bool AddJobPosting(JobPosting jobPosting)
		{
			return this.jobPostingRepo.AddJobPosting(jobPosting);
		}

		public bool DeleteJobPosting(JobPosting jobPosting)
		{
			return this.jobPostingRepo.DeleteJobPosting(jobPosting);
		}

		public List<JobPosting> GetJobPostings()
		{
			return this.jobPostingRepo.GetJobPostings();
		}

		public JobPosting GetJobPosting(string id)
		{
			return this.jobPostingRepo.GetJobPosting(id);
		}

		public bool UpdateJobPostings(JobPosting jobPosting)
		{
			return this.jobPostingRepo.UpdateJobPostings(jobPosting);
		}

		public List<JobPosting> GetJobPostingsJson()
		{
			return this.jobPostingRepo.GetJobPostingsJson();
		}

		public JobPosting GetJobPostingJson(string id)
		{
			return this.jobPostingRepo.GetJobPostingJson(id);
		}
	}
}
