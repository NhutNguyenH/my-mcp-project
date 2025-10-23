namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with metadata useful for the console application.
/// </summary>
public sealed class Monkey
{
    /// <summary>
    /// Gets or sets the common name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary location or region where the species is found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a short description or details about the species.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets an optional image URL or file path for the species.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the estimated population of the species (if known).
    /// </summary>
    public long? Population { get; set; }

    /// <summary>
    /// Gets or sets the approximate latitude for the species' primary location.
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Gets or sets the approximate longitude for the species' primary location.
    /// </summary>
    public double? Longitude { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Monkey"/> class.
    /// </summary>
    public Monkey()
    {
    }
}
