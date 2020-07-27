using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Pages
{
    public class DashboardIndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public DashboardIndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }
        public IList<OralHealthManagement.Models.Demography> Demographies { get; set; }
        public IList<OralHealthManagement.Models.Routine> Routines { get; set; }
        public IList<OralHealthManagement.Models.Lung> Lungs { get; set; }
        public IList<OralHealthManagement.Models.Exhaust> Exhausts { get; set; }
        public IList<OralHealthManagement.Models.OHAT> OHATs { get; set; }
        public IList<OralHealthManagement.Models.Oral6> Oral6s { get; set; }
        public IList<OralHealthManagement.Models.Nutrition> Nutritions { get; set; }
        public Boolean Check_OHM_Routine_Complete(string ChartNo)
        {
            if (_context.Demography.FromSqlRaw("SELECT * FROM OHM_Routine WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Check_OHM_Lung_Complete(string ChartNo)
        {
            if (_context.Demography.FromSqlRaw("SELECT * FROM OHM_Lung WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Check_OHM_Exhaust_Complete(string ChartNo)
        {
            if (_context.Demography.FromSqlRaw("SELECT * FROM OHM_Exhaust WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Check_OHM_OHAT_Complete(string ChartNo)
        {
            if (_context.Demography.FromSqlRaw("SELECT * FROM OHM_OHAT WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Check_OHM_Oral6_Complete(string ChartNo)
        {
            if (_context.Demography.FromSqlRaw("SELECT * FROM OHM_Oral6 WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Check_OHM_Nutrition_Complete(string ChartNo)
        {
            if (_context.Nutrition.FromSqlRaw("SELECT * FROM OHM_Nutrition WHERE ChartNo='" + ChartNo + "'").Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task OnGetAsync()
        {

            Demographies = await _context.Demography.FromSqlRaw("SELECT * FROM OHM_Demography ORDER BY IdNo").ToListAsync();
            Routines = await _context.Routine.FromSqlRaw("SELECT id, Timestamp, a.ChartNo, Temp, HR, RR, SBP, DBP, WBC, Alb, BUN, CRP, CXR, Sputum FROM OHM_Routine a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
            Lungs = await _context.Lung.FromSqlRaw("SELECT id, a.ChartNo, Timestamp, Temp, WBC, SputumChar, O2, SputumCul, LungInf, Total, ThickSputum, Stain FROM OHM_Lung a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
            Exhausts = await _context.Exhaust.FromSqlRaw("SELECT a.ChartNo, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12, Q13, Q14, Q15, Q16, Q17, Q18, Q19, Q20, Q21, Q22, Q23, Q24, Q25, Result, Total FROM OHM_Exhaust a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
            OHATs = await _context.OHAT.FromSqlRaw("SELECT Id, Timestamp, a.ChartNo, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Total, Habbit, Pattern, Reason FROM OHM_OHAT a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
            Oral6s = await _context.Oral6.FromSqlRaw("SELECT Id, Timestamp, a.ChartNo, Q1, Q2_1, Q2_2, Q2_3, Q2_4, Q2_5, Q2_6, Q2_7, Q2_8, Q2_9, Q2_10, Q2_11, Q2_12, Q2_13, Q2_14, Q2_Result, Q3_1, Q3_2, Q3_3, Q3_4, Q4_1, Q4_2, Q4_1_1, Q4_1_2, Q4_1_3, Q4_2_1, Q4_2_2, Q4_2_3, Q5, Q6 FROM OHM_Oral6 a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
            Nutritions = await _context.Nutrition.FromSqlRaw("SELECT Id, Timestamp, a.ChartNo, Q1, Q2, Q3, Q4, Q5, Q6, Total, Result FROM OHM_Nutrition a INNER JOIN OHM_Demography b ON a.ChartNo=b.ChartNo ORDER BY IdNo").ToListAsync();
        }

    }
}
