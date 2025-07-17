using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<RemovePrice>))]
public sealed record class RemovePrice : Orb::ModelBase, Orb::IFromRaw<RemovePrice>
{
    /// <summary>
    /// The external price id of the price to remove on the subscription.
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
    /// The id of the price to remove on the subscription.
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
        _ = this.PriceID;
    }

    public RemovePrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RemovePrice(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RemovePrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
