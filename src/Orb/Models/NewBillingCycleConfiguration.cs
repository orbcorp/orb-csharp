using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<NewBillingCycleConfiguration, NewBillingCycleConfigurationFromRaw>)
)]
public sealed record class NewBillingCycleConfiguration : JsonModel
{
    /// <summary>
    /// The duration of the billing period.
    /// </summary>
    public required long Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required ApiEnum<string, NewBillingCycleConfigurationDurationUnit> DurationUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
            >("duration_unit");
        }
        init { this._rawData.Set("duration_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public NewBillingCycleConfiguration() { }

    public NewBillingCycleConfiguration(NewBillingCycleConfiguration newBillingCycleConfiguration)
        : base(newBillingCycleConfiguration) { }

    public NewBillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewBillingCycleConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewBillingCycleConfigurationFromRaw.FromRawUnchecked"/>
    public static NewBillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewBillingCycleConfigurationFromRaw : IFromRawJson<NewBillingCycleConfiguration>
{
    /// <inheritdoc/>
    public NewBillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewBillingCycleConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// The unit of billing period duration.
/// </summary>
[JsonConverter(typeof(NewBillingCycleConfigurationDurationUnitConverter))]
public enum NewBillingCycleConfigurationDurationUnit
{
    Day,
    Month,
}

sealed class NewBillingCycleConfigurationDurationUnitConverter
    : JsonConverter<NewBillingCycleConfigurationDurationUnit>
{
    public override NewBillingCycleConfigurationDurationUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "day" => NewBillingCycleConfigurationDurationUnit.Day,
            "month" => NewBillingCycleConfigurationDurationUnit.Month,
            _ => (NewBillingCycleConfigurationDurationUnit)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewBillingCycleConfigurationDurationUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewBillingCycleConfigurationDurationUnit.Day => "day",
                NewBillingCycleConfigurationDurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
