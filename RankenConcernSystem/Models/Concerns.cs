using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RankenConcernSystem.Models
{
    public class Concerns
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Date Recieved")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfMake { get; set; }

        [Required]
        [Display(Name = "Name Of Concern Maker")]
        public string ConMakerName { get; set; }


        public enum Relationships { Student, Parent, Employee, Faculty, Other }
        [Required]
        [Display(Name = "Relationship")]
        public Relationships GetRelationship { get; set; }


        public enum Methods { Phone, Emial, Letter, In_Person, Through_HLC }

        [Display(Name = "Concern Made Via")]
        [Required]
        public Methods GetReportingMethod { get; set; }


        [Display(Name = "Student-ID")]
        public string StudentID { get; set; }



        [Display(Name = "Phone")]
        [Required]
        public string ConMakerPhone { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string ConMakerEmail { get; set; }

        [Display(Name = "Reason")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string ReasonConMade { get; set; }

        [Display(Name = "Reported To")]
        [Required]
        public string NameConRecieved { get; set; }


        [StringLength(60, MinimumLength = 3)]
        public string Details { get; set; }

        [Display(Name = "Action")]
        [Required]
        public string ActionMade { get; set; }

        [Display(Name = "Action Made By")]
        [Required]
        public string NameOfActionMaker { get; set; }

        [Display(Name = "Results")]
        [Required]
        public string ResultsOfCon { get; set; }

        [Display(Name = "Result Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfResult { get; set; }
    }
}