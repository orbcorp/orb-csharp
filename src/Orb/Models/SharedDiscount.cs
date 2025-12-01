using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(SharedDiscountConverter))]
public record class SharedDiscount
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                percentage: (x) => x.Reason,
                trial: (x) => x.Reason,
                usage: (x) => x.Reason,
                amount: (x) => x.Reason
            );
        }
    }

    public SharedDiscount(PercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SharedDiscount(TrialDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SharedDiscount(UsageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SharedDiscount(AmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SharedDiscount(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = this.Value as TrialDiscount;
        return value != null;
    }

    public bool TryPickUsage([NotNullWhen(true)] out UsageDiscount? value)
    {
        value = this.Value as UsageDiscount;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<TrialDiscount> trial,
        System::Action<UsageDiscount> usage,
        System::Action<AmountDiscount> amount
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case TrialDiscount value:
                trial(value);
                break;
            case UsageDiscount value:
                usage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SharedDiscount"
                );
        }
    }

    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<TrialDiscount, T> trial,
        System::Func<UsageDiscount, T> usage,
        System::Func<AmountDiscount, T> amount
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            TrialDiscount value => trial(value),
            UsageDiscount value => usage(value),
            AmountDiscount value => amount(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SharedDiscount"
            ),
        };
    }

    public static implicit operator SharedDiscount(PercentageDiscount value) => new(value);

    public static implicit operator SharedDiscount(TrialDiscount value) => new(value);

    public static implicit operator SharedDiscount(UsageDiscount value) => new(value);

    public static implicit operator SharedDiscount(AmountDiscount value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of SharedDiscount");
        }
    }

    public virtual bool Equals(SharedDiscount? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SharedDiscountConverter : JsonConverter<SharedDiscount>
{
    public override SharedDiscount? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? discountType;
        try
        {
            discountType = json.GetProperty("discount_type").GetString();
        }
        catch
        {
            discountType = null;
        }

        switch (discountType)
        {
            case "percentage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PercentageDiscount>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "trial":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrialDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "usage":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UsageDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "amount":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmountDiscount>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new SharedDiscount(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharedDiscount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
