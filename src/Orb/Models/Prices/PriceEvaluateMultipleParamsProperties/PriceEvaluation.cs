using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using PriceEvaluationProperties = Orb.Models.Prices.PriceEvaluateMultipleParamsProperties.PriceEvaluationProperties;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.PriceEvaluateMultipleParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PriceEvaluation>))]
public sealed record class PriceEvaluation : Orb::ModelBase, Orb::IFromRaw<PriceEvaluation>
{
    /// <summary>
    /// The external ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["filter"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public Generic::List<string>? GroupingKeys
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_keys", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set { this.Properties["grouping_keys"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An inline price definition to evaluate, allowing you to test price configurations
    /// before adding them to Orb.
    /// </summary>
    public PriceEvaluationProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<PriceEvaluationProperties::Price?>(element);
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["price_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ExternalPriceID;
        _ = this.Filter;
        foreach (var item in this.GroupingKeys ?? [])
        {
            _ = item;
        }
        this.Price?.Validate();
        _ = this.PriceID;
    }

    public PriceEvaluation() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PriceEvaluation(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluation FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
