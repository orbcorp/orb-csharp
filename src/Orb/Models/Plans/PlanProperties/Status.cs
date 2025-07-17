using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Plans.PlanProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<Status, string>))]
public sealed record class Status(string value) : Orb::IEnum<Status, string>
{
    public static readonly Status Active = new("active");

    public static readonly Status Archived = new("archived");

    public static readonly Status Draft = new("draft");

    readonly string _value = value;

    public enum Value
    {
        Active,
        Archived,
        Draft,
    }

    public Value Known() =>
        _value switch
        {
            "active" => Value.Active,
            "archived" => Value.Archived,
            "draft" => Value.Draft,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
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
