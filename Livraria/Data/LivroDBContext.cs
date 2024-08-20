using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class LivroDBContext : DbContext
    {
        public LivroDBContext(DbContextOptions<LivroDBContext> options) : base(options) 
        {
            
        }
        public DbSet<LivroModel> Livros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
