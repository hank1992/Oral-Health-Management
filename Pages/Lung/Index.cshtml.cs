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
    public class LungIndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public LungIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Lung> Lung { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Lung = await _context.Lung.Where(x => x.ChartNo == ChartNo).OrderByDescending(x => x.Timestamp).ThenBy(x => x.ChartNo).ToListAsync();
            }
            else
            {
                Lung = await _context.Lung.OrderByDescending(x => x.Timestamp).ThenBy(x => x.ChartNo).ToListAsync();
            }
        }

        public FileResult OnPost()
        {
            List<Lung_IdNo> Lung_IdNo = _context.Lung_IdNo.FromSqlRaw("SELECT IdNo,[id],l.[ChartNo],[Timestamp],[Temp],[WBC],[SputumChar],[O2],[SputumCul],[LungInf],[Total],[ThickSputum],[Stain] FROM OHM_Lung l INNER JOIN OHM_Demography d on l.ChartNo=d.ChartNo").ToList<Lung_IdNo>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo,[id],[ChartNo],[Timestamp],[Temp],[WBC],[SputumChar],[O2],[SputumCul],[LungInf],[Total],[ThickSputum],[Stain]\r\n");

            foreach (var demo in Lung_IdNo)
            {
                //Append data with separator.
                sb.Append(demo.IdNo.ToString() + ',');
                sb.Append(demo.id + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Timestamp.ToString("yyyy-MM-dd HH:mm:ss:ff") + ',');
                sb.Append(demo.Temp.ToString() + ',');
                sb.Append(demo.WBC.ToString() + ',');
                sb.Append(demo.SputumChar.ToString() + ',');
                sb.Append(demo.O2.ToString() + ',');
                sb.Append(demo.SputumCul.ToString() + ',');
                sb.Append(demo.LungInf.ToString() + ',');
                sb.Append(demo.Total.ToString() + ',');
                sb.Append(demo.ThickSputum.ToString() + ',');
                sb.Append(demo.Stain.ToString() + ',');

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Lung.csv");
        }
    }
}
