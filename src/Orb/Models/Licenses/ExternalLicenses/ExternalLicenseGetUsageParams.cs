using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Licenses.ExternalLicenses;

/// <summary>
/// Returns usage and remaining credits for a license identified by its external
/// license ID.
///
/// <para>Date range defaults to the current billing period if not specified.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalLicenseGetUsageParams : ParamsBase
{
    public string? ExternalLicenseID { get; init; }

    /// <summary>
    /// The license type ID to filter licenses by.
    /// </summary>
    public required string LicenseTypeID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("license_type_id");
        }
        init { this._rawQueryData.Set("license_type_id", value); }
    }

    /// <summary>
    /// The subscription ID to get license usage for.
    /// </summary>
    public required string SubscriptionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("subscription_id");
        }
        init { this._rawQueryData.Set("subscription_id", value); }
    }

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
    public IReadOnlyList<string>? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("group_by");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "group_by",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public ExternalLicenseGetUsageParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalLicenseGetUsageParams(
        ExternalLicenseGetUsageParams externalLicenseGetUsageParams
    )
        : base(externalLicenseGetUsageParams)
    {
        this.ExternalLicenseID = externalLicenseGetUsageParams.ExternalLicenseID;
    }
#pragma warning restore CS8618

    public ExternalLicenseGetUsageParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalLicenseGetUsageParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ExternalLicenseGetUsageParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ExternalLicenseID"] = JsonSerializer.SerializeToElement(
                        this.ExternalLicenseID
                    ),
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

    public virtual bool Equals(ExternalLicenseGetUsageParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ExternalLicenseID?.Equals(other.ExternalLicenseID)
                ?? other.ExternalLicenseID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/licenses/external_licenses/{0}/usage", this.ExternalLicenseID)
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
