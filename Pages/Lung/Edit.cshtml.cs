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
    public class LungEditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public LungEditModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lung Lung { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lung = await _context.Lung.FirstOrDefaultAsync(m => m.id == id);

            if (Lung == null)
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

            Lung.Total = Lung.Temp + Lung.WBC + Lung.SputumChar + Lung.O2 + Lung.SputumCul + Lung.LungInf;

            if (Lung.ThickSputum)
            {
                Lung.Total++;
            }

            if (Lung.Stain)
            {
                Lung.Total++;
            }

            _context.Attach(Lung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LungExists(Lung.id))
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

        private bool LungExists(string id)
        {
            return _context.Lung.Any(e => e.id == id);
        }
    }
}
