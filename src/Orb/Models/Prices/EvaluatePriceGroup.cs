using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using EvaluatePriceGroupProperties = Orb.Models.Prices.EvaluatePriceGroupProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Prices;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<EvaluatePriceGroup>))]
public sealed record class EvaluatePriceGroup : Orb::ModelBase, Orb::IFromRaw<EvaluatePriceGroup>
{
    /// <summary>
    /// The price's output for the group
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The values for the group in the order specified by `grouping_keys`
    /// </summary>
    public required Generic::List<EvaluatePriceGroupProperties::GroupingValue> GroupingValues
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_values", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "grouping_values",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<EvaluatePriceGroupProperties::GroupingValue>>(
                    element
                ) ?? throw new System::ArgumentNullException("grouping_values");
        }
        set { this.Properties["grouping_values"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price's usage quantity for the group
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    EvaluatePriceGroup(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EvaluatePriceGroup FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
