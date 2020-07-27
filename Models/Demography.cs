using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OralHealthManagement.Models
{
    [Table("OHM_Demography")]
    public class Demography
    {
        [Display(Name = "編號")]
        [Required]
        public int IdNo { get; set; }

        [Display(Name = "姓名")]
        [Required]
        public string Name { get; set; }

        [Key]
        [Display(Name = "病歷號")]
        [Required]
        [RegularExpression("[0-9]{8}")]
        public string ChartNo { get; set; }

        [Display(Name = "性別")]
        [Required]
        public string Sex { get; set; }

        [Display(Name = "入院日期")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "入院診斷")]
        [Required]
        public string Dx { get; set; }

        [Display(Name = "意識")]
        [Required]
        public string Conscious { get; set; }

        [Display(Name = "年紀")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "教育程度")]
        [Required]
        public string Edu { get; set; }

        [Display(Name = "本次入院房型")]
        [Required]
        public string RoomType { get; set; }
        [Display(Name = "從何處入院")]
        [Required]
        public string FromWhere { get; set; }
        [Display(Name = "是否曾住過加護中心")]
        [Required]
        public bool BeenICU { get; set; }
        [Display(Name = "共病病史-失智症")]
        public bool Comorbidity_Dementia { get; set; }
        [Display(Name = "共病病史-高血壓")]
        public bool Comorbidity_HTN { get; set; }
        [Display(Name = "共病病史-糖尿病")]
        public bool Comorbidity_DM { get; set; }
        [Display(Name = "共病病史-慢性阻塞性肺疾病")]
        public bool Comorbidity_COPD { get; set; }
        [Display(Name = "共病病史-心衰竭")]
        public bool Comorbidity_HF { get; set; }
        [Display(Name = "共病病史-腦血管疾病")]
        public bool Comorbidity_CVD { get; set; }
        [Display(Name = "共病病史-癌症")]
        public bool Comorbidity_Cancer { get; set; }
        [Display(Name = "共病病史-肝硬化")]
        public bool Comorbidity_Liver { get; set; }
        [Display(Name = "共病病史-慢性腎衰竭")]
        public bool Comorbidity_CRF { get; set; }
        [Display(Name = "共病病史-免疫低下疾病")]
        public bool Comorbidity_Imune { get; set; }
        [Display(Name = "共病病史-其他")]
        public String Comorbidity_Other { get; set; }
        [Display(Name = "主要照顧者-家人")]
        public bool CareGiver_Family { get; set; }
        [Display(Name = "主要照顧者-外傭")]
        public bool CareGiver_Foreigner { get; set; }
        [Display(Name = "主要照顧者-看護")]
        public bool CareGiver_TW { get; set; }
        [Display(Name = "主要照顧者-無")]
        public bool CareGiver_None { get; set; }
        [Display(Name = "是否為14天內重複入院")]
        public bool ReAdmit14D { get; set; }
        [Display(Name = "此次入院是否曾插支氣管內管")]
        public bool AdmitWithEndo { get; set; }
        [Display(Name = "此次入院是否有鼻胃管")]
        public bool AdmitWithNG { get; set; }
        [Display(Name = "此次入院是否曾使用中央靜脈導管")]
        public bool AdmitWithCVC { get; set; }
        [Display(Name = "是否有多重抗藥性細菌感染")]
        public bool AdmitWithMDR { get; set; }
        [Display(Name = "住院期間使用的抗生素")]
        public string Antibiotics { get; set; }
        [Display(Name = "出院日期")]
        [DataType(DataType.Date)]
        public DateTime? MBDDate { get; set; }
        [Display(Name = "住院天數")]
        public int? LengthOfStay { get; set; }

        [Display(Name = "漱口水型態")]
        public string Solution { get; set; }
    }
}
