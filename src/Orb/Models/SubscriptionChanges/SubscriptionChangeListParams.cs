using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.SubscriptionChanges;

/// <summary>
/// This endpoint returns a list of pending subscription changes for a customer.
/// Use the [Fetch Subscription Change](fetch-subscription-change) endpoint to retrieve
/// the expected subscription state after the pending change is applied.
/// </summary>
public sealed record class SubscriptionChangeListParams : ParamsBase
{
    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { JsonModel.Set(this._rawQueryData, "cursor", value); }
    }

    public string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "customer_id"); }
        init { JsonModel.Set(this._rawQueryData, "customer_id", value); }
    }

    public string? ExternalCustomerID
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawQueryData, "external_customer_id");
        }
        init { JsonModel.Set(this._rawQueryData, "external_customer_id", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
        }
    }

    public ApiEnum<string, global::Orb.Models.SubscriptionChanges.Status>? Status
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, global::Orb.Models.SubscriptionChanges.Status>
            >(this.RawQueryData, "status");
        }
        init { JsonModel.Set(this._rawQueryData, "status", value); }
    }

    public SubscriptionChangeListParams() { }

    public SubscriptionChangeListParams(SubscriptionChangeListParams subscriptionChangeListParams)
        : base(subscriptionChangeListParams) { }

    public SubscriptionChangeListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionChangeListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SubscriptionChangeListParams FromRawUnchecked(
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/subscription_changes"
        )
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

[JsonConverter(typeof(global::Orb.Models.SubscriptionChanges.StatusConverter))]
public enum Status
{
    Pending,
    Applied,
    Cancelled,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.SubscriptionChanges.Status>
{
    public override global::Orb.Models.SubscriptionChanges.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => global::Orb.Models.SubscriptionChanges.Status.Pending,
            "applied" => global::Orb.Models.SubscriptionChanges.Status.Applied,
            "cancelled" => global::Orb.Models.SubscriptionChanges.Status.Cancelled,
            _ => (global::Orb.Models.SubscriptionChanges.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.SubscriptionChanges.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.SubscriptionChanges.Status.Pending => "pending",
                global::Orb.Models.SubscriptionChanges.Status.Applied => "applied",
                global::Orb.Models.SubscriptionChanges.Status.Cancelled => "cancelled",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
