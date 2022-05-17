using Microsoft.EntityFrameworkCore;
using StarterAPI.Entities;
using StarterAPI.Interfaces;


namespace StarterAPI.Presistence
{

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Class> Classes => Set<Class>();
    }
}
