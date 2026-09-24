namespace FoodDelivery.Domain.Model;

/// <summary>
/// Клиент службы доставки еды
/// </summary>
public class Customer
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО клиента
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// Адрес клиента
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Заказы клиента
    /// </summary>
    public List<Order> Orders { get; set; } = [];
}
