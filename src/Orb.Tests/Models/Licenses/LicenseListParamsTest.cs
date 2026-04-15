using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Licenses;

namespace Orb.Tests.Models.Licenses;

public class LicenseListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LicenseListParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            Limit = 1,
            Status = Status.Active,
        };

        string expectedSubscriptionID = "subscription_id";
        string expectedCursor = "cursor";
        string expectedExternalLicenseID = "external_license_id";
        string expectedLicenseTypeID = "license_type_id";
        long expectedLimit = 1;
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedSubscriptionID, parameters.SubscriptionID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedExternalLicenseID, parameters.ExternalLicenseID);
        Assert.Equal(expectedLicenseTypeID, parameters.LicenseTypeID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseListParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            Status = Status.Active,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new LicenseListParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            Status = Status.Active,

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new LicenseListParams { SubscriptionID = "subscription_id", Limit = 1 };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExternalLicenseID);
        Assert.False(parameters.RawQueryData.ContainsKey("external_license_id"));
        Assert.Null(parameters.LicenseTypeID);
        Assert.False(parameters.RawQueryData.ContainsKey("license_type_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new LicenseListParams
        {
            SubscriptionID = "subscription_id",
            Limit = 1,

            Cursor = null,
            ExternalLicenseID = null,
            LicenseTypeID = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.ExternalLicenseID);
        Assert.True(parameters.RawQueryData.ContainsKey("external_license_id"));
        Assert.Null(parameters.LicenseTypeID);
        Assert.True(parameters.RawQueryData.ContainsKey("license_type_id"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        LicenseListParams parameters = new()
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            Limit = 1,
            Status = Status.Active,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.withorb.com/v1/licenses?subscription_id=subscription_id&cursor=cursor&external_license_id=external_license_id&license_type_id=license_type_id&limit=1&status=active"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LicenseListParams
        {
            SubscriptionID = "subscription_id",
            Cursor = "cursor",
            ExternalLicenseID = "external_license_id",
            LicenseTypeID = "license_type_id",
            Limit = 1,
            Status = Status.Active,
        };

        LicenseListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
