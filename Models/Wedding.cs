using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace weddingPlanner.Models{
    public class Wedding : BaseEntity{
        [Key]
        public int weddingId {get; set;}
        public string wedderOne { get; set; }
        public string wedderTwo { get; set; }
        public DateTime date { get; set; }
        public string wedAddress {get; set;}
        public DateTime createdAt {get;set;}
        public DateTime updatedAt { get; set; }
        public int createdBy {get; set;}
        public List<UserWedding> UserWedding {get; set;}
          public Wedding(){
            UserWedding = new List<UserWedding>();
        }

    }
}