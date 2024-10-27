using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsiteJson.Pages
{
	public class LoginPageModel : PageModel
	{
		private readonly IHrAccountService hrAccountService;

		public LoginPageModel(IHrAccountService hrAccountService)
		{
			this.hrAccountService = hrAccountService;
		}
		public void OnGet()
		{
		}

		public void OnPost()
		{
			String email = Request.Form["txtEmail"];
			String password = Request.Form["txtPassword"];

			Hraccount hraccount = hrAccountService.GetAccountByEmail(email);
			if (hraccount is not null && hraccount.Password.Equals(password))
			{
				HttpContext.Session.SetString("RoleID", hraccount.MemberRole.ToString());
				Response.Redirect("/CandidateProfilePage");
			}
			else
			{
				Response.Redirect("/Error");
			}

		}
	}
}
