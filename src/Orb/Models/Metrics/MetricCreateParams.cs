using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Orb.Models.Metrics;

/// <summary>
/// This endpoint is used to create a [metric](/core-concepts###metric) using a SQL
/// string. See [SQL support](/extensibility/advanced-metrics#sql-support) for a
/// description of constructing SQL queries with examples.
/// </summary>
public sealed record class MetricCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// A description of the metric.
    /// </summary>
    public required string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the item
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("item_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("item_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("item_id");
        }
        set { this.BodyProperties["item_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the metric.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("name");
        }
        set { this.BodyProperties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A sql string defining the metric.
    /// </summary>
    public required string Sql
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("sql", out JsonElement element))
                throw new ArgumentOutOfRangeException("sql", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new ArgumentNullException("sql");
        }
        set { this.BodyProperties["sql"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(element);
        }
        set { this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/metrics")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
