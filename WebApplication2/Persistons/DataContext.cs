using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;


namespace WebApplication2.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<TimeTracking> timeTrackings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=Yorozuya;Initial Catalog=issue-tracking-db;Trusted_Connection=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TimeTracking>()
            .HasOne(o => o.Issue)
            .WithMany(m => m.TimeTrackings)
            .OnDelete(DeleteBehavior.NoAction);
    }

}
