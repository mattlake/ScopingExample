/*
 * This is the working example
 */

using DbContext.Context;
using DbContext.Models;

namespace ScopingExample;

public class WorkingWorker : BackgroundService
{
    private readonly ILogger<BrokenWorker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public WorkingWorker(ILogger<BrokenWorker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                DataContext? dataContext = scope.ServiceProvider.GetService<DataContext>();
                User user = dataContext.Users.FirstOrDefault();

                _logger.LogInformation($"Id: {user.UserId}, username: {user.UserName}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}