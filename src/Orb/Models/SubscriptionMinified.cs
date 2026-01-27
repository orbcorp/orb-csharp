using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<SubscriptionMinified, SubscriptionMinifiedFromRaw>))]
public sealed record class SubscriptionMinified : JsonModel
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

    public SubscriptionMinified() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionMinified(SubscriptionMinified subscriptionMinified)
        : base(subscriptionMinified) { }
#pragma warning restore CS8618

    public SubscriptionMinified(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionMinified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionMinifiedFromRaw.FromRawUnchecked"/>
    public static SubscriptionMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionMinified(string id)
        : this()
    {
        this.ID = id;
    }
}

class SubscriptionMinifiedFromRaw : IFromRawJson<SubscriptionMinified>
{
    /// <inheritdoc/>
    public SubscriptionMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionMinified.FromRawUnchecked(rawData);
}
