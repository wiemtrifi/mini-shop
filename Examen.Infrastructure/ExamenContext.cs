using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using System.Collections;
using System.Reflection.Emit;
using Examen.Infrastructure.Configurations;
//using Examen.Infrastructure.Configurations;

namespace Examen.Infrastructure
{
    public class ExamenContext : DbContext
    {

        public DbSet<Bouquet> Bouquet { get; set; }
        public DbSet<Flower> Flower { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<NaturalFlower> NaturalFlower { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=MyDBName;Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NaturalFlower>().ToTable("NaturalFlower");  //heritage
            modelBuilder.Entity<ArtificialFlower>().ToTable("ArtificialFlower");  //heritage
            modelBuilder.Entity<Flower>().ToTable("Flower");  //heritage

            modelBuilder.ApplyConfiguration(new FlowerConfig());
            // interm modelBuilder.Entity<Dossier>().HasKey(r => new { r.Datedepot, r.clientFK, r.avocatFK });
               foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
              /*       .Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(15); //tous les string taille 15
                    property.IsNullable = false; //tous les string obligatoire
                }
               */
          //   .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime))) //conversion
                {
                    property.SetColumnType("date"); // conversion
                   
                }
              base.OnModelCreating(modelBuilder);
             
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);


            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);


            //configurationBuilder
            //  .Properties<DateTime>()
            //      .HaveColumnType("date");
        }

    }
}
