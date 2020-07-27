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
    public class NutritionEditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public NutritionEditModel(OralHealthManagement.Data.OralHealthManagementContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Nutrition.Total = 0;
            Nutrition.Total += Nutrition.Q1;
            Nutrition.Total += Nutrition.Q2;
            Nutrition.Total += Nutrition.Q3;
            Nutrition.Total += Nutrition.Q4;
            Nutrition.Total += Nutrition.Q5;
            Nutrition.Total += Nutrition.Q6;

            if (Nutrition.Total >= 12)
            {
                Nutrition.Result = "低風險";
            }
            else if (Nutrition.Total >= 8)
            {
                Nutrition.Result = "潛在風險";
            }
            else
            {
                Nutrition.Result = "高度風險";
            }

            _context.Attach(Nutrition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionExists(Nutrition.Id))
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

        private bool NutritionExists(string id)
        {
            return _context.Nutrition.Any(e => e.Id == id);
        }
    }
}
