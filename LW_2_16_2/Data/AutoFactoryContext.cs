using System;
using System.Collections.Generic;
using System.Configuration;
using LW_2_16_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LW_2_16_2.Data
{
    public partial class AutoFactoryContext : DbContext
    {
        public AutoFactoryContext()
        {
            Database.EnsureCreated();
        }

        public AutoFactoryContext(DbContextOptions<AutoFactoryContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Body> Bodies { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Body>(entity =>
            {
                entity.ToTable("Body");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BodyTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandCountry).HasMaxLength(50);

                entity.Property(e => e.BrandTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.VehicleBodyId).HasColumnName("VehicleBody_ID");

                entity.Property(e => e.VehicleBrandId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VehicleBrand_ID");

                entity.Property(e => e.VehicleTitle).HasMaxLength(50);

                entity.HasOne(d => d.VehicleBody)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleBodyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Body");

                entity.HasOne(d => d.VehicleBrand)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Brand");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
