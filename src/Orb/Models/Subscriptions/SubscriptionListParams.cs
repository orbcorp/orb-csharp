using System.Collections.Frozen;
using System.Collections.Generic;
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
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[gt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gt]", value); }
    }

    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[gte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[gte]", value); }
    }

    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[lt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lt]", value); }
    }

    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "created_at[lte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "created_at[lte]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    public IReadOnlyList<string>? CustomerID
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawQueryData, "customer_id"); }
        init { ModelBase.Set(this._rawQueryData, "customer_id", value); }
    }

    public IReadOnlyList<string>? ExternalCustomerID
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(
                this.RawQueryData,
                "external_customer_id"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "external_customer_id", value); }
    }

    public string? ExternalPlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "external_plan_id"); }
        init { ModelBase.Set(this._rawQueryData, "external_plan_id", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    public string? PlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "plan_id"); }
        init { ModelBase.Set(this._rawQueryData, "plan_id", value); }
    }

    public ApiEnum<string, global::Orb.Models.Subscriptions.Status>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Orb.Models.Subscriptions.Status>
            >(this.RawQueryData, "status");
        }
        init { ModelBase.Set(this._rawQueryData, "status", value); }
    }

    public SubscriptionListParams() { }

    public SubscriptionListParams(SubscriptionListParams subscriptionListParams)
        : base(subscriptionListParams) { }

    public SubscriptionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
