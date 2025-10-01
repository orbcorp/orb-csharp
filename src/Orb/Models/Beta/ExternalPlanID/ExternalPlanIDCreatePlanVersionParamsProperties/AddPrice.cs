using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using AddPriceProperties = Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties.AddPriceProperties;

namespace Orb.Models.Beta.ExternalPlanID.ExternalPlanIDCreatePlanVersionParamsProperties;

[JsonConverter(typeof(ModelConverter<AddPrice>))]
public sealed record class AddPrice : ModelBase, IFromRaw<AddPrice>
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

            return JsonSerializer.Deserialize<NewAllocationPrice?>(
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
    public AddPriceProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AddPriceProperties::Price?>(
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
        this.Price?.Validate();
    }

    public AddPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
