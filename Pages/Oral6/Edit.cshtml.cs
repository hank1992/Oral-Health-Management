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
    public class Oral6EditModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public Oral6EditModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Oral6 Oral6 { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Oral6 = await _context.Oral6.FirstOrDefaultAsync(m => m.Id == id);

            if (Oral6 == null)
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

            _context.Attach(Oral6).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Oral6Exists(Oral6.Id))
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

        private bool Oral6Exists(string id)
        {
            return _context.Oral6.Any(e => e.Id == id);
        }
    }
}
