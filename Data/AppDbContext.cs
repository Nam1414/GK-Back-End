using Microsoft.EntityFrameworkCore;
using StudentClassApi.Models;


namespace StudentClassApi.Data
{
public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


public DbSet<Class> Classes { get; set; }
public DbSet<Student> Students { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
// Explicit 1-to-many configuration
modelBuilder.Entity<Class>()
.HasMany(c => c.Students)
.WithOne(s => s.Class)
.HasForeignKey(s => s.ClassId)
.OnDelete(DeleteBehavior.Cascade);


base.OnModelCreating(modelBuilder);
}
}
}