using Candidate_BussinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo IAccountRepo;

        public HRAccountService()
        {
            IAccountRepo = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return IAccountRepo.getHRAccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return IAccountRepo.getHRAccounts();
        }
    }
}
