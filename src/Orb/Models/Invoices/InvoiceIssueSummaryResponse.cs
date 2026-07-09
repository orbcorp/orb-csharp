using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    typeof(JsonModelConverter<InvoiceIssueSummaryResponse, InvoiceIssueSummaryResponseFromRaw>)
)]
public sealed record class InvoiceIssueSummaryResponse : JsonModel
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

    /// <summary>
    /// This is the final amount required to be charged to the customer and reflects
    /// the application of the customer balance to the `total` of the invoice.
    /// </summary>
    public required string AmountDue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_due");
        }
        init { this._rawData.Set("amount_due", value); }
    }

    public required InvoiceIssueSummaryResponseAutoCollection AutoCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InvoiceIssueSummaryResponseAutoCollection>(
                "auto_collection"
            );
        }
        init { this._rawData.Set("auto_collection", value); }
    }

    public required Address? BillingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("billing_address");
        }
        init { this._rawData.Set("billing_address", value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// A list of credit notes associated with the invoice
    /// </summary>
    public required IReadOnlyList<InvoiceIssueSummaryResponseCreditNote> CreditNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<InvoiceIssueSummaryResponseCreditNote>
            >("credit_notes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceIssueSummaryResponseCreditNote>>(
                "credit_notes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string or `credits`
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomerMinified Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerMinified>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    public required IReadOnlyList<InvoiceIssueSummaryResponseCustomerBalanceTransaction> CustomerBalanceTransactions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<InvoiceIssueSummaryResponseCustomerBalanceTransaction>
            >("customer_balance_transactions");
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<InvoiceIssueSummaryResponseCustomerBalanceTransaction>
            >("customer_balance_transactions", ImmutableArray.ToImmutableArray(value));
        }
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
    /// for non-Union scheme | | Faroe Islands | `fo_vat` | Faroe Islands VAT Number
    /// | | Finland | `eu_vat` | European VAT Number | | France | `eu_vat` | European
    /// VAT Number | | Georgia | `ge_vat` | Georgian VAT | | Germany | `de_stn` |
    /// German Tax Number (Steuernummer) | | Germany | `eu_vat` | European VAT Number
    /// | | Gibraltar | `gi_tin` | Gibraltar Tax Identification Number | | Greece
    /// | `eu_vat` | European VAT Number | | Guinea | `gn_nif` | Guinea Tax Identification
    /// Number (Número de Identificação Fiscal) | | Hong Kong | `hk_br` | Hong Kong
    /// BR Number | | Hungary | `eu_vat` | European VAT Number | | Hungary | `hu_tin`
    /// | Hungary Tax Number (adószám) | | Iceland | `is_vat` | Icelandic VAT | |
    /// India | `in_gst` | Indian GST Number | | Indonesia | `id_npwp` | Indonesian
    /// NPWP Number | | Ireland | `eu_vat` | European VAT Number | | Israel | `il_vat`
    /// | Israel VAT | | Italy | `eu_vat` | European VAT Number | | Italy | `it_cf`
    /// | Italian Codice Fiscale Number | | Japan | `jp_cn` | Japanese Corporate Number
    /// (*Hōjin Bangō*) | | Japan | `jp_rn` | Japanese Registered Foreign Businesses'
    /// Registration Number (*Tōroku Kokugai Jigyōsha no Tōroku Bangō*) | | Japan
    /// | `jp_trn` | Japanese Tax Registration Number (*Tōroku Bangō*) | | Kazakhstan
    /// | `kz_bin` | Kazakhstani Business Identification Number | | Kenya | `ke_pin`
    /// | Kenya Revenue Authority Personal Identification Number | | Kyrgyzstan |
    /// `kg_tin` | Kyrgyzstan Tax Identification Number | | Laos | `la_tin` | Laos
    /// Tax Identification Number | | Latvia | `eu_vat` | European VAT Number | |
    /// Liechtenstein | `li_uid` | Liechtensteinian UID Number | | Liechtenstein |
    /// `li_vat` | Liechtenstein VAT Number | | Lithuania | `eu_vat` | European VAT
    /// Number | | Luxembourg | `eu_vat` | European VAT Number | | Malaysia | `my_frp`
    /// | Malaysian FRP Number | | Malaysia | `my_itn` | Malaysian ITN | | Malaysia
    /// | `my_sst` | Malaysian SST Number | | Malta | `eu_vat` | European VAT Number
    /// | | Mauritania | `mr_nif` | Mauritania Tax Identification Number (Número de
    /// Identificação Fiscal) | | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova
    /// | `md_vat` | Moldova VAT Number | | Montenegro | `me_pib` | Montenegro PIB
    /// Number | | Morocco | `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` |
    /// Nepal PAN Number | | Netherlands | `eu_vat` | European VAT Number | | New
    /// Zealand | `nz_gst` | New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian
    /// Tax Identification Number | | North Macedonia | `mk_vat` | North Macedonia
    /// VAT Number | | Northern Ireland | `eu_vat` | Northern Ireland VAT Number |
    /// | Norway | `no_vat` | Norwegian VAT Number | | Norway | `no_voec` | Norwegian
    /// VAT on e-commerce Number | | Oman | `om_vat` | Omani VAT Number | | Paraguay
    /// | `py_ruc` | Paraguayan RUC Number | | Peru | `pe_ruc` | Peruvian RUC Number
    /// | | Philippines | `ph_tin` | Philippines Tax Identification Number | | Poland
    /// | `eu_vat` | European VAT Number | | Poland | `pl_nip` | Polish Tax ID Number
    /// | | Portugal | `eu_vat` | European VAT Number | | Romania | `eu_vat` | European
    /// VAT Number | | Romania | `ro_tin` | Romanian Tax ID Number | | Russia | `ru_inn`
    /// | Russian INN | | Russia | `ru_kpp` | Russian KPP | | Saudi Arabia | `sa_vat`
    /// | Saudi Arabia VAT | | Senegal | `sn_ninea` | Senegal NINEA Number | | Serbia
    /// | `rs_pib` | Serbian PIB Number | | Singapore | `sg_gst` | Singaporean GST
    /// | | Singapore | `sg_uen` | Singaporean UEN | | Slovakia | `eu_vat` | European
    /// VAT Number | | Slovenia | `eu_vat` | European VAT Number | | Slovenia | `si_tin`
    /// | Slovenia Tax Number (davčna številka) | | South Africa | `za_vat` | South
    /// African VAT Number | | South Korea | `kr_brn` | Korean BRN | | Spain | `es_cif`
    /// | Spanish NIF Number (previously Spanish CIF Number) | | Spain | `eu_vat`
    /// | European VAT Number | | Sri Lanka | `lk_vat` | Sri Lanka VAT Number | |
    /// Suriname | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat` | European
    /// VAT Number | | Switzerland | `ch_uid` | Switzerland UID Number | | Switzerland
    /// | `ch_vat` | Switzerland VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT
    /// | | Tajikistan | `tj_tin` | Tajikistan Tax Identification Number | | Tanzania
    /// | `tz_vat` | Tanzania VAT Number | | Thailand | `th_vat` | Thai VAT | | Turkey
    /// | `tr_tin` | Turkish Tax Identification Number | | Uganda | `ug_tin` | Uganda
    /// Tax Identification Number | | Ukraine | `ua_vat` | Ukrainian VAT | | United
    /// Arab Emirates | `ae_trn` | United Arab Emirates TRN | | United Kingdom | `gb_vat`
    /// | United Kingdom VAT Number | | United States | `us_ein` | United States
    /// EIN | | Uruguay | `uy_ruc` | Uruguayan RUC Number | | Uzbekistan | `uz_tin`
    /// | Uzbekistan TIN Number | | Uzbekistan | `uz_vat` | Uzbekistan VAT Number
    /// | | Venezuela | `ve_rif` | Venezuelan RIF Number | | Vietnam | `vn_tin` |
    /// Vietnamese Tax ID Number | | Zambia | `zm_tin` | Zambia Tax Identification
    /// Number | | Zimbabwe | `zw_tin` | Zimbabwe Tax Identification Number |</para>
    /// </summary>
    public required CustomerTaxID? CustomerTaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerTaxID>("customer_tax_id");
        }
        init { this._rawData.Set("customer_tax_id", value); }
    }

    /// <summary>
    /// When the invoice payment is due. The due date is null if the invoice is not
    /// yet finalized.
    /// </summary>
    public required System::DateTimeOffset? DueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("due_date");
        }
        init { this._rawData.Set("due_date", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("eligible_to_issue_at");
        }
        init { this._rawData.Set("eligible_to_issue_at", value); }
    }

    /// <summary>
    /// A URL for the customer-facing invoice portal. This URL expires 60 days after
    /// the link is generated, or 30 days after the invoice's due date — whichever
    /// is later.
    /// </summary>
    public required string? HostedInvoiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hosted_invoice_url");
        }
        init { this._rawData.Set("hosted_invoice_url", value); }
    }

    /// <summary>
    /// The scheduled date of the invoice
    /// </summary>
    public required System::DateTimeOffset InvoiceDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("invoice_date");
        }
        init { this._rawData.Set("invoice_date", value); }
    }

    /// <summary>
    /// Automatically generated invoice number to help track and reconcile invoices.
    /// Invoice numbers have a prefix such as `RFOBWG`. These can be sequential per
    /// account or customer.
    /// </summary>
    public required string InvoiceNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_number");
        }
        init { this._rawData.Set("invoice_number", value); }
    }

    /// <summary>
    /// The link to download the PDF representation of the `Invoice`.
    /// </summary>
    public required string? InvoicePdf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("invoice_pdf");
        }
        init { this._rawData.Set("invoice_pdf", value); }
    }

    public required ApiEnum<string, InvoiceIssueSummaryResponseInvoiceSource> InvoiceSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceIssueSummaryResponseInvoiceSource>
            >("invoice_source");
        }
        init { this._rawData.Set("invoice_source", value); }
    }

    /// <summary>
    /// If the invoice failed to issue, this will be the last time it failed to issue
    /// (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssueFailedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("issue_failed_at");
        }
        init { this._rawData.Set("issue_failed_at", value); }
    }

    /// <summary>
    /// If the invoice has been issued, this will be the time it transitioned to
    /// `issued` (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssuedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("issued_at");
        }
        init { this._rawData.Set("issued_at", value); }
    }

    /// <summary>
    /// Free-form text which is available on the invoice PDF and the Orb invoice portal.
    /// </summary>
    public required string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// If the invoice has a status of `paid`, this gives a timestamp when the invoice
    /// was paid.
    /// </summary>
    public required System::DateTimeOffset? PaidAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("paid_at");
        }
        init { this._rawData.Set("paid_at", value); }
    }

    /// <summary>
    /// A list of payment attempts associated with the invoice
    /// </summary>
    public required IReadOnlyList<InvoiceIssueSummaryResponsePaymentAttempt> PaymentAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<InvoiceIssueSummaryResponsePaymentAttempt>
            >("payment_attempts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<InvoiceIssueSummaryResponsePaymentAttempt>>(
                "payment_attempts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If payment was attempted on this invoice but failed, this will be the time
    /// of the most recent attempt.
    /// </summary>
    public required System::DateTimeOffset? PaymentFailedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("payment_failed_at");
        }
        init { this._rawData.Set("payment_failed_at", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("payment_started_at");
        }
        init { this._rawData.Set("payment_started_at", value); }
    }

    /// <summary>
    /// If the invoice is in draft, this timestamp will reflect when the invoice is
    /// scheduled to be issued.
    /// </summary>
    public required System::DateTimeOffset? ScheduledIssueAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("scheduled_issue_at");
        }
        init { this._rawData.Set("scheduled_issue_at", value); }
    }

    public required Address? ShippingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Address>("shipping_address");
        }
        init { this._rawData.Set("shipping_address", value); }
    }

    public required ApiEnum<string, InvoiceIssueSummaryResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceIssueSummaryResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required SubscriptionMinified? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionMinified>("subscription");
        }
        init { this._rawData.Set("subscription", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("sync_failed_at");
        }
        init { this._rawData.Set("sync_failed_at", value); }
    }

    /// <summary>
    /// The total after any minimums and discounts have been applied.
    /// </summary>
    public required string Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// If the invoice has a status of `void`, this gives a timestamp when the invoice
    /// was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("voided_at");
        }
        init { this._rawData.Set("voided_at", value); }
    }

    /// <summary>
    /// This is true if the invoice will be automatically issued in the future, and
    /// false otherwise.
    /// </summary>
    public required bool WillAutoIssue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("will_auto_issue");
        }
        init { this._rawData.Set("will_auto_issue", value); }
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

    public InvoiceIssueSummaryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceIssueSummaryResponse(InvoiceIssueSummaryResponse invoiceIssueSummaryResponse)
        : base(invoiceIssueSummaryResponse) { }
