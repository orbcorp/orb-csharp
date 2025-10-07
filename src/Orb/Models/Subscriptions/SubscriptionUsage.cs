using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionUsageProperties;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(SubscriptionUsageConverter))]
public record class SubscriptionUsage
{
    public object Value { get; private init; }

    public SubscriptionUsage(UngroupedSubscriptionUsage value)
    {
        Value = value;
    }

    public SubscriptionUsage(GroupedSubscriptionUsage value)
    {
        Value = value;
    }

    SubscriptionUsage(UnknownVariant value)
    {
        Value = value;
    }

    public static SubscriptionUsage CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUngrouped([NotNullWhen(true)] out UngroupedSubscriptionUsage? value)
    {
        value = this.Value as UngroupedSubscriptionUsage;
        return value != null;
    }

    public bool TryPickGrouped([NotNullWhen(true)] out GroupedSubscriptionUsage? value)
    {
        value = this.Value as GroupedSubscriptionUsage;
        return value != null;
    }

    public void Switch(
        Action<UngroupedSubscriptionUsage> ungrouped,
        Action<GroupedSubscriptionUsage> grouped
    )
    {
        switch (this.Value)
        {
            case UngroupedSubscriptionUsage value:
                ungrouped(value);
                break;
            case GroupedSubscriptionUsage value:
                grouped(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SubscriptionUsage"
                );
        }
    }

    public T Match<T>(
        Func<UngroupedSubscriptionUsage, T> ungrouped,
        Func<GroupedSubscriptionUsage, T> grouped
    )
    {
        return this.Value switch
        {
            UngroupedSubscriptionUsage value => ungrouped(value),
            GroupedSubscriptionUsage value => grouped(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionUsage"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionUsage"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class SubscriptionUsageConverter : JsonConverter<SubscriptionUsage>
{
    public override SubscriptionUsage? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new SubscriptionUsage(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'UngroupedSubscriptionUsage'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new SubscriptionUsage(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'GroupedSubscriptionUsage'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUsage value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
