using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Prices.EvaluatePriceGroupProperties;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<EvaluatePriceGroup>))]
public sealed record class EvaluatePriceGroup : ModelBase, IFromRaw<EvaluatePriceGroup>
{
    /// <summary>
    /// The price's output for the group
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The values for the group in the order specified by `grouping_keys`
    /// </summary>
    public required List<GroupingValue> GroupingValues
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_values' cannot be null",
                    new ArgumentOutOfRangeException("grouping_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<GroupingValue>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouping_values' cannot be null",
                    new ArgumentNullException("grouping_values")
                );
        }
        set
        {
            this.Properties["grouping_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price's usage quantity for the group
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        foreach (var item in this.GroupingValues)
        {
            item.Validate();
        }
        _ = this.Quantity;
    }

    public EvaluatePriceGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvaluatePriceGroup(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EvaluatePriceGroup FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
