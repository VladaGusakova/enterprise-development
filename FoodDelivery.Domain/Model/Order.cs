using FoodDelivery.Domain.Shared.Enums;

namespace FoodDelivery.Domain.Model;

/// <summary>
/// Заказ на доставку еды
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Дата и время оформления заказа
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Адрес доставки
    /// </summary>
    public required string DeliveryAddress { get; set; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public required OrderStatus Status { get; set; }

    /// <summary>
    /// Способ оплаты
    /// </summary>
    public required PaymentMethod PaymentMethod { get; set; }

    /// <summary>
    /// Стоимость доставки
    /// </summary>
    public required decimal DeliveryFee { get; set; }

    public required int CustomerId { get; set; }

    /// <summary>
    /// Клиент оформивший заказ
    /// </summary>
    public Customer? Customer { get; set; }

    public required int RestaurantId { get; set; }

    /// <summary>
    /// Ресторан в котором оформлен заказ
    /// </summary>
    public Restaurant? Restaurant { get; set; }

    public int? CourierId { get; set; }

    /// <summary>
    /// Курьер доставляющий заказ
    /// </summary>
    public Courier? Courier { get; set; }

    /// <summary>
    /// Блюда в заказе
    /// </summary>
    public List<OrderItem> Items { get; set; } = [];

    /// <summary>
    /// Стоимость заказа
    /// </summary>
    public decimal Total => Items.Sum(item => item.Quantity * item.UnitPrice) + DeliveryFee;
}
