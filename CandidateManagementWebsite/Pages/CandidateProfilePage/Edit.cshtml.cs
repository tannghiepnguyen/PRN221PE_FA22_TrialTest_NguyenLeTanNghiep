using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
	public class EditModel : PageModel
	{
		private readonly ICandidateProfileService candidateProfileService;
		private readonly IJobPostingService jobPostingService;

		public EditModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
		{
			this.candidateProfileService = candidateProfileService;
			this.jobPostingService = jobPostingService;
		}

		[BindProperty]
		public CandidateProfile CandidateProfile { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null || candidateProfileService.GetCandidateProfiles() == null)
			{
				return NotFound();
			}

			var candidateprofile = candidateProfileService.GetCandidateProfile(id);
			if (candidateprofile == null)
			{
				return NotFound();
			}
			CandidateProfile = candidateprofile;
			ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			candidateProfileService.UpdateCandidateProfile(CandidateProfile);

			return RedirectToPage("./Index");
		}

		private bool CandidateProfileExists(string id)
		{
			return candidateProfileService.GetCandidateProfile(id) is not null;
		}
	}
}
