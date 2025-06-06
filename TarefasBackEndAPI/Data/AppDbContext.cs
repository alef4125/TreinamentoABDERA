using Microsoft.EntityFrameworkCore;

namespace TarefasBackEndAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Task> Tarefas => Set<Task>();
}