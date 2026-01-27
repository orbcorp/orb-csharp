using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionChangeMinified, SubscriptionChangeMinifiedFromRaw>)
)]
public sealed record class SubscriptionChangeMinified : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public SubscriptionChangeMinified() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionChangeMinified(SubscriptionChangeMinified subscriptionChangeMinified)
        : base(subscriptionChangeMinified) { }
#pragma warning restore CS8618

    public SubscriptionChangeMinified(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeMinified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionChangeMinifiedFromRaw.FromRawUnchecked"/>
    public static SubscriptionChangeMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionChangeMinified(string id)
        : this()
    {
        this.ID = id;
    }
}

class SubscriptionChangeMinifiedFromRaw : IFromRawJson<SubscriptionChangeMinified>
{
    /// <inheritdoc/>
    public SubscriptionChangeMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeMinified.FromRawUnchecked(rawData);
}
