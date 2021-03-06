﻿using System;
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
    public class LungDeleteModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public LungDeleteModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lung Lung { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lung = await _context.Lung.FirstOrDefaultAsync(m => m.id == id);

            if (Lung == null)
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

            Lung = await _context.Lung.FindAsync(id);

            if (Lung != null)
            {
                _context.Lung.Remove(Lung);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
