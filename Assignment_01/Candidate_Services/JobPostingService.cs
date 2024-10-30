using Candidate_BussinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepo postingRepo;
        public JobPostingService() {
            postingRepo = new JobPostingRepo();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return postingRepo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            return postingRepo.DeleteJobPosting(jobPosting);
        }

        public JobPosting? GetJobPosting(string jobId)
        {
            return postingRepo.GetJobPosting(jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
            return postingRepo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return postingRepo.UpdateJobPosting(jobPosting);
        }
    }
}
