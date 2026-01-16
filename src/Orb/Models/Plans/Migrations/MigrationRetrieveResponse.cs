using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Plans.Migrations;

[JsonConverter(
    typeof(JsonModelConverter<MigrationRetrieveResponse, MigrationRetrieveResponseFromRaw>)
)]
public sealed record class MigrationRetrieveResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required EffectiveTime? EffectiveTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EffectiveTime>("effective_time");
        }
        init { this._rawData.Set("effective_time", value); }
    }

    public required string PlanID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plan_id");
        }
        init { this._rawData.Set("plan_id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EffectiveTime?.Validate();
        _ = this.PlanID;
        this.Status.Validate();
    }

    public MigrationRetrieveResponse() { }

    public MigrationRetrieveResponse(MigrationRetrieveResponse migrationRetrieveResponse)
        : base(migrationRetrieveResponse) { }

    public MigrationRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MigrationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MigrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MigrationRetrieveResponseFromRaw : IFromRawJson<MigrationRetrieveResponse>
{
    /// <inheritdoc/>
    public MigrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MigrationRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EffectiveTimeConverter))]
public record class EffectiveTime : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EffectiveTime(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EffectiveTime(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EffectiveTime(ApiEnum<string, UnionMember2> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EffectiveTime(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum<string, UnionMember2>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnionMember2(out var value)) {
    ///     // `value` is of type `ApiEnum<string, UnionMember2>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnionMember2([NotNullWhen(true)] out ApiEnum<string, UnionMember2>? value)
    {
        value = this.Value as ApiEnum<string, UnionMember2>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, UnionMember2> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<System::DateTimeOffset> @dateTimeOffset,
        System::Action<ApiEnum<string, UnionMember2>> unionMember2
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case System::DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            case ApiEnum<string, UnionMember2> value:
                unionMember2(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of EffectiveTime"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (System::DateTimeOffset value) => {...},
    ///     (ApiEnum<string, UnionMember2> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<System::DateTimeOffset, T> @dateTimeOffset,
        System::Func<ApiEnum<string, UnionMember2>, T> unionMember2
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            System::DateTimeOffset value => @dateTimeOffset(value),
            ApiEnum<string, UnionMember2> value => unionMember2(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of EffectiveTime"
            ),
        };
    }

    public static implicit operator EffectiveTime(string value) => new(value);

    public static implicit operator EffectiveTime(System::DateTimeOffset value) => new(value);

    public static implicit operator EffectiveTime(ApiEnum<string, UnionMember2> value) =>
        new(value);

    public static implicit operator EffectiveTime(UnionMember2 value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of EffectiveTime");
        }
        this.Switch((_) => { }, (_) => { }, (unionMember2) => unionMember2.Validate());
    }

    public virtual bool Equals(EffectiveTime? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class EffectiveTimeConverter : JsonConverter<EffectiveTime?>
{
    public override EffectiveTime? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnionMember2>>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EffectiveTime? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(UnionMember2Converter))]
public enum UnionMember2
{
    EndOfTerm,
}

sealed class UnionMember2Converter : JsonConverter<UnionMember2>
{
    public override UnionMember2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_of_term" => UnionMember2.EndOfTerm,
            _ => (UnionMember2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UnionMember2.EndOfTerm => "end_of_term",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotStarted,
    InProgress,
    Completed,
    ActionNeeded,
    Canceled,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_started" => Status.NotStarted,
            "in_progress" => Status.InProgress,
            "completed" => Status.Completed,
            "action_needed" => Status.ActionNeeded,
            "canceled" => Status.Canceled,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.NotStarted => "not_started",
                Status.InProgress => "in_progress",
                Status.Completed => "completed",
                Status.ActionNeeded => "action_needed",
                Status.Canceled => "canceled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
