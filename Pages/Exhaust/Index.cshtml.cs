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
    public class ExhaustIndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public ExhaustIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Exhaust> Exhaust { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Exhaust = await _context.Exhaust.Where(x => x.ChartNo == ChartNo).OrderBy(x => x.ChartNo).ToListAsync();
            }
            else
            {
                Exhaust = await _context.Exhaust.OrderBy(x => x.ChartNo).ToListAsync();
            }
        }

        public FileResult OnPost()
        {
            List<Exhaust_IdNo> Exhaust_IdNo = _context.Exhaust_IdNo.FromSqlRaw("SELECT IdNo,e.[ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Q7],[Q8],[Q9],[Q10],[Q11],[Q12],[Q13],[Q14],[Q15],[Q16],[Q17],[Q18],[Q19],[Q20],[Q21],[Q22],[Q23],[Q24],[Q25],[Result],[Total] FROM OHM_Exhaust e INNER JOIN OHM_Demography d on e.ChartNo=d.ChartNo").OrderBy(x => x.ChartNo).ToList<Exhaust_IdNo>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo, [ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Q7],[Q8],[Q9],[Q10],[Q11],[Q12],[Q13],[Q14],[Q15],[Q16],[Q17],[Q18],[Q19],[Q20],[Q21],[Q22],[Q23],[Q24]" +
                ",[Q25],[Total],[Result]");
            //Append new line character.
            sb.Append("\r\n");
            foreach (var demo in Exhaust_IdNo)
            {
                //Append data with separator.
                sb.Append(demo.IdNo.ToString() + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Q1.ToString() + ',');
                sb.Append(demo.Q2.ToString() + ',');
                sb.Append(demo.Q3.ToString() + ',');
                sb.Append(demo.Q4.ToString() + ',');
                sb.Append(demo.Q5.ToString() + ',');
                sb.Append(demo.Q6.ToString() + ',');
                sb.Append(demo.Q7.ToString() + ',');
                sb.Append(demo.Q8.ToString() + ',');
                sb.Append(demo.Q9.ToString() + ',');
                sb.Append(demo.Q10.ToString() + ',');
                sb.Append(demo.Q11.ToString() + ',');
                sb.Append(demo.Q12.ToString() + ',');
                sb.Append(demo.Q13.ToString() + ',');
                sb.Append(demo.Q14.ToString() + ',');
                sb.Append(demo.Q15.ToString() + ',');
                sb.Append(demo.Q16.ToString() + ',');
                sb.Append(demo.Q17.ToString() + ',');
                sb.Append(demo.Q18.ToString() + ',');
                sb.Append(demo.Q19.ToString() + ',');
                sb.Append(demo.Q20.ToString() + ',');
                sb.Append(demo.Q21.ToString() + ',');
                sb.Append(demo.Q22.ToString() + ',');
                sb.Append(demo.Q23.ToString() + ',');
                sb.Append(demo.Q24.ToString() + ',');
                sb.Append(demo.Q25.ToString() + ',');
                sb.Append(demo.Total.ToString() + ',');
                sb.Append(demo.Result);

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Exhaust.csv");
        }
    }
}
