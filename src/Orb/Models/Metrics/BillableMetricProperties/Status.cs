using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Metrics.BillableMetricProperties;

[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status Draft = new("draft");

    public static readonly Status Archived = new("archived");

    readonly string _value = value;

    public enum Value
    {
        Active,
        Draft,
        Archived,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "draft" => Value.Draft,
            "archived" => Value.Archived,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Status FromRaw(string value)
    {
        return new(value);
    }
}
