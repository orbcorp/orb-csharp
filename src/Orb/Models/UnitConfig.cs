using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

/// <summary>
/// Configuration for unit pricing
/// </summary>
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
                throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentOutOfRangeException("unit_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_amount' cannot be null",
                    new ArgumentNullException("unit_amount")
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

    [SetsRequiredMembers]
    public UnitConfig(string unitAmount)
        : this()
    {
        this.UnitAmount = unitAmount;
    }
}
