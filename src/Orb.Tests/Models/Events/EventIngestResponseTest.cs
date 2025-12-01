using System.Collections.Generic;
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
}
