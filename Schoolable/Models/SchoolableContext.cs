using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoolable.Models
{
    public class SchoolableContext : DbContext
    {

        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<TypeEtablissement> TypeEtablissements { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Role> Roles { get; set; }



        public SchoolableContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etablissement>(e =>
            {
                e.HasMany<Departement>(e => e.Departements)
                .WithOne(c => c.Etablissement);
                e.HasMany<Salle>(e => e.Salles)
                .WithOne(c => c.Etablissement);
                e.HasOne<TypeEtablissement>(c => c.TypeEtablissement)
                .WithMany(e => e.Etablissements)
                .HasForeignKey(c => c.TypeEtablissementId)
                .IsRequired(false);
            });

            modelBuilder.Entity<TypeEtablissement>(t =>
            {
                t.HasMany<Etablissement>(e => e.Etablissements)
                .WithOne(c => c.TypeEtablissement);
                
            });
            modelBuilder.Entity<Salle>(s =>
            {
                s.HasOne<Etablissement>(c => c.Etablissement)
               .WithMany(e => e.Salles)
               .HasForeignKey(c => c.EtablissementId)
               .IsRequired(false);

            });
            modelBuilder.Entity<Departement>(d =>
            {
                d.HasOne<Etablissement>(c => c.Etablissement)
               .WithMany(e => e.Departements)
               .HasForeignKey(c => c.EtablissementId)
               .IsRequired(false);

            });
            modelBuilder.Entity<Compte>(c =>
            {
                c.HasMany<Role>(c => c.Roles)
               .WithMany(e => e.Comptes);

            });
            modelBuilder.Entity<Role>(d =>
            {
                d.HasMany<Compte>(c => c.Comptes)
               .WithMany(e => e.Roles);
               

            });
        }

    }
}
