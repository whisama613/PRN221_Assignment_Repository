using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BussinessObjects;
using Candidate_Services;

namespace CandidateManagement_PhanHoangDuy_Slot02.Pages
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _jobPosting;
        private readonly ICandidateProfileService _profileService;

        public EditModel(CandidateProfileService profileService, JobPostingService postingService)
        {
            this._profileService = profileService;
            this._jobPosting = postingService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _profileService.GetCandidateProfileById(id) == null)
            {
                return NotFound();
            }

            var candidateprofile = _profileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
           ViewData["PostingId"] = new SelectList(_profileService.GetCandidateProfileById(id).PostingId, "PostingId", "jobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _profileService.UpdateCandidateProfile(CandidateProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        { 
            return _profileService.GetCandidateProfileById(id) != null;
        }
    }
}
