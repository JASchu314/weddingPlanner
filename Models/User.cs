using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models {
 public abstract class BaseEntity {}
	public class User : BaseEntity {

		[Key]
        public int userId {get; set;}   //these variable names must match the table column names exactly
		public string firstName {get; set;}
         public string lastName {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}
        public List<UserWedding> UserWedding {get; set;}
        public User(){
            UserWedding = new List<UserWedding>();
        }
    }
    }

