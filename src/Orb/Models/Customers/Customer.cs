using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.CustomerProperties;

namespace Orb.Models.Customers;

/// <summary>
/// A customer is a buyer of your products, and the other party to the billing relationship.
///
/// In Orb, customers are assigned system generated identifiers automatically, but
/// it's often desirable to have these match existing identifiers in your system.
/// To avoid having to denormalize Orb ID information, you can pass in an `external_customer_id`
/// with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
/// for further information about how these aliases work in Orb.
///
/// In addition to having an identifier in your system, a customer may exist in a
/// payment provider solution like Stripe. Use the `payment_provider_id` and the
/// `payment_provider` enum field to express this mapping.
///
/// A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
/// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
/// for information on what this timezone parameter influences within Orb.
/// </summary>
[JsonConverter(typeof(ModelConverter<Customer>))]
public sealed record class Customer : ModelBase, IFromRaw<Customer>
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

    public required List<string> AdditionalEmails
    {
        get
        {
            if (!this.Properties.TryGetValue("additional_emails", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'additional_emails' cannot be null",
                    new ArgumentOutOfRangeException(
                        "additional_emails",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'additional_emails' cannot be null",
                    new ArgumentNullException("additional_emails")
                );
        }
        set
        {
            this.Properties["additional_emails"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool AutoCollection
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_collection", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new ArgumentOutOfRangeException("auto_collection", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether invoices for this customer should be automatically issued. If true,
    /// invoices will be automatically issued. If false, invoices will require manual
    /// approval. If null, inherits the account-level setting.
    /// </summary>
    public required bool? AutoIssuance
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_issuance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auto_issuance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The customer's current balance in their currency.
    /// </summary>
    public required string Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'balance' cannot be null",
                    new ArgumentOutOfRangeException("balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'balance' cannot be null",
                    new ArgumentNullException("balance")
                );
        }
        set
        {
            this.Properties["balance"] = JsonSerializer.SerializeToElement(
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

    public required string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically
    /// issued receipts.
    /// </summary>
    public required string Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'email' cannot be null",
                    new ArgumentOutOfRangeException("email", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'email' cannot be null",
                    new ArgumentNullException("email")
                );
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool EmailDelivery
    {
        get
        {
            if (!this.Properties.TryGetValue("email_delivery", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'email_delivery' cannot be null",
                    new ArgumentOutOfRangeException("email_delivery", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email_delivery"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required bool? ExemptFromAutomatedTax
    {
        get
        {
            if (!this.Properties.TryGetValue("exempt_from_automated_tax", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["exempt_from_automated_tax"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional user-defined ID for this customer resource, used throughout the
    /// system as an alias for this Customer. Use this field to identify a customer
    /// by an existing identifier in your system.
    /// </summary>
    public required string? ExternalCustomerID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public required Hierarchy Hierarchy
    {
        get
        {
            if (!this.Properties.TryGetValue("hierarchy", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'hierarchy' cannot be null",
                    new ArgumentOutOfRangeException("hierarchy", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Hierarchy>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'hierarchy' cannot be null",
                    new ArgumentNullException("hierarchy")
                );
        }
        set
        {
            this.Properties["hierarchy"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public required ApiEnum<string, PaymentProvider>? PaymentProvider
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, PaymentProvider>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["payment_provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public required string? PaymentProviderID
    {
        get
        {
            if (!this.Properties.TryGetValue("payment_provider_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["payment_provider_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? PortalURL
    {
        get
        {
            if (!this.Properties.TryGetValue("portal_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["portal_url"] = JsonSerializer.SerializeToElement(
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
    public required CustomerTaxID? TaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerTaxID?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A timezone identifier from the IANA timezone database, such as "America/Los_Angeles".
    /// This "defaults to your account's timezone if not set. This cannot be changed
    /// after customer creation.
    /// </summary>
    public required string Timezone
    {
        get
        {
            if (!this.Properties.TryGetValue("timezone", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'timezone' cannot be null",
                    new ArgumentOutOfRangeException("timezone", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'timezone' cannot be null",
                    new ArgumentNullException("timezone")
                );
        }
        set
        {
            this.Properties["timezone"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "accounting_sync_configuration",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<AccountingSyncConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["accounting_sync_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether automatic tax calculation is enabled for this customer. This field
    /// is nullable for backwards compatibility but will always return a boolean value.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            if (!this.Properties.TryGetValue("automatic_tax_enabled", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["automatic_tax_enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ReportingConfiguration? ReportingConfiguration
    {
        get
        {
            if (!this.Properties.TryGetValue("reporting_configuration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ReportingConfiguration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["reporting_configuration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AdditionalEmails;
        _ = this.AutoCollection;
        _ = this.AutoIssuance;
        _ = this.Balance;
        this.BillingAddress?.Validate();
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.Email;
        _ = this.EmailDelivery;
        _ = this.ExemptFromAutomatedTax;
        _ = this.ExternalCustomerID;
        this.Hierarchy.Validate();
        _ = this.Metadata;
        _ = this.Name;
        this.PaymentProvider?.Validate();
        _ = this.PaymentProviderID;
        _ = this.PortalURL;
        this.ShippingAddress?.Validate();
        this.TaxID?.Validate();
        _ = this.Timezone;
        this.AccountingSyncConfiguration?.Validate();
        _ = this.AutomaticTaxEnabled;
        this.ReportingConfiguration?.Validate();
    }

    public Customer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Customer FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
