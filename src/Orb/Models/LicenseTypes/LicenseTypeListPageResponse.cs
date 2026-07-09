using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.LicenseTypes;

[JsonConverter(
    typeof(JsonModelConverter<LicenseTypeListPageResponse, LicenseTypeListPageResponseFromRaw>)
)]
public sealed record class LicenseTypeListPageResponse : JsonModel
{
    public required IReadOnlyList<LicenseTypeListResponse> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<LicenseTypeListResponse>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LicenseTypeListResponse>>(
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

    public LicenseTypeListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseTypeListPageResponse(LicenseTypeListPageResponse licenseTypeListPageResponse)
        : base(licenseTypeListPageResponse) { }
#pragma warning restore CS8618

    public LicenseTypeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseTypeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseTypeListPageResponseFromRaw.FromRawUnchecked"/>
    public static LicenseTypeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LicenseTypeListPageResponseFromRaw : IFromRawJson<LicenseTypeListPageResponse>
{
    /// <inheritdoc/>
    public LicenseTypeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LicenseTypeListPageResponse.FromRawUnchecked(rawData);
}
