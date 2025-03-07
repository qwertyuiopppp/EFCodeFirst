using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace TGKW.ModelFirst;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<SysUser>  SysUsers { get; set; }
    
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 配置 MySQL 连接字符串
        //Server=localhost;uid=root;password=qQ123456!;Database=tgkw_db;
        // const string connectionString = "Server=localhost;uid=root;password=qQ123456!;Database=tgkw_db;";
        //
        // optionsBuilder.UseMySql(connectionString, 
        //         ServerVersion.AutoDetect(connectionString))
        //     .EnableSensitiveDataLogging()
        //     .LogTo(message => Debug.WriteLine(message));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}