using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Coupons;

[JsonConverter(typeof(JsonModelConverter<CouponListPageResponse, CouponListPageResponseFromRaw>))]
public sealed record class CouponListPageResponse : JsonModel
{
    public required IReadOnlyList<Coupon> Data
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Coupon>>("data"); }
        init
        {
            this._rawData.Set<ImmutableArray<Coupon>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get { return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata"); }
        init { this._rawData.Set("pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public CouponListPageResponse() { }

    public CouponListPageResponse(CouponListPageResponse couponListPageResponse)
        : base(couponListPageResponse) { }

    public CouponListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CouponListPageResponseFromRaw.FromRawUnchecked"/>
    public static CouponListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CouponListPageResponseFromRaw : IFromRawJson<CouponListPageResponse>
{
    /// <inheritdoc/>
    public CouponListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CouponListPageResponse.FromRawUnchecked(rawData);
}
