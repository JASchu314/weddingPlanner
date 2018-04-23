using System.ComponentModel.DataAnnotations;
using weddingPlanner.Models;

namespace weddingPlanner{
    public class UserWedding : BaseEntity{
        [Key]
        public int UserWeddingsId {get; set;}
        public int userId {get; set;}
        public User User {get;set;}
        public int weddingId {get; set;}
        public Wedding Wedding {get; set;}

        
    } 
}