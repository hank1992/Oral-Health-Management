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
    public class LungDetailsModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public LungDetailsModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

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
    }
}
