using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Data;
using OralHealthManagement.Models;

namespace OralHealthManagement
{
    public class ExhaustDeleteModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public ExhaustDeleteModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exhaust Exhaust { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exhaust = await _context.Exhaust.FirstOrDefaultAsync(m => m.ChartNo == id);

            if (Exhaust == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exhaust = await _context.Exhaust.FindAsync(id);

            if (Exhaust != null)
            {
                _context.Exhaust.Remove(Exhaust);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
