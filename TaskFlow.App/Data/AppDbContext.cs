using Microsoft.EntityFrameworkCore;
using TaskFlow.App.Models;

namespace TaskFlow.App.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tarefas => Set<TaskItem>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=taskflow.db");
    }
}

