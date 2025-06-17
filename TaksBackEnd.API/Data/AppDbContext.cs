using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaskItem> Tarefas => Set<TaskItem>();
    
    //Mostra em string os status no banco de dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Status)
            .HasConversion<string>();
        
        base.OnModelCreating(modelBuilder);
    }
}

