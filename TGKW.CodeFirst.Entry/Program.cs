// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DbContext = TGKW.ModelFirst.DbContext;

Console.WriteLine("Hello, World!");


var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.SetBasePath(Directory.GetCurrentDirectory());
        config.AddYamlFile("appsettings.yml", optional: false, reloadOnChange: true); // 现在这个方法可用了
    })
    .ConfigureServices((context, services) =>
    {
        // 配置数据库上下文
        services.AddDbContext<DbContext>(options =>
            options.UseMySql(
                context.Configuration.GetConnectionString("MySQL"),
                ServerVersion.AutoDetect(context.Configuration.GetConnectionString("MySQL")),
                mysqlOptions => mysqlOptions.EnableRetryOnFailure()
            ));

        // 注册其他服务...
        services.AddHostedService<Worker>();
    })
    .Build();

// 新增数据库迁移逻辑
using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
    //dbContext.Database.Migrate(); // 应用所有未执行的迁移
    //dbContext.Database.EnsureCreated();
}

await host.RunAsync();


Console.WriteLine("end");

public class Worker : BackgroundService
{
    private readonly DbContext _dbContext;

    public Worker(DbContext  dbContext)
    {
        _dbContext = dbContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {


       await Task.Delay(2000);
    }
}