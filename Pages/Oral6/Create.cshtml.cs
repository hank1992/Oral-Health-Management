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
    public class Oral6CreateModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public Oral6CreateModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Oral6 Oral6 { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Oral6.Id = Oral6.ChartNo + Oral6.Timestamp.ToString("yyyyMMddHHmmssff");

            Oral6.Q4_1 = (Oral6.Q4_1_1 + Oral6.Q4_1_2 + Oral6.Q4_1_3) / 3.0;
            Oral6.Q4_2 = (Oral6.Q4_2_1 + Oral6.Q4_2_2 + Oral6.Q4_2_3) / 3.0;

            int count = 0;
            if (Oral6.Q2_1.Equals("有些吃力") || Oral6.Q2_1.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_2.Equals("有些吃力") || Oral6.Q2_2.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_3.Equals("有些吃力") || Oral6.Q2_3.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_4.Equals("有些吃力") || Oral6.Q2_4.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_5.Equals("有些吃力") || Oral6.Q2_5.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_6.Equals("有些吃力") || Oral6.Q2_6.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_7.Equals("有些吃力") || Oral6.Q2_7.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_8.Equals("有些吃力") || Oral6.Q2_8.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_9.Equals("有些吃力") || Oral6.Q2_9.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_10.Equals("有些吃力") || Oral6.Q2_10.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_11.Equals("有些吃力") || Oral6.Q2_11.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_12.Equals("有些吃力") || Oral6.Q2_12.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_13.Equals("有些吃力") || Oral6.Q2_13.Equals("不能吃"))
            {
                count++;
            }
            if (Oral6.Q2_14.Equals("有些吃力") || Oral6.Q2_14.Equals("不能吃"))
            {
                count++;
            }

            if (count >= 4)
            {
                Oral6.Q2_Result = "異常";
            }
            else
            {
                Oral6.Q2_Result = "正常";
            }

            try
            {
                _context.Oral6.Add(Oral6);
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
