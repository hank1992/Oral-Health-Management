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
    public class ExhaustEditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public ExhaustEditModel(OralHealthManagement.Data.OralHealthManagementContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Exhaust.Total = 0;

            if (Exhaust.Q1 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q2 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q3 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q4 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q5 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q6 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q7 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q8 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q9 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q10 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q11 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q12 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q13 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q14 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q15 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q16 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q17 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q18 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q19 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q20 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q21 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q22 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q23 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q24 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q25 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Total >= 8)
            {
                Exhaust.Result = "衰弱";
            }
            else if (Exhaust.Total >= 4)
            {
                Exhaust.Result = "衰弱前期";
            }
            else
            {
                Exhaust.Result = "非衰弱";
            }

            _context.Attach(Exhaust).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhaustExists(Exhaust.ChartNo))
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

        private bool ExhaustExists(string id)
        {
            return _context.Exhaust.Any(e => e.ChartNo == id);
        }
    }
}