#pragma warning restore CS8618

    public InvoiceIssueSummaryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceIssueSummaryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceIssueSummaryResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceIssueSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceIssueSummaryResponseFromRaw : IFromRawJson<InvoiceIssueSummaryResponse>
{
    /// <inheritdoc/>
    public InvoiceIssueSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceIssueSummaryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceIssueSummaryResponseAutoCollection,
        InvoiceIssueSummaryResponseAutoCollectionFromRaw
    >)
)]
public sealed record class InvoiceIssueSummaryResponseAutoCollection : JsonModel
{
    /// <summary>
    /// True only if auto-collection is enabled for this invoice.
    /// </summary>
    public required bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("next_attempt_at");
        }
        init { this._rawData.Set("next_attempt_at", value); }
    }

    /// <summary>
    /// Number of auto-collection payment attempts.
    /// </summary>
    public required long? NumAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_attempts");
        }
        init { this._rawData.Set("num_attempts", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "previously_attempted_at"
            );
        }
        init { this._rawData.Set("previously_attempted_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.NextAttemptAt;
        _ = this.NumAttempts;
        _ = this.PreviouslyAttemptedAt;
    }

    public InvoiceIssueSummaryResponseAutoCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceIssueSummaryResponseAutoCollection(
        InvoiceIssueSummaryResponseAutoCollection invoiceIssueSummaryResponseAutoCollection
    )
        : base(invoiceIssueSummaryResponseAutoCollection) { }
#pragma warning restore CS8618

    public InvoiceIssueSummaryResponseAutoCollection(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceIssueSummaryResponseAutoCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceIssueSummaryResponseAutoCollectionFromRaw.FromRawUnchecked"/>
    public static InvoiceIssueSummaryResponseAutoCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceIssueSummaryResponseAutoCollectionFromRaw
    : IFromRawJson<InvoiceIssueSummaryResponseAutoCollection>
{
    /// <inheritdoc/>
    public InvoiceIssueSummaryResponseAutoCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceIssueSummaryResponseAutoCollection.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceIssueSummaryResponseCreditNote,
        InvoiceIssueSummaryResponseCreditNoteFromRaw
    >)
)]
public sealed record class InvoiceIssueSummaryResponseCreditNote : JsonModel
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

    public required string CreditNoteNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_note_number");
        }
        init { this._rawData.Set("credit_note_number", value); }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
    }

    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    public required string Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// If the credit note has a status of `void`, this gives a timestamp when the
    /// credit note was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("voided_at");
        }
        init { this._rawData.Set("voided_at", value); }
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

    public InvoiceIssueSummaryResponseCreditNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceIssueSummaryResponseCreditNote(
        InvoiceIssueSummaryResponseCreditNote invoiceIssueSummaryResponseCreditNote
    )
        : base(invoiceIssueSummaryResponseCreditNote) { }
