using Candidate_BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private static CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
            
        }

        public CandidateProfile? GetCandidateProfileById(string id)
        {
            CandidateProfile candidate =
                dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
            if (candidate != null)
                candidate.Posting = JobPostingDAO.Instance.GetJobPosting(candidate.PostingId);
            return candidate;
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            List<CandidateProfile> candidates = dbContext.CandidateProfiles.ToList();
            foreach (CandidateProfile candidateProfile in candidates)
            {
                candidateProfile.Posting = JobPostingDAO.Instance.GetJobPosting(candidateProfile.PostingId);
            }
            return candidates;
        }

        public List<string> GetPostingIds()
        {
            List<JobPosting> jobPostings = dbContext.JobPostings.ToList();

            List<string> formattedIds = new List<string>();

            foreach (var jobPosting in jobPostings)
            {
                formattedIds.Add($"{jobPosting.PostingId} ({jobPosting.JobPostingTitle})");
            }

            return formattedIds;
        }

        public Boolean AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile existingProfile = this.GetCandidateProfileById(candidateProfile.CandidateId);

            if (existingProfile == null)
            {
                dbContext.ChangeTracker.Clear();
                candidateProfile.Posting = null;
                dbContext.CandidateProfiles.Add(candidateProfile);
                dbContext.SaveChanges();
                isSuccess = true;
            }

            return isSuccess;
        }

        public Boolean DeleteCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile profile = this.GetCandidateProfileById(candidate.CandidateId);
            if (profile != null)
            {
                dbContext.ChangeTracker.Clear();
                candidate.Posting = null;
                dbContext.CandidateProfiles.Remove(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean UpdateCandidateProfile(CandidateProfile candidate)
        {
            bool isSuccess = false;
            CandidateProfile profile = this.GetCandidateProfileById(candidate.CandidateId);
            if (profile != null)
            {
                dbContext.ChangeTracker.Clear();
                candidate.Posting = null;
                dbContext.CandidateProfiles.Update(candidate);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}
