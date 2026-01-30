using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Blazored.SessionStorage.JsonConverters;

/// <summary>
/// The new Json.NET doesn't support Timespan at this time
/// https://github.com/dotnet/corefx/issues/38641
/// </summary>
public class TimespanJsonConverter : JsonConverter<TimeSpan>
{
    /// <summary>
    /// Format: Days.Hours:Minutes:Seconds:Milliseconds
    /// </summary>
    public const string TimeSpanFormatString = @"d\.hh\:mm\:ss\:FFF";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var s = reader.GetString();
        if (string.IsNullOrWhiteSpace(s))
        {
            return TimeSpan.Zero;
        }

        if (!TimeSpan.TryParseExact(s, TimeSpanFormatString, null, out var parsedTimeSpan))
        {
            throw new FormatException($"Input timespan is not in an expected format : expected {Regex.Unescape(TimeSpanFormatString)}. Please retrieve this key as a string and parse manually.");
        }

        return parsedTimeSpan;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        var timespanFormatted = $"{value.ToString(TimeSpanFormatString)}";
        writer.WriteStringValue(timespanFormatted);
    }
}
