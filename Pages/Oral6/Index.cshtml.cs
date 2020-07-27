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
    public class Oral6IndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public Oral6IndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Oral6> Oral6 { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Oral6 = await _context.Oral6.Where(x => x.ChartNo == ChartNo).OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }
            else
            {
                Oral6 = await _context.Oral6.OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }

        }

        public FileResult OnPost()
        {
            List<Oral6> Oral6 = _context.Oral6.ToList<Oral6>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("[Id],[Timestamp],[ChartNo],[Q1],[Q2_1],[Q2_2],[Q2_3],[Q2_4],[Q2_5],[Q2_6],[Q2_7],[Q2_8],[Q2_9],[Q2_10],[Q2_11],[Q2_12],[Q2_13],[Q2_14],[Q2_Result]" +
                ",[Q3_1],[Q3_2],[Q3_3],[Q3_4],[Q4_1],[Q4_2],[Q5],[Q6]");
            //Append new line character.
            sb.Append("\r\n");
            foreach (var demo in Oral6)
            {
                //Append data with separator.
                sb.Append(demo.Id + ',');
                sb.Append(demo.Timestamp.ToString("yyyy-MM-dd HH:mm:ss:ff") + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Q1.ToString() + ',');
                sb.Append(demo.Q2_1 + ',');
                sb.Append(demo.Q2_2 + ',');
                sb.Append(demo.Q2_3 + ',');
                sb.Append(demo.Q2_4 + ',');
                sb.Append(demo.Q2_5 + ',');
                sb.Append(demo.Q2_6 + ',');
                sb.Append(demo.Q2_7 + ',');
                sb.Append(demo.Q2_8 + ',');
                sb.Append(demo.Q2_9 + ',');
                sb.Append(demo.Q2_10 + ',');
                sb.Append(demo.Q2_11 + ',');
                sb.Append(demo.Q2_12 + ',');
                sb.Append(demo.Q2_13 + ',');
                sb.Append(demo.Q2_14 + ',');
                sb.Append(demo.Q2_Result + ',');
                sb.Append(demo.Q3_1.ToString() + ',');
                sb.Append(demo.Q3_2.ToString() + ',');
                sb.Append(demo.Q3_3.ToString() + ',');
                sb.Append(demo.Q3_4.ToString() + ',');
                sb.Append(demo.Q4_1.ToString() + ',');
                sb.Append(demo.Q4_2.ToString() + ',');
                sb.Append(demo.Q5.ToString() + ',');
                sb.Append(demo.Q6.ToString());

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Oral6.csv");
        }
    }
}
