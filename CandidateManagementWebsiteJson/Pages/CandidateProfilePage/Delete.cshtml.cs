using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsiteJson.Pages.CandidateProfilePage
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

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null || candidateProfileService.GetCandidateProfilesJson() == null)
			{
				return NotFound();
			}
			var candidateprofile = candidateProfileService.GetCandidateProfileJson(id);

			if (candidateprofile != null)
			{
				CandidateProfile = candidateprofile;
				candidateProfileService.DeleteCandidateProfileJson(CandidateProfile);
			}

			return RedirectToPage("./Index");
		}
	}
}
