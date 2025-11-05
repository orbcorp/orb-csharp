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
    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["created_at[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["created_at[gte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["created_at[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["created_at[lte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The plan status to filter to ('active', 'archived', or 'draft').
    /// </summary>
    public ApiEnum<string, global::Orb.Models.Plans.StatusModel>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Orb.Models.Plans.StatusModel
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/plans")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// The plan status to filter to ('active', 'archived', or 'draft').
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Plans.StatusModelConverter))]
public enum StatusModel
{
    Active,
    Archived,
    Draft,
}

sealed class StatusModelConverter : JsonConverter<global::Orb.Models.Plans.StatusModel>
{
    public override global::Orb.Models.Plans.StatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.Plans.StatusModel.Active,
            "archived" => global::Orb.Models.Plans.StatusModel.Archived,
            "draft" => global::Orb.Models.Plans.StatusModel.Draft,
            _ => (global::Orb.Models.Plans.StatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Plans.StatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Plans.StatusModel.Active => "active",
                global::Orb.Models.Plans.StatusModel.Archived => "archived",
                global::Orb.Models.Plans.StatusModel.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
