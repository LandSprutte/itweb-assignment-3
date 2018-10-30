using assignment3_db.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment3_db.db
{
    public class EmbeddedStockContext : DbContext
    {
        public EmbeddedStockContext(DbContextOptions<EmbeddedStockContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponentTypeCategory>()
                .HasKey(ctc => new { ctc.CategoryId, ctc.ComponentTypeId });

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(ctc => ctc.ComponentType)
                .WithMany(ct => ct.ComponentTypeCategories)
                .HasForeignKey(ctc => ctc.ComponentTypeId);

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(ctc => ctc.Category)
                .WithMany(c => c.ComponentTypeCategories)
                .HasForeignKey(ctc => ctc.CategoryId);
        }
    }
}
