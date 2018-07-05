using Microsoft.EntityFrameworkCore;

namespace cat_api
{
    public class CatDb : DbContext
    {
        // Reference our cat table using this
        public DbSet<Cat> Cats { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Cats.db");
        }
    }
}