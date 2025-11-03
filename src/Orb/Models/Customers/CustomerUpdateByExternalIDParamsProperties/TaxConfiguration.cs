using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties.TaxConfigurationProperties;

namespace Orb.Models.Customers.CustomerUpdateByExternalIDParamsProperties;

[JsonConverter(typeof(TaxConfigurationConverter))]
public record class TaxConfiguration
{
    public object Value { get; private init; }

    public bool TaxExempt
    {
        get
        {
            return Match(
                newAvalara: (x) => x.TaxExempt,
                newTaxJar: (x) => x.TaxExempt,
                newSphere: (x) => x.TaxExempt,
                numeral: (x) => x.TaxExempt,
                anrok: (x) => x.TaxExempt
            );
        }
    }

    public bool? AutomaticTaxEnabled
    {
        get
        {
            return Match<bool?>(
                newAvalara: (x) => x.AutomaticTaxEnabled,
                newTaxJar: (x) => x.AutomaticTaxEnabled,
                newSphere: (x) => x.AutomaticTaxEnabled,
                numeral: (x) => x.AutomaticTaxEnabled,
                anrok: (x) => x.AutomaticTaxEnabled
            );
        }
    }

    public TaxConfiguration(NewAvalaraTaxConfiguration value)
    {
        Value = value;
    }

    public TaxConfiguration(NewTaxJarConfiguration value)
    {
        Value = value;
    }

    public TaxConfiguration(NewSphereConfiguration value)
    {
        Value = value;
    }

    public TaxConfiguration(Numeral value)
    {
        Value = value;
    }

    public TaxConfiguration(Anrok value)
    {
        Value = value;
    }

    TaxConfiguration(UnknownVariant value)
    {
        Value = value;
    }

    public static TaxConfiguration CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickNewAvalara([NotNullWhen(true)] out NewAvalaraTaxConfiguration? value)
    {
        value = this.Value as NewAvalaraTaxConfiguration;
        return value != null;
    }

    public bool TryPickNewTaxJar([NotNullWhen(true)] out NewTaxJarConfiguration? value)
    {
        value = this.Value as NewTaxJarConfiguration;
        return value != null;
    }

    public bool TryPickNewSphere([NotNullWhen(true)] out NewSphereConfiguration? value)
    {
        value = this.Value as NewSphereConfiguration;
        return value != null;
    }

    public bool TryPickNumeral([NotNullWhen(true)] out Numeral? value)
    {
        value = this.Value as Numeral;
        return value != null;
    }

    public bool TryPickAnrok([NotNullWhen(true)] out Anrok? value)
    {
        value = this.Value as Anrok;
        return value != null;
    }

    public void Switch(
        Action<NewAvalaraTaxConfiguration> newAvalara,
        Action<NewTaxJarConfiguration> newTaxJar,
        Action<NewSphereConfiguration> newSphere,
        Action<Numeral> numeral,
        Action<Anrok> anrok
    )
    {
        switch (this.Value)
        {
            case NewAvalaraTaxConfiguration value:
                newAvalara(value);
                break;
            case NewTaxJarConfiguration value:
                newTaxJar(value);
                break;
            case NewSphereConfiguration value:
                newSphere(value);
                break;
            case Numeral value:
                numeral(value);
                break;
            case Anrok value:
                anrok(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of TaxConfiguration"
                );
        }
    }

    public T Match<T>(
        Func<NewAvalaraTaxConfiguration, T> newAvalara,
        Func<NewTaxJarConfiguration, T> newTaxJar,
        Func<NewSphereConfiguration, T> newSphere,
        Func<Numeral, T> numeral,
        Func<Anrok, T> anrok
    )
    {
        return this.Value switch
        {
            NewAvalaraTaxConfiguration value => newAvalara(value),
            NewTaxJarConfiguration value => newTaxJar(value),
            NewSphereConfiguration value => newSphere(value),
            Numeral value => numeral(value),
            Anrok value => anrok(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TaxConfiguration"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of TaxConfiguration");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class TaxConfigurationConverter : JsonConverter<TaxConfiguration?>
{
    public override TaxConfiguration? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? taxProvider;
        try
        {
            taxProvider = json.GetProperty("tax_provider").GetString();
        }
        catch
        {
            taxProvider = null;
        }

        switch (taxProvider)
        {
            case "avalara":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new TaxConfiguration(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewAvalaraTaxConfiguration'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "taxjar":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new TaxConfiguration(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewTaxJarConfiguration'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "sphere":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new TaxConfiguration(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'NewSphereConfiguration'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "numeral":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Numeral>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new TaxConfiguration(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'Numeral'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "anrok":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Anrok>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new TaxConfiguration(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException("Data does not match union variant 'Anrok'", e)
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxConfiguration? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
