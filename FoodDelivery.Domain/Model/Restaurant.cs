namespace FoodDelivery.Domain.Model;

/// <summary>
/// Ресторан в службе доставки
/// </summary>
public class Restaurant
{
    /// <summary>
    /// Идентификатор ресторана
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название ресторана
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Адрес ресторана
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Блюда в меню
    /// </summary>
    public List<Dish> Dishes { get; set; } = [];

    /// <summary>
    /// Заказы оформленные в ресторане
    /// </summary>
    public List<Order> Orders { get; set; } = [];
}
