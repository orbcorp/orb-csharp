using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ChangedSubscriptionResources>))]
public sealed record class ChangedSubscriptionResources
    : ModelBase,
        IFromRaw<ChangedSubscriptionResources>
{
    /// <summary>
    /// The credit notes that were created as part of this operation.
    /// </summary>
    public required List<SharedCreditNote> CreatedCreditNotes
    {
        get
        {
            if (!this._properties.TryGetValue("created_credit_notes", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_credit_notes' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_credit_notes",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<SharedCreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'created_credit_notes' cannot be null",
                    new System::ArgumentNullException("created_credit_notes")
                );
        }
        init
        {
            this._properties["created_credit_notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The invoices that were created as part of this operation.
    /// </summary>
    public required List<CreatedInvoice> CreatedInvoices
    {
        get
        {
            if (!this._properties.TryGetValue("created_invoices", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_invoices' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_invoices",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<CreatedInvoice>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'created_invoices' cannot be null",
                    new System::ArgumentNullException("created_invoices")
                );
        }
        init
        {
            this._properties["created_invoices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The credit notes that were voided as part of this operation.
    /// </summary>
    public required List<SharedCreditNote> VoidedCreditNotes
    {
        get
        {
            if (!this._properties.TryGetValue("voided_credit_notes", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'voided_credit_notes' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "voided_credit_notes",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<SharedCreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'voided_credit_notes' cannot be null",
                    new System::ArgumentNullException("voided_credit_notes")
                );
        }
        init
        {
            this._properties["voided_credit_notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The invoices that were voided as part of this operation.
    /// </summary>
    public required List<Invoice> VoidedInvoices
    {
        get
        {
            if (!this._properties.TryGetValue("voided_invoices", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'voided_invoices' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "voided_invoices",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<Invoice>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'voided_invoices' cannot be null",
                    new System::ArgumentNullException("voided_invoices")
                );
        }
        init
        {
            this._properties["voided_invoices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.CreatedCreditNotes)
        {
            item.Validate();
        }
        foreach (var item in this.CreatedInvoices)
        {
            item.Validate();
        }
        foreach (var item in this.VoidedCreditNotes)
        {
            item.Validate();
        }
        foreach (var item in this.VoidedInvoices)
        {
            item.Validate();
        }
    }

    public ChangedSubscriptionResources() { }

    public ChangedSubscriptionResources(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChangedSubscriptionResources(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ChangedSubscriptionResources FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<CreatedInvoice>))]
public sealed record class CreatedInvoice : ModelBase, IFromRaw<CreatedInvoice>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This is the final amount required to be charged to the customer and reflects
    /// the application of the customer balance to the `total` of the invoice.
    /// </summary>
    public required string AmountDue
    {
        get
        {
            if (!this._properties.TryGetValue("amount_due", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_due' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_due",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_due' cannot be null",
                    new System::ArgumentNullException("amount_due")
                );
        }
        init
        {
            this._properties["amount_due"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required AutoCollection AutoCollection
    {
        get
        {
            if (!this._properties.TryGetValue("auto_collection", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "auto_collection",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AutoCollection>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new System::ArgumentNullException("auto_collection")
                );
        }
        init
        {
            this._properties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Address? BillingAddress
    {
        get
        {
            if (!this._properties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Address?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billing_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of credit notes associated with the invoice
    /// </summary>
    public required List<CreditNote> CreditNotes
    {
        get
        {
            if (!this._properties.TryGetValue("credit_notes", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_notes' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credit_notes",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<CreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'credit_notes' cannot be null",
                    new System::ArgumentNullException("credit_notes")
                );
        }
        init
        {
            this._properties["credit_notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this._properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        init
        {
            this._properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<CustomerBalanceTransaction> CustomerBalanceTransactions
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "customer_balance_transactions",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'customer_balance_transactions' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "customer_balance_transactions",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<CustomerBalanceTransaction>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer_balance_transactions' cannot be null",
                    new System::ArgumentNullException("customer_balance_transactions")
                );
        }
        init
        {
            this._properties["customer_balance_transactions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._properties.TryGetValue("customer_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerTaxID?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["customer_tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is deprecated in favor of `discounts`. If a `discounts` list is
    /// provided, the first discount in the list will be returned. If the list is
    /// empty, `None` will be returned.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required JsonElement Discount
    {
        get
        {
            if (!this._properties.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new System::ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<InvoiceLevelDiscount> Discounts
    {
        get
        {
            if (!this._properties.TryGetValue("discounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<InvoiceLevelDiscount>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discounts' cannot be null",
                    new System::ArgumentNullException("discounts")
                );
        }
        init
        {
            this._properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When the invoice payment is due. The due date is null if the invoice is not
    /// yet finalized.
    /// </summary>
    public required System::DateTimeOffset? DueDate
    {
        get
        {
            if (!this._properties.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("eligible_to_issue_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["eligible_to_issue_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A URL for the customer-facing invoice portal. This URL expires 30 days after
    /// the invoice's due date, or 60 days after being re-generated through the UI.
    /// </summary>
    public required string? HostedInvoiceURL
    {
        get
        {
            if (!this._properties.TryGetValue("hosted_invoice_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["hosted_invoice_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The scheduled date of the invoice
    /// </summary>
    public required System::DateTimeOffset InvoiceDate
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoice_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("invoice_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_number' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_number' cannot be null",
                    new System::ArgumentNullException("invoice_number")
                );
        }
        init
        {
            this._properties["invoice_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The link to download the PDF representation of the `Invoice`.
    /// </summary>
    public required string? InvoicePdf
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_pdf", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_pdf"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, InvoiceSource> InvoiceSource
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_source", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_source' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_source",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, InvoiceSource>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoice_source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// True if the invoice has only in-advance fixed fees and is payable now
    /// </summary>
    public required bool IsPayableNow
    {
        get
        {
            if (!this._properties.TryGetValue("is_payable_now", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'is_payable_now' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "is_payable_now",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["is_payable_now"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice failed to issue, this will be the last time it failed to issue
    /// (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssueFailedAt
    {
        get
        {
            if (!this._properties.TryGetValue("issue_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["issue_failed_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice has been issued, this will be the time it transitioned to
    /// `issued` (even if it is now in a different state.)
    /// </summary>
    public required System::DateTimeOffset? IssuedAt
    {
        get
        {
            if (!this._properties.TryGetValue("issued_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["issued_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The breakdown of prices in this invoice.
    /// </summary>
    public required List<LineItem> LineItems
    {
        get
        {
            if (!this._properties.TryGetValue("line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "line_items",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<LineItem>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentNullException("line_items")
                );
        }
        init
        {
            this._properties["line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Maximum? Maximum
    {
        get
        {
            if (!this._properties.TryGetValue("maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Maximum?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Free-form text which is available on the invoice PDF and the Orb invoice portal.
    /// </summary>
    public required string? Memo
    {
        get
        {
            if (!this._properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Minimum? Minimum
    {
        get
        {
            if (!this._properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Minimum?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this._properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("paid_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["paid_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of payment attempts associated with the invoice
    /// </summary>
    public required List<PaymentAttempt> PaymentAttempts
    {
        get
        {
            if (!this._properties.TryGetValue("payment_attempts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'payment_attempts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "payment_attempts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<PaymentAttempt>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'payment_attempts' cannot be null",
                    new System::ArgumentNullException("payment_attempts")
                );
        }
        init
        {
            this._properties["payment_attempts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("payment_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["payment_failed_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("payment_started_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["payment_started_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice is in draft, this timestamp will reflect when the invoice is
    /// scheduled to be issued.
    /// </summary>
    public required System::DateTimeOffset? ScheduledIssueAt
    {
        get
        {
            if (!this._properties.TryGetValue("scheduled_issue_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["scheduled_issue_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Address? ShippingAddress
    {
        get
        {
            if (!this._properties.TryGetValue("shipping_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Address?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["shipping_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubscriptionMinified? Subscription
    {
        get
        {
            if (!this._properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["subscription"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total before any discounts and minimums are applied.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this._properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentNullException("subtotal")
                );
        }
        init
        {
            this._properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("sync_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["sync_failed_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total after any minimums and discounts have been applied.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this._properties.TryGetValue("total", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentNullException("total")
                );
        }
        init
        {
            this._properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice has a status of `void`, this gives a timestamp when the invoice
    /// was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            if (!this._properties.TryGetValue("voided_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["voided_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This is true if the invoice will be automatically issued in the future, and
    /// false otherwise.
    /// </summary>
    public required bool WillAutoIssue
    {
        get
        {
            if (!this._properties.TryGetValue("will_auto_issue", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'will_auto_issue' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "will_auto_issue",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["will_auto_issue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        _ = this.Discount;
        foreach (var item in this.Discounts)
        {
            item.Validate();
        }
        _ = this.DueDate;
        _ = this.EligibleToIssueAt;
        _ = this.HostedInvoiceURL;
        _ = this.InvoiceDate;
        _ = this.InvoiceNumber;
        _ = this.InvoicePdf;
        this.InvoiceSource.Validate();
        _ = this.IsPayableNow;
        _ = this.IssueFailedAt;
        _ = this.IssuedAt;
        foreach (var item in this.LineItems)
        {
            item.Validate();
        }
        this.Maximum?.Validate();
        _ = this.MaximumAmount;
        _ = this.Memo;
        _ = this.Metadata;
        this.Minimum?.Validate();
        _ = this.MinimumAmount;
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
        _ = this.Subtotal;
        _ = this.SyncFailedAt;
        _ = this.Total;
        _ = this.VoidedAt;
        _ = this.WillAutoIssue;
    }

    public CreatedInvoice() { }

    public CreatedInvoice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedInvoice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CreatedInvoice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<AutoCollection>))]
public sealed record class AutoCollection : ModelBase, IFromRaw<AutoCollection>
{
    /// <summary>
    /// True only if auto-collection is enabled for this invoice.
    /// </summary>
    public required bool? Enabled
    {
        get
        {
            if (!this._properties.TryGetValue("enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("next_attempt_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["next_attempt_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of auto-collection payment attempts.
    /// </summary>
    public required long? NumAttempts
    {
        get
        {
            if (!this._properties.TryGetValue("num_attempts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["num_attempts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this._properties.TryGetValue("previously_attempted_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["previously_attempted_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.NextAttemptAt;
        _ = this.NumAttempts;
        _ = this.PreviouslyAttemptedAt;
    }

    public AutoCollection() { }

    public AutoCollection(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoCollection(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AutoCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<CreditNote>))]
public sealed record class CreditNote : ModelBase, IFromRaw<CreditNote>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string CreditNoteNumber
    {
        get
        {
            if (!this._properties.TryGetValue("credit_note_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_note_number' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credit_note_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credit_note_number' cannot be null",
                    new System::ArgumentNullException("credit_note_number")
                );
        }
        init
        {
            this._properties["credit_note_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get
        {
            if (!this._properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Reason
    {
        get
        {
            if (!this._properties.TryGetValue("reason", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'reason' cannot be null",
                    new System::ArgumentOutOfRangeException("reason", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'reason' cannot be null",
                    new System::ArgumentNullException("reason")
                );
        }
        init
        {
            this._properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Total
    {
        get
        {
            if (!this._properties.TryGetValue("total", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentNullException("total")
                );
        }
        init
        {
            this._properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentNullException("type")
                );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the credit note has a status of `void`, this gives a timestamp when the
    /// credit note was voided.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            if (!this._properties.TryGetValue("voided_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["voided_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public CreditNote() { }

    public CreditNote(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNote(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CreditNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<CustomerBalanceTransaction>))]
public sealed record class CustomerBalanceTransaction
    : ModelBase,
        IFromRaw<CustomerBalanceTransaction>
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Action> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Action>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this._properties.TryGetValue("credit_note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["credit_note"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            if (!this._properties.TryGetValue("ending_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "ending_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentNullException("ending_balance")
                );
        }
        init
        {
            this._properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this._properties.TryGetValue("invoice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceTiny?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            if (!this._properties.TryGetValue("starting_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "starting_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentNullException("starting_balance")
                );
        }
        init
        {
            this._properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Type> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public CustomerBalanceTransaction() { }

    public CustomerBalanceTransaction(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerBalanceTransaction(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CustomerBalanceTransaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ActionConverter))]
public enum Action
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

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => Action.AppliedToInvoice,
            "manual_adjustment" => Action.ManualAdjustment,
            "prorated_refund" => Action.ProratedRefund,
            "revert_prorated_refund" => Action.RevertProratedRefund,
            "return_from_voiding" => Action.ReturnFromVoiding,
            "credit_note_applied" => Action.CreditNoteApplied,
            "credit_note_voided" => Action.CreditNoteVoided,
            "overpayment_refund" => Action.OverpaymentRefund,
            "external_payment" => Action.ExternalPayment,
            "small_invoice_carryover" => Action.SmallInvoiceCarryover,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.AppliedToInvoice => "applied_to_invoice",
                Action.ManualAdjustment => "manual_adjustment",
                Action.ProratedRefund => "prorated_refund",
                Action.RevertProratedRefund => "revert_prorated_refund",
                Action.ReturnFromVoiding => "return_from_voiding",
                Action.CreditNoteApplied => "credit_note_applied",
                Action.CreditNoteVoided => "credit_note_voided",
                Action.OverpaymentRefund => "overpayment_refund",
                Action.ExternalPayment => "external_payment",
                Action.SmallInvoiceCarryover => "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Increment,
    Decrement,
}

sealed class TypeConverter : JsonConverter<global::Orb.Models.Type>
{
    public override global::Orb.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => global::Orb.Models.Type.Increment,
            "decrement" => global::Orb.Models.Type.Decrement,
            _ => (global::Orb.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Type.Increment => "increment",
                global::Orb.Models.Type.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceSourceConverter))]
public enum InvoiceSource
{
    Subscription,
    Partial,
    OneOff,
}

sealed class InvoiceSourceConverter : JsonConverter<InvoiceSource>
{
    public override InvoiceSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "subscription" => InvoiceSource.Subscription,
            "partial" => InvoiceSource.Partial,
            "one_off" => InvoiceSource.OneOff,
            _ => (InvoiceSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceSource.Subscription => "subscription",
                InvoiceSource.Partial => "partial",
                InvoiceSource.OneOff => "one_off",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<LineItem>
{
    /// <summary>
    /// A unique ID for this line item.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The line amount after any adjustments and before overage conversion, credits
    /// and partial invoicing.
    /// </summary>
    public required string AdjustedSubtotal
    {
        get
        {
            if (!this._properties.TryGetValue("adjusted_subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjusted_subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjusted_subtotal",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjusted_subtotal' cannot be null",
                    new System::ArgumentNullException("adjusted_subtotal")
                );
        }
        init
        {
            this._properties["adjusted_subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All adjustments applied to the line item in the order they were applied based
    /// on invoice calculations (ie. usage discounts -> amount discounts -> percentage
    /// discounts -> minimums -> maximums).
    /// </summary>
    public required List<Adjustment> Adjustments
    {
        get
        {
            if (!this._properties.TryGetValue("adjustments", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "adjustments",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<Adjustment>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'adjustments' cannot be null",
                    new System::ArgumentNullException("adjustments")
                );
        }
        init
        {
            this._properties["adjustments"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The final amount for a line item after all adjustments and pre paid credits
    /// have been applied.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of prepaid credits applied.
    /// </summary>
    public required string CreditsApplied
    {
        get
        {
            if (!this._properties.TryGetValue("credits_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credits_applied' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credits_applied",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credits_applied' cannot be null",
                    new System::ArgumentNullException("credits_applied")
                );
        }
        init
        {
            this._properties["credits_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the range of time applied for this line item's price.
    /// </summary>
    public required System::DateTimeOffset EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'end_date' cannot be null",
                    new System::ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An additional filter that was used to calculate the usage for this line item.
    /// </summary>
    public required string? Filter
    {
        get
        {
            if (!this._properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// [DEPRECATED] For configured prices that are split by a grouping key, this
    /// will be populated with the key and a value. The `amount` and `subtotal` will
    /// be the values for this particular grouping.
    /// </summary>
    public required string? Grouping
    {
        get
        {
            if (!this._properties.TryGetValue("grouping", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["grouping"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the price associated with this line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any amount applied from a partial invoice
    /// </summary>
    public required string PartiallyInvoicedAmount
    {
        get
        {
            if (!this._properties.TryGetValue("partially_invoiced_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'partially_invoiced_amount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "partially_invoiced_amount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'partially_invoiced_amount' cannot be null",
                    new System::ArgumentNullException("partially_invoiced_amount")
                );
        }
        init
        {
            this._properties["partially_invoiced_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Price resource represents a price that can be billed on a subscription,
    /// resulting in a charge on an invoice in the form of an invoice line item.
    /// Prices take a quantity and determine an amount to bill.
    ///
    /// <para>Orb supports a few different pricing models out of the box. Each of
    /// these models is serialized differently in a given Price object. The model_type
    /// field determines the key for the configuration object that is present.</para>
    ///
    /// <para>For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)</para>
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentOutOfRangeException("price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new System::ArgumentNullException("price")
                );
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Either the fixed fee quantity or the usage during the service period.
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the range of time applied for this line item's price.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For complex pricing structures, the line item can be broken down further
    /// in `sub_line_items`.
    /// </summary>
    public required List<SubLineItem> SubLineItems
    {
        get
        {
            if (!this._properties.TryGetValue("sub_line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'sub_line_items' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "sub_line_items",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<SubLineItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'sub_line_items' cannot be null",
                    new System::ArgumentNullException("sub_line_items")
                );
        }
        init
        {
            this._properties["sub_line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The line amount before any adjustments.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this._properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentNullException("subtotal")
                );
        }
        init
        {
            this._properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of tax rates and their incurred tax amounts. Empty if no tax integration
    /// is configured.
    /// </summary>
    public required List<TaxAmount> TaxAmounts
    {
        get
        {
            if (!this._properties.TryGetValue("tax_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_amounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<TaxAmount>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentNullException("tax_amounts")
                );
        }
        init
        {
            this._properties["tax_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of customer ids that were used to calculate the usage for this line item.
    /// </summary>
    public required List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this._properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AdjustedSubtotal;
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        _ = this.Amount;
        _ = this.CreditsApplied;
        _ = this.EndDate;
        _ = this.Filter;
        _ = this.Grouping;
        _ = this.Name;
        _ = this.PartiallyInvoicedAmount;
        this.Price.Validate();
        _ = this.Quantity;
        _ = this.StartDate;
        foreach (var item in this.SubLineItems)
        {
            item.Validate();
        }
        _ = this.Subtotal;
        foreach (var item in this.TaxAmounts)
        {
            item.Validate();
        }
        _ = this.UsageCustomerIDs;
    }

    public LineItem() { }

    public LineItem(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(AdjustmentConverter))]
public record class Adjustment
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.ID,
                monetaryAmountDiscount: (x) => x.ID,
                monetaryPercentageDiscount: (x) => x.ID,
                monetaryMinimum: (x) => x.ID,
                monetaryMaximum: (x) => x.ID
            );
        }
    }

    public string Amount
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.Amount,
                monetaryAmountDiscount: (x) => x.Amount,
                monetaryPercentageDiscount: (x) => x.Amount,
                monetaryMinimum: (x) => x.Amount,
                monetaryMaximum: (x) => x.Amount
            );
        }
    }

    public bool IsInvoiceLevel
    {
        get
        {
            return Match(
                monetaryUsageDiscount: (x) => x.IsInvoiceLevel,
                monetaryAmountDiscount: (x) => x.IsInvoiceLevel,
                monetaryPercentageDiscount: (x) => x.IsInvoiceLevel,
                monetaryMinimum: (x) => x.IsInvoiceLevel,
                monetaryMaximum: (x) => x.IsInvoiceLevel
            );
        }
    }

    public string? Reason
    {
        get
        {
            return Match<string?>(
                monetaryUsageDiscount: (x) => x.Reason,
                monetaryAmountDiscount: (x) => x.Reason,
                monetaryPercentageDiscount: (x) => x.Reason,
                monetaryMinimum: (x) => x.Reason,
                monetaryMaximum: (x) => x.Reason
            );
        }
    }

    public string? ReplacesAdjustmentID
    {
        get
        {
            return Match<string?>(
                monetaryUsageDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryAmountDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryPercentageDiscount: (x) => x.ReplacesAdjustmentID,
                monetaryMinimum: (x) => x.ReplacesAdjustmentID,
                monetaryMaximum: (x) => x.ReplacesAdjustmentID
            );
        }
    }

    public Adjustment(MonetaryUsageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryAmountDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryPercentageDiscountAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryMinimumAdjustment value)
    {
        Value = value;
    }

    public Adjustment(MonetaryMaximumAdjustment value)
    {
        Value = value;
    }

    Adjustment(UnknownVariant value)
    {
        Value = value;
    }

    public static Adjustment CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickMonetaryUsageDiscount(
        [NotNullWhen(true)] out MonetaryUsageDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryUsageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryAmountDiscount(
        [NotNullWhen(true)] out MonetaryAmountDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryAmountDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryPercentageDiscount(
        [NotNullWhen(true)] out MonetaryPercentageDiscountAdjustment? value
    )
    {
        value = this.Value as MonetaryPercentageDiscountAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryMinimum([NotNullWhen(true)] out MonetaryMinimumAdjustment? value)
    {
        value = this.Value as MonetaryMinimumAdjustment;
        return value != null;
    }

    public bool TryPickMonetaryMaximum([NotNullWhen(true)] out MonetaryMaximumAdjustment? value)
    {
        value = this.Value as MonetaryMaximumAdjustment;
        return value != null;
    }

    public void Switch(
        System::Action<MonetaryUsageDiscountAdjustment> monetaryUsageDiscount,
        System::Action<MonetaryAmountDiscountAdjustment> monetaryAmountDiscount,
        System::Action<MonetaryPercentageDiscountAdjustment> monetaryPercentageDiscount,
        System::Action<MonetaryMinimumAdjustment> monetaryMinimum,
        System::Action<MonetaryMaximumAdjustment> monetaryMaximum
    )
    {
        switch (this.Value)
        {
            case MonetaryUsageDiscountAdjustment value:
                monetaryUsageDiscount(value);
                break;
            case MonetaryAmountDiscountAdjustment value:
                monetaryAmountDiscount(value);
                break;
            case MonetaryPercentageDiscountAdjustment value:
                monetaryPercentageDiscount(value);
                break;
            case MonetaryMinimumAdjustment value:
                monetaryMinimum(value);
                break;
            case MonetaryMaximumAdjustment value:
                monetaryMaximum(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    public T Match<T>(
        System::Func<MonetaryUsageDiscountAdjustment, T> monetaryUsageDiscount,
        System::Func<MonetaryAmountDiscountAdjustment, T> monetaryAmountDiscount,
        System::Func<MonetaryPercentageDiscountAdjustment, T> monetaryPercentageDiscount,
        System::Func<MonetaryMinimumAdjustment, T> monetaryMinimum,
        System::Func<MonetaryMaximumAdjustment, T> monetaryMaximum
    )
    {
        return this.Value switch
        {
            MonetaryUsageDiscountAdjustment value => monetaryUsageDiscount(value),
            MonetaryAmountDiscountAdjustment value => monetaryAmountDiscount(value),
            MonetaryPercentageDiscountAdjustment value => monetaryPercentageDiscount(value),
            MonetaryMinimumAdjustment value => monetaryMinimum(value),
            MonetaryMaximumAdjustment value => monetaryMaximum(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Adjustment"),
        };
    }

    public static implicit operator Adjustment(MonetaryUsageDiscountAdjustment value) => new(value);

    public static implicit operator Adjustment(MonetaryAmountDiscountAdjustment value) =>
        new(value);

    public static implicit operator Adjustment(MonetaryPercentageDiscountAdjustment value) =>
        new(value);

    public static implicit operator Adjustment(MonetaryMinimumAdjustment value) => new(value);

    public static implicit operator Adjustment(MonetaryMaximumAdjustment value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Adjustment");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AdjustmentConverter : JsonConverter<Adjustment>
{
    public override Adjustment? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? adjustmentType;
        try
        {
            adjustmentType = json.GetProperty("adjustment_type").GetString();
        }
        catch
        {
            adjustmentType = null;
        }

        switch (adjustmentType)
        {
            case "usage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryUsageDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryUsageDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amount_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryAmountDiscountAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryAmountDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "percentage_discount":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<MonetaryPercentageDiscountAdjustment>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryPercentageDiscountAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "minimum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryMinimumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryMinimumAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "maximum":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MonetaryMaximumAdjustment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Adjustment(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MonetaryMaximumAdjustment'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Adjustment value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(SubLineItemConverter))]
public record class SubLineItem
{
    public object Value { get; private init; }

    public string Amount
    {
        get
        {
            return Match(matrix: (x) => x.Amount, tier: (x) => x.Amount, other: (x) => x.Amount);
        }
    }

    public SubLineItemGrouping? Grouping
    {
        get
        {
            return Match<SubLineItemGrouping?>(
                matrix: (x) => x.Grouping,
                tier: (x) => x.Grouping,
                other: (x) => x.Grouping
            );
        }
    }

    public string Name
    {
        get { return Match(matrix: (x) => x.Name, tier: (x) => x.Name, other: (x) => x.Name); }
    }

    public double Quantity
    {
        get
        {
            return Match(
                matrix: (x) => x.Quantity,
                tier: (x) => x.Quantity,
                other: (x) => x.Quantity
            );
        }
    }

    public SubLineItem(MatrixSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(TierSubLineItem value)
    {
        Value = value;
    }

    public SubLineItem(OtherSubLineItem value)
    {
        Value = value;
    }

    SubLineItem(UnknownVariant value)
    {
        Value = value;
    }

    public static SubLineItem CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickMatrix([NotNullWhen(true)] out MatrixSubLineItem? value)
    {
        value = this.Value as MatrixSubLineItem;
        return value != null;
    }

    public bool TryPickTier([NotNullWhen(true)] out TierSubLineItem? value)
    {
        value = this.Value as TierSubLineItem;
        return value != null;
    }

    public bool TryPickOther([NotNullWhen(true)] out OtherSubLineItem? value)
    {
        value = this.Value as OtherSubLineItem;
        return value != null;
    }

    public void Switch(
        System::Action<MatrixSubLineItem> matrix,
        System::Action<TierSubLineItem> tier,
        System::Action<OtherSubLineItem> other
    )
    {
        switch (this.Value)
        {
            case MatrixSubLineItem value:
                matrix(value);
                break;
            case TierSubLineItem value:
                tier(value);
                break;
            case OtherSubLineItem value:
                other(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    public T Match<T>(
        System::Func<MatrixSubLineItem, T> matrix,
        System::Func<TierSubLineItem, T> tier,
        System::Func<OtherSubLineItem, T> other
    )
    {
        return this.Value switch
        {
            MatrixSubLineItem value => matrix(value),
            TierSubLineItem value => tier(value),
            OtherSubLineItem value => other(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of SubLineItem"),
        };
    }

    public static implicit operator SubLineItem(MatrixSubLineItem value) => new(value);

    public static implicit operator SubLineItem(TierSubLineItem value) => new(value);

    public static implicit operator SubLineItem(OtherSubLineItem value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of SubLineItem");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class SubLineItemConverter : JsonConverter<SubLineItem>
{
    public override SubLineItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "matrix":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatrixSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'MatrixSubLineItem'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "tier":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TierSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'TierSubLineItem'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "'null'":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<OtherSubLineItem>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new SubLineItem(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'OtherSubLineItem'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubLineItem value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<PaymentAttempt>))]
public sealed record class PaymentAttempt : ModelBase, IFromRaw<PaymentAttempt>
{
    /// <summary>
    /// The ID of the payment attempt.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount of the payment attempt.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the payment attempt was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The payment provider that attempted to collect the payment.
    /// </summary>
    public required ApiEnum<string, PaymentProvider>? PaymentProvider
    {
        get
        {
            if (!this._properties.TryGetValue("payment_provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["payment_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the payment attempt in the payment provider.
    /// </summary>
    public required string? PaymentProviderID
    {
        get
        {
            if (!this._properties.TryGetValue("payment_provider_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["payment_provider_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to the downloadable PDF version of the receipt. This field will be `null`
    /// for payment attempts that did not succeed.
    /// </summary>
    public required string? ReceiptPdf
    {
        get
        {
            if (!this._properties.TryGetValue("receipt_pdf", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["receipt_pdf"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the payment attempt succeeded.
    /// </summary>
    public required bool Succeeded
    {
        get
        {
            if (!this._properties.TryGetValue("succeeded", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'succeeded' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "succeeded",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["succeeded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public PaymentAttempt() { }

    public PaymentAttempt(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentAttempt(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PaymentAttempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The payment provider that attempted to collect the payment.
/// </summary>
[JsonConverter(typeof(PaymentProviderConverter))]
public enum PaymentProvider
{
    Stripe,
}

sealed class PaymentProviderConverter : JsonConverter<PaymentProvider>
{
    public override PaymentProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => PaymentProvider.Stripe,
            _ => (PaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentProvider.Stripe => "stripe",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Issued,
    Paid,
    Synced,
    Void,
    Draft,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "issued" => Status.Issued,
            "paid" => Status.Paid,
            "synced" => Status.Synced,
            "void" => Status.Void,
            "draft" => Status.Draft,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Issued => "issued",
                Status.Paid => "paid",
                Status.Synced => "synced",
                Status.Void => "void",
                Status.Draft => "draft",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
