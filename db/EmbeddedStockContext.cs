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

            modelBuilder.Entity<User>()
                .HasIndex(user => new { user.Name }).IsUnique();

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Cat1"});
        }

        public DbSet<assignment3_db.Models.Component> Component { get; set; }

        public DbSet<assignment3_db.Models.Category> Category { get; set; }

        public DbSet<assignment3_db.Models.ComponentType> ComponentType { get; set; }

        public DbSet<assignment3_db.Models.ComponentTypeCategory> ComponentTypeCategory { get; set; }

        public DbSet<assignment3_db.Models.ESImage> ESImage { get; set; }

        public DbSet<User> User { get; set; }
    }
}
