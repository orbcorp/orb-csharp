using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint returns a list of all subscriptions for an account as a [paginated](/api-reference/pagination)
/// list, ordered starting from the most recently created subscription. For a full
/// discussion of the subscription resource, see [Subscription](/core-concepts##subscription).
///
/// <para>Subscriptions can be filtered for a specific customer by using either the
/// customer_id or external_customer_id query parameters. To filter subscriptions
/// for multiple customers, use the customer_id[] or external_customer_id[] query parameters.</para>
/// </summary>
public sealed record class SubscriptionListParams : ParamsBase
{
    public System::DateTimeOffset? CreatedAtGt
    {
        get
        {
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gt]");
        }
        init { this._rawQueryData.Set("created_at[gt]", value); }
    }

    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gte]");
        }
        init { this._rawQueryData.Set("created_at[gte]", value); }
    }

    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lt]");
        }
        init { this._rawQueryData.Set("created_at[lt]", value); }
    }

    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lte]");
        }
        init { this._rawQueryData.Set("created_at[lte]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return this._rawQueryData.GetNullableClass<string>("cursor"); }
        init { this._rawQueryData.Set("cursor", value); }
    }

    public IReadOnlyList<string>? CustomerID
    {
        get { return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("customer_id"); }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "customer_id",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? ExternalCustomerID
    {
        get
        {
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "external_customer_id"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "external_customer_id",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ExternalPlanID
    {
        get { return this._rawQueryData.GetNullableClass<string>("external_plan_id"); }
        init { this._rawQueryData.Set("external_plan_id", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return this._rawQueryData.GetNullableStruct<long>("limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public string? PlanID
    {
        get { return this._rawQueryData.GetNullableClass<string>("plan_id"); }
        init { this._rawQueryData.Set("plan_id", value); }
    }

    public ApiEnum<string, global::Orb.Models.Subscriptions.Status>? Status
    {
        get
        {
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, global::Orb.Models.Subscriptions.Status>
            >("status");
        }
        init { this._rawQueryData.Set("status", value); }
    }

    public SubscriptionListParams() { }

    public SubscriptionListParams(SubscriptionListParams subscriptionListParams)
        : base(subscriptionListParams) { }

    public SubscriptionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/subscriptions")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(global::Orb.Models.Subscriptions.StatusConverter))]
public enum Status
{
    Active,
    Ended,
    Upcoming,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.Subscriptions.Status>
{
    public override global::Orb.Models.Subscriptions.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.Subscriptions.Status.Active,
            "ended" => global::Orb.Models.Subscriptions.Status.Ended,
            "upcoming" => global::Orb.Models.Subscriptions.Status.Upcoming,
            _ => (global::Orb.Models.Subscriptions.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Subscriptions.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Subscriptions.Status.Active => "active",
                global::Orb.Models.Subscriptions.Status.Ended => "ended",
                global::Orb.Models.Subscriptions.Status.Upcoming => "upcoming",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
