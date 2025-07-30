using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using TransformPriceFilterProperties = Orb.Models.TransformPriceFilterProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TransformPriceFilter>))]
public sealed record class TransformPriceFilter : ModelBase, IFromRaw<TransformPriceFilter>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required TransformPriceFilterProperties::Field Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("field", "Missing required argument");

            return JsonSerializer.Deserialize<TransformPriceFilterProperties::Field>(element)
                ?? throw new System::ArgumentNullException("field");
        }
        set { this.Properties["field"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required TransformPriceFilterProperties::Operator Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "operator",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TransformPriceFilterProperties::Operator>(element)
                ?? throw new System::ArgumentNullException("operator");
        }
        set { this.Properties["operator"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required List<string> Values
    {
        get
        {
            if (!this.Properties.TryGetValue("values", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "values",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string>>(element)
                ?? throw new System::ArgumentNullException("values");
        }
        set { this.Properties["values"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    TransformPriceFilter(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TransformPriceFilter FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
