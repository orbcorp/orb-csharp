using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.TierSubLineItemProperties;

[JsonConverter(typeof(ModelConverter<TierConfig>))]
public sealed record class TierConfig : ModelBase, IFromRaw<TierConfig>
{
    public required double FirstUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("first_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'first_unit' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "first_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["first_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double? LastUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("last_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["last_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string UnitAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("unit_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new System::ArgumentNullException("unit_amount")
                );
        }
        set
        {
            this.Properties["unit_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.LastUnit;
        _ = this.UnitAmount;
    }

    public TierConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TierConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
