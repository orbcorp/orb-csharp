using System;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.Migrations;

namespace Orb.Tests.Models.Plans.Migrations;

public class MigrationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MigrationListResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationListResponseStatus.NotStarted,
        };

        string expectedID = "id";
        MigrationListResponseEffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, MigrationListResponseStatus> expectedStatus =
            MigrationListResponseStatus.NotStarted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEffectiveTime, model.EffectiveTime);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MigrationListResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationListResponseStatus.NotStarted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MigrationListResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationListResponseStatus.NotStarted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        MigrationListResponseEffectiveTime expectedEffectiveTime = "2019-12-27";
        string expectedPlanID = "plan_id";
        ApiEnum<string, MigrationListResponseStatus> expectedStatus =
            MigrationListResponseStatus.NotStarted;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEffectiveTime, deserialized.EffectiveTime);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MigrationListResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationListResponseStatus.NotStarted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MigrationListResponse
        {
            ID = "id",
            EffectiveTime = "2019-12-27",
            PlanID = "plan_id",
            Status = MigrationListResponseStatus.NotStarted,
        };

        MigrationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MigrationListResponseEffectiveTimeTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MigrationListResponseEffectiveTime value = "2019-12-27";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        MigrationListResponseEffectiveTime value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void MigrationListResponseEffectiveTimeUnionMember2ValidationWorks()
    {
        MigrationListResponseEffectiveTime value =
            MigrationListResponseEffectiveTimeUnionMember2.EndOfTerm;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MigrationListResponseEffectiveTime value = "2019-12-27";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        MigrationListResponseEffectiveTime value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MigrationListResponseEffectiveTimeUnionMember2SerializationRoundtripWorks()
    {
        MigrationListResponseEffectiveTime value =
            MigrationListResponseEffectiveTimeUnionMember2.EndOfTerm;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MigrationListResponseEffectiveTime>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MigrationListResponseEffectiveTimeUnionMember2Test : TestBase
{
    [Theory]
    [InlineData(MigrationListResponseEffectiveTimeUnionMember2.EndOfTerm)]
    public void Validation_Works(MigrationListResponseEffectiveTimeUnionMember2 rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MigrationListResponseEffectiveTimeUnionMember2.EndOfTerm)]
    public void SerializationRoundtrip_Works(
        MigrationListResponseEffectiveTimeUnionMember2 rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MigrationListResponseEffectiveTimeUnionMember2>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MigrationListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(MigrationListResponseStatus.NotStarted)]
    [InlineData(MigrationListResponseStatus.InProgress)]
    [InlineData(MigrationListResponseStatus.Completed)]
    [InlineData(MigrationListResponseStatus.ActionNeeded)]
    [InlineData(MigrationListResponseStatus.Canceled)]
    public void Validation_Works(MigrationListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MigrationListResponseStatus.NotStarted)]
    [InlineData(MigrationListResponseStatus.InProgress)]
    [InlineData(MigrationListResponseStatus.Completed)]
    [InlineData(MigrationListResponseStatus.ActionNeeded)]
    [InlineData(MigrationListResponseStatus.Canceled)]
    public void SerializationRoundtrip_Works(MigrationListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MigrationListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MigrationListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
