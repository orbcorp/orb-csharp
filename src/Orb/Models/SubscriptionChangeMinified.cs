using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<SubscriptionChangeMinified, SubscriptionChangeMinifiedFromRaw>)
)]
public sealed record class SubscriptionChangeMinified : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public SubscriptionChangeMinified() { }

    public SubscriptionChangeMinified(SubscriptionChangeMinified subscriptionChangeMinified)
        : base(subscriptionChangeMinified) { }

    public SubscriptionChangeMinified(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeMinified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SubscriptionChangeMinifiedFromRaw : IFromRaw<SubscriptionChangeMinified>
{
    /// <inheritdoc/>
    public SubscriptionChangeMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionChangeMinified.FromRawUnchecked(rawData);
}
