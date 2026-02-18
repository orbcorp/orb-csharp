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
            ParameterDefinitions =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
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
        List<Dictionary<string, JsonElement>> expectedParameterDefinitions =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

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
        Assert.NotNull(model.ParameterDefinitions);
        Assert.Equal(expectedParameterDefinitions.Count, model.ParameterDefinitions.Count);
        for (int i = 0; i < expectedParameterDefinitions.Count; i++)
        {
            Assert.Equal(
                expectedParameterDefinitions[i].Count,
                model.ParameterDefinitions[i].Count
            );
            foreach (var item in expectedParameterDefinitions[i])
            {
                Assert.True(model.ParameterDefinitions[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.ParameterDefinitions[i][item.Key]));
            }
        }
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
            ParameterDefinitions =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(
            json,
            ModelBase.SerializerOptions
        );

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
            ParameterDefinitions =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableMetric>(
            element,
            ModelBase.SerializerOptions
        );
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
        List<Dictionary<string, JsonElement>> expectedParameterDefinitions =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

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
        Assert.NotNull(deserialized.ParameterDefinitions);
        Assert.Equal(expectedParameterDefinitions.Count, deserialized.ParameterDefinitions.Count);
        for (int i = 0; i < expectedParameterDefinitions.Count; i++)
        {
            Assert.Equal(
                expectedParameterDefinitions[i].Count,
                deserialized.ParameterDefinitions[i].Count
            );
            foreach (var item in expectedParameterDefinitions[i])
            {
                Assert.True(
                    deserialized.ParameterDefinitions[i].TryGetValue(item.Key, out var value)
                );

                Assert.True(
                    JsonElement.DeepEquals(value, deserialized.ParameterDefinitions[i][item.Key])
                );
            }
        }
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
            ParameterDefinitions =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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

        Assert.Null(model.ParameterDefinitions);
        Assert.False(model.RawData.ContainsKey("parameter_definitions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            ParameterDefinitions = null,
        };

        Assert.Null(model.ParameterDefinitions);
        Assert.True(model.RawData.ContainsKey("parameter_definitions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            ParameterDefinitions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
            ParameterDefinitions =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        BillableMetric copied = new(model);

        Assert.Equal(model, copied);
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
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
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
