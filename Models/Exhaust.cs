using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_Exhaust")]
    public class Exhaust
    {
        [Display(Name = "病歷號")]
        [Required]
        [Key]
        [RegularExpression("[0-9]{8}")]
        public string ChartNo { get; set; }

        [Display(Name = "平常是否一個人搭乘公共交通工具(如捷運、公車、電車)外出嗎？")]
        [Required]
        public int Q1 { get; set; }

        [Display(Name = "是否自行購買日常生活用品？")]
        [Required]
        public int Q2 { get; set; }

        [Display(Name = "是否自己去銀行存提款？")]
        [Required]
        public int Q3 { get; set; }

        [Display(Name = "是否有到朋友家拜訪？")]
        [Required]
        public int Q4 { get; set; }

        [Display(Name = "是否成為家人或朋友訴苦或諮詢的對象？")]
        [Required]
        public int Q5 { get; set; }

        [Display(Name = "是否不須靠扶手或強並即可爬樓梯上樓？")]
        [Required]
        public int Q6 { get; set; }

        [Display(Name = "是否不須抓握任何東西即可從椅子上站立起來？")]
        [Required]
        public int Q7 { get; set; }

        [Display(Name = "是否可持續走路15分鐘以上？")]
        [Required]
        public int Q8 { get; set; }

        [Display(Name = "過去一年是否曾經跌倒過？")]
        [Required]
        public int Q9 { get; set; }

        [Display(Name = "是否非常擔心自己會跌倒？")]
        [Required]
        public int Q10 { get; set; }

        [Display(Name = "6個月內體重是否曾減輕2~3公斤以上？")]
        [Required]
        public int Q11 { get; set; }

        [Display(Name = "BMI未滿 18.5？")]
        [Required]
        public int Q12 { get; set; }

        [Display(Name = "跟半年前比起來，是否更無法吃較硬的東西？")]
        [Required]
        public int Q13 { get; set; }

        [Display(Name = "喝茶或喝湯時，是否會嗆到？")]
        [Required]
        public int Q14 { get; set; }

        [Display(Name = "是否常感到口渴？")]
        [Required]
        public int Q15 { get; set; }

        [Display(Name = "是否每週至少出門一次？")]
        [Required]
        public int Q16 { get; set; }

        [Display(Name = "外出次數是否比去年減少？")]
        [Required]
        public int Q17 { get; set; }

        [Display(Name = "是否有健忘現象，例如被周遭的人說「怎麼老是問同樣的是呢？」等？")]
        [Required]
        public int Q18 { get; set; }

        [Display(Name = "是否自行查詢電話號碼、撥打電話？")]
        [Required]
        public int Q19 { get; set; }

        [Display(Name = "有無曾經發生過不知道今天是幾月幾日的情形？")]
        [Required]
        public int Q20 { get; set; }

        [Display(Name = "近兩週內，有無覺得每天的生活缺乏充實感？")]
        [Required]
        public int Q21 { get; set; }

        [Display(Name = "近兩週內，對於以前感興趣的事情開始覺得無趣、乏味？")]
        [Required]
        public int Q22 { get; set; }

        [Display(Name = "近兩週內，有無以前坐起來覺得輕鬆自如之事，現在卻覺得吃力？")]
        [Required]
        public int Q23 { get; set; }

        [Display(Name = "近兩週內，有無覺得或認為自己是個無用之人？")]
        [Required]
        public int Q24 { get; set; }

        [Display(Name = "近兩週內，有無不明所以地感到疲累或倦怠？")]
        [Required]
        public int Q25 { get; set; }

        [Display(Name = "Total")]
        public int Total { get; set; }

        [Display(Name = "Result")]
        public string Result { get; set; }
    }
}
