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
    typeof(JsonModelConverter<BillingCycleConfiguration, BillingCycleConfigurationFromRaw>)
)]
public sealed record class BillingCycleConfiguration : JsonModel
{
    public required long Duration
    {
        get { return this._rawData.GetNotNullStruct<long>("duration"); }
        init { this._rawData.Set("duration", value); }
    }

    public required ApiEnum<string, DurationUnit> DurationUnit
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, DurationUnit>>("duration_unit");
        }
        init { this._rawData.Set("duration_unit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public BillingCycleConfiguration() { }

    public BillingCycleConfiguration(BillingCycleConfiguration billingCycleConfiguration)
        : base(billingCycleConfiguration) { }

    public BillingCycleConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingCycleConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingCycleConfigurationFromRaw.FromRawUnchecked"/>
    public static BillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillingCycleConfigurationFromRaw : IFromRawJson<BillingCycleConfiguration>
{
    /// <inheritdoc/>
    public BillingCycleConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BillingCycleConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DurationUnitConverter))]
public enum DurationUnit
{
    Day,
    Month,
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
            "day" => DurationUnit.Day,
            "month" => DurationUnit.Month,
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
                DurationUnit.Day => "day",
                DurationUnit.Month => "month",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
