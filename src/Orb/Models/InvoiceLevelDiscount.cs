using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(InvoiceLevelDiscountConverter))]
public record class InvoiceLevelDiscount
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
                amount: (x) => x.Reason,
                trial: (x) => x.Reason
            );
        }
    }

    public InvoiceLevelDiscount(PercentageDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvoiceLevelDiscount(AmountDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvoiceLevelDiscount(TrialDiscount value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvoiceLevelDiscount(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickPercentage([NotNullWhen(true)] out PercentageDiscount? value)
    {
        value = this.Value as PercentageDiscount;
        return value != null;
    }

    public bool TryPickAmount([NotNullWhen(true)] out AmountDiscount? value)
    {
        value = this.Value as AmountDiscount;
        return value != null;
    }

    public bool TryPickTrial([NotNullWhen(true)] out TrialDiscount? value)
    {
        value = this.Value as TrialDiscount;
        return value != null;
    }

    public void Switch(
        System::Action<PercentageDiscount> percentage,
        System::Action<AmountDiscount> amount,
        System::Action<TrialDiscount> trial
    )
    {
        switch (this.Value)
        {
            case PercentageDiscount value:
                percentage(value);
                break;
            case AmountDiscount value:
                amount(value);
                break;
            case TrialDiscount value:
                trial(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of InvoiceLevelDiscount"
                );
        }
    }

    public T Match<T>(
        System::Func<PercentageDiscount, T> percentage,
        System::Func<AmountDiscount, T> amount,
        System::Func<TrialDiscount, T> trial
    )
    {
        return this.Value switch
        {
            PercentageDiscount value => percentage(value),
            AmountDiscount value => amount(value),
            TrialDiscount value => trial(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            ),
        };
    }

    public static implicit operator InvoiceLevelDiscount(PercentageDiscount value) => new(value);

    public static implicit operator InvoiceLevelDiscount(AmountDiscount value) => new(value);

    public static implicit operator InvoiceLevelDiscount(TrialDiscount value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceLevelDiscount"
            );
        }
    }
}

sealed class InvoiceLevelDiscountConverter : JsonConverter<InvoiceLevelDiscount>
{
    public override InvoiceLevelDiscount? Read(
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
            default:
            {
                return new InvoiceLevelDiscount(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceLevelDiscount value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
