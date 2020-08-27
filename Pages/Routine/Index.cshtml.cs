using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Data;
using OralHealthManagement.Models;

namespace OralHealthManagement
{
    public class RoutineIndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public RoutineIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Routine> Routine { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Routine = await _context.Routine.Where(x => x.ChartNo == ChartNo).OrderByDescending(x => x.Timestamp).ThenBy(x => x.ChartNo).ToListAsync();
            }
            else
            {
                Routine = await _context.Routine.OrderByDescending(x => x.Timestamp).ThenBy(x => x.ChartNo).ToListAsync();
            }
        }

        public FileResult OnPost()
        {
            List<Routine_IdNo> Routine_IdNo = _context.Routine_IdNo.FromSqlRaw("SELECT IdNo,[id],[Timestamp],r.[ChartNo],[Temp],[HR],[RR],[SBP],[DBP],[WBC],[Alb],[BUN],[CRP],[CXR],[Sputum] FROM OHM_Routine r INNER JOIN OHM_Demography d on r.ChartNo=d.ChartNo").ToList<Routine_IdNo>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo,[id],[Timestamp],[ChartNo],[Temp],[HR],[RR],[SBP],[DBP],[WBC],[Alb],[BUN],[CRP],[CXR],[Sputum]");
            //Append new line character.
            sb.Append("\r\n");
            foreach (var demo in Routine_IdNo)
            {
                //Append data with separator.
                sb.Append(demo.IdNo.ToString() + ',');
                sb.Append(demo.ID + ',');
                sb.Append(demo.Timestamp.ToString("yyyy-MM-dd HH:mm:ss:ff") + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Temp.ToString() + ',');
                sb.Append(demo.HR.ToString() + ',');
                sb.Append(demo.RR.ToString() + ',');
                sb.Append(demo.SBP.ToString() + ',');
                sb.Append(demo.DBP.ToString() + ',');
                sb.Append(demo.WBC.ToString() + ',');
                sb.Append(demo.Alb.ToString() + ',');
                sb.Append(demo.BUN.ToString() + ',');
                sb.Append(demo.CRP.ToString() + ',');
                sb.Append(demo.CXR + ',');
                sb.Append(demo.Sputum);

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Routine.csv");
        }
    }
}
