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
    public class OHATEditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public OHATEditModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OHAT OHAT { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OHAT = await _context.OHAT.FirstOrDefaultAsync(m => m.Id == id);

            if (OHAT == null)
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

            OHAT.Total = 0;
            OHAT.Total += OHAT.Q1;
            OHAT.Total += OHAT.Q2;
            OHAT.Total += OHAT.Q3;
            OHAT.Total += OHAT.Q4;
            OHAT.Total += OHAT.Q5;
            OHAT.Total += OHAT.Q6;
            OHAT.Total += OHAT.Q7;
            OHAT.Total += OHAT.Q8;

            _context.Attach(OHAT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OHATExists(OHAT.Id))
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

        private bool OHATExists(string id)
        {
            return _context.OHAT.Any(e => e.Id == id);
        }
    }
}
