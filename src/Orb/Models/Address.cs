using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    public required string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    public required string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    public required string? Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    public required string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    public required string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}
