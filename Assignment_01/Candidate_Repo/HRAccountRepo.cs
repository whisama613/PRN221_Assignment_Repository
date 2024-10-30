using Candidate_BussinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public List<Hraccount> getHRAccounts() => HRAccountDAO.Instance.GetHraccounts();

        public Hraccount getHRAccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);
    }
}
