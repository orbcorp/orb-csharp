using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ItemExternalConnection> expectedExternalConnections =
        [
            new()
            {
                ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                ExternalEntityID = "external_entity_id",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExternalConnections.Count, model.ExternalConnections.Count);
        for (int i = 0; i < expectedExternalConnections.Count; i++)
        {
            Assert.Equal(expectedExternalConnections[i], model.ExternalConnections[i]);
        }
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ItemExternalConnection> expectedExternalConnections =
        [
            new()
            {
                ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                ExternalEntityID = "external_entity_id",
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExternalConnections.Count, deserialized.ExternalConnections.Count);
        for (int i = 0; i < expectedExternalConnections.Count; i++)
        {
            Assert.Equal(expectedExternalConnections[i], deserialized.ExternalConnections[i]);
        }
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        Assert.Null(model.ArchivedAt);
        Assert.False(model.RawData.ContainsKey("archived_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",

            ArchivedAt = null,
        };

        Assert.Null(model.ArchivedAt);
        Assert.True(model.RawData.ContainsKey("archived_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalConnections =
            [
                new()
                {
                    ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
                    ExternalEntityID = "external_entity_id",
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",

            ArchivedAt = null,
        };

        model.Validate();
    }
}

public class ItemExternalConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemExternalConnection
        {
            ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        ApiEnum<
            string,
            ItemExternalConnectionExternalConnectionName
        > expectedExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, model.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, model.ExternalEntityID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ItemExternalConnection
        {
            ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemExternalConnection>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemExternalConnection
        {
            ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ItemExternalConnection>(json);
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ItemExternalConnectionExternalConnectionName
        > expectedExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, deserialized.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, deserialized.ExternalEntityID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ItemExternalConnection
        {
            ExternalConnectionName = ItemExternalConnectionExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        model.Validate();
    }
}
