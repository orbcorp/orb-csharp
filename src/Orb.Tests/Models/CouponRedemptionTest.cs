using System;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class CouponRedemptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponRedemption
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCouponID = "coupon_id";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCouponID, model.CouponID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponRedemption
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRedemption>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponRedemption
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRedemption>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCouponID = "coupon_id";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCouponID, deserialized.CouponID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponRedemption
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponRedemption
        {
            CouponID = "coupon_id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CouponRedemption copied = new(model);

        Assert.Equal(model, copied);
    }
}
