using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<SubscriptionTrialInfo, SubscriptionTrialInfoFromRaw>))]
public sealed record class SubscriptionTrialInfo : JsonModel
{
    public required DateTimeOffset? EndDate
    {
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("end_date"); }
        init { this._rawData.Set("end_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndDate;
    }

    public SubscriptionTrialInfo() { }

    public SubscriptionTrialInfo(SubscriptionTrialInfo subscriptionTrialInfo)
        : base(subscriptionTrialInfo) { }

    public SubscriptionTrialInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTrialInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionTrialInfoFromRaw.FromRawUnchecked"/>
    public static SubscriptionTrialInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscriptionTrialInfo(DateTimeOffset? endDate)
        : this()
    {
        this.EndDate = endDate;
    }
}

class SubscriptionTrialInfoFromRaw : IFromRawJson<SubscriptionTrialInfo>
{
    /// <inheritdoc/>
    public SubscriptionTrialInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionTrialInfo.FromRawUnchecked(rawData);
}
