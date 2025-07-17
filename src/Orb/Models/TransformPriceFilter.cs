using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TransformPriceFilter>))]
public sealed record class TransformPriceFilter
    : Orb::ModelBase,
        Orb::IFromRaw<TransformPriceFilter>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required TransformPriceFilterProperties::Field Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("field", "Missing required argument");

            return Json::JsonSerializer.Deserialize<TransformPriceFilterProperties::Field>(element)
                ?? throw new System::ArgumentNullException("field");
        }
        set { this.Properties["field"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required TransformPriceFilterProperties::Operator Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "operator",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<TransformPriceFilterProperties::Operator>(
                    element
                ) ?? throw new System::ArgumentNullException("operator");
        }
        set { this.Properties["operator"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required Generic::List<string> Values
    {
        get
        {
            if (!this.Properties.TryGetValue("values", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "values",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("values");
        }
        set { this.Properties["values"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        foreach (var item in this.Values)
        {
            _ = item;
        }
    }

    public TransformPriceFilter() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TransformPriceFilter(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TransformPriceFilter FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
