using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models 
{
    public class ToDoDbContext : DbContext 
    {
        public ToDoDbContext (DbContextOptions<ToDoDbContext> options) : base (options) 
        { 

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoList>(entity =>
            {
                entity.Property(x => x.Title).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<ToDoList>()
                .HasMany(x => x.Items)
                .WithOne(x => x.ToDoList)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.Property(x => x.Title).IsRequired().HasMaxLength(256);
            });
        }
    }
}