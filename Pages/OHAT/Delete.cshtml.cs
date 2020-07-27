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
    public class OHATDeleteModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public OHATDeleteModel(OralHealthManagement.Data.OralHealthManagementContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OHAT = await _context.OHAT.FindAsync(id);

            if (OHAT != null)
            {
                _context.OHAT.Remove(OHAT);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
