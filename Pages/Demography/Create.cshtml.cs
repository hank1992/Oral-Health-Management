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
    public class CreateModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public CreateModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Demography Demography { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DateTime DOB = DateTime.Parse(Request.Form["DOB"]).Date;
            DateTime AdmissionDate = Demography.AdmissionDate;
            Demography.Age = (int)(AdmissionDate.Subtract(DOB).Days / 365.25);

            if (Demography.MBDDate != null)
            {
                int LengthOfStay = Demography.MBDDate.Value.Subtract(AdmissionDate).Days;
                Demography.LengthOfStay = LengthOfStay;
            }

            try
            {
                _context.Demography.Add(Demography);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //Console.WriteLine("here:" + e.GetBaseException());
                var baseEx = e.GetBaseException();
                if (baseEx != null && baseEx is SqlException)
                {
                    if (((SqlException)baseEx).Number == 2627)
                    {
                        ModelState.AddModelError("ErrorMessage", "病歷號重覆.");
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
