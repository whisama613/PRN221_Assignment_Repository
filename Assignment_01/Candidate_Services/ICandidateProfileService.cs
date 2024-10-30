using Candidate_BussinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidateProfiles();

        public CandidateProfile GetCandidateProfileById(string id);

        public List<String> GetPostingIds();

        public bool AddCandidateProfile(CandidateProfile profile);

        public bool DeleteCandidateProfile(CandidateProfile profile);

        public bool UpdateCandidateProfile(CandidateProfile profile);

    }
}
