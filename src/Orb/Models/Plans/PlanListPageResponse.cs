using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models.Plans;

[JsonConverter(typeof(JsonModelConverter<PlanListPageResponse, PlanListPageResponseFromRaw>))]
public sealed record class PlanListPageResponse : JsonModel
{
    public required IReadOnlyList<Plan> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Plan>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Plan>>("data", ImmutableArray.ToImmutableArray(value));
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

    public PlanListPageResponse() { }

    public PlanListPageResponse(PlanListPageResponse planListPageResponse)
        : base(planListPageResponse) { }

    public PlanListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanListPageResponseFromRaw.FromRawUnchecked"/>
    public static PlanListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanListPageResponseFromRaw : IFromRawJson<PlanListPageResponse>
{
    /// <inheritdoc/>
    public PlanListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlanListPageResponse.FromRawUnchecked(rawData);
}
