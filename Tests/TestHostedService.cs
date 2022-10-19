using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public sealed class TestHostedService : IHostedService
{
    private readonly ILogger _logger;
    private readonly IHostApplicationLifetime appLifetime;
    private readonly IServiceProvider services;
    
    public TestHostedService(
        ILogger<TestHostedService> logger,
        IServiceProvider services,
        IHostApplicationLifetime appLifetime)
    {
        _logger = logger;
        this.appLifetime = appLifetime;
        this.services = services;

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var test = services.GetRequiredService<ITest>();
        await test.ExcuteAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    //     private readonly ILogger _logger;

    // public TestHostedService(
    //     ILogger<TestHostedService> logger,
    //     IHostApplicationLifetime appLifetime)
    // {
    //     _logger = logger;

    //     appLifetime.ApplicationStarted.Register(OnStarted);
    //     appLifetime.ApplicationStopping.Register(OnStopping);
    //     appLifetime.ApplicationStopped.Register(OnStopped);
    // }

    // public Task StartAsync(CancellationToken cancellationToken)
    // {
    //     _logger.LogInformation("1. StartAsync has been called.");

    //     return Task.CompletedTask;
    // }

    // public Task StopAsync(CancellationToken cancellationToken)
    // {
    //     _logger.LogInformation("4. StopAsync has been called.");

    //     return Task.CompletedTask;
    // }

    // private void OnStarted()
    // {
    //     _logger.LogInformation("2. OnStarted has been called.");
    // }

    // private void OnStopping()
    // {
    //     _logger.LogInformation("3. OnStopping has been called.");
    // }

    // private void OnStopped()
    // {
    //     _logger.LogInformation("5. OnStopped has been called.");
    // }
}