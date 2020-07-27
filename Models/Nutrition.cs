using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_Nutrition")]
    public class Nutrition
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

        [Display(Name = "過去三個月之中，是否因食欲不佳、消化問題、咀嚼或吞咽困難以致進食量減少？")]
        [Required]
        public int Q1 { get; set; }

        [Display(Name = "近三個月體重變化？")]
        [Required]
        public int Q2 { get; set; }

        [Display(Name = "行動力")]
        [Required]
        public int Q3 { get; set; }

        [Display(Name = "過去三個月曾有精神性壓力或急性疾病發作？")]
        [Required]
        public int Q4 { get; set; }

        [Display(Name = "神經精神問題")]
        [Required]
        public int Q5 { get; set; }

        [Display(Name = "身體質量指數(BMI)")]
        [Required]
        public int Q6 { get; set; }

        [Display(Name = "Total")]
        [Required]
        public int Total { get; set; }

        [Display(Name = "Result")]
        //[Required]
        public string Result { get; set; }

    }
}
