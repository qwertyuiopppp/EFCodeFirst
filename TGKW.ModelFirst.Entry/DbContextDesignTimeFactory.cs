using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace TGKW.ModelFirst.Entry;
public class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
{
    public DbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddYamlFile("appsettings.yml")
            .AddEnvironmentVariables()  // 新增环境变量支持
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder.UseMySql(
            configuration.GetConnectionString("MySQL"),
            new MySqlServerVersion(new Version(8, 0, 36)), // 显式指定版本
            options => options.MigrationsAssembly("TGKW.ModelFirst.Migrations"));

        return new DbContext(optionsBuilder.Options);
    }
}