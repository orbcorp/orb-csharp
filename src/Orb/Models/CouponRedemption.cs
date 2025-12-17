using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<CouponRedemption, CouponRedemptionFromRaw>))]
public sealed record class CouponRedemption : JsonModel
{
    public required string CouponID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "coupon_id"); }
        init { JsonModel.Set(this._rawData, "coupon_id", value); }
    }

    public required DateTimeOffset? EndDate
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    public required DateTimeOffset StartDate
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CouponID;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public CouponRedemption() { }

    public CouponRedemption(CouponRedemption couponRedemption)
        : base(couponRedemption) { }

    public CouponRedemption(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRedemption(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponRedemptionFromRaw.FromRawUnchecked"/>
    public static CouponRedemption FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponRedemptionFromRaw : IFromRawJson<CouponRedemption>
{
    /// <inheritdoc/>
    public CouponRedemption FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CouponRedemption.FromRawUnchecked(rawData);
}