#pragma warning restore CS8618

    public InvoiceIssueSummaryResponseCreditNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceIssueSummaryResponseCreditNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceIssueSummaryResponseCreditNoteFromRaw.FromRawUnchecked"/>
    public static InvoiceIssueSummaryResponseCreditNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceIssueSummaryResponseCreditNoteFromRaw
    : IFromRawJson<InvoiceIssueSummaryResponseCreditNote>
{
    /// <inheritdoc/>
    public InvoiceIssueSummaryResponseCreditNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceIssueSummaryResponseCreditNote.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        InvoiceIssueSummaryResponseCustomerBalanceTransaction,
        InvoiceIssueSummaryResponseCustomerBalanceTransactionFromRaw
    >)
)]
public sealed record class InvoiceIssueSummaryResponseCustomerBalanceTransaction : JsonModel
{
    /// <summary>
    /// A unique id for this transaction.
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

    public required ApiEnum<
        string,
        InvoiceIssueSummaryResponseCustomerBalanceTransactionAction
    > Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceIssueSummaryResponseCustomerBalanceTransactionAction>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
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
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditNoteTiny>("credit_note");
        }
        init { this._rawData.Set("credit_note", value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ending_balance");
        }
        init { this._rawData.Set("ending_balance", value); }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceTiny>("invoice");
        }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("starting_balance");
        }
        init { this._rawData.Set("starting_balance", value); }
    }

    public required ApiEnum<string, InvoiceIssueSummaryResponseCustomerBalanceTransactionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, InvoiceIssueSummaryResponseCustomerBalanceTransactionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
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

    public InvoiceIssueSummaryResponseCustomerBalanceTransaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceIssueSummaryResponseCustomerBalanceTransaction(
        InvoiceIssueSummaryResponseCustomerBalanceTransaction invoiceIssueSummaryResponseCustomerBalanceTransaction
    )
        : base(invoiceIssueSummaryResponseCustomerBalanceTransaction) { }
