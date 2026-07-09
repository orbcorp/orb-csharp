using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseRetrieveByExternalIDResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseRetrieveByExternalIDResponse
        {
            ID = "id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = LicenseRetrieveByExternalIDResponseStatus.Active,
            SubscriptionID = "subscription_id",
        };

        string expectedID = "id";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus> expectedStatus =
            LicenseRetrieveByExternalIDResponseStatus.Active;
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedExternalLicenseID, model.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, model.LicenseTypeID);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseRetrieveByExternalIDResponse
        {
            ID = "id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = LicenseRetrieveByExternalIDResponseStatus.Active,
            SubscriptionID = "subscription_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseRetrieveByExternalIDResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseRetrieveByExternalIDResponse
        {
            ID = "id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = LicenseRetrieveByExternalIDResponseStatus.Active,
            SubscriptionID = "subscription_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseRetrieveByExternalIDResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus> expectedStatus =
            LicenseRetrieveByExternalIDResponseStatus.Active;
        string expectedSubscriptionID = "subscription_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedExternalLicenseID, deserialized.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, deserialized.LicenseTypeID);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseRetrieveByExternalIDResponse
        {
            ID = "id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = LicenseRetrieveByExternalIDResponseStatus.Active,
            SubscriptionID = "subscription_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseRetrieveByExternalIDResponse
        {
            ID = "id",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = LicenseRetrieveByExternalIDResponseStatus.Active,
            SubscriptionID = "subscription_id",
        };

        LicenseRetrieveByExternalIDResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LicenseRetrieveByExternalIDResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(LicenseRetrieveByExternalIDResponseStatus.Active)]
    [InlineData(LicenseRetrieveByExternalIDResponseStatus.Inactive)]
    public void Validation_Works(LicenseRetrieveByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LicenseRetrieveByExternalIDResponseStatus.Active)]
    [InlineData(LicenseRetrieveByExternalIDResponseStatus.Inactive)]
    public void SerializationRoundtrip_Works(LicenseRetrieveByExternalIDResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LicenseRetrieveByExternalIDResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
