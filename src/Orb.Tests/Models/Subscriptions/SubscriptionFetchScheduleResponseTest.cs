using System;
using System.Text.Json;
using Orb.Models.Subscriptions;

namespace Orb.Tests.Models.Subscriptions;

public class SubscriptionFetchScheduleResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionFetchScheduleResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Plan = new()
            {
                ID = "m2t5akQeh2obwxeU",
                ExternalPlanID = "m2t5akQeh2obwxeU",
                Name = "Example plan",
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Plan expectedPlan = new()
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedPlan, model.Plan);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionFetchScheduleResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Plan = new()
            {
                ID = "m2t5akQeh2obwxeU",
                ExternalPlanID = "m2t5akQeh2obwxeU",
                Name = "Example plan",
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionFetchScheduleResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionFetchScheduleResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Plan = new()
            {
                ID = "m2t5akQeh2obwxeU",
                ExternalPlanID = "m2t5akQeh2obwxeU",
                Name = "Example plan",
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionFetchScheduleResponse>(element);
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Plan expectedPlan = new()
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedPlan, deserialized.Plan);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionFetchScheduleResponse
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Plan = new()
            {
                ID = "m2t5akQeh2obwxeU",
                ExternalPlanID = "m2t5akQeh2obwxeU",
                Name = "Example plan",
            },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class PlanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalPlanID, model.ExternalPlanID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Plan>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Plan>(element);
        Assert.NotNull(deserialized);

        string expectedID = "m2t5akQeh2obwxeU";
        string expectedExternalPlanID = "m2t5akQeh2obwxeU";
        string expectedName = "Example plan";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalPlanID, deserialized.ExternalPlanID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plan
        {
            ID = "m2t5akQeh2obwxeU",
            ExternalPlanID = "m2t5akQeh2obwxeU",
            Name = "Example plan",
        };

        model.Validate();
    }
}
