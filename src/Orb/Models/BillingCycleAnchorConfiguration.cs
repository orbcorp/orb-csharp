using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        BillingCycleAnchorConfiguration,
        BillingCycleAnchorConfigurationFromRaw
    >)
)]
public sealed record class BillingCycleAnchorConfiguration : JsonModel
{
    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the
    /// month is the billing cycle day (e.g. billing_cycle_day=31 for April means
    /// the billing period begins on the 30th.
    /// </summary>
    public required long Day
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("day");
        }
        init { this._rawData.Set("day", value); }
    }

    /// <summary>
    /// The month on which the billing cycle is anchored (e.g. a quarterly price anchored
    /// in February would have cycles starting February, May, August, and November).
    /// </summary>
    public long? Month
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("month");
        }
        init { this._rawData.Set("month", value); }
    }

    /// <summary>
    /// The year on which the billing cycle is anchored (e.g. a 2 year billing cycle
    /// anchored on 2021 would have cycles starting on 2021, 2023, 2025, etc.).
    /// </summary>
    public long? Year
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("year");
        }
        init { this._rawData.Set("year", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Day;
        _ = this.Month;
        _ = this.Year;
    }

    public BillingCycleAnchorConfiguration() { }

    public BillingCycleAnchorConfiguration(
        BillingCycleAnchorConfiguration billingCycleAnchorConfiguration
    )
        : base(billingCycleAnchorConfiguration) { }

    public BillingCycleAnchorConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingCycleAnchorConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingCycleAnchorConfigurationFromRaw.FromRawUnchecked"/>
    public static BillingCycleAnchorConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillingCycleAnchorConfiguration(long day)
        : this()
    {
        this.Day = day;
    }
}

class BillingCycleAnchorConfigurationFromRaw : IFromRawJson<BillingCycleAnchorConfiguration>
{
    /// <inheritdoc/>
    public BillingCycleAnchorConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BillingCycleAnchorConfiguration.FromRawUnchecked(rawData);
}
