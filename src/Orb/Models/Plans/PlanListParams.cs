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

    /// <summary>
    /// The plan status to filter to ('active', 'archived', or 'draft').
    /// </summary>
    public ApiEnum<string, StatusModel>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, StatusModel>>(
                this.RawQueryData,
                "status"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "status", value);
        }
    }

    public PlanListParams() { }

    public PlanListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlanListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

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
[JsonConverter(typeof(StatusModelConverter))]
public enum StatusModel
{
    Active,
    Archived,
    Draft,
}

sealed class StatusModelConverter : JsonConverter<StatusModel>
{
    public override StatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => StatusModel.Active,
            "archived" => StatusModel.Archived,
            "draft" => StatusModel.Draft,
            _ => (StatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusModel.Active => "active",
                StatusModel.Archived => "archived",
                StatusModel.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
