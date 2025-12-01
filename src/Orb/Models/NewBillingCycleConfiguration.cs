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
    typeof(ModelConverter<NewBillingCycleConfiguration, NewBillingCycleConfigurationFromRaw>)
)]
public sealed record class NewBillingCycleConfiguration : ModelBase
{
    /// <summary>
    /// The duration of the billing period.
    /// </summary>
    public required long Duration
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "duration"); }
        init { ModelBase.Set(this._rawData, "duration", value); }
    }

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required ApiEnum<string, NewBillingCycleConfigurationDurationUnit> DurationUnit
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, NewBillingCycleConfigurationDurationUnit>
            >(this.RawData, "duration_unit");
        }
        init { ModelBase.Set(this._rawData, "duration_unit", value); }
    }

    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public NewBillingCycleConfiguration() { }

    public NewBillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewBillingCycleConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewBillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewBillingCycleConfigurationFromRaw : IFromRaw<NewBillingCycleConfiguration>
{
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
