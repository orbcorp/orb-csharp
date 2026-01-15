using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventIngestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
            Debug = new() { Duplicate = ["string"], Ingested = ["string"] },
        };

        List<ValidationFailed> expectedValidationFailed =
        [
            new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
        ];
        Debug expectedDebug = new() { Duplicate = ["string"], Ingested = ["string"] };

        Assert.Equal(expectedValidationFailed.Count, model.ValidationFailed.Count);
        for (int i = 0; i < expectedValidationFailed.Count; i++)
        {
            Assert.Equal(expectedValidationFailed[i], model.ValidationFailed[i]);
        }
        Assert.Equal(expectedDebug, model.Debug);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
            Debug = new() { Duplicate = ["string"], Ingested = ["string"] },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventIngestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
            Debug = new() { Duplicate = ["string"], Ingested = ["string"] },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventIngestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ValidationFailed> expectedValidationFailed =
        [
            new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
        ];
        Debug expectedDebug = new() { Duplicate = ["string"], Ingested = ["string"] };

        Assert.Equal(expectedValidationFailed.Count, deserialized.ValidationFailed.Count);
        for (int i = 0; i < expectedValidationFailed.Count; i++)
        {
            Assert.Equal(expectedValidationFailed[i], deserialized.ValidationFailed[i]);
        }
        Assert.Equal(expectedDebug, deserialized.Debug);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
            Debug = new() { Duplicate = ["string"], Ingested = ["string"] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
        };

        Assert.Null(model.Debug);
        Assert.False(model.RawData.ContainsKey("debug"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],

            Debug = null,
        };

        Assert.Null(model.Debug);
        Assert.True(model.RawData.ContainsKey("debug"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EventIngestResponse
        {
            ValidationFailed =
            [
                new() { IdempotencyKey = "idempotency_key", ValidationErrors = ["string"] },
            ],

            Debug = null,
        };

        model.Validate();
    }
}

public class ValidationFailedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValidationFailed
        {
            IdempotencyKey = "idempotency_key",
            ValidationErrors = ["string"],
        };

        string expectedIdempotencyKey = "idempotency_key";
        List<string> expectedValidationErrors = ["string"];

        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
        Assert.Equal(expectedValidationErrors.Count, model.ValidationErrors.Count);
        for (int i = 0; i < expectedValidationErrors.Count; i++)
        {
            Assert.Equal(expectedValidationErrors[i], model.ValidationErrors[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValidationFailed
        {
            IdempotencyKey = "idempotency_key",
            ValidationErrors = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationFailed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValidationFailed
        {
            IdempotencyKey = "idempotency_key",
            ValidationErrors = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationFailed>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIdempotencyKey = "idempotency_key";
        List<string> expectedValidationErrors = ["string"];

        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
        Assert.Equal(expectedValidationErrors.Count, deserialized.ValidationErrors.Count);
        for (int i = 0; i < expectedValidationErrors.Count; i++)
        {
            Assert.Equal(expectedValidationErrors[i], deserialized.ValidationErrors[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValidationFailed
        {
            IdempotencyKey = "idempotency_key",
            ValidationErrors = ["string"],
        };

        model.Validate();
    }
}

public class DebugTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Debug { Duplicate = ["string"], Ingested = ["string"] };

        List<string> expectedDuplicate = ["string"];
        List<string> expectedIngested = ["string"];

        Assert.Equal(expectedDuplicate.Count, model.Duplicate.Count);
        for (int i = 0; i < expectedDuplicate.Count; i++)
        {
            Assert.Equal(expectedDuplicate[i], model.Duplicate[i]);
        }
        Assert.Equal(expectedIngested.Count, model.Ingested.Count);
        for (int i = 0; i < expectedIngested.Count; i++)
        {
            Assert.Equal(expectedIngested[i], model.Ingested[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Debug { Duplicate = ["string"], Ingested = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debug>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Debug { Duplicate = ["string"], Ingested = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debug>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<string> expectedDuplicate = ["string"];
        List<string> expectedIngested = ["string"];

        Assert.Equal(expectedDuplicate.Count, deserialized.Duplicate.Count);
        for (int i = 0; i < expectedDuplicate.Count; i++)
        {
            Assert.Equal(expectedDuplicate[i], deserialized.Duplicate[i]);
        }
        Assert.Equal(expectedIngested.Count, deserialized.Ingested.Count);
        for (int i = 0; i < expectedIngested.Count; i++)
        {
            Assert.Equal(expectedIngested[i], deserialized.Ingested[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Debug { Duplicate = ["string"], Ingested = ["string"] };

        model.Validate();
    }
}
