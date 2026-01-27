using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<InvoiceTiny, InvoiceTinyFromRaw>))]
public sealed record class InvoiceTiny : JsonModel
{
    /// <summary>
    /// The Invoice id
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public InvoiceTiny() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceTiny(InvoiceTiny invoiceTiny)
        : base(invoiceTiny) { }
#pragma warning restore CS8618

    public InvoiceTiny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceTiny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceTinyFromRaw.FromRawUnchecked"/>
    public static InvoiceTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InvoiceTiny(string id)
        : this()
    {
        this.ID = id;
    }
}

class InvoiceTinyFromRaw : IFromRawJson<InvoiceTiny>
{
    /// <inheritdoc/>
    public InvoiceTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceTiny.FromRawUnchecked(rawData);
}
