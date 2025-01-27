using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

public class OrderStatusUpdaterService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public OrderStatusUpdaterService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IRepository<Order>>();

                await UpdateOrderStatuses(orderRepository);
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    private async Task UpdateOrderStatuses(IRepository<Order> orderRepository)
    {
        var orders = await orderRepository.Get();

        foreach (var order in orders)
        {
            if (order.Status == "Preparing" && DateTime.UtcNow - order.CreatedAt > TimeSpan.FromMinutes(3))
            {
                order.Status = "Cooking";
                order.CookingStartedAt = DateTime.UtcNow;

                await orderRepository.Update(order);
            }
            else if (order.Status == "Cooking" && order.CookingStartedAt != null && DateTime.UtcNow - order.CookingStartedAt.Value > TimeSpan.FromMinutes(15))
            {
                order.Status = "Delivered";
                order.DeliveredAt = DateTime.UtcNow;

                await orderRepository.Update(order);
            }
        }
    }
}
