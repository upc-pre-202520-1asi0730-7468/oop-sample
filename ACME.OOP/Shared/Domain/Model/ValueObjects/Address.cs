namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a value object for an address with detailed information including street, number,
/// city, state or region, postal code, and country. This record is immutable and ensures the
/// integrity of its state through validation during initialization.
/// </summary>
public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string? StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Address"/> Value Object. 
    /// </summary>
    /// <param name="street">the address street</param>
    /// <param name="number">the address street number</param>
    /// <param name="city">the address city</param>
    /// <param name="stateOrRegion">the address state or region</param>
    /// <param name="postalCode">the address postal code</param>
    /// <param name="country">the address country</param>
    /// <exception cref="ArgumentException">Thrown when any required parameter is null or whitespace.</exception>
    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or whitespace.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Number cannot be null or whitespace.", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or whitespace.", nameof(city));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be null or whitespace.", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or whitespace.", nameof(country));
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    /// <summary>
    /// Returns a string representation of the Address Value Object. 
    /// </summary>
    /// <returns>A formatted string containing the full address details with the format: Street Number, City, StateOrRegion, PostalCode, Country.</returns>
    public override string ToString() => $"{Street} {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";
}