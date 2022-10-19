using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tests;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        configHost.AddJsonFile("appsettings.json", optional: true);
        configHost.AddEnvironmentVariables(prefix: "PREFIX_");
        configHost.AddCommandLine(args);
        configHost.SetBasePath(Directory.GetCurrentDirectory());

    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddTransient<ITest, SqliteTest>();
        services.AddHostedService<TestHostedService>();
    })
    .Build();

// Application code should start here.

await host.RunAsync();