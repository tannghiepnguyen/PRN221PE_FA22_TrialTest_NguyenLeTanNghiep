using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsiteJson.Pages.CandidateProfilePage
{
	public class IndexModel : PageModel
	{
		private readonly ICandidateProfileService candidateProfileService;
		private readonly IJobPostingService jobPostingService;

		public IndexModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
		{
			this.candidateProfileService = candidateProfileService;
			this.jobPostingService = jobPostingService;
		}

		public IList<CandidateProfile> CandidateProfile { get; set; } = default!;

		public string GetJobPostingTitle(string postingId)
		{
			return jobPostingService.GetJobPosting(postingId).JobPostingTitle;
		}

		public async Task OnGetAsync()
		{
			if (candidateProfileService.GetCandidateProfilesJson() != null)
			{
				CandidateProfile = candidateProfileService.GetCandidateProfilesJson();
			}
		}
	}
}
