using Candidate_BusinessObject;

namespace Candidate_Repository
{
	public interface IHrAccountRepo
	{
		public Hraccount GetAccountByEmail(string email);
		public List<Hraccount> GetAccounts();
		public Hraccount GetAccountByEmailJson(string email);
	}
}
