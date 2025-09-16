using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SubLineItemVariants = Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.LineItemProperties.SubLineItemVariants;

namespace Orb.Models.ChangedSubscriptionResourcesProperties.CreatedInvoiceProperties.LineItemProperties;

[JsonConverter(typeof(SubLineItemConverter))]
public abstract record class SubLineItem
{
    internal SubLineItem() { }

    public static implicit operator SubLineItem(MatrixSubLineItem value) =>
        new SubLineItemVariants::MatrixSubLineItem(value);

    public static implicit operator SubLineItem(TierSubLineItem value) =>
        new SubLineItemVariants::TierSubLineItem(value);

    public static implicit operator SubLineItem(OtherSubLineItem value) =>
        new SubLineItemVariants::OtherSubLineItem(value);

    public bool TryPickMatrix([NotNullWhen(true)] out MatrixSubLineItem? value)
    {
        value = (this as SubLineItemVariants::MatrixSubLineItem)?.Value;
        return value != null;
    }

    public bool TryPickTier([NotNullWhen(true)] out TierSubLineItem? value)
    {
        value = (this as SubLineItemVariants::TierSubLineItem)?.Value;
        return value != null;
    }

    public bool TryPickOther([NotNullWhen(true)] out OtherSubLineItem? value)
    {
        value = (this as SubLineItemVariants::OtherSubLineItem)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SubLineItemVariants::MatrixSubLineItem> matrix,
        Action<SubLineItemVariants::TierSubLineItem> tier,
        Action<SubLineItemVariants::OtherSubLineItem> other
    )
    {
        switch (this)
        {
            case SubLineItemVariants::MatrixSubLineItem inner:
                matrix(inner);
                break;
            case SubLineItemVariants::TierSubLineItem inner:
                tier(inner);
                break;
            case SubLineItemVariants::OtherSubLineItem inner:
                other(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SubLineItemVariants::MatrixSubLineItem, T> matrix,
        Func<SubLineItemVariants::TierSubLineItem, T> tier,
        Func<SubLineItemVariants::OtherSubLineItem, T> other
    )
    {
        return this switch
        {
            SubLineItemVariants::MatrixSubLineItem inner => matrix(inner),
            SubLineItemVariants::TierSubLineItem inner => tier(inner),
            SubLineItemVariants::OtherSubLineItem inner => other(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        return new SubLineItemVariants::MatrixSubLineItem(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "tier":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        return new SubLineItemVariants::TierSubLineItem(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "'null'":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        return new SubLineItemVariants::OtherSubLineItem(deserialized);
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
        SubLineItem value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            SubLineItemVariants::MatrixSubLineItem(var matrix) => matrix,
            SubLineItemVariants::TierSubLineItem(var tier) => tier,
            SubLineItemVariants::OtherSubLineItem(var other) => other,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
