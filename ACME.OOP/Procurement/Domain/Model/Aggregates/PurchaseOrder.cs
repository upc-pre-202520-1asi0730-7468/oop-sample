using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

/// <summary>
/// Represents a purchase order aggregate root in the Procurement bounded context. 
/// </summary>
/// <param name="orderNumber">The unique order number of the purchase order.</param>
/// <param name="supplierId">The supplier <see cref="SupplierId"/> identifier.</param>
/// <param name="orderDate">The date the order was placed.</param>
/// <param name="currency">The currency code (ISO 4217) for the purchase order.</param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = new();    
    public string OrderNumber { get; init; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; init; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; init; } = orderDate;
    public string Currency { get; init; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3 
        ? throw new ArgumentException("Currency must be a valid 3-letter ISO 4217 currency code.", nameof(currency))
        : currency;
    public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds a new item to the purchase order. 
    /// </summary>
    /// <param name="productId">The product <see cref="ProductId"/> identifier.</param>   
    /// <param name="quantity">The quantity of the product ordered.</param>
    /// <param name="unitPriceAmount">The unit price amount of the product.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when quantity or unit price amount is less than or equal to zero.</exception>
    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount <= 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit price must be greater than zero.");
        
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);   
    }

    /// <summary>
    /// Calculates the total amount of the purchase order. 
    /// </summary>
    /// <returns>The total amount as a <see cref="Money"/> value object.</returns>
    public Money CalculateTotal()
    {
        var orderTotalAmount = _items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(orderTotalAmount, Currency);       
    }
}