using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Licenses.Usage;

[JsonConverter(typeof(JsonModelConverter<UsageGetUsageResponse, UsageGetUsageResponseFromRaw>))]
public sealed record class UsageGetUsageResponse : JsonModel
{
    public required IReadOnlyList<UsageGetUsageResponseData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UsageGetUsageResponseData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageGetUsageResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public UsageGetUsageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetUsageResponse(UsageGetUsageResponse usageGetUsageResponse)
        : base(usageGetUsageResponse) { }
#pragma warning restore CS8618

    public UsageGetUsageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetUsageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageGetUsageResponseFromRaw.FromRawUnchecked"/>
    public static UsageGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageGetUsageResponseFromRaw : IFromRawJson<UsageGetUsageResponse>
{
    /// <inheritdoc/>
    public UsageGetUsageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageGetUsageResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The LicenseUsage resource represents usage and remaining credits for a license
/// over a date range.
///
/// <para>When grouped by 'day' only, license_id and external_license_id will be
/// null as the data is aggregated across all licenses.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageGetUsageResponseData, UsageGetUsageResponseDataFromRaw>)
)]
public sealed record class UsageGetUsageResponseData : JsonModel
{
    /// <summary>
    /// The total credits allocated to this license for the period.
    /// </summary>
    public required double AllocatedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("allocated_credits");
        }
        init { this._rawData.Set("allocated_credits", value); }
    }

    /// <summary>
    /// The credits consumed by this license for the period.
    /// </summary>
    public required double ConsumedCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("consumed_credits");
        }
        init { this._rawData.Set("consumed_credits", value); }
    }

    /// <summary>
    /// The end date of the usage period.
    /// </summary>
    public required string EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// The unique identifier for the license type.
    /// </summary>
    public required string LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
    }

    /// <summary>
    /// The pricing unit for the credits (e.g., 'credits').
    /// </summary>
    public required string PricingUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pricing_unit");
        }
        init { this._rawData.Set("pricing_unit", value); }
    }

    /// <summary>
    /// The remaining credits available for this license (allocated - consumed).
    /// </summary>
    public required double RemainingCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("remaining_credits");
        }
        init { this._rawData.Set("remaining_credits", value); }
    }

    /// <summary>
    /// The start date of the usage period.
    /// </summary>
    public required string StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <summary>
    /// The unique identifier for the subscription.
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawData.Set("subscription_id", value); }
    }

    /// <summary>
    /// Credits consumed while the license was active (eligible for individual allocation deduction).
    /// </summary>
    public double? AllocationEligibleCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("allocation_eligible_credits");
        }
        init { this._rawData.Set("allocation_eligible_credits", value); }
    }

    /// <summary>
    /// The external identifier for the license. Null when grouped by day only.
    /// </summary>
    public string? ExternalLicenseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_license_id");
        }
        init { this._rawData.Set("external_license_id", value); }
    }

    /// <summary>
    /// The unique identifier for the license. Null when grouped by day only.
    /// </summary>
    public string? LicenseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_id");
        }
        init { this._rawData.Set("license_id", value); }
    }

    /// <summary>
    /// Credits consumed while the license was inactive (draws from shared pool, not
    /// individual allocation).
    /// </summary>
    public double? SharedPoolCredits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("shared_pool_credits");
        }
        init { this._rawData.Set("shared_pool_credits", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllocatedCredits;
        _ = this.ConsumedCredits;
        _ = this.EndDate;
        _ = this.LicenseTypeID;
        _ = this.PricingUnit;
        _ = this.RemainingCredits;
        _ = this.StartDate;
        _ = this.SubscriptionID;
        _ = this.AllocationEligibleCredits;
        _ = this.ExternalLicenseID;
        _ = this.LicenseID;
        _ = this.SharedPoolCredits;
    }

    public UsageGetUsageResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetUsageResponseData(UsageGetUsageResponseData usageGetUsageResponseData)
        : base(usageGetUsageResponseData) { }
#pragma warning restore CS8618

    public UsageGetUsageResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetUsageResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageGetUsageResponseDataFromRaw.FromRawUnchecked"/>
    public static UsageGetUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageGetUsageResponseDataFromRaw : IFromRawJson<UsageGetUsageResponseData>
{
    /// <inheritdoc/>
    public UsageGetUsageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageGetUsageResponseData.FromRawUnchecked(rawData);
}
