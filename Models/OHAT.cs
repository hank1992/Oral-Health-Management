using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_OHAT")]
    public class OHAT
    {
        [Display(Name = "Id")]
        [Key]
        [RegularExpression("[0-9]{24}")]
        public string Id { get; set; }

        [Display(Name = "Timestamp")]
        public DateTime Timestamp { get; set; }

        [Display(Name = "病歷號")]
        [Required]
        [RegularExpression("[0-9]{8}")]
        public string ChartNo { get; set; }

        [Display(Name = "嘴唇")]
        [Required]
        public int Q1 { get; set; }

        [Display(Name = "舌頭")]
        [Required]
        public int Q2 { get; set; }

        [Display(Name = "牙齦")]
        [Required]
        public int Q3 { get; set; }

        [Display(Name = "唾液")]
        [Required]
        public int Q4 { get; set; }

        [Display(Name = "自然牙")]
        [Required]
        public int Q5 { get; set; }

        [Display(Name = "假牙")]
        [Required]
        public int Q6 { get; set; }

        [Display(Name = "口腔清潔")]
        [Required]
        public int Q7 { get; set; }

        [Display(Name = "牙齒疼痛")]
        [Required]
        public int Q8 { get; set; }

        [Display(Name = "Total")]
        public int Total { get; set; }

        [Display(Name = "刷牙習慣(次/天)")]
        public int? Habbit { get; set; }

        [Display(Name = "刷牙型態")]
        public string Pattern { get; set; }

        [Display(Name = "住院後刷牙減少原因")]
        public string Reason { get; set; }
    }
}
