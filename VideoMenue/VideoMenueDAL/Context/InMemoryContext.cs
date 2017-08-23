using Microsoft.EntityFrameworkCore;
using VideoMeueEntity;

namespace VideoMenueDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("The DB").Options;
        
        //base coll superclass
        public InMemoryContext() : base(options) 
        {

        }

        //table named Video
        public DbSet<Video> Video { get; set; }
    }
}
