using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Eventum.One2
{
    public partial class EventumOneContext : DbContext
    {
        public EventumOneContext()
        {
        }

        public EventumOneContext(DbContextOptions<EventumOneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<HColor> HColor { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("brand_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HColorId).HasColumnName("h_color_id");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasColumnName("model_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.HColor)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.HColorId)
                    .HasConstraintName("FK__car__h_color_id__38996AB5");
            });

            modelBuilder.Entity<HColor>(entity =>
            {
                entity.ToTable("h_color");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
