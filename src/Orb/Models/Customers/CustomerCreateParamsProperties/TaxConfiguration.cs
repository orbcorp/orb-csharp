using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaxConfigurationVariants = Orb.Models.Customers.CustomerCreateParamsProperties.TaxConfigurationVariants;

namespace Orb.Models.Customers.CustomerCreateParamsProperties;

[JsonConverter(typeof(TaxConfigurationConverter))]
public abstract record class TaxConfiguration
{
    internal TaxConfiguration() { }

    public static implicit operator TaxConfiguration(NewAvalaraTaxConfiguration value) =>
        new TaxConfigurationVariants::NewAvalaraTaxConfiguration(value);

    public static implicit operator TaxConfiguration(NewTaxJarConfiguration value) =>
        new TaxConfigurationVariants::NewTaxJarConfiguration(value);

    public static implicit operator TaxConfiguration(NewSphereConfiguration value) =>
        new TaxConfigurationVariants::NewSphereConfiguration(value);

    public bool TryPickNewAvalara([NotNullWhen(true)] out NewAvalaraTaxConfiguration? value)
    {
        value = (this as TaxConfigurationVariants::NewAvalaraTaxConfiguration)?.Value;
        return value != null;
    }

    public bool TryPickNewTaxJar([NotNullWhen(true)] out NewTaxJarConfiguration? value)
    {
        value = (this as TaxConfigurationVariants::NewTaxJarConfiguration)?.Value;
        return value != null;
    }

    public bool TryPickNewSphere([NotNullWhen(true)] out NewSphereConfiguration? value)
    {
        value = (this as TaxConfigurationVariants::NewSphereConfiguration)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TaxConfigurationVariants::NewAvalaraTaxConfiguration> newAvalara,
        Action<TaxConfigurationVariants::NewTaxJarConfiguration> newTaxJar,
        Action<TaxConfigurationVariants::NewSphereConfiguration> newSphere
    )
    {
        switch (this)
        {
            case TaxConfigurationVariants::NewAvalaraTaxConfiguration inner:
                newAvalara(inner);
                break;
            case TaxConfigurationVariants::NewTaxJarConfiguration inner:
                newTaxJar(inner);
                break;
            case TaxConfigurationVariants::NewSphereConfiguration inner:
                newSphere(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TaxConfigurationVariants::NewAvalaraTaxConfiguration, T> newAvalara,
        Func<TaxConfigurationVariants::NewTaxJarConfiguration, T> newTaxJar,
        Func<TaxConfigurationVariants::NewSphereConfiguration, T> newSphere
    )
    {
        return this switch
        {
            TaxConfigurationVariants::NewAvalaraTaxConfiguration inner => newAvalara(inner),
            TaxConfigurationVariants::NewTaxJarConfiguration inner => newTaxJar(inner),
            TaxConfigurationVariants::NewSphereConfiguration inner => newSphere(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TaxConfigurationVariants::NewAvalaraTaxConfiguration(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "taxjar":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TaxConfigurationVariants::NewTaxJarConfiguration(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "sphere":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TaxConfigurationVariants::NewSphereConfiguration(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxConfiguration? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value switch
        {
            null => null,
            TaxConfigurationVariants::NewAvalaraTaxConfiguration(var newAvalara) => newAvalara,
            TaxConfigurationVariants::NewTaxJarConfiguration(var newTaxJar) => newTaxJar,
            TaxConfigurationVariants::NewSphereConfiguration(var newSphere) => newSphere,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
