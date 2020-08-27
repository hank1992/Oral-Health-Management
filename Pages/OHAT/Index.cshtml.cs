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
    public class OHATIndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public OHATIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<OHAT> OHAT { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                OHAT = await _context.OHAT.Where(x => x.ChartNo == ChartNo).OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }
            else
            {
                OHAT = await _context.OHAT.OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }
        }
        public FileResult OnPost()
        {
            List<OHAT_IdNo> OHAT_IdNo = _context.OHAT_IdNo.FromSqlRaw("SELECT IdNo,[Id],[Timestamp],o.[ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Q7],[Q8],[Total],Habbit,Pattern,Reason FROM OHM_OHAT o INNER JOIN OHM_Demography d on o.ChartNo=d.ChartNo").ToList<OHAT_IdNo>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo,[Id],[Timestamp],[ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Q7],[Q8],[Total],刷牙習慣(次/天),刷牙型態,住院後刷牙減少原因");
            //Append new line character.
            sb.Append("\r\n");
            foreach (var demo in OHAT_IdNo)
            {
                //Append data with separator.
                sb.Append(demo.IdNo.ToString() + ',');
                sb.Append(demo.Id + ',');
                sb.Append(demo.Timestamp.ToString("yyyy-MM-dd HH:mm:ss:ff") + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Q1.ToString() + ',');
                sb.Append(demo.Q2.ToString() + ',');
                sb.Append(demo.Q3.ToString() + ',');
                sb.Append(demo.Q4.ToString() + ',');
                sb.Append(demo.Q5.ToString() + ',');
                sb.Append(demo.Q6.ToString() + ',');
                sb.Append(demo.Q7.ToString() + ',');
                sb.Append(demo.Q8.ToString() + ',');
                sb.Append(demo.Total.ToString() + ',');
                sb.Append(demo.Habbit.ToString() + ',');
                sb.Append(demo.Pattern + ',');
                sb.Append(demo.Reason);

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "OHAT.csv");
        }
    }
}
