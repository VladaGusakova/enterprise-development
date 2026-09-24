namespace FoodDelivery.Domain.Model;

/// <summary>
/// Блюдо и его количество
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Идентификатор блюда
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Количество единиц блюда
    /// </summary>
    public required int Quantity { get; set; }

    /// <summary>
    /// Цена блюда
    /// </summary>
    public required decimal Price { get; set; }

    /// <summary>
    /// Идентификатор заказа с блюдом
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Заказ которому принадлежит блюдо
    /// </summary>
    public Order? Order { get; set; }

    /// <summary>
    /// Идентификатор блюда из меню
    /// </summary>
    public int DishId { get; set; }

    /// <summary>
    /// Заказанное блюдо
    /// </summary>
    public Dish? Dish { get; set; }
}