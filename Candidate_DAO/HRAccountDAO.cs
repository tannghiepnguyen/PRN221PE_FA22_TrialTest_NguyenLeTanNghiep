using Candidate_BusinessObject;
using System.Text.Json;

namespace Candidate_DAO
{
	public class HRAccountDAO
	{
		//private CandidateManagementContext context;
		private static HRAccountDAO instance;
		private string HRAccountJsonPath;

		public HRAccountDAO()
		{
			//this.context = new CandidateManagementContext();
			HRAccountJsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "HRAccount.json");
		}

		public static HRAccountDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new HRAccountDAO();
				}
				return instance;
			}
		}

		public Hraccount GetHrAccountByEmail(string email)
		{
			using (var context = new CandidateManagementContext())
			{
				return context.Hraccounts.SingleOrDefault(hr => hr.Email.Equals(email));
			}

		}

		public Hraccount GetHrAccountByEmailJson(string email)
		{
			var jsonString = File.ReadAllText(HRAccountJsonPath);
			var accounts = JsonSerializer.Deserialize<List<Hraccount>>(jsonString);
			return accounts.SingleOrDefault(hr => hr.Email.Equals(email));
		}

		public List<Hraccount> GetHrAccounts()
		{
			using (var context = new CandidateManagementContext())
			{
				return context.Hraccounts.ToList();
			}

		}
	}
}
