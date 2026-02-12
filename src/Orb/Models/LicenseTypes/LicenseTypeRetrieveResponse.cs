using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.LicenseTypes;

/// <summary>
/// The LicenseType resource represents a type of license that can be assigned to
/// users. License types are used during billing by grouping metrics on the configured
/// grouping key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<LicenseTypeRetrieveResponse, LicenseTypeRetrieveResponseFromRaw>)
)]
public sealed record class LicenseTypeRetrieveResponse : JsonModel
{
    /// <summary>
    /// The Orb-assigned unique identifier for the license type.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The key used for grouping licenses of this type. This is typically a user
    /// identifier field.
    /// </summary>
    public required string GroupingKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("grouping_key");
        }
        init { this._rawData.Set("grouping_key", value); }
    }

    /// <summary>
    /// The name of the license type.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.GroupingKey;
        _ = this.Name;
    }

    public LicenseTypeRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseTypeRetrieveResponse(LicenseTypeRetrieveResponse licenseTypeRetrieveResponse)
        : base(licenseTypeRetrieveResponse) { }
#pragma warning restore CS8618

    public LicenseTypeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseTypeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseTypeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static LicenseTypeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseTypeRetrieveResponseFromRaw : IFromRawJson<LicenseTypeRetrieveResponse>
{
    /// <inheritdoc/>
    public LicenseTypeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseTypeRetrieveResponse.FromRawUnchecked(rawData);
}
