using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<
        SubscriptionFetchScheduleResponse,
        SubscriptionFetchScheduleResponseFromRaw
    >)
)]
public sealed record class SubscriptionFetchScheduleResponse : JsonModel
{
    public required DateTimeOffset CreatedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required DateTimeOffset? EndDate
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    public required Plan? Plan
    {
        get { return JsonModel.GetNullableClass<Plan>(this.RawData, "plan"); }
        init { JsonModel.Set(this._rawData, "plan", value); }
    }

    public required DateTimeOffset StartDate
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EndDate;
        this.Plan?.Validate();
        _ = this.StartDate;
    }

    public SubscriptionFetchScheduleResponse() { }

    public SubscriptionFetchScheduleResponse(
        SubscriptionFetchScheduleResponse subscriptionFetchScheduleResponse
    )
        : base(subscriptionFetchScheduleResponse) { }

    public SubscriptionFetchScheduleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionFetchScheduleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFetchScheduleResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionFetchScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionFetchScheduleResponseFromRaw : IFromRawJson<SubscriptionFetchScheduleResponse>
{
    /// <inheritdoc/>
    public SubscriptionFetchScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionFetchScheduleResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : JsonModel
{
    public required string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_plan_id"); }
        init { JsonModel.Set(this._rawData, "external_plan_id", value); }
    }

    public required string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
    }

    public Plan() { }

    public Plan(Plan plan)
        : base(plan) { }

    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRawJson<Plan>
{
    /// <inheritdoc/>
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
}
