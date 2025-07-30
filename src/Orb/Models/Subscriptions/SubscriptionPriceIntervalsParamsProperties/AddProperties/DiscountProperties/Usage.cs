using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties.DiscountProperties;

[JsonConverter(typeof(ModelConverter<Usage>))]
public sealed record class Usage : ModelBase, IFromRaw<Usage>
{
    public JsonElement DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("discount_type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element);
        }
        set { this.Properties["discount_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for.
    /// </summary>
    public required double UsageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_discount", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "usage_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["usage_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.UsageDiscount;
    }

    public Usage()
    {
        this.DiscountType = JsonSerializer.Deserialize<JsonElement>("\"usage\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
