using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class ExamenContext:DbContext
    {
        public DbSet<Membre> Membres  { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Trophee> Trophees { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Entraineur> Entraineurs { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=HassenDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrat>().HasKey(c => new { c.DateContrat, c.EquipeFK, c.MembreFK });
            modelBuilder.Entity<Membre>()
                .HasDiscriminator<Char>("Type")
                .HasValue<Membre>('M')
                .HasValue<Joueur>('J')
                .HasValue<Entraineur>('E');
            modelBuilder.Entity<Trophee>()
                .HasOne(t => t.Equipe)
                .WithMany(e => e.Trophees)
                .HasForeignKey(t => t.EquipeFK);
            base.OnModelCreating(modelBuilder);
        }

    }
}
