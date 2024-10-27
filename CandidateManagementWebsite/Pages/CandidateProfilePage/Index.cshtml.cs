using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
	public class IndexModel : PageModel
	{
		private readonly ICandidateProfileService _candidateProfileService;

		public IndexModel(ICandidateProfileService candidateProfileService)
		{
			_candidateProfileService = candidateProfileService;
		}

		public IList<CandidateProfile> CandidateProfile { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_candidateProfileService.GetCandidateProfiles() is not null)
			{
				CandidateProfile = _candidateProfileService.GetCandidateProfiles();
			}
		}
	}
}
