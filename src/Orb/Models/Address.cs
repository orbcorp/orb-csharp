using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : ModelBase
{
    public required string? City
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "city"); }
        init { ModelBase.Set(this._rawData, "city", value); }
    }

    public required string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    public required string? Line1
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "line1"); }
        init { ModelBase.Set(this._rawData, "line1", value); }
    }

    public required string? Line2
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "line2"); }
        init { ModelBase.Set(this._rawData, "line2", value); }
    }

    public required string? PostalCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "postal_code"); }
        init { ModelBase.Set(this._rawData, "postal_code", value); }
    }

    public required string? State
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "state"); }
        init { ModelBase.Set(this._rawData, "state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.PostalCode;
        _ = this.State;
    }

    public Address() { }

    public Address(Address address)
        : base(address) { }

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRaw<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}
