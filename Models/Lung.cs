using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_Lung")]
    public class Lung
    {
        [Display(Name = "Lung ID")]
        [Key]
        public string id { get; set; }

        [Display(Name = "病歷號")]
        [Required]
        [RegularExpression("[0-9]{8}")]
        public string ChartNo { get; set; }

        [Display(Name = "時間戳")]
        public DateTime Timestamp { get; set; }

        [Display(Name = "體溫")]
        [Required]
        public int Temp { get; set; }

        [Display(Name = "白血球")]
        [Required]
        public int WBC { get; set; }

        [Display(Name = "痰液特徵")]
        [Required]
        public int SputumChar { get; set; }

        [Display(Name = "血氧狀態")]
        [Required]
        public int O2 { get; set; }

        [Display(Name = "痰液培養")]
        [Required]
        public int SputumCul { get; set; }

        [Display(Name = "肺部浸潤")]
        [Required]
        public int LungInf { get; set; }

        [Display(Name = "總分")]
        public int Total { get; set; }

        [Display(Name = "膿痰")]
        public Boolean ThickSputum { get; set; }

        [Display(Name = "革蘭氏染色與培養結果相同")]
        public Boolean Stain { get; set; }
    }
}
