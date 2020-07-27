﻿using System;
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
    public class RoutineCreateModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public RoutineCreateModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Routine Routine { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Routine.ID = Routine.ChartNo + Routine.Timestamp.ToString("yyyyMMddHHmmssff");
            try
            {
                _context.Routine.Add(Routine);
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
