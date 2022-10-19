
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Blogs;

namespace Databases;

public class SqliteDbContext : DbContext
{
    public SqliteDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");

        Console.WriteLine("数据库路径:" + DbPath);
    }

    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();

    public string DbPath { get; }


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging()
            .UseSqlite($"Data Source={DbPath}");
    }
}
