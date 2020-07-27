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
    public class OHATDetailsModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public OHATDetailsModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

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
    }
}
