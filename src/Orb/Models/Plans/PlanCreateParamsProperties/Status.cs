using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

/// <summary>
/// The status of the plan to create (either active or draft). If not specified, this
/// defaults to active.
/// </summary>
[JsonConverter(typeof(EnumConverter<Status, string>))]
public sealed record class Status(string value) : IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status Draft = new("draft");

    readonly string _value = value;

    public enum Value
    {
        Active,
        Draft,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "draft" => Value.Draft,
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
