using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IHRAccountRepo
    {
        public Hraccount getHRAccountByEmail(string email);

        public List<Hraccount> getHRAccounts();
    }
}
