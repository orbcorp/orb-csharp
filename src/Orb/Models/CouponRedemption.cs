using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<CouponRedemption>))]
public sealed record class CouponRedemption : ModelBase, IFromRaw<CouponRedemption>
{
    public required string CouponID
    {
        get
        {
            if (!this.Properties.TryGetValue("coupon_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "coupon_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("coupon_id");
        }
        set { this.Properties["coupon_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
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
