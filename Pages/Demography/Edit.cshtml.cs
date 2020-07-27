using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Data;
using OralHealthManagement.Models;

namespace OralHealthManagement
{
    public class EditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public EditModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Demography Demography { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Demography = await _context.Demography.FirstOrDefaultAsync(m => m.ChartNo == id);

            if (Demography == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DateTime AdmissionDate = Demography.AdmissionDate;
            if (Demography.MBDDate != null)
            {
                int LengthOfStay = Demography.MBDDate.Value.Subtract(AdmissionDate).Days;
                Demography.LengthOfStay = LengthOfStay;
            }

            _context.Attach(Demography).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemographyExists(Demography.ChartNo))
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

        private bool DemographyExists(string id)
        {
            return _context.Demography.Any(e => e.ChartNo == id);
        }
    }
}
