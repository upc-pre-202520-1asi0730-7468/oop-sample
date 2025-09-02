using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// Represents a purchase order item for the purchase order aggregate in the Procurement bounded context. 
/// </summary>
/// <param name="productId">The product <see cref="ProductId"/> identifier.</param>
/// <param name="quantity">The quantity of the product ordered.</param>
/// <param name="unitPrice">The unit price of the product as a <see cref="Money"/> value object.</param>
public class PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
{
    public ProductId ProductId { get; init; } = productId ?? throw new ArgumentNullException(nameof(productId));
    public int Quantity { get; init; } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
    public Money UnitPrice { get; init; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    
    /// <summary>
    /// Calculates the total price of the item based on the quantity and unit price. 
    /// </summary>
    /// <returns>The total price as a <see cref="Money"/> value object.</returns>
    public Money CalculateItemTotal() => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);
}

