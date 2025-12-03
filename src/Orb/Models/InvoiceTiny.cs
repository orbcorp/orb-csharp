using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<InvoiceTiny, InvoiceTinyFromRaw>))]
public sealed record class InvoiceTiny : ModelBase
{
    /// <summary>
    /// The Invoice id
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public InvoiceTiny() { }

    public InvoiceTiny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceTiny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class InvoiceTinyFromRaw : IFromRaw<InvoiceTiny>
{
    /// <inheritdoc/>
    public InvoiceTiny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InvoiceTiny.FromRawUnchecked(rawData);
}
