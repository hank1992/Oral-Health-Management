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
    public class RoutineDetailsModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public RoutineDetailsModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

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
    }
}
