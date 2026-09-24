namespace FoodDelivery.Domain.Shared.Enums;

/// <summary>
/// Статус заказа
/// </summary>
public enum OrderStatus
{
    Created,
    Preparing,
    Delivering,
    Delivered,
    Cancelled
}
