using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Data;
using OralHealthManagement.Models;

namespace OralHealthManagement
{
    public class ExhaustCreateModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public ExhaustCreateModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Exhaust Exhaust { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Exhaust.Total = 0;

            if (Exhaust.Q1 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q2 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q3 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q4 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q5 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q6 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q7 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q8 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q9 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q10 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q11 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q12 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q13 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q14 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q15 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q16 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q17 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q18 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q19 == 0)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q20 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q21 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q22 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q23 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q24 == 1)
            {
                Exhaust.Total++;
            }

            if (Exhaust.Q25 == 1)
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

            try
            {
                _context.Exhaust.Add(Exhaust);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx is SqlException)
                {
                    if (((SqlException)baseEx).Number == 547)
                    {
                        ModelState.AddModelError("ErrorMessage", "病歷號不存在");
                    }
                    if (((SqlException)baseEx).Number == 2627)
                    {
                        ModelState.AddModelError("ErrorMessage", "病歷號重複");
                    }
                    else
                    {
                        ModelState.AddModelError("SqlException", "資料庫例外.");
                    }
                }
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
