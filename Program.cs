using System;
using System.Globalization;
using System.Linq;

namespace MyMonkeyApp;

/// <summary>
/// Interactive console UI for the Monkey Explorer application.
/// </summary>
internal static class Program
{
	private const string MonkeyArt = @"
   .-.
  (o o)
   |=|
  __|__
 /__|__\
(_/  \_)
";

	private static void Main()
	{
		while (true)
		{
			Console.WriteLine();
			Console.WriteLine("Monkey Explorer");
			Console.WriteLine("1) List all monkeys");
			Console.WriteLine("2) Get details for a monkey by name");
			Console.WriteLine("3) Get a random monkey");
			Console.WriteLine("4) Exit");
			Console.Write("Choose an option: ");

			var input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("Please enter a choice.");
				continue;
			}

			switch (input.Trim())
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetDetailsByName();
					break;
				case "3":
					ShowRandomMonkey();
					break;
				case "4":
				case "q":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Unknown option. Try again.");
					break;
			}
		}
	}

	private static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		if (monkeys.Count == 0)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}

		Console.WriteLine("Available monkeys:");
		for (var i = 0; i < monkeys.Count; i++)
		{
			var m = monkeys[i];
			var count = MonkeyHelper.GetAccessCount(m.Name);
			Console.WriteLine($"{i + 1}. {m.Name} — {m.Location} (accessed: {count} times)");
		}
	}

	private static void GetDetailsByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(name))
		{
			Console.WriteLine("Name required.");
			return;
		}

		var monkey = MonkeyHelper.GetMonkeyByName(name!);
		if (monkey is null)
		{
			Console.WriteLine("Monkey not found (case-insensitive search).");
			return;
		}

		MonkeyHelper.IncrementAccessCount(monkey.Name);
		DisplayMonkey(monkey);
	}

	private static void ShowRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey is null)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}

		MonkeyHelper.IncrementAccessCount(monkey.Name);
		DisplayMonkey(monkey);
	}

	private static void DisplayMonkey(Monkey monkey)
	{
		Console.WriteLine();
		Console.WriteLine(MonkeyArt);
		Console.WriteLine($"Name: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Details: {monkey.Details}");
		Console.WriteLine($"Population: {(monkey.Population?.ToString("N0", CultureInfo.InvariantCulture) ?? "Unknown")}");
		Console.WriteLine($"Coordinates: {(monkey.Latitude?.ToString(CultureInfo.InvariantCulture) ?? "?")}, {(monkey.Longitude?.ToString(CultureInfo.InvariantCulture) ?? "?")}");
		Console.WriteLine($"Access count: {MonkeyHelper.GetAccessCount(monkey.Name)}");
		Console.WriteLine();
	}
}

