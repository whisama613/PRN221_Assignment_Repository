using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BussinessObjects;
using Candidate_Services;

namespace CandidateManagement_PhanHoangDuy_Slot02.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Candidate_BussinessObjects.CandidateManagementContext _context;
        private readonly CandidateProfileService _profileService;

        public CreateModel(CandidateProfileService service)
        {
            _profileService = service;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(CandidateProfile.PostingId, "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _profileService.GetCandidateProfiles == null || CandidateProfile == null)
            {
                return Page();
            }

            _profileService.AddCandidateProfile(CandidateProfile);
            
            return RedirectToPage("./Index");
        }
    }
}
