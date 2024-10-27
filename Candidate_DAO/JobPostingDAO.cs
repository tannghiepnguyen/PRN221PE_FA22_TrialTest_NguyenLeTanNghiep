using Candidate_BusinessObject;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Candidate_DAO
{
	public class JobPostingDAO
	{
		//private CandidateManagementContext context;
		private static JobPostingDAO instance;
		private ILogger logger;
		private string JobPostingJsonPath;

		public JobPostingDAO()
		{
			//this.context = new CandidateManagementContext();
			logger = new LoggerFactory().CreateLogger<JobPostingDAO>();
			JobPostingJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "JobPosting.json");
		}

		public static JobPostingDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new JobPostingDAO();
				}
				return instance;
			}
		}

		public List<JobPosting> GetJobPostings()
		{
			using (var context = new CandidateManagementContext())
			{
				return context.JobPostings.ToList();
			}
		}

		public List<JobPosting> GetJobPostingsJson()
		{
			var jsonString = File.ReadAllText(JobPostingJsonPath);
			var jobPostings = JsonSerializer.Deserialize<List<JobPosting>>(jsonString);
			return jobPostings;
		}

		public JobPosting GetJobPosting(string id)
		{
			using (var context = new CandidateManagementContext())
			{
				return context.JobPostings.FirstOrDefault(j => j.PostingId.Equals(id));
			}
		}

		public JobPosting GetJobPostingJson(string id)
		{
			var jsonString = File.ReadAllText(JobPostingJsonPath);
			var accounts = JsonSerializer.Deserialize<List<JobPosting>>(jsonString);
			return accounts.FirstOrDefault(c => c.PostingId == id);
		}

		public bool AddJobPosting(JobPosting jobPosting)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				JobPosting jobPost = GetJobPosting(jobPosting.PostingId);
				try
				{
					if (jobPost == null)
					{
						context.JobPostings.Add(jobPosting);
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
		public bool DeleteJobPosting(JobPosting jobPosting)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				JobPosting jobPost = GetJobPosting(jobPosting.PostingId);
				try
				{
					if (jobPost != null)
					{
						context.JobPostings.Remove(jobPosting);
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
		public bool UpdateJobPosting(JobPosting jobPosting)
		{
			using (var context = new CandidateManagementContext())
			{
				bool isSuccess = false;
				JobPosting jobPost = GetJobPosting(jobPosting.PostingId);
				try
				{
					if (jobPost != null)
					{
						context.Entry<JobPosting>(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
	}
}
