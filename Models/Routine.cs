using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_Routine")]
    public class Routine
    {
        [Display(Name = "Routine ID")]
        [Key]
        public string ID { get; set; }

        [Display(Name = "時間戳")]
        public DateTime Timestamp { get; set; }

        [Display(Name = "病歷號")]
        [RegularExpression("[0-9]{8}")]
        public string ChartNo { get; set; }

        [Display(Name = "體溫")]
        public double? Temp { get; set; }

        [Display(Name = "心律")]
        public int? HR { get; set; }

        [Display(Name = "呼吸")]
        public int? RR { get; set; }

        [Display(Name = "收縮壓")]
        public int? SBP { get; set; }

        [Display(Name = "舒張壓")]
        public int? DBP { get; set; }

        public double? WBC { get; set; }
        public double? Alb { get; set; }
        public double? BUN { get; set; }
        public double? CRP { get; set; }
        public String CXR { get; set; }
        public String Sputum { get; set; }
    }
}
