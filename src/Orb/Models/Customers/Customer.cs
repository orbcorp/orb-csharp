using System.Collections.Frozen;
using System.Collections.Generic;
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
[JsonConverter(typeof(ModelConverter<Customer, CustomerFromRaw>))]
public sealed record class Customer : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required IReadOnlyList<string> AdditionalEmails
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "additional_emails"); }
        init { ModelBase.Set(this._rawData, "additional_emails", value); }
    }

    public required bool AutoCollection
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "auto_collection"); }
        init { ModelBase.Set(this._rawData, "auto_collection", value); }
    }

    /// <summary>
    /// Whether invoices for this customer should be automatically issued. If true,
    /// invoices will be automatically issued. If false, invoices will require manual
    /// approval. If null, inherits the account-level setting.
    /// </summary>
    public required bool? AutoIssuance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "auto_issuance"); }
        init { ModelBase.Set(this._rawData, "auto_issuance", value); }
    }

    /// <summary>
    /// The customer's current balance in their currency.
    /// </summary>
    public required string Balance
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "balance"); }
        init { ModelBase.Set(this._rawData, "balance", value); }
    }

    public required Address? BillingAddress
    {
        get { return ModelBase.GetNullableClass<Address>(this.RawData, "billing_address"); }
        init { ModelBase.Set(this._rawData, "billing_address", value); }
    }

    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically issued receipts.
    /// </summary>
    public required string Email
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    public required bool EmailDelivery
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "email_delivery"); }
        init { ModelBase.Set(this._rawData, "email_delivery", value); }
    }

    public required bool? ExemptFromAutomatedTax
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "exempt_from_automated_tax"); }
        init { ModelBase.Set(this._rawData, "exempt_from_automated_tax", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this customer resource, used throughout the
    /// system as an alias for this Customer. Use this field to identify a customer
    /// by an existing identifier in your system.
    /// </summary>
    public required string? ExternalCustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_customer_id"); }
        init { ModelBase.Set(this._rawData, "external_customer_id", value); }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public required Hierarchy Hierarchy
    {
        get { return ModelBase.GetNotNullClass<Hierarchy>(this.RawData, "hierarchy"); }
        init { ModelBase.Set(this._rawData, "hierarchy", value); }
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
            return ModelBase.GetNotNullClass<Dictionary<string, string>>(this.RawData, "metadata");
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public required ApiEnum<string, CustomerPaymentProvider>? PaymentProvider
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, CustomerPaymentProvider>>(
                this.RawData,
                "payment_provider"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_provider", value); }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public required string? PaymentProviderID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "payment_provider_id"); }
        init { ModelBase.Set(this._rawData, "payment_provider_id", value); }
    }

    public required string? PortalURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "portal_url"); }
        init { ModelBase.Set(this._rawData, "portal_url", value); }
    }

    public required Address? ShippingAddress
    {
        get { return ModelBase.GetNullableClass<Address>(this.RawData, "shipping_address"); }
        init { ModelBase.Set(this._rawData, "shipping_address", value); }
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
    public required CustomerTaxID? TaxID
    {
        get { return ModelBase.GetNullableClass<CustomerTaxID>(this.RawData, "tax_id"); }
        init { ModelBase.Set(this._rawData, "tax_id", value); }
    }

    /// <summary>
    /// A timezone identifier from the IANA timezone database, such as "America/Los_Angeles".
    /// This "defaults to your account's timezone if not set. This cannot be changed
    /// after customer creation.
    /// </summary>
    public required string Timezone
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "timezone"); }
        init { ModelBase.Set(this._rawData, "timezone", value); }
    }

    public AccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<AccountingSyncConfiguration>(
                this.RawData,
                "accounting_sync_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "accounting_sync_configuration", value); }
    }

    /// <summary>
    /// Whether automatic tax calculation is enabled for this customer. This field
    /// is nullable for backwards compatibility but will always return a boolean value.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "automatic_tax_enabled"); }
        init { ModelBase.Set(this._rawData, "automatic_tax_enabled", value); }
    }

    /// <summary>
    /// Payment configuration for the customer, applicable when using Orb Invoicing
    /// with a supported payment provider such as Stripe.
    /// </summary>
    public CustomerPaymentConfiguration? PaymentConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<CustomerPaymentConfiguration>(
                this.RawData,
                "payment_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "payment_configuration", value); }
    }

    public ReportingConfiguration? ReportingConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<ReportingConfiguration>(
                this.RawData,
                "reporting_configuration"
            );
        }
        init { ModelBase.Set(this._rawData, "reporting_configuration", value); }
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
        this.PaymentConfiguration?.Validate();
        this.ReportingConfiguration?.Validate();
    }

    public Customer() { }

    public Customer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Customer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerFromRaw : IFromRaw<Customer>
{
    public Customer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Customer.FromRawUnchecked(rawData);
}

