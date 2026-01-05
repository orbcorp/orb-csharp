using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ItemUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemUpdateParams
        {
            ItemID = "item_id",
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedItemID = "item_id";
        List<ExternalConnection> expectedExternalConnections =
        [
            new()
            {
                ExternalConnectionName = ExternalConnectionName.Stripe,
                ExternalEntityID = "external_entity_id",
            },
        ];
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedItemID, parameters.ItemID);
        Assert.NotNull(parameters.ExternalConnections);
        Assert.Equal(expectedExternalConnections.Count, parameters.ExternalConnections.Count);
        for (int i = 0; i < expectedExternalConnections.Count; i++)
        {
            Assert.Equal(expectedExternalConnections[i], parameters.ExternalConnections[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemUpdateParams { ItemID = "item_id" };

        Assert.Null(parameters.ExternalConnections);
        Assert.False(parameters.RawBodyData.ContainsKey("external_connections"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ItemUpdateParams
        {
            ItemID = "item_id",

            ExternalConnections = null,
            Metadata = null,
            Name = null,
        };

        Assert.Null(parameters.ExternalConnections);
        Assert.True(parameters.RawBodyData.ContainsKey("external_connections"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        ItemUpdateParams parameters = new() { ItemID = "item_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.withorb.com/v1/items/item_id"), url);
    }
}

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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalConnection>(element);
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

        Assert.NotNull(value);
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
