using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.data;

public class apiContext : DbContext{
    public DbSet<ApiModel> Username { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite("Data Source=teste.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}