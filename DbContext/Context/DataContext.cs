using DbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContext.Context;

public partial class DataContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("filename=../data.db");
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}