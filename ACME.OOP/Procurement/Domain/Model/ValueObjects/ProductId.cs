namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// Represents a value object for a product identifier in the Procurement bounded context. 
/// </summary>
public record ProductId
{
    public Guid Id { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductId"/> Value Object. 
    /// </summary>
    /// <param name="id">The <see cref="Guid"/> unique identifier for the product.</param>
    /// <exception cref="ArgumentException">Thrown when the provided <paramref name="id"/> is an empty GUID.</exception>
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product Id cannot be an empty GUID.", nameof(id));
        Id = id;   
    }
    
    /// <summary>
    /// Creates a new <see cref="ProductId"/> Value Object with a new GUID as the identifier. 
    /// </summary>
    /// <returns>A new instance of <see cref="ProductId"/> with a unique identifier.</returns>
    public static ProductId New() => new (Guid.NewGuid());
    
    /// <summary>
    /// Returns a string representation of the ProductId Value Object. 
    /// </summary>
    /// <returns>A string representation of the ProductId.</returns>
    public override string ToString() => Id.ToString();
}