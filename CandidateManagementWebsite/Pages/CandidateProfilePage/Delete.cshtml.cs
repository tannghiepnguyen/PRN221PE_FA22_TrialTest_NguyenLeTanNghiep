using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
	public class DeleteModel : PageModel
	{
		private readonly ICandidateProfileService candidateProfileService;

		public DeleteModel(ICandidateProfileService candidateProfileService)
		{
			this.candidateProfileService = candidateProfileService;
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
			else
			{
				CandidateProfile = candidateprofile;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null || candidateProfileService.GetCandidateProfiles() == null)
			{
				return NotFound();
			}
			var candidateprofile = candidateProfileService.GetCandidateProfile(id);

			if (candidateprofile is not null)
			{
				CandidateProfile = candidateprofile;
				candidateProfileService.DeleteCandidateProfile(CandidateProfile);
			}

			return RedirectToPage("./Index");
		}
	}
}
