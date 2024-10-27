using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsiteJson.Pages.CandidateProfilePage
{
	public class DetailsModel : PageModel
	{
		private readonly ICandidateProfileService candidateProfileService;
		private readonly IJobPostingService jobPostingService;

		public DetailsModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
		{
			this.candidateProfileService = candidateProfileService;
			this.jobPostingService = jobPostingService;
		}

		public CandidateProfile CandidateProfile { get; set; } = default!;

		public string GetJobPostingTitle(string postingId)
		{
			return jobPostingService.GetJobPosting(postingId).JobPostingTitle;
		}

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null || candidateProfileService.GetCandidateProfilesJson() == null)
			{
				return NotFound();
			}

			var candidateprofile = candidateProfileService.GetCandidateProfileJson(id);
			if (candidateprofile == null)
			{
				return NotFound();
			}
			else
			{
				CandidateProfile = candidateprofile;
			}
			return Page();
		}
	}
}
