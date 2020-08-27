using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    public class Oral6_IdNo
    {
        [Display(Name = "編號")]
        public int IdNo { get; set; }

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

        [Display(Name = "牙齒數<20")]
        [Required]
        public bool Q1 { get; set; }

        [Display(Name = "水煮花枝")]
        [Required]
        public string Q2_1 { get; set; }

        [Display(Name = "炒花生")]
        [Required]
        public string Q2_2 { get; set; }

        [Display(Name = "炸雞")]
        [Required]
        public string Q2_3 { get; set; }

        [Display(Name = "滷豬耳朵")]
        [Required]
        public string Q2_4 { get; set; }

        [Display(Name = "水煮玉米(整枝)")]
        [Required]
        public string Q2_5 { get; set; }

        [Display(Name = "芭樂(切片處理)")]
        [Required]
        public string Q2_6 { get; set; }

        [Display(Name = "蘋果/梨子(切片處理)")]
        [Required]
        public string Q2_7 { get; set; }

        [Display(Name = "烤魷魚/雞胗")]
        [Required]
        public string Q2_8 { get; set; }

        [Display(Name = "甘蔗(非榨汁)")]
        [Required]
        public string Q2_9 { get; set; }

        [Display(Name = "小黃瓜(切片處理)/敏豆")]
        [Required]
        public string Q2_10 { get; set; }

        [Display(Name = "竹筍/花椰菜")]
        [Required]
        public string Q2_11 { get; set; }

        [Display(Name = "柳丁(切片處理)")]
        [Required]
        public string Q2_12 { get; set; }

        [Display(Name = "楊桃/蓮霧(切片處理)")]
        [Required]
        public string Q2_13 { get; set; }

        [Display(Name = "煮熟的紅蘿蔔/煮熟的白羅蔔")]
        [Required]
        public string Q2_14 { get; set; }

        [Display(Name = "咀嚼能力結果")]
        public string Q2_Result { get; set; }

        [Display(Name = "Ta 於10秒內發音次數")]
        [Required]
        public int Q3_1 { get; set; }

        [Display(Name = "Ba 於10秒內發音次數")]
        [Required]
        public int Q3_2 { get; set; }

        [Display(Name = "Ka 於10秒內發音次數")]
        [Required]
        public int Q3_3 { get; set; }

        [Display(Name = "Ta.Ba.Ka. 於10秒內發音次數")]
        [Required]
        public int Q3_4 { get; set; }

        [Display(Name = "舌頭壓力平均")]
        public double Q4_1 { get; set; }
        [Display(Name = "舌頭壓力1")]
        [Required]
        public double Q4_1_1 { get; set; }
        [Display(Name = "舌頭壓力2")]
        [Required]
        public double Q4_1_2 { get; set; }
        [Display(Name = "舌頭壓力3")]
        public double Q4_1_3 { get; set; }

        [Display(Name = "吞嚥壓力平均")]
        public double Q4_2 { get; set; }
        [Display(Name = "吞嚥壓力1")]
        [Required]
        public double Q4_2_1 { get; set; }
        [Display(Name = "吞嚥壓力2")]
        [Required]
        public double Q4_2_2 { get; set; }
        [Display(Name = "吞嚥壓力3")]
        [Required]
        public double Q4_2_3 { get; set; }

        [Display(Name = "主訴硬的食物難以咀嚼")]
        [Required]
        public bool Q5 { get; set; }

        [Display(Name = "RSST30秒次數")]
        [Required]
        public int Q6 { get; set; }
    }
}
