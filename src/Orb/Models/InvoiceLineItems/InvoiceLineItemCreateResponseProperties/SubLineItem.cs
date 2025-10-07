using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.InvoiceLineItems.InvoiceLineItemCreateResponseProperties;

[JsonConverter(typeof(SubLineItemConverter))]
public record class SubLineItem
{
    public object Value { get; private init; }

    public string Amount
    {
        get
        {
            return Match(matrix: (x) => x.Amount, tier: (x) => x.Amount, other: (x) => x.Amount);
        }
    }

    public SubLineItemGrouping? Grouping
    {
        get
        {
            return Match<SubLineItemGrouping?>(
                matrix: (x) => x.Grouping,
                tier: (x) => x.Grouping,
                other: (x) => x.Grouping
            );
        }
    }

    public string Name
    {
        get { return Match(matrix: (x) => x.Name, tier: (x) => x.Name, other: (x) => x.Name); }
    }

    public double Quantity
    {
        get
        {
            return Match(
                matrix: (x) => x.Quantity,
                tier: (x) => x.Quantity,
                other: (x) => x.Quantity
            );
        }
    }

    public SubLineItem(MatrixSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(TierSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(OtherSubLineItem value)
    {
        Value = value;
    }

    SubLineItem(UnknownVariant value)
    {
        Value = value;
    }

    public static SubLineItem CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickMatrix([NotNullWhen(true)] out MatrixSubLineItem? value)
    {
        value = this.Value as MatrixSubLineItem;
        return value != null;
    }

    public bool TryPickTier([NotNullWhen(true)] out TierSubLineItem? value)
    {
        value = this.Value as TierSubLineItem;
        return value != null;
    }

    public bool TryPickOther([NotNullWhen(true)] out OtherSubLineItem? value)
    {
        value = this.Value as OtherSubLineItem;
        return value != null;
    }

    public void Switch(
        Action<MatrixSubLineItem> matrix,
        Action<TierSubLineItem> tier,
        Action<OtherSubLineItem> other
    )
    {
        switch (this.Value)
        {
            case MatrixSubLineItem value:
                matrix(value);
                break;
            case TierSubLineItem value:
                tier(value);
                break;
            case OtherSubLineItem value:
                other(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    public T Match<T>(
        Func<MatrixSubLineItem, T> matrix,
        Func<TierSubLineItem, T> tier,
        Func<OtherSubLineItem, T> other
    )
    {
        return this.Value switch
        {
            MatrixSubLineItem value => matrix(value),
            TierSubLineItem value => tier(value),
            OtherSubLineItem value => other(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of SubLineItem"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class SubLineItemConverter : JsonConverter<SubLineItem>
{
    public override SubLineItem? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MatrixSubLineItem'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "tier":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TierSubLineItem'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "'null'":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'OtherSubLineItem'",
                            e
                        )
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
        SubLineItem value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
