using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PriceEvaluationProperties = Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties.PriceEvaluationProperties;

namespace Orb.Models.Prices.PriceEvaluatePreviewEventsParamsProperties;

[JsonConverter(typeof(ModelConverter<PriceEvaluation>))]
public sealed record class PriceEvaluation : ModelBase, IFromRaw<PriceEvaluation>
{
    /// <summary>
    /// The external ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A boolean [computed property](/extensibility/advanced-metrics#computed-properties)
    /// used to filter the underlying billable metric
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["filter"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Properties (or [computed properties](/extensibility/advanced-metrics#computed-properties))
    /// used to group the underlying billable metric
    /// </summary>
    public List<string>? GroupingKeys
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping_keys", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element);
        }
        set { this.Properties["grouping_keys"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An inline price definition to evaluate, allowing you to test price configurations
    /// before adding them to Orb.
    /// </summary>
    public PriceEvaluationProperties::Price1? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceEvaluationProperties::Price1?>(element);
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of a price to evaluate that exists in your Orb account.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["price_id"] = JsonSerializer.SerializeToElement(value); }
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
    [SetsRequiredMembers]
    PriceEvaluation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
