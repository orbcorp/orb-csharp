using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Subscriptions.SubscriptionUsageProperties;
using SubscriptionUsageVariants = Orb.Models.Subscriptions.SubscriptionUsageVariants;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(SubscriptionUsageConverter))]
public abstract record class SubscriptionUsage
{
    internal SubscriptionUsage() { }

    public static implicit operator SubscriptionUsage(UngroupedSubscriptionUsage value) =>
        new SubscriptionUsageVariants::UngroupedSubscriptionUsage(value);

    public static implicit operator SubscriptionUsage(GroupedSubscriptionUsage value) =>
        new SubscriptionUsageVariants::GroupedSubscriptionUsage(value);

    public bool TryPickUngrouped([NotNullWhen(true)] out UngroupedSubscriptionUsage? value)
    {
        value = (this as SubscriptionUsageVariants::UngroupedSubscriptionUsage)?.Value;
        return value != null;
    }

    public bool TryPickGrouped([NotNullWhen(true)] out GroupedSubscriptionUsage? value)
    {
        value = (this as SubscriptionUsageVariants::GroupedSubscriptionUsage)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SubscriptionUsageVariants::UngroupedSubscriptionUsage> ungrouped,
        Action<SubscriptionUsageVariants::GroupedSubscriptionUsage> grouped
    )
    {
        switch (this)
        {
            case SubscriptionUsageVariants::UngroupedSubscriptionUsage inner:
                ungrouped(inner);
                break;
            case SubscriptionUsageVariants::GroupedSubscriptionUsage inner:
                grouped(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SubscriptionUsageVariants::UngroupedSubscriptionUsage, T> ungrouped,
        Func<SubscriptionUsageVariants::GroupedSubscriptionUsage, T> grouped
    )
    {
        return this switch
        {
            SubscriptionUsageVariants::UngroupedSubscriptionUsage inner => ungrouped(inner),
            SubscriptionUsageVariants::GroupedSubscriptionUsage inner => grouped(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SubscriptionUsageConverter : JsonConverter<SubscriptionUsage>
{
    public override SubscriptionUsage? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SubscriptionUsageVariants::UngroupedSubscriptionUsage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SubscriptionUsageVariants::GroupedSubscriptionUsage(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUsage value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            SubscriptionUsageVariants::UngroupedSubscriptionUsage(var ungrouped) => ungrouped,
            SubscriptionUsageVariants::GroupedSubscriptionUsage(var grouped) => grouped,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
