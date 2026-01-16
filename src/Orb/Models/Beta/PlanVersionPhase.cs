using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<PlanVersionPhase, PlanVersionPhaseFromRaw>))]
public sealed record class PlanVersionPhase : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    public required ApiEnum<string, DurationUnit>? DurationUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DurationUnit>>("duration_unit");
        }
        init { this._rawData.Set("duration_unit", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("order");
        }
        init { this._rawData.Set("order", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Duration;
        this.DurationUnit?.Validate();
        _ = this.Name;
        _ = this.Order;
    }

    public PlanVersionPhase() { }

    public PlanVersionPhase(PlanVersionPhase planVersionPhase)
        : base(planVersionPhase) { }

    public PlanVersionPhase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersionPhase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanVersionPhaseFromRaw.FromRawUnchecked"/>
    public static PlanVersionPhase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionPhaseFromRaw : IFromRawJson<PlanVersionPhase>
{
    /// <inheritdoc/>
    public PlanVersionPhase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanVersionPhase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DurationUnitConverter))]
public enum DurationUnit
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class DurationUnitConverter : JsonConverter<DurationUnit>
{
    public override DurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => DurationUnit.Daily,
            "monthly" => DurationUnit.Monthly,
            "quarterly" => DurationUnit.Quarterly,
            "semi_annual" => DurationUnit.SemiAnnual,
            "annual" => DurationUnit.Annual,
            _ => (DurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DurationUnit.Daily => "daily",
                DurationUnit.Monthly => "monthly",
                DurationUnit.Quarterly => "quarterly",
                DurationUnit.SemiAnnual => "semi_annual",
                DurationUnit.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
