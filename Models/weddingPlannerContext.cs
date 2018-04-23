
using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Models
{
    public class weddingPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public weddingPlannerContext(DbContextOptions<weddingPlannerContext> options) : base(options) { }

	public DbSet<User> users {get; set;}
    public DbSet<Wedding> weddings {get; set;}
    public DbSet<UserWedding> userweddings {get; set;}
    }
}