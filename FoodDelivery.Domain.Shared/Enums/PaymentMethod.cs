namespace FoodDelivery.Domain.Shared.Enums;

/// <summary>
/// Способ оплаты заказа
/// </summary>
public enum PaymentMethod
{
    /// <summary>
    /// Оплата наличными
    /// </summary>
    Cash,

    /// <summary>
    /// Оплата картой
    /// </summary>
    Card,

    /// <summary>
    /// Оплата онлайн
    /// </summary>
    Online
}