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
    public class ExhaustDetailsModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public ExhaustDetailsModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

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
    }
}
