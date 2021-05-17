using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReferenceBookApp.DataAccess.Entities;

namespace ReferenceBookApp.DataAccess.Context
{
    public partial class ReferenceBookAppContext : DbContext
    {
        public ReferenceBookAppContext()
        {
        }

        public ReferenceBookAppContext(DbContextOptions<ReferenceBookAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Fact> Fact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(fct => fct.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.HasOne(fld => fld.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(fld => fld.ParentId)
                    .HasConstraintName("FK_Field_Field");
            });

            modelBuilder.Entity<Fact>(entity =>
            {
                entity.Property(fct => fct.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

                entity.Property(fct => fct.Text).IsRequired();

                entity.HasOne(fld => fld.Field)
                    .WithMany(p => p.Fact)
                    .HasForeignKey(fld => fld.FieldId)
                    .HasConstraintName("FK_Fact_Field");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}