using Microsoft.EntityFrameworkCore;
using Pschool.Infrastructure.Models;

namespace Pschool.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Parent>()
            .HasMany(p => p.Students)
            .WithOne(s => s.Parent)
            .HasForeignKey(s => s.ParentId);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}