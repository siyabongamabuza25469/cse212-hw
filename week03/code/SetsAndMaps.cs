using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SetsAndMaps
{
    /// <summary>
    /// Finds all symmetric pairs of two-character words.
    /// For example, ["am", "ma"] returns ["am & ma"].
    /// </summary>
    public static string[] FindPairs(string[]? words)
    {
        if (words == null || words.Length == 0)
        {
            return Array.Empty<string>();
        }

        var wordsSet = new HashSet<string>(StringComparer.Ordinal);
        var pairs = new List<string>();

        foreach (string? word in words)
        {
            if (word == null || word.Length != 2)
            {
                continue;
            }

            if (!wordsSet.Add(word))
            {
                continue;
            }

            string reversed = string.Concat(word[1], word[0]);

            if (word[0] != word[1] && wordsSet.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Reads a census file and counts the number of people with each degree.
    /// The degree is expected to be in the fourth column.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.Ordinal);

        foreach (string line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] fields = line.Split(',');

            if (fields.Length < 4)
            {
                continue;
            }

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determines whether two words are anagrams.
    /// Spaces are ignored and letter casing is ignored.
    /// </summary>
    public static bool IsAnagram(string? word1, string? word2)
    {
        if (word1 == null || word2 == null)
        {
            return false;
        }

        int[] counts = new int[char.MaxValue + 1];
        int remainingCharacters = 0;

        foreach (char character in word1)
        {
            if (char.IsWhiteSpace(character))
            {
                continue;
            }

            char normalized = char.ToLowerInvariant(character);
            counts[normalized]++;
            remainingCharacters++;
        }

        foreach (char character in word2)
        {
            if (char.IsWhiteSpace(character))
            {
                continue;
            }

            char normalized = char.ToLowerInvariant(character);
            counts[normalized]--;
            remainingCharacters--;

            if (counts[normalized] < 0)
            {
                return false;
            }
        }

        if (remainingCharacters != 0)
        {
            return false;
        }

        for (int index = 0; index < counts.Length; index++)
        {
            if (counts[index] != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Downloads the current day's earthquake data from the USGS
    /// and returns each earthquake's location and magnitude.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        string json = client
            .GetStringAsync(uri)
            .GetAwaiter()
            .GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        FeatureCollection? collection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (collection?.Features == null)
        {
            return Array.Empty<string>();
        }

        var earthquakes = new List<string>();

        foreach (Feature feature in collection.Features)
        {
            string location = feature.Properties?.Place ?? "Unknown location";
            double? magnitude = feature.Properties?.Mag;

            if (magnitude.HasValue)
            {
                earthquakes.Add(
                    $"{location}: Magnitude {magnitude.Value.ToString(
                        "0.0",CultureInfo.InvariantCulture)}");
        }
        else
        {
            earthquakes.Add($"{location}: Magnitude Unknown");
        }
    }

    return earthquakes.ToArray();
}

private sealed class FeatureCollection
{
    [JsonPropertyName("features")]
    public List<Feature>? Features { get; set; }
}

private sealed class Feature
{
    [JsonPropertyName("properties")]
    public EarthquakeProperties? Properties { get; set; }
}

private sealed class EarthquakeProperties
{
    [JsonPropertyName("place")]
    public string? Place { get; set; }

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}
}