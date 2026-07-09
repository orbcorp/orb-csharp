using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Licenses;

/// <summary>
/// This endpoint is used to fetch a license given an external license identifier.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LicenseRetrieveByExternalIDParams : ParamsBase
{
    public string? ExternalLicenseID { get; init; }

    /// <summary>
    /// The ID of the license type to fetch the license for.
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
    /// The ID of the subscription to fetch the license for.
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

    public LicenseRetrieveByExternalIDParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseRetrieveByExternalIDParams(
        LicenseRetrieveByExternalIDParams licenseRetrieveByExternalIDParams
    )
        : base(licenseRetrieveByExternalIDParams)
    {
        this.ExternalLicenseID = licenseRetrieveByExternalIDParams.ExternalLicenseID;
    }
#pragma warning restore CS8618

    public LicenseRetrieveByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseRetrieveByExternalIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string externalLicenseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ExternalLicenseID = externalLicenseID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LicenseRetrieveByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string externalLicenseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            externalLicenseID
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

    public virtual bool Equals(LicenseRetrieveByExternalIDParams? other)
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
                + string.Format("/licenses/external_license_id/{0}", this.ExternalLicenseID)
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
