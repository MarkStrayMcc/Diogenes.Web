using Microsoft.Extensions.Hosting;
namespace Diogenes.Web;

public class RunnerBackgroundService : BackgroundService
{
    private readonly ILogger<RunnerBackgroundService> logger;
    private readonly IRunner runner;

    public RunnerBackgroundService(
        ILogger<RunnerBackgroundService> logger,
        IRunner runner)
    {
        this.logger = logger;
        this.runner = runner;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Runner background service started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                runner.Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Runner failed");
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}