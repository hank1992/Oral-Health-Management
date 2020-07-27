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
    public class NutritionDeleteModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public NutritionDeleteModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nutrition Nutrition { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nutrition = await _context.Nutrition.FirstOrDefaultAsync(m => m.Id == id);

            if (Nutrition == null)
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

            Nutrition = await _context.Nutrition.FindAsync(id);

            if (Nutrition != null)
            {
                _context.Nutrition.Remove(Nutrition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
