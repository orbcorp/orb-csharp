using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// #InvoiceApiResourceWithoutLineItems
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InvoiceListSummaryResponse, InvoiceListSummaryResponseFromRaw>)
)]
public sealed record class InvoiceListSummaryResponse : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// This is the final amount required to be charged to the customer and reflects
    /// the application of the customer balance to the `total` of the invoice.
    /// </summary>
    public required string AmountDue
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount_due"); }
        init { JsonModel.Set(this._rawData, "amount_due", value); }
    }

    public required InvoiceListSummaryResponseAutoCollection AutoCollection
    {
        get
        {
            return JsonModel.GetNotNullClass<InvoiceListSummaryResponseAutoCollection>(
                this.RawData,
                "auto_collection"
            );
        }
        init { JsonModel.Set(this._rawData, "auto_collection", value); }
    }

    public required Address? BillingAddress
    {
        get { return JsonModel.GetNullableClass<Address>(this.RawData, "billing_address"); }
        init { JsonModel.Set(this._rawData, "billing_address", value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// A list of credit notes associated with the invoice
    /// </summary>
    public required IReadOnlyList<InvoiceListSummaryResponseCreditNote> CreditNotes
    {
        get
        {
            return JsonModel.GetNotNullClass<List<InvoiceListSummaryResponseCreditNote>>(
                this.RawData,
                "credit_notes"
            );
        }
        init { JsonModel.Set(this._rawData, "credit_notes", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or `credits`
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    public required CustomerMinified Customer
    {
        get { return JsonModel.GetNotNullClass<CustomerMinified>(this.RawData, "customer"); }
        init { JsonModel.Set(this._rawData, "customer", value); }
    }

    public required IReadOnlyList<InvoiceListSummaryResponseCustomerBalanceTransaction> CustomerBalanceTransactions
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<InvoiceListSummaryResponseCustomerBalanceTransaction>
            >(this.RawData, "customer_balance_transactions");
        }
        init { JsonModel.Set(this._rawData, "customer_balance_transactions", value); }
    }

    /// <summary>
    /// Tax IDs are commonly required to be displayed on customer invoices, which
    /// are added to the headers of invoices.
    ///
    /// <para>### Supported Tax ID Countries and Types</para>
    ///
    /// <para>| Country | Type | Description | |---------|------|-------------| |
    /// Albania | `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt`
    /// | Andorran NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number
    /// | | Argentina | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin`
    /// | Armenia Tax Identification Number | | Aruba | `aw_tin` | Aruba Tax Identification
    /// Number | | Australia | `au_abn` | Australian Business Number (AU ABN) | |
    /// Australia | `au_arn` | Australian Taxation Office Reference Number | | Austria
    /// | `eu_vat` | European VAT Number | | Azerbaijan | `az_tin` | Azerbaijan Tax
    /// Identification Number | | Bahamas | `bs_tin` | Bahamas Tax Identification
    /// Number | | Bahrain | `bh_vat` | Bahraini VAT Number | | Bangladesh | `bd_bin`
    /// | Bangladesh Business Identification Number | | Barbados | `bb_tin` | Barbados
    /// Tax Identification Number | | Belarus | `by_tin` | Belarus TIN Number | |
    /// Belgium | `eu_vat` | European VAT Number | | Benin | `bj_ifu` | Benin Tax
    /// Identification Number (Identifiant Fiscal Unique) | | Bolivia | `bo_tin`
    /// | Bolivian Tax ID | | Bosnia and Herzegovina | `ba_tin` | Bosnia and Herzegovina
    /// Tax Identification Number | | Brazil | `br_cnpj` | Brazilian CNPJ Number |
    /// | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria | `bg_uic` | Bulgaria
    /// Unified Identification Code | | Bulgaria | `eu_vat` | European VAT Number
    /// | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification Number (Numéro
    /// d'Identifiant Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia Tax Identification
    /// Number | | Cameroon | `cm_niu` | Cameroon Tax Identification Number (Numéro
    /// d'Identifiant fiscal Unique) | | Canada | `ca_bn` | Canadian BN | | Canada
    /// | `ca_gst_hst` | Canadian GST/HST Number | | Canada | `ca_pst_bc` | Canadian
    /// PST Number (British Columbia) | | Canada | `ca_pst_mb` | Canadian PST Number
    /// (Manitoba) | | Canada | `ca_pst_sk` | Canadian PST Number (Saskatchewan) |
    /// | Canada | `ca_qst` | Canadian QST Number (Québec) | | Cape Verde | `cv_nif`
    /// | Cape Verde Tax Identification Number (Número de Identificação Fiscal) |
    /// | Chile | `cl_tin` | Chilean TIN | | China | `cn_tin` | Chinese Tax ID | |
    /// Colombia | `co_nit` | Colombian NIT Number | | Congo-Kinshasa | `cd_nif`
    /// | Congo (DR) Tax Identification Number (Número de Identificação Fiscal) |
    /// | Costa Rica | `cr_tin` | Costa Rican Tax ID | | Croatia | `eu_vat` | European
    /// VAT Number | | Croatia | `hr_oib` | Croatian Personal Identification Number
    /// (OIB) | | Cyprus | `eu_vat` | European VAT Number | | Czech Republic | `eu_vat`
    /// | European VAT Number | | Denmark | `eu_vat` | European VAT Number | | Dominican
    /// Republic | `do_rcn` | Dominican RCN Number | | Ecuador | `ec_ruc` | Ecuadorian
    /// RUC Number | | Egypt | `eg_tin` | Egyptian Tax Identification Number | |
    /// El Salvador | `sv_nit` | El Salvadorian NIT Number | | Estonia | `eu_vat`
    /// | European VAT Number | | Ethiopia | `et_tin` | Ethiopia Tax Identification
    /// Number | | European Union | `eu_oss_vat` | European One Stop Shop VAT Number
    /// for non-Union scheme | | Finland | `eu_vat` | European VAT Number | | France
    /// | `eu_vat` | European VAT Number | | Georgia | `ge_vat` | Georgian VAT | |
    /// Germany | `de_stn` | German Tax Number (Steuernummer) | | Germany | `eu_vat`
    /// | European VAT Number | | Greece | `eu_vat` | European VAT Number | | Guinea
    /// | `gn_nif` | Guinea Tax Identification Number (Número de Identificação Fiscal)
    /// | | Hong Kong | `hk_br` | Hong Kong BR Number | | Hungary | `eu_vat` | European
    /// VAT Number | | Hungary | `hu_tin` | Hungary Tax Number (adószám) | | Iceland
    /// | `is_vat` | Icelandic VAT | | India | `in_gst` | Indian GST Number | | Indonesia
    /// | `id_npwp` | Indonesian NPWP Number | | Ireland | `eu_vat` | European VAT
    /// Number | | Israel | `il_vat` | Israel VAT | | Italy | `eu_vat` | European
    /// VAT Number | | Japan | `jp_cn` | Japanese Corporate Number (*Hōjin Bangō*)
    /// | | Japan | `jp_rn` | Japanese Registered Foreign Businesses' Registration
    /// Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*) | | Japan | `jp_trn` |
    /// Japanese Tax Registration Number (*Tōroku Bangō*) | | Kazakhstan | `kz_bin`
    /// | Kazakhstani Business Identification Number | | Kenya | `ke_pin` | Kenya
    /// Revenue Authority Personal Identification Number | | Kyrgyzstan | `kg_tin`
    /// | Kyrgyzstan Tax Identification Number | | Laos | `la_tin` | Laos Tax Identification
    /// Number | | Latvia | `eu_vat` | European VAT Number | | Liechtenstein | `li_uid`
    /// | Liechtensteinian UID Number | | Liechtenstein | `li_vat` | Liechtenstein
    /// VAT Number | | Lithuania | `eu_vat` | European VAT Number | | Luxembourg
    /// | `eu_vat` | European VAT Number | | Malaysia | `my_frp` | Malaysian FRP
    /// Number | | Malaysia | `my_itn` | Malaysian ITN | | Malaysia | `my_sst` | Malaysian
    /// SST Number | | Malta | `eu_vat` | European VAT Number | | Mauritania | `mr_nif`
    /// | Mauritania Tax Identification Number (Número de Identificação Fiscal) |
    /// | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova | `md_vat` | Moldova
    /// VAT Number | | Montenegro | `me_pib` | Montenegro PIB Number | | Morocco |
    /// `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal PAN Number | |
    /// Netherlands | `eu_vat` | European VAT Number | | New Zealand | `nz_gst` |
    /// New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification
    /// Number | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern
    /// Ireland | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` |
    /// Norwegian VAT Number | | Norway | `no_voec` | Norwegian VAT on e-commerce
    /// Number | | Oman | `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian
    /// RUC Number | | Philippines | `ph_tin` | Philippines Tax Identification Number
    /// | | Poland | `eu_vat` | European VAT Number | | Portugal | `eu_vat` | European
    /// VAT Number | | Romania | `eu_vat` | European VAT Number | | Romania | `ro_tin`
    /// | Romanian Tax ID Number | | Russia | `ru_inn` | Russian INN | | Russia |
    /// `ru_kpp` | Russian KPP | | Saudi Arabia | `sa_vat` | Saudi Arabia VAT | |
    /// Senegal | `sn_ninea` | Senegal NINEA Number | | Serbia | `rs_pib` | Serbian
    /// PIB Number | | Singapore | `sg_gst` | Singaporean GST | | Singapore | `sg_uen`
    /// | Singaporean UEN | | Slovakia | `eu_vat` | European VAT Number | | Slovenia
    /// | `eu_vat` | European VAT Number | | Slovenia | `si_tin` | Slovenia Tax Number
    /// (davčna številka) | | South Africa | `za_vat` | South African VAT Number |
    /// | South Korea | `kr_brn` | Korean BRN | | Spain | `es_cif` | Spanish NIF
    /// Number (previously Spanish CIF Number) | | Spain | `eu_vat` | European VAT
    /// Number | | Suriname | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat`
    /// | European VAT Number | | Switzerland | `ch_uid` | Switzerland UID Number
    /// | | Switzerland | `ch_vat` | Switzerland VAT Number | | Taiwan | `tw_vat`
    /// | Taiwanese VAT | | Tajikistan | `tj_tin` | Tajikistan Tax Identification
    /// Number | | Tanzania | `tz_vat` | Tanzania VAT Number | | Thailand | `th_vat`
    /// | Thai VAT | | Turkey | `tr_tin` | Turkish Tax Identification Number | | Uganda
    /// | `ug_tin` | Uganda Tax Identification Number | | Ukraine | `ua_vat` | Ukrainian
    /// VAT | | United Arab Emirates | `ae_trn` | United Arab Emirates TRN | | United
    /// Kingdom | `gb_vat` | United Kingdom VAT Number | | United States | `us_ein`
    /// | United States EIN | | Uruguay | `uy_ruc` | Uruguayan RUC Number | | Uzbekistan
    /// | `uz_tin` | Uzbekistan TIN Number | | Uzbekistan | `uz_vat` | Uzbekistan
    /// VAT Number | | Venezuela | `ve_rif` | Venezuelan RIF Number | | Vietnam |
    /// `vn_tin` | Vietnamese Tax ID Number | | Zambia | `zm_tin` | Zambia Tax Identification
    /// Number | | Zimbabwe | `zw_tin` | Zimbabwe Tax Identification Number |</para>
    /// </summary>
    public required CustomerTaxID? CustomerTaxID
    {
        get { return JsonModel.GetNullableClass<CustomerTaxID>(this.RawData, "customer_tax_id"); }
        init { JsonModel.Set(this._rawData, "customer_tax_id", value); }
    }

    /// <summary>
    /// When the invoice payment is due. The due date is null if the invoice is not
    /// yet finalized.
    /// </summary>
    public required System::DateTimeOffset? DueDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "due_date");
        }
        init { JsonModel.Set(this._rawData, "due_date", value); }
    }

    /// <summary>
    /// If the invoice has a status of `draft`, this will be the time that the invoice
    /// will be eligible to be issued, otherwise it will be `null`. If `auto-issue`
    /// is true, the invoice will automatically begin issuing at this time.
    /// </summary>
    public required System::DateTimeOffset? EligibleToIssueAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "eligible_to_issue_at"
            );
        }
        init { JsonModel.Set(this._rawData, "eligible_to_issue_at", value); }
    }

    /// <summary>
    /// A URL for the customer-facing invoice portal. This URL expires 30 days after
    /// the invoice's due date, or 60 days after being re-generated through the UI.
    /// </summary>
    public required string? HostedInvoiceUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "hosted_invoice_url"); }
        init { JsonModel.Set(this._rawData, "hosted_invoice_url", value); }
    }

    /// <summary>
    /// The scheduled date of the invoice
    /// </summary>
    public required System::DateTimeOffset InvoiceDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "invoice_date");
        }
        init { JsonModel.Set(this._rawData, "invoice_date", value); }
    }

    /// <summary>
    /// Automatically generated invoice number to help track and reconcile invoices.
    /// Invoice numbers have a prefix such as `RFOBWG`. These can be sequential per
    /// account or customer.
    /// </summary>
    public required string InvoiceNumber
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "invoice_number"); }
        init { JsonModel.Set(this._rawData, "invoice_number", value); }
    }

    /// <summary>
    /// The link to download the PDF representation of the `Invoice`.
    /// </summary>
    public required string? InvoicePdf
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "invoice_pdf"); }
        init { JsonModel.Set(this._rawData, "invoice_pdf", value); }
    }

    public required ApiEnum<string, InvoiceListSummaryResponseInvoiceSource> InvoiceSource
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, InvoiceListSummaryResponseInvoiceSource>
            >(this.RawData, "invoice_source");
        }
        init { JsonModel.Set(this._rawData, "invoice_source", value); }
    }

    /// <summary>
    /// If the invoice failed to issue, this will be the last time it failed to issue
    /// (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssueFailedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "issue_failed_at"
            );
        }
        init { JsonModel.Set(this._rawData, "issue_failed_at", value); }
    }

    /// <summary>
    /// If the invoice has been issued, this will be the time it transitioned to
    /// `issued` (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssuedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "issued_at");
        }
        init { JsonModel.Set(this._rawData, "issued_at", value); }
    }

    /// <summary>
    /// Free-form text which is available on the invoice PDF and the Orb invoice portal.
    /// </summary>
    public required string? Memo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "memo"); }
        init { JsonModel.Set(this._rawData, "memo", value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { JsonModel.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// If the invoice has a status of `paid`, this gives a timestamp when the invoice
    /// was paid.
    /// </summary>
    public required System::DateTimeOffset? PaidAt
    {
        get { return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "paid_at"); }
        init { JsonModel.Set(this._rawData, "paid_at", value); }
    }

    /// <summary>
    /// A list of payment attempts associated with the invoice
    /// </summary>
    public required IReadOnlyList<InvoiceListSummaryResponsePaymentAttempt> PaymentAttempts
    {
        get
        {
            return JsonModel.GetNotNullClass<List<InvoiceListSummaryResponsePaymentAttempt>>(
                this.RawData,
                "payment_attempts"
            );
        }
        init { JsonModel.Set(this._rawData, "payment_attempts", value); }
    }

    /// <summary>
    /// If payment was attempted on this invoice but failed, this will be the time
    /// of the most recent attempt.
    /// </summary>
    public required System::DateTimeOffset? PaymentFailedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "payment_failed_at"
            );
        }
        init { JsonModel.Set(this._rawData, "payment_failed_at", value); }
    }

    /// <summary>
    /// If payment was attempted on this invoice, this will be the start time of
    /// the most recent attempt. This field is especially useful for delayed-notification
    /// payment mechanisms (like bank transfers), where payment can take 3 days or more.
    /// </summary>
    public required System::DateTimeOffset? PaymentStartedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "payment_started_at"
            );
        }
        init { JsonModel.Set(this._rawData, "payment_started_at", value); }
    }

    /// <summary>
    /// If the invoice is in draft, this timestamp will reflect when the invoice is
    /// scheduled to be issued.
    /// </summary>
    public required System::DateTimeOffset? ScheduledIssueAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "scheduled_issue_at"
            );
        }
        init { JsonModel.Set(this._rawData, "scheduled_issue_at", value); }
    }

    public required Address? ShippingAddress
    {
        get { return JsonModel.GetNullableClass<Address>(this.RawData, "shipping_address"); }
        init { JsonModel.Set(this._rawData, "shipping_address", value); }
    }

    public required ApiEnum<string, InvoiceListSummaryResponseStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, InvoiceListSummaryResponseStatus>>(
                this.RawData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    public required SubscriptionMinified? Subscription
    {
        get
        {
            return JsonModel.GetNullableClass<SubscriptionMinified>(this.RawData, "subscription");
        }
        init { JsonModel.Set(this._rawData, "subscription", value); }
    }

    /// <summary>
    /// If the invoice failed to sync, this will be the last time an external invoicing
    /// provider sync was attempted. This field will always be `null` for invoices
    /// using Orb Invoicing.
    /// </summary>
    public required System::DateTimeOffset? SyncFailedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "sync_failed_at"
            );
        }
        init { JsonModel.Set(this._rawData, "sync_failed_at", value); }
    }

    /// <summary>
    /// The total after any minimums and discounts have been applied.
    /// </summary>
    public required string Total
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    /// <summary>
    /// If the invoice has a status of `void`, this gives a timestamp when the invoice
    /// was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "voided_at");
        }
        init { JsonModel.Set(this._rawData, "voided_at", value); }
    }

    /// <summary>
    /// This is true if the invoice will be automatically issued in the future, and
    /// false otherwise.
    /// </summary>
    public required bool WillAutoIssue
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "will_auto_issue"); }
        init { JsonModel.Set(this._rawData, "will_auto_issue", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AmountDue;
        this.AutoCollection.Validate();
        this.BillingAddress?.Validate();
        _ = this.CreatedAt;
        foreach (var item in this.CreditNotes)
        {
            item.Validate();
        }
        _ = this.Currency;
        this.Customer.Validate();
        foreach (var item in this.CustomerBalanceTransactions)
        {
            item.Validate();
        }
        this.CustomerTaxID?.Validate();
        _ = this.DueDate;
        _ = this.EligibleToIssueAt;
        _ = this.HostedInvoiceUrl;
        _ = this.InvoiceDate;
        _ = this.InvoiceNumber;
        _ = this.InvoicePdf;
        this.InvoiceSource.Validate();
        _ = this.IssueFailedAt;
        _ = this.IssuedAt;
        _ = this.Memo;
        _ = this.Metadata;
        _ = this.PaidAt;
        foreach (var item in this.PaymentAttempts)
        {
            item.Validate();
        }
        _ = this.PaymentFailedAt;
        _ = this.PaymentStartedAt;
        _ = this.ScheduledIssueAt;
        this.ShippingAddress?.Validate();
        this.Status.Validate();
        this.Subscription?.Validate();
        _ = this.SyncFailedAt;
        _ = this.Total;
        _ = this.VoidedAt;
        _ = this.WillAutoIssue;
    }

    public InvoiceListSummaryResponse() { }

    public InvoiceListSummaryResponse(InvoiceListSummaryResponse invoiceListSummaryResponse)
        : base(invoiceListSummaryResponse) { }

    public InvoiceListSummaryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryResponseFromRaw : IFromRawJson<InvoiceListSummaryResponse>
{
    /// <inheritdoc/>
    public InvoiceListSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceListSummaryResponseAutoCollection,
        InvoiceListSummaryResponseAutoCollectionFromRaw
    >)
)]
public sealed record class InvoiceListSummaryResponseAutoCollection : JsonModel
{
    /// <summary>
    /// True only if auto-collection is enabled for this invoice.
    /// </summary>
    public required bool? Enabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "enabled"); }
        init { JsonModel.Set(this._rawData, "enabled", value); }
    }

    /// <summary>
    /// If the invoice is scheduled for auto-collection, this field will reflect when
    /// the next attempt will occur. If dunning has been exhausted, or auto-collection
    /// is not enabled for this invoice, this field will be `null`.
    /// </summary>
    public required System::DateTimeOffset? NextAttemptAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "next_attempt_at"
            );
        }
        init { JsonModel.Set(this._rawData, "next_attempt_at", value); }
    }

    /// <summary>
    /// Number of auto-collection payment attempts.
    /// </summary>
    public required long? NumAttempts
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "num_attempts"); }
        init { JsonModel.Set(this._rawData, "num_attempts", value); }
    }

    /// <summary>
    /// If Orb has ever attempted payment auto-collection for this invoice, this field
    /// will reflect when that attempt occurred. In conjunction with `next_attempt_at`,
    /// this can be used to tell whether the invoice is currently in dunning (that
    /// is, `previously_attempted_at` is non-null, and `next_attempt_time` is non-null),
    /// or if dunning has been exhausted (`previously_attempted_at` is non-null, but
    /// `next_attempt_time` is null).
    /// </summary>
    public required System::DateTimeOffset? PreviouslyAttemptedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "previously_attempted_at"
            );
        }
        init { JsonModel.Set(this._rawData, "previously_attempted_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.NextAttemptAt;
        _ = this.NumAttempts;
        _ = this.PreviouslyAttemptedAt;
    }

    public InvoiceListSummaryResponseAutoCollection() { }

    public InvoiceListSummaryResponseAutoCollection(
        InvoiceListSummaryResponseAutoCollection invoiceListSummaryResponseAutoCollection
    )
        : base(invoiceListSummaryResponseAutoCollection) { }

    public InvoiceListSummaryResponseAutoCollection(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryResponseAutoCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryResponseAutoCollectionFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryResponseAutoCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryResponseAutoCollectionFromRaw
    : IFromRawJson<InvoiceListSummaryResponseAutoCollection>
{
    /// <inheritdoc/>
    public InvoiceListSummaryResponseAutoCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryResponseAutoCollection.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceListSummaryResponseCreditNote,
        InvoiceListSummaryResponseCreditNoteFromRaw
    >)
)]
public sealed record class InvoiceListSummaryResponseCreditNote : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required string CreditNoteNumber
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "credit_note_number"); }
        init { JsonModel.Set(this._rawData, "credit_note_number", value); }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "memo"); }
        init { JsonModel.Set(this._rawData, "memo", value); }
    }

    public required string Reason
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
    }

    public required string Total
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public required string Type
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// If the credit note has a status of `void`, this gives a timestamp when the
    /// credit note was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "voided_at");
        }
        init { JsonModel.Set(this._rawData, "voided_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreditNoteNumber;
        _ = this.Memo;
        _ = this.Reason;
        _ = this.Total;
        _ = this.Type;
        _ = this.VoidedAt;
    }

    public InvoiceListSummaryResponseCreditNote() { }

    public InvoiceListSummaryResponseCreditNote(
        InvoiceListSummaryResponseCreditNote invoiceListSummaryResponseCreditNote
    )
        : base(invoiceListSummaryResponseCreditNote) { }

    public InvoiceListSummaryResponseCreditNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryResponseCreditNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryResponseCreditNoteFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryResponseCreditNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryResponseCreditNoteFromRaw
    : IFromRawJson<InvoiceListSummaryResponseCreditNote>
{
    /// <inheritdoc/>
    public InvoiceListSummaryResponseCreditNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryResponseCreditNote.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceListSummaryResponseCustomerBalanceTransaction,
        InvoiceListSummaryResponseCustomerBalanceTransactionFromRaw
    >)
)]
public sealed record class InvoiceListSummaryResponseCustomerBalanceTransaction : JsonModel
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<
        string,
        InvoiceListSummaryResponseCustomerBalanceTransactionAction
    > Action
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionAction>
            >(this.RawData, "action");
        }
        init { JsonModel.Set(this._rawData, "action", value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    public required CreditNoteTiny? CreditNote
    {
        get { return JsonModel.GetNullableClass<CreditNoteTiny>(this.RawData, "credit_note"); }
        init { JsonModel.Set(this._rawData, "credit_note", value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "ending_balance"); }
        init { JsonModel.Set(this._rawData, "ending_balance", value); }
    }

    public required InvoiceTiny? Invoice
    {
        get { return JsonModel.GetNullableClass<InvoiceTiny>(this.RawData, "invoice"); }
        init { JsonModel.Set(this._rawData, "invoice", value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "starting_balance"); }
        init { JsonModel.Set(this._rawData, "starting_balance", value); }
    }

    public required ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, InvoiceListSummaryResponseCustomerBalanceTransactionType>
            >(this.RawData, "type");
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Action.Validate();
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditNote?.Validate();
        _ = this.Description;
        _ = this.EndingBalance;
        this.Invoice?.Validate();
        _ = this.StartingBalance;
        this.Type.Validate();
    }

    public InvoiceListSummaryResponseCustomerBalanceTransaction() { }

    public InvoiceListSummaryResponseCustomerBalanceTransaction(
        InvoiceListSummaryResponseCustomerBalanceTransaction invoiceListSummaryResponseCustomerBalanceTransaction
    )
        : base(invoiceListSummaryResponseCustomerBalanceTransaction) { }

    public InvoiceListSummaryResponseCustomerBalanceTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryResponseCustomerBalanceTransaction(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryResponseCustomerBalanceTransactionFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryResponseCustomerBalanceTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryResponseCustomerBalanceTransactionFromRaw
    : IFromRawJson<InvoiceListSummaryResponseCustomerBalanceTransaction>
{
    /// <inheritdoc/>
    public InvoiceListSummaryResponseCustomerBalanceTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryResponseCustomerBalanceTransaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InvoiceListSummaryResponseCustomerBalanceTransactionActionConverter))]
