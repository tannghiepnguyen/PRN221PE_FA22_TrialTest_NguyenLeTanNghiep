using Candidate_BusinessObject;
using Candidate_Repository;

namespace Candidate_Service
{
	public class HrAccountService : IHrAccountService
	{
		private IHrAccountRepo hrAccountRepo;
		public HrAccountService()
		{
			this.hrAccountRepo = new HrAccountRepo();
		}
		public HrAccountService(IHrAccountRepo hrAccountRepo)
		{
			this.hrAccountRepo = hrAccountRepo;
		}
		public Hraccount GetAccountByEmail(string email)
		{
			return hrAccountRepo.GetAccountByEmail(email);
		}

		public Hraccount GetAccountByEmailJson(string email)
		{
			return hrAccountRepo.GetAccountByEmailJson(email);
		}

		public List<Hraccount> GetAccounts()
		{
			return hrAccountRepo.GetAccounts();
		}
	}
}
