namespace ACME.OOP.SCM.Domain.Model.ValueObjects;

/// <summary>
/// Represents a value object for a supplier identifier. 
/// </summary>
public record SupplierId
{
    public string Identifier { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SupplierId"/> Value Object. 
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null or whitespace.</exception>
    public SupplierId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Identifier cannot be null or whitespace.", nameof(identifier));
        Identifier = identifier;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SupplierId"/> Value Object with a new GUID as the identifier.
    /// </summary>
    public SupplierId() : this(Guid.NewGuid().ToString()) { }
}