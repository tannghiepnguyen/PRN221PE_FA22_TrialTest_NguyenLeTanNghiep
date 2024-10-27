using Candidate_BusinessObject;
using Candidate_DAO;

namespace Candidate_Repository
{
	public class HrAccountRepo : IHrAccountRepo
	{
		public Hraccount GetAccountByEmail(string email)
		{
			return HRAccountDAO.Instance.GetHrAccountByEmail(email);
		}

		public Hraccount GetAccountByEmailJson(string email)
		{
			return HRAccountDAO.Instance.GetHrAccountByEmailJson(email);
		}

		public List<Hraccount> GetAccounts()
		{
			return HRAccountDAO.Instance.GetHrAccounts();
		}
	}
}
