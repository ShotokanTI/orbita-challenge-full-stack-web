using Infra.Seed;
using Desafio_A__Educacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed
            modelBuilder.Entity<Student>().HasData(StudentSeed.GetStudents().ToArray());
        }
    }
}
