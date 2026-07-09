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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("coupon_id");
        }
        init { this._rawData.Set("coupon_id", value); }
    }

    public required DateTimeOffset? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    public required DateTimeOffset StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CouponID;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public CouponRedemption() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CouponRedemption(CouponRedemption couponRedemption)
        : base(couponRedemption) { }
#pragma warning restore CS8618

    public CouponRedemption(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRedemption(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
