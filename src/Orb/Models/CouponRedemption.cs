using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CouponRedemption, CouponRedemptionFromRaw>))]
public sealed record class CouponRedemption : ModelBase
{
    public required string CouponID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "coupon_id"); }
        init { ModelBase.Set(this._rawData, "coupon_id", value); }
    }

    public required DateTimeOffset? EndDate
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    public required DateTimeOffset StartDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
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

class CouponRedemptionFromRaw : IFromRaw<CouponRedemption>
{
    /// <inheritdoc/>
    public CouponRedemption FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CouponRedemption.FromRawUnchecked(rawData);
}
