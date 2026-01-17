using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditNotes;

/// <summary>
/// This endpoint is used to create a single [`Credit Note`](/invoicing/credit-notes).
///
/// <para>The credit note service period configuration supports two explicit modes:</para>
///
/// <para>1. Global service periods: Specify start_date and end_date at the credit
/// note level.    These dates will be applied to all line items uniformly.</para>
///
/// <para>2. Individual service periods: Specify start_date and end_date for each
/// line item.    When using this mode, ALL line items must have individual periods specified.</para>
///
/// <para>3. Default behavior: If no service periods are specified (neither global
/// nor individual),    the original invoice line item service periods will be used.</para>
///
/// <para>Note: Mixing global and individual service periods in the same request is
/// not allowed to prevent confusion.</para>
///
/// <para>Service period dates are normalized to the start of the day in the customer's
/// timezone to ensure consistent handling across different timezones.</para>
///
/// <para>Date Format: Use start_date and end_date with format "YYYY-MM-DD" (e.g.,
/// "2023-09-22") to match other Orb APIs like /v1/invoice_line_items.</para>
///
/// <para>Note: Both start_date and end_date are inclusive - the service period will
/// cover both the start date and end date completely (from start of start_date to
/// end of end_date).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CreditNoteCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyList<LineItem> LineItems
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<LineItem>>("line_items");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<LineItem>>(
                "line_items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An optional reason for the credit note.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period end date in
    /// the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public string? EndDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("end_date");
        }
        init { this._rawBodyData.Set("end_date", value); }
    }

    /// <summary>
    /// An optional memo to attach to the credit note.
    /// </summary>
    public string? Memo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("memo");
        }
        init { this._rawBodyData.Set("memo", value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period start date
    /// in the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public string? StartDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("start_date");
        }
        init { this._rawBodyData.Set("start_date", value); }
    }

    public CreditNoteCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditNoteCreateParams(CreditNoteCreateParams creditNoteCreateParams)
        : base(creditNoteCreateParams)
    {
        this._rawBodyData = new(creditNoteCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CreditNoteCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CreditNoteCreateParams FromRawUnchecked(
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CreditNoteCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<LineItem, LineItemFromRaw>))]
public sealed record class LineItem : JsonModel
{
    /// <summary>
    /// The total amount in the invoice's currency to credit this line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The ID of the line item to credit.
    /// </summary>
    public required string InvoiceLineItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_line_item_id");
        }
        init { this._rawData.Set("invoice_line_item_id", value); }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period end date
    /// in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global end_date if available, otherwise
    /// defaults to the original invoice line item's end date. This date is inclusive.
    /// </summary>
    public string? EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("end_date");
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period start
    /// date in the customer's timezone. If provided, this will be used for this
    /// specific line item. If not provided, will use the global start_date if available,
    /// otherwise defaults to the original invoice line item's start date. This date
    /// is inclusive.
    /// </summary>
    public string? StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("start_date");
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.InvoiceLineItemID;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public LineItem() { }

    public LineItem(LineItem lineItem)
        : base(lineItem) { }

    public LineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineItemFromRaw.FromRawUnchecked"/>
    public static LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRawJson<LineItem>
{
    /// <inheritdoc/>
    public LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LineItem.FromRawUnchecked(rawData);
}

/// <summary>
/// An optional reason for the credit note.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Duplicate,
    Fraudulent,
    OrderChange,
    ProductUnsatisfactory,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate" => Reason.Duplicate,
            "fraudulent" => Reason.Fraudulent,
            "order_change" => Reason.OrderChange,
            "product_unsatisfactory" => Reason.ProductUnsatisfactory,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Duplicate => "duplicate",
                Reason.Fraudulent => "fraudulent",
                Reason.OrderChange => "order_change",
                Reason.ProductUnsatisfactory => "product_unsatisfactory",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
