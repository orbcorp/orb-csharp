using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PriceProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<Price1>))]
public sealed record class Price1 : ModelBase, IFromRaw<Price1>
{
    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewAllocationPrice?>(element);
        }
        set { this.Properties["allocation_price"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The phase to add this price to.
    /// </summary>
    public long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price to add to the plan
    /// </summary>
    public PriceProperties::Price2? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceProperties::Price2?>(element);
        }
        set { this.Properties["price"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price?.Validate();
    }

    public Price1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Price1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Price1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
