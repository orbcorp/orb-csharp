using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.PriceProperties.ThresholdTotalAmountProperties.ThresholdTotalAmountConfigProperties;

namespace Orb.Models.PriceProperties.ThresholdTotalAmountProperties;

/// <summary>
/// Configuration for threshold_total_amount pricing
/// </summary>
[JsonConverter(typeof(ModelConverter<ThresholdTotalAmountConfig>))]
public sealed record class ThresholdTotalAmountConfig
    : ModelBase,
        IFromRaw<ThresholdTotalAmountConfig>
{
    /// <summary>
    /// When the quantity consumed passes a provided threshold, the configured total
    /// will be charged
    /// </summary>
    public required List<ConsumptionTable> ConsumptionTable
    {
        get
        {
            if (!this.Properties.TryGetValue("consumption_table", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "consumption_table",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<ConsumptionTable>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("consumption_table");
        }
        set
        {
            this.Properties["consumption_table"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the unit price will be prorated to the billing period
    /// </summary>
    public bool? Prorate
    {
        get
        {
            if (!this.Properties.TryGetValue("prorate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prorate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.ConsumptionTable)
        {
            item.Validate();
        }
        _ = this.Prorate;
    }

    public ThresholdTotalAmountConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThresholdTotalAmountConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThresholdTotalAmountConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ThresholdTotalAmountConfig(List<ConsumptionTable> consumptionTable)
        : this()
    {
        this.ConsumptionTable = consumptionTable;
    }
}
