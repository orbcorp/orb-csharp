using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Licenses.Usage;

/// <summary>
/// Returns usage and remaining credits for a specific license over a date range.
///
/// <para>Date range defaults to the current billing period if not specified.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageGetUsageParams : ParamsBase
{
    public string? LicenseID { get; init; }

    /// <summary>
    /// Pagination cursor from a previous request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// End date for the usage period (YYYY-MM-DD). Defaults to end of current billing period.
    /// </summary>
    public string? EndDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("end_date");
        }
        init { this._rawQueryData.Set("end_date", value); }
    }

    /// <summary>
    /// How to group the results. Valid values: 'license', 'day'. Can be combined
    /// (e.g., 'license,day').
    /// </summary>
    public string? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("group_by");
        }
        init { this._rawQueryData.Set("group_by", value); }
    }

    /// <summary>
    /// Maximum number of rows in the response data (default 20, max 100).
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Start date for the usage period (YYYY-MM-DD). Defaults to start of current
    /// billing period.
    /// </summary>
    public string? StartDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("start_date");
        }
        init { this._rawQueryData.Set("start_date", value); }
    }

    public UsageGetUsageParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageGetUsageParams(UsageGetUsageParams usageGetUsageParams)
        : base(usageGetUsageParams)
    {
        this.LicenseID = usageGetUsageParams.LicenseID;
    }
#pragma warning restore CS8618

    public UsageGetUsageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetUsageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string licenseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.LicenseID = licenseID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UsageGetUsageParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string licenseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            licenseID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["LicenseID"] = JsonSerializer.SerializeToElement(this.LicenseID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UsageGetUsageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.LicenseID?.Equals(other.LicenseID) ?? other.LicenseID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/licenses/{0}/usage", this.LicenseID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
