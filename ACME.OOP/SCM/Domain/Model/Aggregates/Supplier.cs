using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// Represents a supplier aggregate. 
/// </summary>
public class Supplier
{
    public SupplierId Id { get; init; }
    public string Name { get; init; }
    public Address Address { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Supplier"/> aggregate. 
    /// </summary>
    /// <param name="id">the unique identifier for the supplier</param>
    /// <param name="name">the name of the supplier</param>   
    /// <param name="address">the address of the supplier</param>
    /// <exception cref="ArgumentException">if <paramref name="id"/> or <paramref name="name"/> is null or whitespace</exception>
    public Supplier(string id, string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or whitespace.", nameof(id));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        ArgumentNullException.ThrowIfNull(address);
        Id = new SupplierId(id);
        Name = name;
        Address = address;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Supplier"/> aggregate. 
    /// </summary>
    /// <param name="name">the name of the supplier</param>  
    /// <param name="address">the address of the supplier</param>
    /// <exception cref="ArgumentException">if <paramref name="name"/> is null or whitespace</exception>
    public Supplier(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        ArgumentNullException.ThrowIfNull(address);
        Id = new SupplierId();
        Name = name;
        Address = address;   
    }
}