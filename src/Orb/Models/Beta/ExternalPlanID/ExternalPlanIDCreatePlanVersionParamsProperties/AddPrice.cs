using AddPriceProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AddPrice>))]
public sealed record class AddPrice : Orb::ModelBase, Orb::IFromRaw<AddPrice>
{
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
    /// The phase to add this price to.
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
    public AddPriceProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddPriceProperties::Price?>(element);
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public AddPrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AddPrice(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddPrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
