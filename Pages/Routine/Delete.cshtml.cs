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
    public class RoutineDeleteModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public RoutineDeleteModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Routine Routine { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Routine = await _context.Routine.FirstOrDefaultAsync(m => m.ID == id);

            if (Routine == null)
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

            Routine = await _context.Routine.FindAsync(id);

            if (Routine != null)
            {
                _context.Routine.Remove(Routine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
