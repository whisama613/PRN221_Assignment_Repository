using Candidate_BussinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo ICandidateRepo;

        public CandidateProfileService()
        {
            ICandidateRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile profile) => ICandidateRepo.AddCandidateProfile(profile);

        public bool DeleteCandidateProfile(CandidateProfile profile) => ICandidateRepo.DeleteCandidateProfile(profile);

        public CandidateProfile GetCandidateProfileById(string id) => ICandidateRepo.getCandidateProfileById(id);

        public List<CandidateProfile> GetCandidateProfiles() => ICandidateRepo.getCandidateProfiles();

        public List<string> GetPostingIds() => ICandidateRepo.GetPostingIds();

        public bool UpdateCandidateProfile(CandidateProfile profile) => ICandidateRepo.UpdateCandidateProfile(profile);
    }
}
