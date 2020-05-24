using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Api;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK_Domain.Clients");

                entity.Property(e => e.ClientId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Alias).HasMaxLength(1000);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.FirstName).HasMaxLength(1000);

                entity.Property(e => e.LastName).HasMaxLength(1000);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("client_fk");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PK_Domain.Managers");

                entity.Property(e => e.ManagerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Alias).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.FirstName).HasMaxLength(1000);

                entity.Property(e => e.LastName).HasMaxLength(1000);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