#pragma warning restore CS8618

    public InvoiceIssueSummaryResponseCustomerBalanceTransaction(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceIssueSummaryResponseCustomerBalanceTransaction(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceIssueSummaryResponseCustomerBalanceTransactionFromRaw.FromRawUnchecked"/>
    public static InvoiceIssueSummaryResponseCustomerBalanceTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceIssueSummaryResponseCustomerBalanceTransactionFromRaw
    : IFromRawJson<InvoiceIssueSummaryResponseCustomerBalanceTransaction>
{
    /// <inheritdoc/>
    public InvoiceIssueSummaryResponseCustomerBalanceTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceIssueSummaryResponseCustomerBalanceTransaction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InvoiceIssueSummaryResponseCustomerBalanceTransactionActionConverter))]
public enum InvoiceIssueSummaryResponseCustomerBalanceTransactionAction
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

sealed class InvoiceIssueSummaryResponseCustomerBalanceTransactionActionConverter
    : JsonConverter<InvoiceIssueSummaryResponseCustomerBalanceTransactionAction>
{
    public override InvoiceIssueSummaryResponseCustomerBalanceTransactionAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice,
            "manual_adjustment" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment,
            "prorated_refund" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ProratedRefund,
            "revert_prorated_refund" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund,
            "return_from_voiding" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding,
            "credit_note_applied" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied,
            "credit_note_voided" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided,
            "overpayment_refund" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund,
            "external_payment" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ExternalPayment,
            "small_invoice_carryover" =>
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover,
            _ => (InvoiceIssueSummaryResponseCustomerBalanceTransactionAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceIssueSummaryResponseCustomerBalanceTransactionAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.AppliedToInvoice =>
                    "applied_to_invoice",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ManualAdjustment =>
                    "manual_adjustment",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ProratedRefund =>
                    "prorated_refund",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.RevertProratedRefund =>
                    "revert_prorated_refund",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ReturnFromVoiding =>
                    "return_from_voiding",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.CreditNoteApplied =>
                    "credit_note_applied",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.CreditNoteVoided =>
                    "credit_note_voided",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.OverpaymentRefund =>
                    "overpayment_refund",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.ExternalPayment =>
                    "external_payment",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionAction.SmallInvoiceCarryover =>
                    "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceIssueSummaryResponseCustomerBalanceTransactionTypeConverter))]
public enum InvoiceIssueSummaryResponseCustomerBalanceTransactionType
{
    Increment,
    Decrement,
}

sealed class InvoiceIssueSummaryResponseCustomerBalanceTransactionTypeConverter
    : JsonConverter<InvoiceIssueSummaryResponseCustomerBalanceTransactionType>
{
    public override InvoiceIssueSummaryResponseCustomerBalanceTransactionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => InvoiceIssueSummaryResponseCustomerBalanceTransactionType.Increment,
            "decrement" => InvoiceIssueSummaryResponseCustomerBalanceTransactionType.Decrement,
            _ => (InvoiceIssueSummaryResponseCustomerBalanceTransactionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceIssueSummaryResponseCustomerBalanceTransactionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceIssueSummaryResponseCustomerBalanceTransactionType.Increment => "increment",
                InvoiceIssueSummaryResponseCustomerBalanceTransactionType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceIssueSummaryResponseInvoiceSourceConverter))]
public enum InvoiceIssueSummaryResponseInvoiceSource
{
    Subscription,
    Partial,
    OneOff,
}

sealed class InvoiceIssueSummaryResponseInvoiceSourceConverter
    : JsonConverter<InvoiceIssueSummaryResponseInvoiceSource>
{
    public override InvoiceIssueSummaryResponseInvoiceSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => InvoiceIssueSummaryResponseInvoiceSource.Subscription,
            "partial" => InvoiceIssueSummaryResponseInvoiceSource.Partial,
            "one_off" => InvoiceIssueSummaryResponseInvoiceSource.OneOff,
            _ => (InvoiceIssueSummaryResponseInvoiceSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceIssueSummaryResponseInvoiceSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceIssueSummaryResponseInvoiceSource.Subscription => "subscription",
                InvoiceIssueSummaryResponseInvoiceSource.Partial => "partial",
                InvoiceIssueSummaryResponseInvoiceSource.OneOff => "one_off",
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
        InvoiceIssueSummaryResponsePaymentAttempt,
        InvoiceIssueSummaryResponsePaymentAttemptFromRaw
    >)
)]
public sealed record class InvoiceIssueSummaryResponsePaymentAttempt : JsonModel
{
    /// <summary>
    /// The ID of the payment attempt.
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

