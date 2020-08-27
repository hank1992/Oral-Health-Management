using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OralHealthManagement.Data;
using OralHealthManagement.Models;

namespace OralHealthManagement
{
    public class IndexModel : PageModel
    {
        private readonly OralHealthManagement.Data.OralHealthManagementContext _context;

        public IndexModel(OralHealthManagement.Data.OralHealthManagementContext context)
        {
            _context = context;
        }

        public IList<Demography> Demography { get; set; }

        public async Task OnGetAsync(string ChartNo)
        {
            if (ChartNo != null)
            {
                Demography = await _context.Demography.Where(x => x.ChartNo == ChartNo).OrderBy(x => x.AdmissionDate).ThenBy(x => x.ChartNo).ToListAsync();
            }
            else
            {
                Demography = await _context.Demography.OrderBy(x => x.IdNo).ToListAsync();
            }
        }

        public FileResult OnPost()
        {
            List<Demography> Demography = _context.Demography.ToList<Demography>();
            StringBuilder sb = new StringBuilder();
            //Column
            sb.Append("IdNo, [Name],[ChartNo],[Sex],[AdmissionDate],[Dx],[Conscious],[Age],[Edu],[RoomType],[FromWhere],[BeenICU],[Comorbidity_Dementia],[Comorbidity_HTN],[Comorbidity_DM],[Comorbidity_COPD]" +
                ",[Comorbidity_HF],[Comorbidity_CVD],[Comorbidity_Cancer],[Comorbidity_Liver],[Comorbidity_CRF],[Comorbidity_Imune],[Comorbidity_Other],[CareGiver_Family]" +
                ",[CareGiver_Foreigner],[CareGiver_TW],[CareGiver_None],[ReAdmit14D],[AdmitWithEndo],[AdmitWithNG],[AdmitWithCVC],[AdmitWithMDR],[Antibiotics],MBDDate,[LengthOfStay],Gargle\r\n");

            foreach (var demo in Demography)
            {
                //Append data with separator.
                sb.Append(demo.IdNo.ToString() + ',');
                sb.Append(demo.Name + ',');
                sb.Append(demo.ChartNo + ',');
                sb.Append(demo.Sex + ',');
                sb.Append(demo.AdmissionDate.ToString("yyyy-MM-dd") + ',');
                sb.Append(demo.Dx + ',');
                sb.Append(demo.Conscious + ',');
                sb.Append(demo.Age.ToString() + ',');
                sb.Append(demo.Edu + ',');
                sb.Append(demo.RoomType + ',');
                sb.Append(demo.FromWhere + ',');
                sb.Append(demo.BeenICU.ToString() + ',');
                sb.Append(demo.Comorbidity_Dementia.ToString() + ',');
                sb.Append(demo.Comorbidity_HTN.ToString() + ',');
                sb.Append(demo.Comorbidity_DM.ToString() + ',');
                sb.Append(demo.Comorbidity_COPD.ToString() + ',');
                sb.Append(demo.Comorbidity_HF.ToString() + ',');
                sb.Append(demo.Comorbidity_CVD.ToString() + ',');
                sb.Append(demo.Comorbidity_Cancer.ToString() + ',');
                sb.Append(demo.Comorbidity_Liver.ToString() + ',');
                sb.Append(demo.Comorbidity_CRF.ToString() + ',');
                sb.Append(demo.Comorbidity_Imune.ToString() + ',');
                sb.Append(demo.Comorbidity_Other + ',');
                sb.Append(demo.CareGiver_Family.ToString() + ',');
                sb.Append(demo.CareGiver_Foreigner.ToString() + ',');
                sb.Append(demo.CareGiver_TW.ToString() + ',');
                sb.Append(demo.CareGiver_None.ToString() + ',');
                sb.Append(demo.ReAdmit14D.ToString() + ',');
                sb.Append(demo.AdmitWithEndo.ToString() + ',');
                sb.Append(demo.AdmitWithNG.ToString() + ',');
                sb.Append(demo.AdmitWithCVC.ToString() + ',');
                sb.Append(demo.AdmitWithMDR.ToString() + ',');
                sb.Append(demo.Antibiotics + ',');
                sb.Append(demo.MBDDate.ToString() + ',');
                sb.Append(demo.LengthOfStay.ToString() + ',');
                sb.Append(demo.Solution);
                //Append new line character.
                sb.Append("\r\n");
            }
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Demography.csv");
        }
    }
}
