using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using ReplacePriceProperties = Orb.Models.Beta.BetaCreatePlanVersionParamsProperties.ReplacePriceProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Beta.BetaCreatePlanVersionParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ReplacePrice>))]
public sealed record class ReplacePrice : Orb::ModelBase, Orb::IFromRaw<ReplacePrice>
{
    /// <summary>
    /// The id of the price on the plan to replace in the plan.
    /// </summary>
    public required string ReplacesPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "replaces_price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("replaces_price_id");
        }
        set
        {
            this.Properties["replaces_price_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public Models::NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::NewAllocationPrice?>(element);
        }
        set
        {
            this.Properties["allocation_price"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The phase to replace this price from.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["plan_phase_order"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The price to add to the plan
    /// </summary>
    public ReplacePriceProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<ReplacePriceProperties::Price?>(element);
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ReplacesPriceID;
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public ReplacePrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ReplacePrice(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ReplacePrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