    /// <summary>
    /// The amount of the payment attempt.
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
    /// The time at which the payment attempt was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The payment provider that attempted to collect the payment.
    /// </summary>
    public required ApiEnum<
        string,
        InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider
    >? PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider>
            >("payment_provider");
        }
        init { this._rawData.Set("payment_provider", value); }
    }

    /// <summary>
    /// The ID of the payment attempt in the payment provider.
    /// </summary>
    public required string? PaymentProviderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("payment_provider_id");
        }
        init { this._rawData.Set("payment_provider_id", value); }
    }

    /// <summary>
    /// URL to the downloadable PDF version of the receipt. This field will be `null`
    /// for payment attempts that did not succeed.
    /// </summary>
    public required string? ReceiptPdf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("receipt_pdf");
        }
        init { this._rawData.Set("receipt_pdf", value); }
    }

    /// <summary>
    /// Whether the payment attempt succeeded.
    /// </summary>
    public required bool Succeeded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("succeeded");
        }
        init { this._rawData.Set("succeeded", value); }
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

    public InvoiceIssueSummaryResponsePaymentAttempt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceIssueSummaryResponsePaymentAttempt(
        InvoiceIssueSummaryResponsePaymentAttempt invoiceIssueSummaryResponsePaymentAttempt
    )
        : base(invoiceIssueSummaryResponsePaymentAttempt) { }
