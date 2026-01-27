using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MigrationCancelResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationCancelResponseStatus.NotStarted,
        };

        string expectedID = "id";
        MigrationCancelResponseEffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, MigrationCancelResponseStatus> expectedStatus =
            MigrationCancelResponseStatus.NotStarted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEffectiveTime, model.EffectiveTime);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MigrationCancelResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationCancelResponseStatus.NotStarted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MigrationCancelResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationCancelResponseStatus.NotStarted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        MigrationCancelResponseEffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, MigrationCancelResponseStatus> expectedStatus =
            MigrationCancelResponseStatus.NotStarted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEffectiveTime, deserialized.EffectiveTime);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MigrationCancelResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationCancelResponseStatus.NotStarted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MigrationCancelResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationCancelResponseStatus.NotStarted,
        };

        MigrationCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MigrationCancelResponseEffectiveTimeTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MigrationCancelResponseEffectiveTime value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        MigrationCancelResponseEffectiveTime value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void MigrationCancelResponseEffectiveTimeUnionMember2ValidationWorks()
    {
        MigrationCancelResponseEffectiveTime value =
            MigrationCancelResponseEffectiveTimeUnionMember2.EndOfTerm;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MigrationCancelResponseEffectiveTime value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationCancelResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        MigrationCancelResponseEffectiveTime value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationCancelResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MigrationCancelResponseEffectiveTimeUnionMember2SerializationRoundtripWorks()
    {
        MigrationCancelResponseEffectiveTime value =
            MigrationCancelResponseEffectiveTimeUnionMember2.EndOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationCancelResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MigrationCancelResponseEffectiveTimeUnionMember2Test : TestBase
{
    [Theory]
    [InlineData(MigrationCancelResponseEffectiveTimeUnionMember2.EndOfTerm)]
    public void Validation_Works(MigrationCancelResponseEffectiveTimeUnionMember2 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MigrationCancelResponseEffectiveTimeUnionMember2.EndOfTerm)]
    public void SerializationRoundtrip_Works(
        MigrationCancelResponseEffectiveTimeUnionMember2 rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseEffectiveTimeUnionMember2>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MigrationCancelResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(MigrationCancelResponseStatus.NotStarted)]
    [InlineData(MigrationCancelResponseStatus.InProgress)]
    [InlineData(MigrationCancelResponseStatus.Completed)]
    [InlineData(MigrationCancelResponseStatus.ActionNeeded)]
    [InlineData(MigrationCancelResponseStatus.Canceled)]
    public void Validation_Works(MigrationCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationCancelResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MigrationCancelResponseStatus.NotStarted)]
    [InlineData(MigrationCancelResponseStatus.InProgress)]
    [InlineData(MigrationCancelResponseStatus.Completed)]
    [InlineData(MigrationCancelResponseStatus.ActionNeeded)]
    [InlineData(MigrationCancelResponseStatus.Canceled)]
    public void SerializationRoundtrip_Works(MigrationCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationCancelResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationCancelResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
