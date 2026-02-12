using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Licenses;

[JsonConverter(typeof(JsonModelConverter<LicenseListPageResponse, LicenseListPageResponseFromRaw>))]
public sealed record class LicenseListPageResponse : JsonModel
{
    public required IReadOnlyList<LicenseListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LicenseListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LicenseListResponse>>(
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

    public LicenseListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseListPageResponse(LicenseListPageResponse licenseListPageResponse)
        : base(licenseListPageResponse) { }
#pragma warning restore CS8618

    public LicenseListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseListPageResponseFromRaw.FromRawUnchecked"/>
    public static LicenseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseListPageResponseFromRaw : IFromRawJson<LicenseListPageResponse>
{
    /// <inheritdoc/>
    public LicenseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseListPageResponse.FromRawUnchecked(rawData);
}
