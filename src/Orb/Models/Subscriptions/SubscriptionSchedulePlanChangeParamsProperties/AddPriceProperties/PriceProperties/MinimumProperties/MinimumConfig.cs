using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionSchedulePlanChangeParamsProperties.AddPriceProperties.PriceProperties.MinimumProperties;

[JsonConverter(typeof(ModelConverter<MinimumConfig>))]
public sealed record class MinimumConfig : ModelBase, IFromRaw<MinimumConfig>
{
    /// <summary>
    /// The minimum amount to apply
    /// </summary>
    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("minimum_amount");
        }
        set
        {
            this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// By default, subtotals from minimum composite prices are prorated based on
    /// the service period. Set to false to disable proration.
    /// </summary>
    public bool? Prorated
    {
        get
        {
            if (!this.Properties.TryGetValue("prorated", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prorated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MinimumAmount;
        _ = this.Prorated;
    }

    public MinimumConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MinimumConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MinimumConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MinimumConfig(string minimumAmount)
        : this()
    {
        this.MinimumAmount = minimumAmount;
    }
}
