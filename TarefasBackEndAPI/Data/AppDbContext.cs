using Microsoft.EntityFrameworkCore;
using TarefasBackEndAPI.Modelos;

namespace TarefasBackEndAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tarefas => Set<TaskItem>();
}