/// <summary>
/// The hierarchical relationships for this customer.
/// </summary>
[JsonConverter(typeof(ModelConverter<Hierarchy, HierarchyFromRaw>))]
public sealed record class Hierarchy : ModelBase
{
    public required IReadOnlyList<CustomerMinified> Children
    {
        get { return ModelBase.GetNotNullClass<List<CustomerMinified>>(this.RawData, "children"); }
        init { ModelBase.Set(this._rawData, "children", value); }
    }

    public required CustomerMinified? Parent
    {
        get { return ModelBase.GetNullableClass<CustomerMinified>(this.RawData, "parent"); }
        init { ModelBase.Set(this._rawData, "parent", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Children)
        {
            item.Validate();
        }
        this.Parent?.Validate();
    }

    public Hierarchy() { }

    public Hierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Hierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Hierarchy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HierarchyFromRaw : IFromRaw<Hierarchy>
{
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
    typeof(ModelConverter<AccountingSyncConfiguration, AccountingSyncConfigurationFromRaw>)
)]
public sealed record class AccountingSyncConfiguration : ModelBase
{
    public required IReadOnlyList<AccountingProvider> AccountingProviders
    {
        get
        {
            return ModelBase.GetNotNullClass<List<AccountingProvider>>(
                this.RawData,
                "accounting_providers"
            );
        }
        init { ModelBase.Set(this._rawData, "accounting_providers", value); }
    }

    public required bool Excluded
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "excluded"); }
        init { ModelBase.Set(this._rawData, "excluded", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.AccountingProviders)
        {
            item.Validate();
        }
        _ = this.Excluded;
    }

    public AccountingSyncConfiguration() { }

    public AccountingSyncConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingSyncConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingSyncConfigurationFromRaw : IFromRaw<AccountingSyncConfiguration>
{
    public AccountingSyncConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AccountingSyncConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<AccountingProvider, AccountingProviderFromRaw>))]
public sealed record class AccountingProvider : ModelBase
{
    public required string? ExternalProviderID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_provider_id"); }
        init { ModelBase.Set(this._rawData, "external_provider_id", value); }
    }

    public required ApiEnum<string, AccountingProviderProviderType> ProviderType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AccountingProviderProviderType>>(
                this.RawData,
                "provider_type"
            );
        }
        init { ModelBase.Set(this._rawData, "provider_type", value); }
    }

    public override void Validate()
    {
        _ = this.ExternalProviderID;
        this.ProviderType.Validate();
    }

    public AccountingProvider() { }

    public AccountingProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountingProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AccountingProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountingProviderFromRaw : IFromRaw<AccountingProvider>
{
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
    typeof(ModelConverter<CustomerPaymentConfiguration, CustomerPaymentConfigurationFromRaw>)
)]
public sealed record class CustomerPaymentConfiguration : ModelBase
{
    /// <summary>
    /// Provider-specific payment configuration.
    /// </summary>
    public IReadOnlyList<CustomerPaymentConfigurationPaymentProvider>? PaymentProviders
    {
        get
        {
            return ModelBase.GetNullableClass<List<CustomerPaymentConfigurationPaymentProvider>>(
                this.RawData,
                "payment_providers"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "payment_providers", value);
        }
    }

    public override void Validate()
    {
        foreach (var item in this.PaymentProviders ?? [])
        {
            item.Validate();
        }
    }

    public CustomerPaymentConfiguration() { }

    public CustomerPaymentConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPaymentConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CustomerPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerPaymentConfigurationFromRaw : IFromRaw<CustomerPaymentConfiguration>
{
    public CustomerPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerPaymentConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        CustomerPaymentConfigurationPaymentProvider,
        CustomerPaymentConfigurationPaymentProviderFromRaw
    >)
)]
public sealed record class CustomerPaymentConfigurationPaymentProvider : ModelBase
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
            return ModelBase.GetNotNullClass<
                ApiEnum<string, CustomerPaymentConfigurationPaymentProviderProviderType>
            >(this.RawData, "provider_type");
        }
        init { ModelBase.Set(this._rawData, "provider_type", value); }
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
            return ModelBase.GetNullableClass<List<string>>(
                this.RawData,
                "excluded_payment_method_types"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "excluded_payment_method_types", value);
        }
    }

    public override void Validate()
    {
        this.ProviderType.Validate();
        _ = this.ExcludedPaymentMethodTypes;
    }

    public CustomerPaymentConfigurationPaymentProvider() { }

    public CustomerPaymentConfigurationPaymentProvider(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerPaymentConfigurationPaymentProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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
    : IFromRaw<CustomerPaymentConfigurationPaymentProvider>
{
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

[JsonConverter(typeof(ModelConverter<ReportingConfiguration, ReportingConfigurationFromRaw>))]
public sealed record class ReportingConfiguration : ModelBase
{
    public required bool Exempt
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "exempt"); }
        init { ModelBase.Set(this._rawData, "exempt", value); }
    }

    public override void Validate()
    {
        _ = this.Exempt;
    }

    public ReportingConfiguration() { }

    public ReportingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class ReportingConfigurationFromRaw : IFromRaw<ReportingConfiguration>
{
    public ReportingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReportingConfiguration.FromRawUnchecked(rawData);
}
