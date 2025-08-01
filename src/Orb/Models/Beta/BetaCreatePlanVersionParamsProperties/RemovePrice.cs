using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties;

[JsonConverter(typeof(ModelConverter<RemovePrice>))]
public sealed record class RemovePrice : ModelBase, IFromRaw<RemovePrice>
{
    /// <summary>
    /// The id of the price to remove from the plan.
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("price_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price_id");
        }
        set { this.Properties["price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The phase to remove this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.PriceID;
        _ = this.PlanPhaseOrder;
    }

    public RemovePrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovePrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RemovePrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public RemovePrice(string priceID)
    {
        this.PriceID = priceID;
    }
}
