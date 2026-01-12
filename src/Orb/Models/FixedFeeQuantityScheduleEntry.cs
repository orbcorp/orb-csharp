using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<FixedFeeQuantityScheduleEntry, FixedFeeQuantityScheduleEntryFromRaw>)
)]
public sealed record class FixedFeeQuantityScheduleEntry : JsonModel
{
    public required DateTimeOffset? EndDate
    {
        get { return this._rawData.GetNullableStruct<DateTimeOffset>("end_date"); }
        init { this._rawData.Set("end_date", value); }
    }

    public required string PriceID
    {
        get { return this._rawData.GetNotNullClass<string>("price_id"); }
        init { this._rawData.Set("price_id", value); }
    }

    public required double Quantity
    {
        get { return this._rawData.GetNotNullStruct<double>("quantity"); }
        init { this._rawData.Set("quantity", value); }
    }

    public required DateTimeOffset StartDate
    {
        get { return this._rawData.GetNotNullStruct<DateTimeOffset>("start_date"); }
        init { this._rawData.Set("start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndDate;
        _ = this.PriceID;
        _ = this.Quantity;
        _ = this.StartDate;
    }

    public FixedFeeQuantityScheduleEntry() { }

    public FixedFeeQuantityScheduleEntry(
        FixedFeeQuantityScheduleEntry fixedFeeQuantityScheduleEntry
    )
        : base(fixedFeeQuantityScheduleEntry) { }

    public FixedFeeQuantityScheduleEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityScheduleEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FixedFeeQuantityScheduleEntryFromRaw.FromRawUnchecked"/>
    public static FixedFeeQuantityScheduleEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FixedFeeQuantityScheduleEntryFromRaw : IFromRawJson<FixedFeeQuantityScheduleEntry>
{
    /// <inheritdoc/>
    public FixedFeeQuantityScheduleEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityScheduleEntry.FromRawUnchecked(rawData);
}
