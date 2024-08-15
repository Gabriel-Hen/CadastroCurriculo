using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Data;
public class InitDataBaseServices : IHostedLifecycleService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IList<Action<IServiceProvider>> _actions;

    public InitDataBaseServices(
        IServiceProvider serviceProvider,
        IList<Action<IServiceProvider>> actions = null
    )
    {
        _serviceProvider = serviceProvider;
        _actions = actions;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task StartedAsync(CancellationToken cancellationToken)
    {
        if (_actions != null)
        {
            foreach (Action<IServiceProvider> action in _actions)
            {
                await Task.Run(() =>
                {
                    action.Invoke(_serviceProvider);
                });
            }
        }
    }

    public async Task StartingAsync(CancellationToken cancellationToken)
    {
        using (var scoope = _serviceProvider.CreateScope())
        {
            var context = scoope.ServiceProvider.GetService<DatabaseContext>();
            var migracaoPendente = context.Database.GetPendingMigrations();
            if (migracaoPendente.Any())
            {
                await context.Database.MigrateAsync();
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
