using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaskItem> Tarefas => Set<TaskItem>();
}