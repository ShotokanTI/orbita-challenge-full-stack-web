using Desafio_A__Educacao.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio_A__Educacao.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
