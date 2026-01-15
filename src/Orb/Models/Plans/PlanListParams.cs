using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Plans;

/// <summary>
/// This endpoint returns a list of all [plans](/core-concepts#plan-and-price) for
/// an account in a list format. The list of plans is ordered starting from the most
/// recently created plan. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.
/// </summary>
public sealed record class PlanListParams : ParamsBase
{
    public System::DateTimeOffset? CreatedAtGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gt]");
        }
        init { this._rawQueryData.Set("created_at[gt]", value); }
    }

    public System::DateTimeOffset? CreatedAtGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[gte]");
        }
        init { this._rawQueryData.Set("created_at[gte]", value); }
    }

    public System::DateTimeOffset? CreatedAtLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("created_at[lt]");
        }
        init { this._rawQueryData.Set("created_at[lt]", value); }
    }

    public System::DateTimeOffset? CreatedAtLte
    {
        get
        {
            this._rawQueryData.Freeze();
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// The plan status to filter to ('active', 'archived', or 'draft').
    /// </summary>
    public ApiEnum<string, PlanListParamsStatus>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, PlanListParamsStatus>>(
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public PlanListParams() { }

    public PlanListParams(PlanListParams planListParams)
        : base(planListParams) { }

    public PlanListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PlanListParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/plans")
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

/// <summary>
/// The plan status to filter to ('active', 'archived', or 'draft').
/// </summary>
[JsonConverter(typeof(PlanListParamsStatusConverter))]
public enum PlanListParamsStatus
{
    Active,
    Archived,
    Draft,
}

sealed class PlanListParamsStatusConverter : JsonConverter<PlanListParamsStatus>
{
    public override PlanListParamsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => PlanListParamsStatus.Active,
            "archived" => PlanListParamsStatus.Archived,
            "draft" => PlanListParamsStatus.Draft,
            _ => (PlanListParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlanListParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlanListParamsStatus.Active => "active",
                PlanListParamsStatus.Archived => "archived",
                PlanListParamsStatus.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
