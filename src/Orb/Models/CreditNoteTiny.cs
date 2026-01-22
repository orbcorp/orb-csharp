using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<CreditNoteTiny, CreditNoteTinyFromRaw>))]
public sealed record class CreditNoteTiny : JsonModel
{
    /// <summary>
    /// The id of the Credit note
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

    public CreditNoteTiny() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditNoteTiny(CreditNoteTiny creditNoteTiny)
        : base(creditNoteTiny) { }
#pragma warning restore CS8618

    public CreditNoteTiny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteTiny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditNoteTinyFromRaw.FromRawUnchecked"/>
    public static CreditNoteTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CreditNoteTiny(string id)
        : this()
    {
        this.ID = id;
    }
}

class CreditNoteTinyFromRaw : IFromRawJson<CreditNoteTiny>
{
    /// <inheritdoc/>
    public CreditNoteTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditNoteTiny.FromRawUnchecked(rawData);
}
