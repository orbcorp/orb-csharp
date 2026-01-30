using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers;

/// <summary>
/// A customer is a buyer of your products, and the other party to the billing relationship.
///
/// <para>In Orb, customers are assigned system generated identifiers automatically,
/// but it's often desirable to have these match existing identifiers in your system.
/// To avoid having to denormalize Orb ID information, you can pass in an `external_customer_id`
/// with your own identifier. See [Customer ID Aliases](/events-and-metrics/customer-aliases)
/// for further information about how these aliases work in Orb.</para>
///
/// <para>In addition to having an identifier in your system, a customer may exist
/// in a payment provider solution like Stripe. Use the `payment_provider_id` and
/// the `payment_provider` enum field to express this mapping.</para>
///
/// <para>A customer also has a timezone (from the standard [IANA timezone database](https://www.iana.org/time-zones)),
/// which defaults to your account's timezone. See [Timezone localization](/essentials/timezones)
/// for information on what this timezone parameter influences within Orb.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Customer, CustomerFromRaw>))]
public sealed record class Customer : JsonModel
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

    public required IReadOnlyList<string> AdditionalEmails
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("additional_emails");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "additional_emails",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool AutoCollection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("auto_collection");
        }
        init { this._rawData.Set("auto_collection", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_issuance");
        }
        init { this._rawData.Set("auto_issuance", value); }
    }

    /// <summary>
    /// The customer's current balance in their currency.
    /// </summary>
    public required string Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("balance");
        }
        init { this._rawData.Set("balance", value); }
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

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically issued receipts.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    public required bool EmailDelivery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("email_delivery");
        }
        init { this._rawData.Set("email_delivery", value); }
    }

    public required bool? ExemptFromAutomatedTax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("exempt_from_automated_tax");
        }
        init { this._rawData.Set("exempt_from_automated_tax", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawData.Set("external_customer_id", value); }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public required Hierarchy Hierarchy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Hierarchy>("hierarchy");
        }
        init { this._rawData.Set("hierarchy", value); }
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
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public required ApiEnum<string, CustomerPaymentProvider>? PaymentProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CustomerPaymentProvider>>(
                "payment_provider"
            );
        }
        init { this._rawData.Set("payment_provider", value); }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
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

    public required string? PortalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("portal_url");
        }
        init { this._rawData.Set("portal_url", value); }
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
    /// | | Poland | `eu_vat` | European VAT Number | | Poland | `pl_nip` | Polish
    /// Tax ID Number | | Portugal | `eu_vat` | European VAT Number | | Romania |
    /// `eu_vat` | European VAT Number | | Romania | `ro_tin` | Romanian Tax ID Number
    /// | | Russia | `ru_inn` | Russian INN | | Russia | `ru_kpp` | Russian KPP |
    /// | Saudi Arabia | `sa_vat` | Saudi Arabia VAT | | Senegal | `sn_ninea` | Senegal
    /// NINEA Number | | Serbia | `rs_pib` | Serbian PIB Number | | Singapore | `sg_gst`
    /// | Singaporean GST | | Singapore | `sg_uen` | Singaporean UEN | | Slovakia
    /// | `eu_vat` | European VAT Number | | Slovenia | `eu_vat` | European VAT Number
    /// | | Slovenia | `si_tin` | Slovenia Tax Number (davčna številka) | | South
    /// Africa | `za_vat` | South African VAT Number | | South Korea | `kr_brn` |
    /// Korean BRN | | Spain | `es_cif` | Spanish NIF Number (previously Spanish CIF
    /// Number) | | Spain | `eu_vat` | European VAT Number | | Suriname | `sr_fin`
    /// | Suriname FIN Number | | Sweden | `eu_vat` | European VAT Number | | Switzerland
    /// | `ch_uid` | Switzerland UID Number | | Switzerland | `ch_vat` | Switzerland
    /// VAT Number | | Taiwan | `tw_vat` | Taiwanese VAT | | Tajikistan | `tj_tin`
    /// | Tajikistan Tax Identification Number | | Tanzania | `tz_vat` | Tanzania
    /// VAT Number | | Thailand | `th_vat` | Thai VAT | | Turkey | `tr_tin` | Turkish
    /// Tax Identification Number | | Uganda | `ug_tin` | Uganda Tax Identification
    /// Number | | Ukraine | `ua_vat` | Ukrainian VAT | | United Arab Emirates | `ae_trn`
    /// | United Arab Emirates TRN | | United Kingdom | `gb_vat` | United Kingdom
    /// VAT Number | | United States | `us_ein` | United States EIN | | Uruguay |
    /// `uy_ruc` | Uruguayan RUC Number | | Uzbekistan | `uz_tin` | Uzbekistan TIN
    /// Number | | Uzbekistan | `uz_vat` | Uzbekistan VAT Number | | Venezuela | `ve_rif`
    /// | Venezuelan RIF Number | | Vietnam | `vn_tin` | Vietnamese Tax ID Number
    /// | | Zambia | `zm_tin` | Zambia Tax Identification Number | | Zimbabwe | `zw_tin`
    /// | Zimbabwe Tax Identification Number |</para>
    /// </summary>
    public required CustomerTaxID? TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerTaxID>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    public AccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AccountingSyncConfiguration>(
                "accounting_sync_configuration"
            );
        }
        init { this._rawData.Set("accounting_sync_configuration", value); }
    }

    /// <summary>
    /// Whether automatic tax calculation is enabled for this customer. This field
    /// is nullable for backwards compatibility but will always return a boolean value.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("automatic_tax_enabled");
        }
        init { this._rawData.Set("automatic_tax_enabled", value); }
    }

    /// <summary>
    /// Payment configuration for the customer, applicable when using Orb Invoicing
    /// with a supported payment provider such as Stripe.
    /// </summary>
    public CustomerPaymentConfiguration? PaymentConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerPaymentConfiguration>(
                "payment_configuration"
            );
        }
        init { this._rawData.Set("payment_configuration", value); }
    }

    public ReportingConfiguration? ReportingConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReportingConfiguration>(
                "reporting_configuration"
            );
        }
        init { this._rawData.Set("reporting_configuration", value); }
    }

    /// <inheritdoc/>
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
        _ = this.PortalUrl;
        this.ShippingAddress?.Validate();
        this.TaxID?.Validate();
        _ = this.Timezone;
        this.AccountingSyncConfiguration?.Validate();
        _ = this.AutomaticTaxEnabled;
        this.PaymentConfiguration?.Validate();
        this.ReportingConfiguration?.Validate();
    }

    public Customer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Customer(Customer customer)
        : base(customer) { }
