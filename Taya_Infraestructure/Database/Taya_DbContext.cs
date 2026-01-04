namespace Taya_Infraestructure.Database
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Taya_Domain.Entities;
    using Taya_Infraestructure.Database.Configurations;

    public class Taya_DbContext : DbContext
    {
        public DbSet<Movement> Movements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ISAWORLD\SQLEXPRESS;Database=Taya_Database;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovementTypeConfiguration());

            //modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movement>().HasData(
                new Movement { Id = new Guid(), Description = "Enfermedad" }
                );
        }
    }
}
