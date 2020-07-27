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
    public class NutritionCreateModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public NutritionCreateModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Nutrition Nutrition { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Nutrition.Id = Nutrition.ChartNo + Nutrition.Timestamp.ToString("yyyyMMddHHmmssff");
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

            try
            {
                _context.Nutrition.Add(Nutrition);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //Console.WriteLine("here:" + e.GetBaseException());
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx is SqlException)
                {
                    if (((SqlException)baseEx).Number == 547)
                    {
                        ModelState.AddModelError("ErrorMessage", "該病歷號不存在.");
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
