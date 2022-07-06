using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            builder.Entity<User>()
              .Property(u => u.Document)
              .IsRequired();
        }   
    }
}
