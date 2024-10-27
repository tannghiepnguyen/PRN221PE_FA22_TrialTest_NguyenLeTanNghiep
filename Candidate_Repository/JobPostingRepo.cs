using Candidate_BusinessObject;
using Candidate_DAO;

namespace Candidate_Repository
{
	public class JobPostingRepo : IJobPostingRepo
	{
		public bool AddJobPosting(JobPosting jobPosting)
		{
			return JobPostingDAO.Instance.AddJobPosting(jobPosting);
		}

		public bool DeleteJobPosting(JobPosting jobPosting)
		{
			return JobPostingDAO.Instance.DeleteJobPosting(jobPosting);
		}

		public List<JobPosting> GetJobPostings()
		{
			return JobPostingDAO.Instance.GetJobPostings();
		}

		public JobPosting GetJobPosting(string id)
		{
			return JobPostingDAO.Instance.GetJobPosting(id);
		}

		public bool UpdateJobPostings(JobPosting jobPosting)
		{
			return JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
		}

		public List<JobPosting> GetJobPostingsJson()
		{
			return JobPostingDAO.Instance.GetJobPostingsJson();
		}

		public JobPosting GetJobPostingJson(string id)
		{
			return JobPostingDAO.Instance.GetJobPostingJson(id);
		}
	}
}