#pragma warning restore CS8618

    public Customer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerFromRaw.FromRawUnchecked"/>
    public static Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerFromRaw : IFromRawJson<Customer>
{
    /// <inheritdoc/>
    public Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customer.FromRawUnchecked(rawData);
}

/// <summary>
/// The hierarchical relationships for this customer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Hierarchy, HierarchyFromRaw>))]
public sealed record class Hierarchy : JsonModel
{
    public required IReadOnlyList<CustomerMinified> Children
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CustomerMinified>>("children");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CustomerMinified>>(
                "children",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required CustomerMinified? Parent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerMinified>("parent");
        }
        init { this._rawData.Set("parent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Children)
        {
            item.Validate();
        }
        this.Parent?.Validate();
    }

    public Hierarchy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Hierarchy(Hierarchy hierarchy)
        : base(hierarchy) { }
#pragma warning restore CS8618

    public Hierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HierarchyFromRaw.FromRawUnchecked"/>
    public static Hierarchy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HierarchyFromRaw : IFromRawJson<Hierarchy>
{
    /// <inheritdoc/>
    public Hierarchy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Hierarchy.FromRawUnchecked(rawData);
}

/// <summary>
/// This is used for creating charges or invoices in an external system via Orb.
/// When not in test mode, the connection must first be configured in the Orb webapp.
/// </summary>
[JsonConverter(typeof(CustomerPaymentProviderConverter))]
public enum CustomerPaymentProvider
{
    Quickbooks,
    BillCom,
    StripeCharge,
    StripeInvoice,
    Netsuite,
}

sealed class CustomerPaymentProviderConverter : JsonConverter<CustomerPaymentProvider>
{
    public override CustomerPaymentProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => CustomerPaymentProvider.Quickbooks,
            "bill.com" => CustomerPaymentProvider.BillCom,
            "stripe_charge" => CustomerPaymentProvider.StripeCharge,
            "stripe_invoice" => CustomerPaymentProvider.StripeInvoice,
            "netsuite" => CustomerPaymentProvider.Netsuite,
            _ => (CustomerPaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerPaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerPaymentProvider.Quickbooks => "quickbooks",
                CustomerPaymentProvider.BillCom => "bill.com",
                CustomerPaymentProvider.StripeCharge => "stripe_charge",
                CustomerPaymentProvider.StripeInvoice => "stripe_invoice",
                CustomerPaymentProvider.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<AccountingSyncConfiguration, AccountingSyncConfigurationFromRaw>)
)]
public sealed record class AccountingSyncConfiguration : JsonModel
{
    public required IReadOnlyList<AccountingProvider> AccountingProviders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountingProvider>>(
                "accounting_providers"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountingProvider>>(
                "accounting_providers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required bool Excluded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("excluded");
        }
        init { this._rawData.Set("excluded", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AccountingProviders)
        {
            item.Validate();
        }
        _ = this.Excluded;
    }

    public AccountingSyncConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountingSyncConfiguration(AccountingSyncConfiguration accountingSyncConfiguration)
        : base(accountingSyncConfiguration) { }
#pragma warning restore CS8618

    public AccountingSyncConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingSyncConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountingSyncConfigurationFromRaw.FromRawUnchecked"/>
    public static AccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingSyncConfigurationFromRaw : IFromRawJson<AccountingSyncConfiguration>
{
    /// <inheritdoc/>
    public AccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountingSyncConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AccountingProvider, AccountingProviderFromRaw>))]
public sealed record class AccountingProvider : JsonModel
{
    public required string? ExternalProviderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_provider_id");
        }
        init { this._rawData.Set("external_provider_id", value); }
    }

    public required ApiEnum<string, AccountingProviderProviderType> ProviderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AccountingProviderProviderType>>(
                "provider_type"
            );
        }
        init { this._rawData.Set("provider_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalProviderID;
        this.ProviderType.Validate();
    }

    public AccountingProvider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountingProvider(AccountingProvider accountingProvider)
        : base(accountingProvider) { }
#pragma warning restore CS8618

    public AccountingProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountingProviderFromRaw.FromRawUnchecked"/>
    public static AccountingProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingProviderFromRaw : IFromRawJson<AccountingProvider>
{
    /// <inheritdoc/>
    public AccountingProvider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountingProvider.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AccountingProviderProviderTypeConverter))]