#pragma warning restore CS8618

    public InvoiceIssueSummaryResponsePaymentAttempt(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceIssueSummaryResponsePaymentAttempt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceIssueSummaryResponsePaymentAttemptFromRaw.FromRawUnchecked"/>
    public static InvoiceIssueSummaryResponsePaymentAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceIssueSummaryResponsePaymentAttemptFromRaw
    : IFromRawJson<InvoiceIssueSummaryResponsePaymentAttempt>
{
    /// <inheritdoc/>
    public InvoiceIssueSummaryResponsePaymentAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InvoiceIssueSummaryResponsePaymentAttempt.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[JsonConverter(typeof(InvoiceIssueSummaryResponsePaymentAttemptPaymentProviderConverter))]
public enum InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider
{
    Stripe,
    Adyen,
}

sealed class InvoiceIssueSummaryResponsePaymentAttemptPaymentProviderConverter
    : JsonConverter<InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider>
{
    public override InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider.Stripe,
            "adyen" => InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider.Adyen,
            _ => (InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider.Stripe => "stripe",
                InvoiceIssueSummaryResponsePaymentAttemptPaymentProvider.Adyen => "adyen",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceIssueSummaryResponseStatusConverter))]
public enum InvoiceIssueSummaryResponseStatus
{
    Issued,
    Paid,
    Synced,
    Void,
    Draft,
}

sealed class InvoiceIssueSummaryResponseStatusConverter
    : JsonConverter<InvoiceIssueSummaryResponseStatus>
{
    public override InvoiceIssueSummaryResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issued" => InvoiceIssueSummaryResponseStatus.Issued,
            "paid" => InvoiceIssueSummaryResponseStatus.Paid,
            "synced" => InvoiceIssueSummaryResponseStatus.Synced,
            "void" => InvoiceIssueSummaryResponseStatus.Void,
            "draft" => InvoiceIssueSummaryResponseStatus.Draft,
            _ => (InvoiceIssueSummaryResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceIssueSummaryResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceIssueSummaryResponseStatus.Issued => "issued",
                InvoiceIssueSummaryResponseStatus.Paid => "paid",
                InvoiceIssueSummaryResponseStatus.Synced => "synced",
                InvoiceIssueSummaryResponseStatus.Void => "void",
                InvoiceIssueSummaryResponseStatus.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
