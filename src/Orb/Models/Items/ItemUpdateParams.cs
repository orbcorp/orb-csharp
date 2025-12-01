using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Items;

/// <summary>
/// This endpoint can be used to update properties on the Item.
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ItemID { get; init; }

    public IReadOnlyList<ExternalConnection>? ExternalConnections
    {
        get
        {
            return ModelBase.GetNullableClass<List<ExternalConnection>>(
                this.RawBodyData,
                "external_connections"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "external_connections", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    public ItemUpdateParams() { }

    public ItemUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static ItemUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/items/{0}", this.ItemID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
/// Represents a connection between an Item and an external system for invoicing
/// or tax calculation purposes.
/// </summary>
[JsonConverter(typeof(ModelConverter<ExternalConnection, ExternalConnectionFromRaw>))]
public sealed record class ExternalConnection : ModelBase
{
    /// <summary>
    /// The name of the external system this item is connected to.
    /// </summary>
    public required ApiEnum<string, ExternalConnectionName> ExternalConnectionName
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ExternalConnectionName>>(
                this.RawData,
                "external_connection_name"
            );
        }
        init { ModelBase.Set(this._rawData, "external_connection_name", value); }
    }

    /// <summary>
    /// The identifier of this item in the external system.
    /// </summary>
    public required string ExternalEntityID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "external_entity_id"); }
        init { ModelBase.Set(this._rawData, "external_entity_id", value); }
    }

    public override void Validate()
    {
        this.ExternalConnectionName.Validate();
        _ = this.ExternalEntityID;
    }

    public ExternalConnection() { }

    public ExternalConnection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ExternalConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalConnectionFromRaw : IFromRaw<ExternalConnection>
{
    public ExternalConnection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalConnection.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the external system this item is connected to.
/// </summary>
[JsonConverter(typeof(ExternalConnectionNameConverter))]
public enum ExternalConnectionName
{
    Stripe,
    Quickbooks,
    BillCom,
    Netsuite,
    Taxjar,
    Avalara,
    Anrok,
    Numeral,
}

sealed class ExternalConnectionNameConverter : JsonConverter<ExternalConnectionName>
{
    public override ExternalConnectionName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ExternalConnectionName.Stripe,
            "quickbooks" => ExternalConnectionName.Quickbooks,
            "bill.com" => ExternalConnectionName.BillCom,
            "netsuite" => ExternalConnectionName.Netsuite,
            "taxjar" => ExternalConnectionName.Taxjar,
            "avalara" => ExternalConnectionName.Avalara,
            "anrok" => ExternalConnectionName.Anrok,
            "numeral" => ExternalConnectionName.Numeral,
            _ => (ExternalConnectionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalConnectionName.Stripe => "stripe",
                ExternalConnectionName.Quickbooks => "quickbooks",
                ExternalConnectionName.BillCom => "bill.com",
                ExternalConnectionName.Netsuite => "netsuite",
                ExternalConnectionName.Taxjar => "taxjar",
                ExternalConnectionName.Avalara => "avalara",
                ExternalConnectionName.Anrok => "anrok",
                ExternalConnectionName.Numeral => "numeral",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
