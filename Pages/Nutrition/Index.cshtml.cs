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
    public class NutritionIndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public NutritionIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Nutrition> Nutrition { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Nutrition = await _context.Nutrition.Where(x => x.ChartNo == ChartNo).OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }
            else
            {
                Nutrition = await _context.Nutrition.OrderBy(x => x.Timestamp).ThenBy(x => x.Id).ToListAsync();
            }
        }
        public FileResult OnPost()
        {
            List<Nutrition_IdNo> Nutrition_IdNo = _context.Nutrition_IdNo.FromSqlRaw("SELECT IdNo, [Id],[Timestamp],n.[ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Total],Result FROM OHM_Nutrition n INNER JOIN OHM_Demography d on n.ChartNo=d.ChartNo").ToList<Nutrition_IdNo>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo, [Id],[Timestamp],[ChartNo],[Q1],[Q2],[Q3],[Q4],[Q5],[Q6],[Total],Result");
            //Append new line character.
            sb.Append("\r\n");
            foreach (var demo in Nutrition_IdNo)
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
                sb.Append(demo.Total.ToString() + ",");
                sb.Append(demo.Result);

                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Nutrition.csv");
        }
    }
}
