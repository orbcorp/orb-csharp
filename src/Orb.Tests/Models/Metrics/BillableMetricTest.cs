using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Items;
using Orb.Models.Metrics;

namespace Orb.Tests.Models.Metrics;

public class BillableMetricTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillableMetric
        {
            ID = "id",
            Description = "description",
            Item = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Status = Status.Active,
        };

        string expectedID = "id";
        string expectedDescription = "description";
        Item expectedItem = new()
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillableMetric
        {
            ID = "id",
            Description = "description",
            Item = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Status = Status.Active,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillableMetric
        {
            ID = "id",
            Description = "description",
            Item = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Status = Status.Active,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        Item expectedItem = new()
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedItem, deserialized.Item);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillableMetric
        {
            ID = "id",
            Description = "description",
            Item = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalConnections =
                [
                    new()
                    {
                        ExternalConnectionName =
                            ItemExternalConnectionExternalConnectionName.Stripe,
                        ExternalEntityID = "external_entity_id",
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Status = Status.Active,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Draft)]
    [InlineData(Status.Archived)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Draft)]
    [InlineData(Status.Archived)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
