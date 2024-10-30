using Candidate_BussinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile profile) => CandidateProfileDAO.Instance.AddCandidateProfile(profile);
        
        public List<CandidateProfile> getCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public CandidateProfile getCandidateProfileById(string id) => CandidateProfileDAO.Instance.GetCandidateProfileById(id);

        public bool DeleteCandidateProfile(CandidateProfile profile) => CandidateProfileDAO.Instance.DeleteCandidateProfile(profile);

        public bool UpdateCandidateProfile(CandidateProfile profile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(profile);

        public List<string> GetPostingIds() => CandidateProfileDAO.Instance.GetPostingIds();
    }
}
