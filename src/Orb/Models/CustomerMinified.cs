using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<CustomerMinified, CustomerMinifiedFromRaw>))]
public sealed record class CustomerMinified : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required string? ExternalCustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "external_customer_id"); }
        init { JsonModel.Set(this._rawData, "external_customer_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalCustomerID;
    }

    public CustomerMinified() { }

    public CustomerMinified(CustomerMinified customerMinified)
        : base(customerMinified) { }

    public CustomerMinified(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerMinified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerMinifiedFromRaw.FromRawUnchecked"/>
    public static CustomerMinified FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerMinifiedFromRaw : IFromRawJson<CustomerMinified>
{
    /// <inheritdoc/>
    public CustomerMinified FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CustomerMinified.FromRawUnchecked(rawData);
}
