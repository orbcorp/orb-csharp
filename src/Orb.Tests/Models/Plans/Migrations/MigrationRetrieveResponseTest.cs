using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MigrationRetrieveResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = Status.NotStarted,
        };

        string expectedID = "id";
        EffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, Status> expectedStatus = Status.NotStarted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEffectiveTime, model.EffectiveTime);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MigrationRetrieveResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = Status.NotStarted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MigrationRetrieveResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = Status.NotStarted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        EffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, Status> expectedStatus = Status.NotStarted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEffectiveTime, deserialized.EffectiveTime);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MigrationRetrieveResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = Status.NotStarted,
        };

        model.Validate();
    }
}

public class EffectiveTimeTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        EffectiveTime value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        EffectiveTime value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void UnionMember2ValidationWorks()
    {
        EffectiveTime value = UnionMember2.EndOfTerm;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        EffectiveTime value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        EffectiveTime value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember2SerializationRoundtripWorks()
    {
        EffectiveTime value = UnionMember2.EndOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember2Test : TestBase
{
    [Theory]
    [InlineData(UnionMember2.EndOfTerm)]
    public void Validation_Works(UnionMember2 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember2.EndOfTerm)]
    public void SerializationRoundtrip_Works(UnionMember2 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.Canceled)]
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
    [InlineData(Status.NotStarted)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.Completed)]
    [InlineData(Status.ActionNeeded)]
    [InlineData(Status.Canceled)]
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
