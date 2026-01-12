using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Alerts;

[JsonConverter(typeof(JsonModelConverter<AlertListPageResponse, AlertListPageResponseFromRaw>))]
public sealed record class AlertListPageResponse : JsonModel
{
    public required IReadOnlyList<Alert> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Alert>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Alert>>(
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

    public AlertListPageResponse() { }

    public AlertListPageResponse(AlertListPageResponse alertListPageResponse)
        : base(alertListPageResponse) { }

    public AlertListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlertListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlertListPageResponseFromRaw.FromRawUnchecked"/>
    public static AlertListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlertListPageResponseFromRaw : IFromRawJson<AlertListPageResponse>
{
    /// <inheritdoc/>
    public AlertListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlertListPageResponse.FromRawUnchecked(rawData);
}
