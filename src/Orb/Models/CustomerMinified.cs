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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string? ExternalCustomerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawData.Set("external_customer_id", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerMinified(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
