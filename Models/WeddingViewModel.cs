using System;
using System.ComponentModel.DataAnnotations;


namespace weddingPlanner.Models{
    public class WeddingViewModel : BaseEntity{
        public int weddingId {get; set;}
        
        [Required]
          [Display(Name="Wedder One:")]
        public string wedderOne { get; set; }
        
        [Required]
         [Display(Name="Wedder Two:")]
        public string wedderTwo { get; set; }
        
        [Required]
         [Display(Name="Date:")]
         [DataType(DataType.Date)]
         [CurrentDate(ErrorMessage="Date cannot be in the past!")]
        public DateTime date { get; set; }
        
        [Required]
          [Display(Name="Wedding Address:")]
        public string wedAddress {get; set;}
        
        public DateTime createdAt {get;set;}
        public DateTime updatedAt { get; set; }
        public int createdBy {get; set;}

                public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    } 
    } 
}