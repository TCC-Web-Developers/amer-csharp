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

        //DbSet<Student> IApplicationDbContext.Students { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
