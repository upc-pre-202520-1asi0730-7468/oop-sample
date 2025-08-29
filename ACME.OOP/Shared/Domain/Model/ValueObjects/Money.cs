namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a value object for a monetary amount with detailed information including amount,
/// currency. This record is immutable and ensures the integrity of its state through validation. 
/// </summary>
public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> Value Object. 
    /// </summary>
    /// <param name="amount">the monetary amount must be non-negative</param>
    /// <param name="currency">the currency code must be a valid 3-letter ISO 4217 code</param>
    /// <exception cref="ArgumentException">Thrown when the amount is negative or the currency code is invalid.</exception>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a valid 3-letter ISO 4217 currency code.", nameof(currency));
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        Amount = amount;
        Currency = currency;
    }
    
    /// <summary>
    /// Returns a string representation of the Money Value Object. 
    /// </summary>
    /// <returns>A string in the format "Amount Currency".</returns>
    public override string ToString() => $"{Amount} {Currency}";
}