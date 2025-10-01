using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CouponRedemption>))]
public sealed record class CouponRedemption : ModelBase, IFromRaw<CouponRedemption>
{
    public required string CouponID
    {
        get
        {
            if (!this.Properties.TryGetValue("coupon_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'coupon_id' cannot be null",
                    new ArgumentOutOfRangeException("coupon_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'coupon_id' cannot be null",
                    new ArgumentNullException("coupon_id")
                );
        }
        set
        {
            this.Properties["coupon_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CouponID;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public CouponRedemption() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CouponRedemption(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CouponRedemption FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