public enum AccountingProviderProviderType
{
    Quickbooks,
    Netsuite,
}

sealed class AccountingProviderProviderTypeConverter : JsonConverter<AccountingProviderProviderType>
{
    public override AccountingProviderProviderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => AccountingProviderProviderType.Quickbooks,
            "netsuite" => AccountingProviderProviderType.Netsuite,
            _ => (AccountingProviderProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AccountingProviderProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AccountingProviderProviderType.Quickbooks => "quickbooks",
                AccountingProviderProviderType.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Payment configuration for the customer, applicable when using Orb Invoicing with
/// a supported payment provider such as Stripe.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CustomerPaymentConfiguration, CustomerPaymentConfigurationFromRaw>)
)]
public sealed record class CustomerPaymentConfiguration : JsonModel
{
    /// <summary>
    /// Provider-specific payment configuration.
    /// </summary>
    public IReadOnlyList<CustomerPaymentConfigurationPaymentProvider>? PaymentProviders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerPaymentConfigurationPaymentProvider>
            >("payment_providers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerPaymentConfigurationPaymentProvider>?>(
                "payment_providers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.PaymentProviders ?? [])
        {
            item.Validate();
        }
    }

    public CustomerPaymentConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerPaymentConfiguration(CustomerPaymentConfiguration customerPaymentConfiguration)
        : base(customerPaymentConfiguration) { }
#pragma warning restore CS8618

