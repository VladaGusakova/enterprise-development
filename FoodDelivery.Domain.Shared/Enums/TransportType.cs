namespace FoodDelivery.Domain.Shared.Enums;

/// <summary>
/// Способ доставки курьером
/// </summary>
public enum TransportType
{
    /// <summary>
    /// Доставка пешком
    /// </summary>
    Foot,

    /// <summary>
    /// Доставка на ведосипеде
    /// </summary>
    Bicycle,

    /// <summary>
    /// Доставка на скуторе
    /// </summary>
    Scooter,

    /// <summary>
    /// Доставка на машине
    /// </summary>
    Car
}