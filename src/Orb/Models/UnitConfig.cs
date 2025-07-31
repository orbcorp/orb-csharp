using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<UnitConfig>))]
public sealed record class UnitConfig : ModelBase, IFromRaw<UnitConfig>
{
    /// <summary>
    /// Rate per unit of usage
    /// </summary>
    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "unit_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("unit_amount");
        }
        set { this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.UnitAmount;
    }

    public UnitConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnitConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnitConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
