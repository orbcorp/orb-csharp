using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.NewFloatingThresholdTotalAmountPriceProperties.ThresholdTotalAmountConfigProperties;

/// <summary>
/// Configuration for a single threshold
/// </summary>
[JsonConverter(typeof(ModelConverter<ConsumptionTable>))]
public sealed record class ConsumptionTable : ModelBase, IFromRaw<ConsumptionTable>
{
    /// <summary>
    /// Quantity threshold
    /// </summary>
    public required string Threshold
    {
        get
        {
            if (!this.Properties.TryGetValue("threshold", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'threshold' cannot be null",
                    new ArgumentOutOfRangeException("threshold", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'threshold' cannot be null",
                    new ArgumentNullException("threshold")
                );
        }
        set
        {
            this.Properties["threshold"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total amount for this threshold
    /// </summary>
    public required string TotalAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("total_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total_amount' cannot be null",
                    new ArgumentOutOfRangeException("total_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total_amount' cannot be null",
                    new ArgumentNullException("total_amount")
                );
        }
        set
        {
            this.Properties["total_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Threshold;
        _ = this.TotalAmount;
    }

    public ConsumptionTable() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConsumptionTable(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ConsumptionTable FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