public enum InvoiceListSummaryResponseCustomerBalanceTransactionAction
{
    AppliedToInvoice,
    ManualAdjustment,
    ProratedRefund,
    RevertProratedRefund,
    ReturnFromVoiding,
    CreditNoteApplied,
    CreditNoteVoided,
    OverpaymentRefund,
    ExternalPayment,
    SmallInvoiceCarryover,
}

sealed class InvoiceListSummaryResponseCustomerBalanceTransactionActionConverter
    : JsonConverter<InvoiceListSummaryResponseCustomerBalanceTransactionAction>
{
    public override InvoiceListSummaryResponseCustomerBalanceTransactionAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            "manual_adjustment" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment,
            "prorated_refund" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ProratedRefund,
            "revert_prorated_refund" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund,
            "return_from_voiding" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding,
            "credit_note_applied" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied,
            "credit_note_voided" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided,
            "overpayment_refund" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund,
            "external_payment" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ExternalPayment,
            "small_invoice_carryover" =>
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover,
            _ => (InvoiceListSummaryResponseCustomerBalanceTransactionAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryResponseCustomerBalanceTransactionAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice =>
                    "applied_to_invoice",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment =>
                    "manual_adjustment",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ProratedRefund =>
                    "prorated_refund",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund =>
                    "revert_prorated_refund",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding =>
                    "return_from_voiding",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied =>
                    "credit_note_applied",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided =>
                    "credit_note_voided",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund =>
                    "overpayment_refund",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.ExternalPayment =>
                    "external_payment",
                InvoiceListSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover =>
                    "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceListSummaryResponseCustomerBalanceTransactionTypeConverter))]
public enum InvoiceListSummaryResponseCustomerBalanceTransactionType
{
    Increment,
    Decrement,
}

sealed class InvoiceListSummaryResponseCustomerBalanceTransactionTypeConverter
    : JsonConverter<InvoiceListSummaryResponseCustomerBalanceTransactionType>
{
    public override InvoiceListSummaryResponseCustomerBalanceTransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment,
            "decrement" => InvoiceListSummaryResponseCustomerBalanceTransactionType.Decrement,
            _ => (InvoiceListSummaryResponseCustomerBalanceTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryResponseCustomerBalanceTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryResponseCustomerBalanceTransactionType.Increment => "increment",
                InvoiceListSummaryResponseCustomerBalanceTransactionType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceListSummaryResponseInvoiceSourceConverter))]
public enum InvoiceListSummaryResponseInvoiceSource
{
    Subscription,
    Partial,
    OneOff,
}

sealed class InvoiceListSummaryResponseInvoiceSourceConverter
    : JsonConverter<InvoiceListSummaryResponseInvoiceSource>
{
    public override InvoiceListSummaryResponseInvoiceSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => InvoiceListSummaryResponseInvoiceSource.Subscription,
            "partial" => InvoiceListSummaryResponseInvoiceSource.Partial,
            "one_off" => InvoiceListSummaryResponseInvoiceSource.OneOff,
            _ => (InvoiceListSummaryResponseInvoiceSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryResponseInvoiceSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryResponseInvoiceSource.Subscription => "subscription",
                InvoiceListSummaryResponseInvoiceSource.Partial => "partial",
                InvoiceListSummaryResponseInvoiceSource.OneOff => "one_off",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceListSummaryResponsePaymentAttempt,
        InvoiceListSummaryResponsePaymentAttemptFromRaw
    >)
)]
public sealed record class InvoiceListSummaryResponsePaymentAttempt : JsonModel
{
    /// <summary>
    /// The ID of the payment attempt.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The amount of the payment attempt.
    /// </summary>
    public required string Amount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The time at which the payment attempt was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The payment provider that attempted to collect the payment.
    /// </summary>
    public required ApiEnum<
        string,
        InvoiceListSummaryResponsePaymentAttemptPaymentProvider
    >? PaymentProvider
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
            >(this.RawData, "payment_provider");
        }
        init { JsonModel.Set(this._rawData, "payment_provider", value); }
    }

    /// <summary>
    /// The ID of the payment attempt in the payment provider.
    /// </summary>
    public required string? PaymentProviderID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "payment_provider_id"); }
        init { JsonModel.Set(this._rawData, "payment_provider_id", value); }
    }

    /// <summary>
    /// URL to the downloadable PDF version of the receipt. This field will be `null`
    /// for payment attempts that did not succeed.
    /// </summary>
    public required string? ReceiptPdf
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "receipt_pdf"); }
        init { JsonModel.Set(this._rawData, "receipt_pdf", value); }
    }

    /// <summary>
    /// Whether the payment attempt succeeded.
    /// </summary>
    public required bool Succeeded
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "succeeded"); }
        init { JsonModel.Set(this._rawData, "succeeded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.PaymentProvider?.Validate();
        _ = this.PaymentProviderID;
        _ = this.ReceiptPdf;
        _ = this.Succeeded;
    }

    public InvoiceListSummaryResponsePaymentAttempt() { }

    public InvoiceListSummaryResponsePaymentAttempt(
        InvoiceListSummaryResponsePaymentAttempt invoiceListSummaryResponsePaymentAttempt
    )
        : base(invoiceListSummaryResponsePaymentAttempt) { }

    public InvoiceListSummaryResponsePaymentAttempt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryResponsePaymentAttempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListSummaryResponsePaymentAttemptFromRaw.FromRawUnchecked"/>
    public static InvoiceListSummaryResponsePaymentAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceListSummaryResponsePaymentAttemptFromRaw
    : IFromRawJson<InvoiceListSummaryResponsePaymentAttempt>
{
    /// <inheritdoc/>
    public InvoiceListSummaryResponsePaymentAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceListSummaryResponsePaymentAttempt.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[JsonConverter(typeof(InvoiceListSummaryResponsePaymentAttemptPaymentProviderConverter))]
public enum InvoiceListSummaryResponsePaymentAttemptPaymentProvider
{
    Stripe,
}

sealed class InvoiceListSummaryResponsePaymentAttemptPaymentProviderConverter
    : JsonConverter<InvoiceListSummaryResponsePaymentAttemptPaymentProvider>
{
    public override InvoiceListSummaryResponsePaymentAttemptPaymentProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            _ => (InvoiceListSummaryResponsePaymentAttemptPaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryResponsePaymentAttemptPaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryResponsePaymentAttemptPaymentProvider.Stripe => "stripe",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceListSummaryResponseStatusConverter))]
public enum InvoiceListSummaryResponseStatus
{
    Issued,
    Paid,
    Synced,
    Void,
    Draft,
}

sealed class InvoiceListSummaryResponseStatusConverter
    : JsonConverter<InvoiceListSummaryResponseStatus>
{
    public override InvoiceListSummaryResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issued" => InvoiceListSummaryResponseStatus.Issued,
            "paid" => InvoiceListSummaryResponseStatus.Paid,
            "synced" => InvoiceListSummaryResponseStatus.Synced,
            "void" => InvoiceListSummaryResponseStatus.Void,
            "draft" => InvoiceListSummaryResponseStatus.Draft,
            _ => (InvoiceListSummaryResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryResponseStatus.Issued => "issued",
                InvoiceListSummaryResponseStatus.Paid => "paid",
                InvoiceListSummaryResponseStatus.Synced => "synced",
                InvoiceListSummaryResponseStatus.Void => "void",
                InvoiceListSummaryResponseStatus.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
