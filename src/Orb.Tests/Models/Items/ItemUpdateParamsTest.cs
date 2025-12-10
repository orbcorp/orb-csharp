using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ExternalConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        ApiEnum<string, ExternalConnectionName> expectedExternalConnectionName =
            ExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, model.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, model.ExternalEntityID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalConnection>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalConnection>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ExternalConnectionName> expectedExternalConnectionName =
            ExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, deserialized.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, deserialized.ExternalEntityID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        model.Validate();
    }
}

public class ExternalConnectionNameTest : TestBase
{
    [Theory]
    [InlineData(ExternalConnectionName.Stripe)]
    [InlineData(ExternalConnectionName.Quickbooks)]
    [InlineData(ExternalConnectionName.BillCom)]
    [InlineData(ExternalConnectionName.Netsuite)]
    [InlineData(ExternalConnectionName.Taxjar)]
    [InlineData(ExternalConnectionName.Avalara)]
    [InlineData(ExternalConnectionName.Anrok)]
    [InlineData(ExternalConnectionName.Numeral)]
    public void Validation_Works(ExternalConnectionName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalConnectionName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalConnectionName.Stripe)]
    [InlineData(ExternalConnectionName.Quickbooks)]
    [InlineData(ExternalConnectionName.BillCom)]
    [InlineData(ExternalConnectionName.Netsuite)]
    [InlineData(ExternalConnectionName.Taxjar)]
    [InlineData(ExternalConnectionName.Avalara)]
    [InlineData(ExternalConnectionName.Anrok)]
    [InlineData(ExternalConnectionName.Numeral)]
    public void SerializationRoundtrip_Works(ExternalConnectionName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalConnectionName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalConnectionName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
