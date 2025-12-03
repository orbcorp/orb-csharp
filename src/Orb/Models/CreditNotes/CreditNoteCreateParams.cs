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
/// </summary>
public sealed record class CreditNoteCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required IReadOnlyList<global::Orb.Models.CreditNotes.LineItem> LineItems
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Orb.Models.CreditNotes.LineItem>>(
                this.RawBodyData,
                "line_items"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "line_items", value); }
    }

    /// <summary>
    /// An optional reason for the credit note.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.CreditNotes.Reason> Reason
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.CreditNotes.Reason>
            >(this.RawBodyData, "reason");
        }
        init { ModelBase.Set(this._rawBodyData, "reason", value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period end date in
    /// the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? EndDate
    {
        get { return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawBodyData, "end_date"); }
        init { ModelBase.Set(this._rawBodyData, "end_date", value); }
    }

    /// <summary>
    /// An optional memo to attach to the credit note.
    /// </summary>
    public string? Memo
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "memo"); }
        init { ModelBase.Set(this._rawBodyData, "memo", value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period start date
    /// in the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? StartDate
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawBodyData, "start_date");
        }
        init { ModelBase.Set(this._rawBodyData, "start_date", value); }
    }

    public CreditNoteCreateParams() { }

    public CreditNoteCreateParams(
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
    CreditNoteCreateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
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

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.CreditNotes.LineItem,
        global::Orb.Models.CreditNotes.LineItemFromRaw
    >)
)]
public sealed record class LineItem : ModelBase
{
    /// <summary>
    /// The total amount in the invoice's currency to credit this line item.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The ID of the line item to credit.
    /// </summary>
    public required string InvoiceLineItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "invoice_line_item_id"); }
        init { ModelBase.Set(this._rawData, "invoice_line_item_id", value); }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period end date
    /// in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global end_date if available, otherwise
    /// defaults to the original invoice line item's end date. This date is inclusive.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? EndDate
    {
        get { return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period start
    /// date in the customer's timezone. If provided, this will be used for this
    /// specific line item. If not provided, will use the global start_date if available,
    /// otherwise defaults to the original invoice line item's start date. This date
    /// is inclusive.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? StartDate
    {
        get { return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
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

    public LineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.CreditNotes.LineItemFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.CreditNotes.LineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRaw<global::Orb.Models.CreditNotes.LineItem>
{
    /// <inheritdoc/>
    public global::Orb.Models.CreditNotes.LineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.CreditNotes.LineItem.FromRawUnchecked(rawData);
}

/// <summary>
/// An optional reason for the credit note.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.CreditNotes.ReasonConverter))]
public enum Reason
{
    Duplicate,
    Fraudulent,
    OrderChange,
    ProductUnsatisfactory,
}

sealed class ReasonConverter : JsonConverter<global::Orb.Models.CreditNotes.Reason>
{
    public override global::Orb.Models.CreditNotes.Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate" => global::Orb.Models.CreditNotes.Reason.Duplicate,
            "fraudulent" => global::Orb.Models.CreditNotes.Reason.Fraudulent,
            "order_change" => global::Orb.Models.CreditNotes.Reason.OrderChange,
            "product_unsatisfactory" => global::Orb.Models.CreditNotes.Reason.ProductUnsatisfactory,
            _ => (global::Orb.Models.CreditNotes.Reason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.CreditNotes.Reason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.CreditNotes.Reason.Duplicate => "duplicate",
                global::Orb.Models.CreditNotes.Reason.Fraudulent => "fraudulent",
                global::Orb.Models.CreditNotes.Reason.OrderChange => "order_change",
                global::Orb.Models.CreditNotes.Reason.ProductUnsatisfactory =>
                    "product_unsatisfactory",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
