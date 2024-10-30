using Candidate_BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext dbContext;

        private static JobPostingDAO? instance;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public JobPosting? GetJobPosting(string jobId)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(jobId));
        }

        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? jobPost = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (jobPost == null)
                {
                    dbContext.JobPostings.Add(jobPosting);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? jobPost = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (jobPost != null)
                {
                    dbContext.ChangeTracker.Clear();
                    dbContext.JobPostings.Remove(jobPosting);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting? jobPost = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (jobPost != null)
                {
                    dbContext.ChangeTracker.Clear();
                    dbContext.JobPostings.Update(jobPosting);
                    dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
