using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CandidateManagementWebsiteJson.Pages.CandidateProfilePage
{
	public class CreateModel : PageModel
	{
		private readonly ICandidateProfileService candidateProfileService;
		private readonly IJobPostingService jobPostingService;

		public CreateModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
		{
			this.candidateProfileService = candidateProfileService;
			this.jobPostingService = jobPostingService;
		}

		public IActionResult OnGet()
		{
			ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostingsJson(), "PostingId", "JobPostingTitle");
			return Page();
		}

		[BindProperty]
		public CandidateProfile CandidateProfile { get; set; } = default!;


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || candidateProfileService.GetCandidateProfilesJson() == null || CandidateProfile == null)
			{
				return Page();
			}

			candidateProfileService.AddCandidateProfileJson(CandidateProfile);

			return RedirectToPage("./Index");
		}
	}
}