    public CustomerPaymentConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPaymentConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerPaymentConfigurationFromRaw.FromRawUnchecked"/>
    public static CustomerPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerPaymentConfigurationFromRaw : IFromRawJson<CustomerPaymentConfiguration>
{
    /// <inheritdoc/>
    public CustomerPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerPaymentConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerPaymentConfigurationPaymentProvider,
        CustomerPaymentConfigurationPaymentProviderFromRaw
    >)
)]
public sealed record class CustomerPaymentConfigurationPaymentProvider : JsonModel
{
    /// <summary>
    /// The payment provider to configure.
    /// </summary>
    public required ApiEnum<
        string,
        CustomerPaymentConfigurationPaymentProviderProviderType
    > ProviderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
            >("provider_type");
        }
        init { this._rawData.Set("provider_type", value); }
    }

    /// <summary>
    /// List of Stripe payment method types to exclude for this customer. Excluded
    /// payment methods will not be available for the customer to select during payment,
    /// and will not be used for auto-collection. If a customer's default payment
    /// method becomes excluded, Orb will attempt to use the next available compatible
    /// payment method for auto-collection.
    /// </summary>
    public IReadOnlyList<string>? ExcludedPaymentMethodTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_payment_method_types"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_payment_method_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ProviderType.Validate();
        _ = this.ExcludedPaymentMethodTypes;
    }

    public CustomerPaymentConfigurationPaymentProvider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerPaymentConfigurationPaymentProvider(
        CustomerPaymentConfigurationPaymentProvider customerPaymentConfigurationPaymentProvider
    )
        : base(customerPaymentConfigurationPaymentProvider) { }
#pragma warning restore CS8618

    public CustomerPaymentConfigurationPaymentProvider(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPaymentConfigurationPaymentProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerPaymentConfigurationPaymentProviderFromRaw.FromRawUnchecked"/>
    public static CustomerPaymentConfigurationPaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerPaymentConfigurationPaymentProvider(
        ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType> providerType
    )
        : this()
    {
        this.ProviderType = providerType;
    }
}

class CustomerPaymentConfigurationPaymentProviderFromRaw
    : IFromRawJson<CustomerPaymentConfigurationPaymentProvider>
{
    /// <inheritdoc/>
    public CustomerPaymentConfigurationPaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerPaymentConfigurationPaymentProvider.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment provider to configure.
/// </summary>
[JsonConverter(typeof(CustomerPaymentConfigurationPaymentProviderProviderTypeConverter))]
public enum CustomerPaymentConfigurationPaymentProviderProviderType
{
    Stripe,
}

sealed class CustomerPaymentConfigurationPaymentProviderProviderTypeConverter
    : JsonConverter<CustomerPaymentConfigurationPaymentProviderProviderType>
{
    public override CustomerPaymentConfigurationPaymentProviderProviderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => CustomerPaymentConfigurationPaymentProviderProviderType.Stripe,
            _ => (CustomerPaymentConfigurationPaymentProviderProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerPaymentConfigurationPaymentProviderProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerPaymentConfigurationPaymentProviderProviderType.Stripe => "stripe",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ReportingConfiguration, ReportingConfigurationFromRaw>))]
public sealed record class ReportingConfiguration : JsonModel
{
    public required bool Exempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("exempt");
        }
        init { this._rawData.Set("exempt", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Exempt;
    }

    public ReportingConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportingConfiguration(ReportingConfiguration reportingConfiguration)
        : base(reportingConfiguration) { }
#pragma warning restore CS8618

    public ReportingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReportingConfigurationFromRaw.FromRawUnchecked"/>
    public static ReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ReportingConfiguration(bool exempt)
        : this()
    {
        this.Exempt = exempt;
    }
}

class ReportingConfigurationFromRaw : IFromRawJson<ReportingConfiguration>
{
    /// <inheritdoc/>
    public ReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportingConfiguration.FromRawUnchecked(rawData);
}
