using Candidate_BussinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> getCandidateProfiles();

        public CandidateProfile getCandidateProfileById(string id);

        public List<string> GetPostingIds();

        public bool AddCandidateProfile(CandidateProfile profile);

        public bool DeleteCandidateProfile(CandidateProfile profile);

        public bool UpdateCandidateProfile(CandidateProfile profile);
    }
}
