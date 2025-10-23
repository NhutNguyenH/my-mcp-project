using System.Collections.Concurrent;

namespace MyMonkeyApp;

/// <summary>
/// Provides in-memory storage and helper methods for monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> s_monkeys = new()
    {
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Atlantic Forest, Brazil",
            Details = "Small, brightly colored New World monkey with a distinctive mane of golden fur.",
            Image = null,
            Population = 3200,
            Latitude = -23.0,
            Longitude = -46.0
        },
        new Monkey
        {
            Name = "Emperor Tamarin",
            Location = "Amazon Basin",
            Details = "Known for its long, white moustache and playful behavior.",
            Image = null,
            Population = null,
            Latitude = -2.0,
            Longitude = -60.0
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Details = "Loud vocalizations can be heard for miles; folivorous diet.",
            Image = null,
            Population = null,
            Latitude = -10.0,
            Longitude = -55.0
        }
    };

    private static readonly ConcurrentDictionary<string, int> s_accessCounts = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Gets all known monkeys.
    /// </summary>
    /// <returns>Readonly list of monkeys.</returns>
    public static IReadOnlyList<Monkey> GetMonkeys() => s_monkeys.AsReadOnly();

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    /// <param name="name">The name to search for.</param>
    /// <returns>The matching <see cref="Monkey"/> or null if not found.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return s_monkeys.FirstOrDefault(m => string.Equals(m.Name, name.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Returns a random monkey from the collection.
    /// </summary>
    /// <returns>A random <see cref="Monkey"/> or null if none exist.</returns>
    public static Monkey? GetRandomMonkey()
    {
        if (s_monkeys.Count == 0)
            return null;

        var idx = Random.Shared.Next(s_monkeys.Count);
        return s_monkeys[idx];
    }

    /// <summary>
    /// Increment the access count for a monkey name.
    /// </summary>
    /// <param name="name">The monkey name.</param>
    public static void IncrementAccessCount(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        s_accessCounts.AddOrUpdate(name.Trim(), 1, (_, existing) => existing + 1);
    }

    /// <summary>
    /// Gets the access count for a monkey by name.
    /// </summary>
    /// <param name="name">The monkey name.</param>
    /// <returns>Number of times the monkey details were viewed.</returns>
    public static int GetAccessCount(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return 0;

        return s_accessCounts.TryGetValue(name.Trim(), out var c) ? c : 0;
    }
}
