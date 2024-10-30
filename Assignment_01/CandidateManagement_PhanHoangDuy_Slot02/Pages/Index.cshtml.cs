using Microsoft.AspNetCore.Mvc.RazorPages;
using Candidate_BussinessObjects;
using Candidate_Services;

namespace CandidateManagement_PhanHoangDuy_Slot02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Candidate_BussinessObjects.CandidateManagementContext _context;
        private readonly CandidateProfileService candidateProfileService;

        
        public IndexModel(CandidateProfileService service)
        {
            candidateProfileService = service;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (candidateProfileService.GetCandidateProfiles != null)
            {
                CandidateProfile = candidateProfileService.GetCandidateProfiles();
            }
        }
    }
}
