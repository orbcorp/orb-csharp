using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<FixedFeeQuantityScheduleEntry, FixedFeeQuantityScheduleEntryFromRaw>)
)]
public sealed record class FixedFeeQuantityScheduleEntry : ModelBase
{
    public required DateTimeOffset? EndDate
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    public required string PriceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "price_id"); }
        init { ModelBase.Set(this._rawData, "price_id", value); }
    }

    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public required DateTimeOffset StartDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityScheduleEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class FixedFeeQuantityScheduleEntryFromRaw : IFromRaw<FixedFeeQuantityScheduleEntry>
{
    /// <inheritdoc/>
    public FixedFeeQuantityScheduleEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FixedFeeQuantityScheduleEntry.FromRawUnchecked(rawData);
}
