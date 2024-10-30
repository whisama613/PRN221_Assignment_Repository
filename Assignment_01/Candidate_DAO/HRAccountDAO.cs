﻿using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;
        private static HRAccountDAO instance;

        public HRAccountDAO ()
        {
            context = new CandidateManagementContext ();
        }

        public static HRAccountDAO Instance 
        { 
            get 
            {
            if (instance == null)
                {
                    instance = new HRAccountDAO ();
                }
            return instance;
            }
        }

        public Hraccount? GetHraccountByEmail(string email)
        {
            try
            {
                return context.Hraccounts.SingleOrDefault(x => x.Email.Equals(email));
            }
            catch (Exception ex)
            {
                //log
            }
            return null;
        }
        

        public  List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
