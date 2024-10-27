using Candidate_BusinessObject;

namespace Candidate_Service
{
	public interface IHrAccountService
	{
		public Hraccount GetAccountByEmail(string email);
		public Hraccount GetAccountByEmailJson(string email);
		public List<Hraccount> GetAccounts();
	}
}
