using FoodDelivery.Domain.Shared.Enums;

namespace FoodDelivery.Tests;

/// <summary>
/// Тесты к данным службы доставки еды
/// </summary>
public class FoodDeliveryTests
{
    /// <summary>
    /// Поиск отмененных заказов
    /// </summary>
    [Fact]
    public void GetCancelledOrders()
    {
        var cancelledOrders = FoodDeliveryData.Orders
        .Where(order => order.Status == OrderStatus.Cancelled)
        .ToList();

        Assert.Single(cancelledOrders);
        Assert.Equal(7, cancelledOrders.First().Id);
    }

    /// <summary>
    /// Вывод информации о клиентах заказавших блюда в указанном ресторане
    /// </summary>
    [Fact]
    public void GetCustomersByRestaurantOrderedByFullName()
    {
        const int restaurantId = 1;

        var customers = FoodDeliveryData.Orders
            .Where(order => order.RestaurantId == restaurantId)
            .Select(order => order.Customer!)
            .Distinct()
            .OrderBy(customer => customer.FullName)
            .Select(customer => customer.FullName)
            .ToList();

        Assert.Equal(2, customers.Count);
        Assert.Equal(["Иванов А.", "Иванов Б."], customers);
    }

    /// <summary>
    /// Вывод топ 5 популярных блюд
    /// </summary>
    [Fact]
    public void GetTopFiveMostOrderedDishesInDeliveredOrders()
    {
        var topDishes = FoodDeliveryData.OrderItems
            .Where(item => item.Order!.Status == OrderStatus.Delivered)
            .GroupBy(item => item.Dish!.Name)
            .Select(group => new { DishName = group.Key, TotalQuantity = group.Sum(item => item.Quantity) })
            .OrderByDescending(dish => dish.TotalQuantity)
            .ThenBy(dish => dish.DishName)
            .Take(5)
            .ToList();

        Assert.Equal(5, topDishes.Count);

        var top = topDishes[0];
        Assert.Equal("Пепперони", top.DishName);
        Assert.Equal(3, top.TotalQuantity);
    }

    /// <summary>
    /// Вывод информации о заказах курьера за заданный период
    /// </summary>
    [Fact]
    public void GetCourierOrdersForPeriod()
    {
        const int courierId = 1;
        var from = new DateTime(2024, 5, 1);
        var to = new DateTime(2024, 5, 31);

        var orders = FoodDeliveryData.Orders
            .Where(order => order.CourierId == courierId && order.CreatedAt >= from && order.CreatedAt <= to)
            .OrderBy(order => order.CreatedAt)
            .ToList();

        Assert.Equal(2, orders.Count);
        Assert.All(orders, order => Assert.Equal(courierId, order.CourierId));
        Assert.Equal([1, 4], orders.Select(order => order.Id));
    }

    /// <summary>
    /// Вывести количество заказов доставляемых каждым транспортом
    /// </summary>
    [Fact]
    public void GetOrderCountByTransportType()
    {
        var transportStats = FoodDeliveryData.Orders
            .Where(order => order.Courier != null)
            .GroupBy(order => order.Courier!.Transport)
            .ToDictionary(key => key.Transport, value => value.Count);
            .ToDictionary(group => group.Key, group => group.Count());

        Assert.Equal(3, transportStats[TransportType.Bicycle]);
        Assert.Equal(3, transportStats[TransportType.Car]);
        Assert.Equal(2, transportStats[TransportType.Foot]);
        Assert.Equal(2, transportStats[TransportType.Scooter]);
    }
}
