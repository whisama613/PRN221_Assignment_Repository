using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObjects;
using Candidate_Services;

namespace CandidateManagement_PhanHoangDuy_Slot02.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Candidate_BussinessObjects.CandidateManagementContext _context;
        private readonly CandidateProfileService _profileService;

        public DeleteModel(CandidateProfileService service)
        {
            _profileService = service;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _profileService.GetCandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile = _profileService.GetCandidateProfileById(id);

            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _profileService.GetCandidateProfiles == null)
            {
                return NotFound();
            }
            var candidateprofile = _profileService.GetCandidateProfileById(id);

            if (candidateprofile != null)
            {
                _profileService.DeleteCandidateProfile(candidateprofile);
            }

            return RedirectToPage("./Index");
        }
    }
}
