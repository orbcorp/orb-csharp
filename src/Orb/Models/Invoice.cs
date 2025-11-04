using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using InvoiceProperties = Orb.Models.InvoiceProperties;

namespace Orb.Models;

/// <summary>
/// An [`Invoice`](/core-concepts#invoice) is a fundamental billing entity, representing
/// the request for payment for a single subscription. This includes a set of line
/// items, which correspond to prices in the subscription's plan and can represent
/// fixed recurring fees or usage-based fees. They are generated at the end of a billing
/// period, or as the result of an action, such as a cancellation.
/// </summary>
[JsonConverter(typeof(ModelConverter<Invoice>))]
public sealed record class Invoice : ModelBase, IFromRaw<Invoice>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("amount_due", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_due' cannot be null",
                    new ArgumentOutOfRangeException("amount_due", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_due' cannot be null",
                    new ArgumentNullException("amount_due")
                );
        }
        set
        {
            this.Properties["amount_due"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceProperties::AutoCollection AutoCollection
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_collection", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new ArgumentOutOfRangeException("auto_collection", "Missing required argument")
                );

            return JsonSerializer.Deserialize<InvoiceProperties::AutoCollection>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new ArgumentNullException("auto_collection")
                );
        }
        set
        {
            this.Properties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Address? BillingAddress
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Address?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["billing_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of credit notes associated with the invoice
    /// </summary>
    public required List<InvoiceProperties::CreditNote> CreditNotes
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_notes", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_notes' cannot be null",
                    new ArgumentOutOfRangeException("credit_notes", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<InvoiceProperties::CreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'credit_notes' cannot be null",
                    new ArgumentNullException("credit_notes")
                );
        }
        set
        {
            this.Properties["credit_notes"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<InvoiceProperties::CustomerBalanceTransaction> CustomerBalanceTransactions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "customer_balance_transactions",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'customer_balance_transactions' cannot be null",
                    new ArgumentOutOfRangeException(
                        "customer_balance_transactions",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<InvoiceProperties::CustomerBalanceTransaction>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer_balance_transactions' cannot be null",
                    new ArgumentNullException("customer_balance_transactions")
                );
        }
        set
        {
            this.Properties["customer_balance_transactions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax IDs are commonly required to be displayed on customer invoices, which
    /// are added to the headers of invoices.
    ///
    /// ### Supported Tax ID Countries and Types
    ///
    /// | Country | Type | Description | |---------|------|-------------| | Albania
    /// | `al_tin` | Albania Tax Identification Number | | Andorra | `ad_nrt` | Andorran
    /// NRT Number | | Angola | `ao_tin` | Angola Tax Identification Number | | Argentina
    /// | `ar_cuit` | Argentinian Tax ID Number | | Armenia | `am_tin` | Armenia
    /// Tax Identification Number | | Aruba | `aw_tin` | Aruba Tax Identification
    /// Number | | Australia | `au_abn` | Australian Business Number (AU ABN) | |
    /// Australia | `au_arn` | Australian Taxation Office Reference Number | | Austria
    /// | `eu_vat` | European VAT Number | | Azerbaijan | `az_tin` | Azerbaijan Tax
    /// Identification Number | | Bahamas | `bs_tin` | Bahamas Tax Identification
    /// Number | | Bahrain | `bh_vat` | Bahraini VAT Number | | Bangladesh | `bd_bin`
    /// | Bangladesh Business Identification Number | | Barbados | `bb_tin` | Barbados
    /// Tax Identification Number | | Belarus | `by_tin` | Belarus TIN Number | |
    /// Belgium | `eu_vat` | European VAT Number | | Benin | `bj_ifu` | Benin Tax
    /// Identification Number (Identifiant Fiscal Unique) | | Bolivia | `bo_tin` |
    /// Bolivian Tax ID | | Bosnia and Herzegovina | `ba_tin` | Bosnia and Herzegovina
    /// Tax Identification Number | | Brazil | `br_cnpj` | Brazilian CNPJ Number
    /// | | Brazil | `br_cpf` | Brazilian CPF Number | | Bulgaria | `bg_uic` | Bulgaria
    /// Unified Identification Code | | Bulgaria | `eu_vat` | European VAT Number
    /// | | Burkina Faso | `bf_ifu` | Burkina Faso Tax Identification Number (Numéro
    /// d'Identifiant Fiscal Unique) | | Cambodia | `kh_tin` | Cambodia Tax Identification
    /// Number | | Cameroon | `cm_niu` | Cameroon Tax Identification Number (Numéro
    /// d'Identifiant fiscal Unique) | | Canada | `ca_bn` | Canadian BN | | Canada
    /// | `ca_gst_hst` | Canadian GST/HST Number | | Canada | `ca_pst_bc` | Canadian
    /// PST Number (British Columbia) | | Canada | `ca_pst_mb` | Canadian PST Number
    /// (Manitoba) | | Canada | `ca_pst_sk` | Canadian PST Number (Saskatchewan)
    /// | | Canada | `ca_qst` | Canadian QST Number (Québec) | | Cape Verde | `cv_nif`
    /// | Cape Verde Tax Identification Number (Número de Identificação Fiscal) |
    /// | Chile | `cl_tin` | Chilean TIN | | China | `cn_tin` | Chinese Tax ID |
    /// | Colombia | `co_nit` | Colombian NIT Number | | Congo-Kinshasa | `cd_nif`
    /// | Congo (DR) Tax Identification Number (Número de Identificação Fiscal) |
    /// | Costa Rica | `cr_tin` | Costa Rican Tax ID | | Croatia | `eu_vat` | European
    /// VAT Number | | Croatia | `hr_oib` | Croatian Personal Identification Number
    /// (OIB) | | Cyprus | `eu_vat` | European VAT Number | | Czech Republic | `eu_vat`
    /// | European VAT Number | | Denmark | `eu_vat` | European VAT Number | | Dominican
    /// Republic | `do_rcn` | Dominican RCN Number | | Ecuador | `ec_ruc` | Ecuadorian
    /// RUC Number | | Egypt | `eg_tin` | Egyptian Tax Identification Number | | El
    /// Salvador | `sv_nit` | El Salvadorian NIT Number | | Estonia | `eu_vat` |
    /// European VAT Number | | Ethiopia | `et_tin` | Ethiopia Tax Identification
    /// Number | | European Union | `eu_oss_vat` | European One Stop Shop VAT Number
    /// for non-Union scheme | | Finland | `eu_vat` | European VAT Number | | France
    /// | `eu_vat` | European VAT Number | | Georgia | `ge_vat` | Georgian VAT |
    /// | Germany | `de_stn` | German Tax Number (Steuernummer) | | Germany | `eu_vat`
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
    /// VAT Number | | Lithuania | `eu_vat` | European VAT Number | | Luxembourg |
    /// `eu_vat` | European VAT Number | | Malaysia | `my_frp` | Malaysian FRP Number
    /// | | Malaysia | `my_itn` | Malaysian ITN | | Malaysia | `my_sst` | Malaysian
    /// SST Number | | Malta | `eu_vat` | European VAT Number | | Mauritania | `mr_nif`
    /// | Mauritania Tax Identification Number (Número de Identificação Fiscal) |
    /// | Mexico | `mx_rfc` | Mexican RFC Number | | Moldova | `md_vat` | Moldova
    /// VAT Number | | Montenegro | `me_pib` | Montenegro PIB Number | | Morocco
    /// | `ma_vat` | Morocco VAT Number | | Nepal | `np_pan` | Nepal PAN Number |
    /// | Netherlands | `eu_vat` | European VAT Number | | New Zealand | `nz_gst`
    /// | New Zealand GST Number | | Nigeria | `ng_tin` | Nigerian Tax Identification
    /// Number | | North Macedonia | `mk_vat` | North Macedonia VAT Number | | Northern
    /// Ireland | `eu_vat` | Northern Ireland VAT Number | | Norway | `no_vat` | Norwegian
    /// VAT Number | | Norway | `no_voec` | Norwegian VAT on e-commerce Number |
    /// | Oman | `om_vat` | Omani VAT Number | | Peru | `pe_ruc` | Peruvian RUC Number
    /// | | Philippines | `ph_tin` | Philippines Tax Identification Number | | Poland
    /// | `eu_vat` | European VAT Number | | Portugal | `eu_vat` | European VAT Number
    /// | | Romania | `eu_vat` | European VAT Number | | Romania | `ro_tin` | Romanian
    /// Tax ID Number | | Russia | `ru_inn` | Russian INN | | Russia | `ru_kpp` |
    /// Russian KPP | | Saudi Arabia | `sa_vat` | Saudi Arabia VAT | | Senegal |
    /// `sn_ninea` | Senegal NINEA Number | | Serbia | `rs_pib` | Serbian PIB Number
    /// | | Singapore | `sg_gst` | Singaporean GST | | Singapore | `sg_uen` | Singaporean
    /// UEN | | Slovakia | `eu_vat` | European VAT Number | | Slovenia | `eu_vat`
    /// | European VAT Number | | Slovenia | `si_tin` | Slovenia Tax Number (davčna
    /// številka) | | South Africa | `za_vat` | South African VAT Number | | South
    /// Korea | `kr_brn` | Korean BRN | | Spain | `es_cif` | Spanish NIF Number (previously
    /// Spanish CIF Number) | | Spain | `eu_vat` | European VAT Number | | Suriname
    /// | `sr_fin` | Suriname FIN Number | | Sweden | `eu_vat` | European VAT Number
    /// | | Switzerland | `ch_uid` | Switzerland UID Number | | Switzerland | `ch_vat`
    /// | Switzerland VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT | | Tajikistan
    /// | `tj_tin` | Tajikistan Tax Identification Number | | Tanzania | `tz_vat`
    /// | Tanzania VAT Number | | Thailand | `th_vat` | Thai VAT | | Turkey | `tr_tin`
    /// | Turkish Tax Identification Number | | Uganda | `ug_tin` | Uganda Tax Identification
    /// Number | | Ukraine | `ua_vat` | Ukrainian VAT | | United Arab Emirates |
    /// `ae_trn` | United Arab Emirates TRN | | United Kingdom | `gb_vat` | United
    /// Kingdom VAT Number | | United States | `us_ein` | United States EIN | | Uruguay
    /// | `uy_ruc` | Uruguayan RUC Number | | Uzbekistan | `uz_tin` | Uzbekistan TIN
    /// Number | | Uzbekistan | `uz_vat` | Uzbekistan VAT Number | | Venezuela |
    /// `ve_rif` | Venezuelan RIF Number | | Vietnam | `vn_tin` | Vietnamese Tax ID
    /// Number | | Zambia | `zm_tin` | Zambia Tax Identification Number | | Zimbabwe
    /// | `zw_tin` | Zimbabwe Tax Identification Number |
    /// </summary>
    public required CustomerTaxID? CustomerTaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("customer_tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerTaxID?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customer_tax_id"] = JsonSerializer.SerializeToElement(
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
    public required JsonElement Discount
    {
        get
        {
            if (!this.Properties.TryGetValue("discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount' cannot be null",
                    new ArgumentOutOfRangeException("discount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<InvoiceLevelDiscount> Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discounts' cannot be null",
                    new ArgumentOutOfRangeException("discounts", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<InvoiceLevelDiscount>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'discounts' cannot be null",
                    new ArgumentNullException("discounts")
                );
        }
        set
        {
            this.Properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When the invoice payment is due. The due date is null if the invoice is not
    /// yet finalized.
    /// </summary>
    public required DateTime? DueDate
    {
        get
        {
            if (!this.Properties.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["due_date"] = JsonSerializer.SerializeToElement(
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
    public required DateTime? EligibleToIssueAt
    {
        get
        {
            if (!this.Properties.TryGetValue("eligible_to_issue_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["eligible_to_issue_at"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("hosted_invoice_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hosted_invoice_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The scheduled date of the invoice
    /// </summary>
    public required DateTime InvoiceDate
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_date' cannot be null",
                    new ArgumentOutOfRangeException("invoice_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice_date"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("invoice_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_number' cannot be null",
                    new ArgumentOutOfRangeException("invoice_number", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_number' cannot be null",
                    new ArgumentNullException("invoice_number")
                );
        }
        set
        {
            this.Properties["invoice_number"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("invoice_pdf", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice_pdf"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, InvoiceProperties::InvoiceSource> InvoiceSource
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_source", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_source' cannot be null",
                    new ArgumentOutOfRangeException("invoice_source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, InvoiceProperties::InvoiceSource>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["invoice_source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice failed to issue, this will be the last time it failed to issue
    /// (even if it is now in a different state.)
    /// </summary>
    public required DateTime? IssueFailedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("issue_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["issue_failed_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice has been issued, this will be the time it transitioned to `issued`
    /// (even if it is now in a different state.)
    /// </summary>
    public required DateTime? IssuedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("issued_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["issued_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The breakdown of prices in this invoice.
    /// </summary>
    public required List<InvoiceProperties::LineItem> LineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new ArgumentOutOfRangeException("line_items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<InvoiceProperties::LineItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new ArgumentNullException("line_items")
                );
        }
        set
        {
            this.Properties["line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Maximum? Maximum
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Maximum?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["memo"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Minimum? Minimum
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Minimum?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice has a status of `paid`, this gives a timestamp when the invoice
    /// was paid.
    /// </summary>
    public required DateTime? PaidAt
    {
        get
        {
            if (!this.Properties.TryGetValue("paid_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["paid_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of payment attempts associated with the invoice
    /// </summary>
    public required List<InvoiceProperties::PaymentAttempt> PaymentAttempts
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_attempts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'payment_attempts' cannot be null",
                    new ArgumentOutOfRangeException("payment_attempts", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<InvoiceProperties::PaymentAttempt>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'payment_attempts' cannot be null",
                    new ArgumentNullException("payment_attempts")
                );
        }
        set
        {
            this.Properties["payment_attempts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If payment was attempted on this invoice but failed, this will be the time
    /// of the most recent attempt.
    /// </summary>
    public required DateTime? PaymentFailedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_failed_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If payment was attempted on this invoice, this will be the start time of the
    /// most recent attempt. This field is especially useful for delayed-notification
    /// payment mechanisms (like bank transfers), where payment can take 3 days or more.
    /// </summary>
    public required DateTime? PaymentStartedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_started_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_started_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice is in draft, this timestamp will reflect when the invoice
    /// is scheduled to be issued.
    /// </summary>
    public required DateTime? ScheduledIssueAt
    {
        get
        {
            if (!this.Properties.TryGetValue("scheduled_issue_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["scheduled_issue_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Address? ShippingAddress
    {
        get
        {
            if (!this.Properties.TryGetValue("shipping_address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Address?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["shipping_address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, InvoiceProperties::Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, InvoiceProperties::Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubscriptionMinified? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["subscription"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new ArgumentNullException("subtotal")
                );
        }
        set
        {
            this.Properties["subtotal"] = JsonSerializer.SerializeToElement(
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
    public required DateTime? SyncFailedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("sync_failed_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sync_failed_at"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("total", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new ArgumentNullException("total")
                );
        }
        set
        {
            this.Properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the invoice has a status of `void`, this gives a timestamp when the invoice
    /// was voided.
    /// </summary>
    public required DateTime? VoidedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["voided_at"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("will_auto_issue", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'will_auto_issue' cannot be null",
                    new ArgumentOutOfRangeException("will_auto_issue", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["will_auto_issue"] = JsonSerializer.SerializeToElement(
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

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Invoice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
