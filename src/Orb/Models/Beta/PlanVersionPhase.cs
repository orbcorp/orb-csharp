using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Beta;

[JsonConverter(typeof(ModelConverter<PlanVersionPhase, PlanVersionPhaseFromRaw>))]
public sealed record class PlanVersionPhase : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// How many terms of length `duration_unit` this phase is active for. If null,
    /// this phase is evergreen and active indefinitely
    /// </summary>
    public required long? Duration
    {
        get
        {
            if (!this._rawData.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Beta.DurationUnit>? DurationUnit
    {
        get
        {
            if (!this._rawData.TryGetValue("duration_unit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Orb.Models.Beta.DurationUnit
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["duration_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determines the ordering of the phase in a plan's lifecycle. 1 = first phase.
    /// </summary>
    public required long Order
    {
        get
        {
            if (!this._rawData.TryGetValue("order", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'order' cannot be null",
                    new System::ArgumentOutOfRangeException("order", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["order"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public PlanVersionPhase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanVersionPhase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PlanVersionPhase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanVersionPhaseFromRaw : IFromRaw<PlanVersionPhase>
{
    public PlanVersionPhase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlanVersionPhase.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Beta.DurationUnitConverter))]
public enum DurationUnit
{
    Daily,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class DurationUnitConverter : JsonConverter<global::Orb.Models.Beta.DurationUnit>
{
    public override global::Orb.Models.Beta.DurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "daily" => global::Orb.Models.Beta.DurationUnit.Daily,
            "monthly" => global::Orb.Models.Beta.DurationUnit.Monthly,
            "quarterly" => global::Orb.Models.Beta.DurationUnit.Quarterly,
            "semi_annual" => global::Orb.Models.Beta.DurationUnit.SemiAnnual,
            "annual" => global::Orb.Models.Beta.DurationUnit.Annual,
            _ => (global::Orb.Models.Beta.DurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Beta.DurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Beta.DurationUnit.Daily => "daily",
                global::Orb.Models.Beta.DurationUnit.Monthly => "monthly",
                global::Orb.Models.Beta.DurationUnit.Quarterly => "quarterly",
                global::Orb.Models.Beta.DurationUnit.SemiAnnual => "semi_annual",
                global::Orb.Models.Beta.DurationUnit.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
