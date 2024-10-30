using Candidate_BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IJobPostingRepo
    {
        public JobPosting? GetJobPosting(string jobId);


        public List<JobPosting> GetJobPostings();


        public bool AddJobPosting(JobPosting jobPosting);


        public bool DeleteJobPosting(JobPosting jobPosting);


        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
