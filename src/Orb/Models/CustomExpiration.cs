using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CustomExpirationProperties = Orb.Models.CustomExpirationProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CustomExpiration>))]
public sealed record class CustomExpiration : ModelBase, IFromRaw<CustomExpiration>
{
    public required long Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["duration"] = JsonSerializer.SerializeToElement(value); }
    }

    public required CustomExpirationProperties::DurationUnit DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CustomExpirationProperties::DurationUnit>(element)
                ?? throw new System::ArgumentNullException("duration_unit");
        }
        set { this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public CustomExpiration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomExpiration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomExpiration FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
