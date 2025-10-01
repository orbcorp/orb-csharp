using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Models = Orb.Models;
using PriceProperties = Orb.Models.Plans.PlanCreateParamsProperties.PriceProperties;

namespace Orb.Models.Plans.PlanCreateParamsProperties;

[JsonConverter(typeof(ModelConverter<Price>))]
public sealed record class Price : ModelBase, IFromRaw<Price>
{
    /// <summary>
    /// The allocation price to add to the plan.
    /// </summary>
    public Models::NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Models::NewAllocationPrice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["allocation_price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["plan_phase_order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// New plan price request body params.
    /// </summary>
    public PriceProperties::Price? Price1
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PriceProperties::Price?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AllocationPrice?.Validate();
        _ = this.PlanPhaseOrder;
        this.Price1?.Validate();
    }

    public Price() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Price(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Price FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
