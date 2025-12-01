using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubscriptionTrialInfo, SubscriptionTrialInfoFromRaw>))]
public sealed record class SubscriptionTrialInfo : ModelBase
{
    public required DateTimeOffset? EndDate
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
    }

    public SubscriptionTrialInfo() { }

    public SubscriptionTrialInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTrialInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class SubscriptionTrialInfoFromRaw : IFromRaw<SubscriptionTrialInfo>
{
    public SubscriptionTrialInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionTrialInfo.FromRawUnchecked(rawData);
}
