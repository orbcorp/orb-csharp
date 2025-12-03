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

namespace Orb.Models.Customers;

/// <summary>
/// This operation is used to create an Orb customer, who is party to the core billing
/// relationship. See [Customer](/core-concepts##customer) for an overview of the
/// customer resource.
///
/// <para>This endpoint is critical in the following Orb functionality: * Automated
/// charges can be configured by setting `payment_provider` and `payment_provider_id`
/// to automatically   issue invoices * [Customer ID Aliases](/events-and-metrics/customer-aliases)
/// can be configured by setting   `external_customer_id` * [Timezone localization](/essentials/timezones)
/// can be configured on a per-customer basis by   setting the `timezone` parameter</para>
/// </summary>
public sealed record class CustomerCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A valid customer email, to be used for notifications. When Orb triggers payment
    /// through a payment gateway, this email will be used for any automatically issued receipts.
    /// </summary>
    public required string Email
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "email"); }
        init { ModelBase.Set(this._rawBodyData, "email", value); }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    public NewAccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewAccountingSyncConfiguration>(
                this.RawBodyData,
                "accounting_sync_configuration"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "accounting_sync_configuration", value); }
    }

    /// <summary>
    /// Additional email addresses for this customer. If populated, these email addresses
    /// will be CC'd for customer communications. The total number of email addresses
    /// (including the primary email) cannot exceed 50.
    /// </summary>
    public IReadOnlyList<string>? AdditionalEmails
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "additional_emails");
        }
        init { ModelBase.Set(this._rawBodyData, "additional_emails", value); }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will automatically attempt
    /// to charge a saved payment method, if available. This parameter defaults to
    /// `True` when a payment provider is provided on customer creation.
    /// </summary>
    public bool? AutoCollection
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "auto_collection"); }
        init { ModelBase.Set(this._rawBodyData, "auto_collection", value); }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will be automatically issued.
    /// If true, invoices will be automatically issued. If false, invoices will require
    /// manual approval. If `null` is specified, the customer's auto issuance setting
    /// will be inherited from the account-level setting.
    /// </summary>
    public bool? AutoIssuance
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "auto_issuance"); }
        init { ModelBase.Set(this._rawBodyData, "auto_issuance", value); }
    }

    public AddressInput? BillingAddress
    {
        get
        {
            return ModelBase.GetNullableClass<AddressInput>(this.RawBodyData, "billing_address");
        }
        init { ModelBase.Set(this._rawBodyData, "billing_address", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string used for the customer's invoices and balance.
    /// If not set at creation time, will be set at subscription creation time.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "currency"); }
        init { ModelBase.Set(this._rawBodyData, "currency", value); }
    }

    public bool? EmailDelivery
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "email_delivery"); }
        init { ModelBase.Set(this._rawBodyData, "email_delivery", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this customer resource, used throughout the
    /// system as an alias for this Customer. Use this field to identify a customer
    /// by an existing identifier in your system.
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "external_customer_id"); }
        init { ModelBase.Set(this._rawBodyData, "external_customer_id", value); }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public CustomerHierarchyConfig? Hierarchy
    {
        get
        {
            return ModelBase.GetNullableClass<CustomerHierarchyConfig>(
                this.RawBodyData,
                "hierarchy"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "hierarchy", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
    }

    /// <summary>
    /// Payment configuration for the customer, applicable when using Orb Invoicing
    /// with a supported payment provider such as Stripe.
    /// </summary>
    public PaymentConfiguration? PaymentConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<PaymentConfiguration>(
                this.RawBodyData,
                "payment_configuration"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "payment_configuration", value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode, the connection must first be configured in the Orb webapp.
    /// </summary>
    public ApiEnum<string, PaymentProviderModel>? PaymentProvider
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PaymentProviderModel>>(
                this.RawBodyData,
                "payment_provider"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "payment_provider", value); }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public string? PaymentProviderID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "payment_provider_id"); }
        init { ModelBase.Set(this._rawBodyData, "payment_provider_id", value); }
    }

    public NewReportingConfiguration? ReportingConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<NewReportingConfiguration>(
                this.RawBodyData,
                "reporting_configuration"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "reporting_configuration", value); }
    }

    public AddressInput? ShippingAddress
    {
        get
        {
            return ModelBase.GetNullableClass<AddressInput>(this.RawBodyData, "shipping_address");
        }
        init { ModelBase.Set(this._rawBodyData, "shipping_address", value); }
    }

    public TaxConfiguration? TaxConfiguration
    {
        get
        {
            return ModelBase.GetNullableClass<TaxConfiguration>(
                this.RawBodyData,
                "tax_configuration"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "tax_configuration", value); }
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
    public CustomerTaxID? TaxID
    {
        get { return ModelBase.GetNullableClass<CustomerTaxID>(this.RawBodyData, "tax_id"); }
        init { ModelBase.Set(this._rawBodyData, "tax_id", value); }
    }

    /// <summary>
    /// A timezone identifier from the IANA timezone database, such as `"America/Los_Angeles"`.
    /// This defaults to your account's timezone if not set. This cannot be changed
    /// after customer creation.
    /// </summary>
    public string? Timezone
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "timezone"); }
        init { ModelBase.Set(this._rawBodyData, "timezone", value); }
    }

    public CustomerCreateParams() { }

    public CustomerCreateParams(
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
    CustomerCreateParams(
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

    public static CustomerCreateParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/customers")
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

/// <summary>
/// Payment configuration for the customer, applicable when using Orb Invoicing with
/// a supported payment provider such as Stripe.
/// </summary>
[JsonConverter(typeof(ModelConverter<PaymentConfiguration, PaymentConfigurationFromRaw>))]
public sealed record class PaymentConfiguration : ModelBase
{
    /// <summary>
    /// Provider-specific payment configuration.
    /// </summary>
    public IReadOnlyList<global::Orb.Models.Customers.PaymentProvider>? PaymentProviders
    {
        get
        {
            return ModelBase.GetNullableClass<List<global::Orb.Models.Customers.PaymentProvider>>(
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

    public PaymentConfiguration() { }

    public PaymentConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PaymentConfigurationFromRaw : IFromRaw<PaymentConfiguration>
{
    public PaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PaymentConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.Customers.PaymentProvider, PaymentProviderFromRaw>)
)]
public sealed record class PaymentProvider : ModelBase
{
    /// <summary>
    /// The payment provider to configure.
    /// </summary>
    public required ApiEnum<string, ProviderType> ProviderType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ProviderType>>(
                this.RawData,
                "provider_type"
            );
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

    public PaymentProvider() { }

    public PaymentProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PaymentProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.PaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PaymentProvider(ApiEnum<string, ProviderType> providerType)
        : this()
    {
        this.ProviderType = providerType;
    }
}

class PaymentProviderFromRaw : IFromRaw<global::Orb.Models.Customers.PaymentProvider>
{
    public global::Orb.Models.Customers.PaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Customers.PaymentProvider.FromRawUnchecked(rawData);
}

/// <summary>
/// The payment provider to configure.
/// </summary>
[JsonConverter(typeof(ProviderTypeConverter))]
public enum ProviderType
{
    Stripe,
}

sealed class ProviderTypeConverter : JsonConverter<ProviderType>
{
    public override ProviderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ProviderType.Stripe,
            _ => (ProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderType.Stripe => "stripe",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This is used for creating charges or invoices in an external system via Orb.
/// When not in test mode, the connection must first be configured in the Orb webapp.
/// </summary>
[JsonConverter(typeof(PaymentProviderModelConverter))]
public enum PaymentProviderModel
{
    Quickbooks,
    BillCom,
    StripeCharge,
    StripeInvoice,
    Netsuite,
}

sealed class PaymentProviderModelConverter : JsonConverter<PaymentProviderModel>
{
    public override PaymentProviderModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => PaymentProviderModel.Quickbooks,
            "bill.com" => PaymentProviderModel.BillCom,
            "stripe_charge" => PaymentProviderModel.StripeCharge,
            "stripe_invoice" => PaymentProviderModel.StripeInvoice,
            "netsuite" => PaymentProviderModel.Netsuite,
            _ => (PaymentProviderModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PaymentProviderModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PaymentProviderModel.Quickbooks => "quickbooks",
                PaymentProviderModel.BillCom => "bill.com",
                PaymentProviderModel.StripeCharge => "stripe_charge",
                PaymentProviderModel.StripeInvoice => "stripe_invoice",
                PaymentProviderModel.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(TaxConfigurationConverter))]
public record class TaxConfiguration
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public bool TaxExempt
    {
        get
        {
            return Match(
                newAvalara: (x) => x.TaxExempt,
                newTaxJar: (x) => x.TaxExempt,
                newSphere: (x) => x.TaxExempt,
                numeral: (x) => x.TaxExempt,
                anrok: (x) => x.TaxExempt,
                stripe: (x) => x.TaxExempt
            );
        }
    }

    public bool? AutomaticTaxEnabled
    {
        get
        {
            return Match<bool?>(
                newAvalara: (x) => x.AutomaticTaxEnabled,
                newTaxJar: (x) => x.AutomaticTaxEnabled,
                newSphere: (x) => x.AutomaticTaxEnabled,
                numeral: (x) => x.AutomaticTaxEnabled,
                anrok: (x) => x.AutomaticTaxEnabled,
                stripe: (x) => x.AutomaticTaxEnabled
            );
        }
    }

    public TaxConfiguration(NewAvalaraTaxConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(NewTaxJarConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(NewSphereConfiguration value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(Numeral value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(Anrok value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(Stripe value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public TaxConfiguration(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickNewAvalara([NotNullWhen(true)] out NewAvalaraTaxConfiguration? value)
    {
        value = this.Value as NewAvalaraTaxConfiguration;
        return value != null;
    }

    public bool TryPickNewTaxJar([NotNullWhen(true)] out NewTaxJarConfiguration? value)
    {
        value = this.Value as NewTaxJarConfiguration;
        return value != null;
    }

    public bool TryPickNewSphere([NotNullWhen(true)] out NewSphereConfiguration? value)
    {
        value = this.Value as NewSphereConfiguration;
        return value != null;
    }

    public bool TryPickNumeral([NotNullWhen(true)] out Numeral? value)
    {
        value = this.Value as Numeral;
        return value != null;
    }

    public bool TryPickAnrok([NotNullWhen(true)] out Anrok? value)
    {
        value = this.Value as Anrok;
        return value != null;
    }

    public bool TryPickStripe([NotNullWhen(true)] out Stripe? value)
    {
        value = this.Value as Stripe;
        return value != null;
    }

    public void Switch(
        System::Action<NewAvalaraTaxConfiguration> newAvalara,
        System::Action<NewTaxJarConfiguration> newTaxJar,
        System::Action<NewSphereConfiguration> newSphere,
        System::Action<Numeral> numeral,
        System::Action<Anrok> anrok,
        System::Action<Stripe> stripe
    )
    {
        switch (this.Value)
        {
            case NewAvalaraTaxConfiguration value:
                newAvalara(value);
                break;
            case NewTaxJarConfiguration value:
                newTaxJar(value);
                break;
            case NewSphereConfiguration value:
                newSphere(value);
                break;
            case Numeral value:
                numeral(value);
                break;
            case Anrok value:
                anrok(value);
                break;
            case Stripe value:
                stripe(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of TaxConfiguration"
                );
        }
    }

    public T Match<T>(
        System::Func<NewAvalaraTaxConfiguration, T> newAvalara,
        System::Func<NewTaxJarConfiguration, T> newTaxJar,
        System::Func<NewSphereConfiguration, T> newSphere,
        System::Func<Numeral, T> numeral,
        System::Func<Anrok, T> anrok,
        System::Func<Stripe, T> stripe
    )
    {
        return this.Value switch
        {
            NewAvalaraTaxConfiguration value => newAvalara(value),
            NewTaxJarConfiguration value => newTaxJar(value),
            NewSphereConfiguration value => newSphere(value),
            Numeral value => numeral(value),
            Anrok value => anrok(value),
            Stripe value => stripe(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of TaxConfiguration"
            ),
        };
    }

    public static implicit operator TaxConfiguration(NewAvalaraTaxConfiguration value) =>
        new(value);

    public static implicit operator TaxConfiguration(NewTaxJarConfiguration value) => new(value);

    public static implicit operator TaxConfiguration(NewSphereConfiguration value) => new(value);

    public static implicit operator TaxConfiguration(Numeral value) => new(value);

    public static implicit operator TaxConfiguration(Anrok value) => new(value);

    public static implicit operator TaxConfiguration(Stripe value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of TaxConfiguration");
        }
    }

    public virtual bool Equals(TaxConfiguration? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class TaxConfigurationConverter : JsonConverter<TaxConfiguration?>
{
    public override TaxConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? taxProvider;
        try
        {
            taxProvider = json.GetProperty("tax_provider").GetString();
        }
        catch
        {
            taxProvider = null;
        }

        switch (taxProvider)
        {
            case "avalara":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewAvalaraTaxConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "taxjar":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "sphere":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "numeral":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Numeral>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "anrok":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Anrok>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "stripe":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Stripe>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new TaxConfiguration(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxConfiguration? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Numeral, NumeralFromRaw>))]
public sealed record class Numeral : ModelBase
{
    public required bool TaxExempt
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_exempt"); }
        init { ModelBase.Set(this._rawData, "tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "tax_provider"); }
        init { ModelBase.Set(this._rawData, "tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "automatic_tax_enabled"); }
        init { ModelBase.Set(this._rawData, "automatic_tax_enabled", value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        if (
            !JsonElement.DeepEquals(
                this.TaxProvider,
                JsonSerializer.Deserialize<JsonElement>("\"numeral\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.AutomaticTaxEnabled;
    }

    public Numeral()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

    public Numeral(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Numeral(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Numeral FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Numeral(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class NumeralFromRaw : IFromRaw<Numeral>
{
    public Numeral FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Numeral.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Anrok, AnrokFromRaw>))]
public sealed record class Anrok : ModelBase
{
    public required bool TaxExempt
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_exempt"); }
        init { ModelBase.Set(this._rawData, "tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "tax_provider"); }
        init { ModelBase.Set(this._rawData, "tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "automatic_tax_enabled"); }
        init { ModelBase.Set(this._rawData, "automatic_tax_enabled", value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        if (
            !JsonElement.DeepEquals(
                this.TaxProvider,
                JsonSerializer.Deserialize<JsonElement>("\"anrok\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.AutomaticTaxEnabled;
    }

    public Anrok()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
    }

    public Anrok(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Anrok(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Anrok FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Anrok(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class AnrokFromRaw : IFromRaw<Anrok>
{
    public Anrok FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Anrok.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Stripe, StripeFromRaw>))]
public sealed record class Stripe : ModelBase
{
    public required bool TaxExempt
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "tax_exempt"); }
        init { ModelBase.Set(this._rawData, "tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "tax_provider"); }
        init { ModelBase.Set(this._rawData, "tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
    /// </summary>
    public bool? AutomaticTaxEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "automatic_tax_enabled"); }
        init { ModelBase.Set(this._rawData, "automatic_tax_enabled", value); }
    }

    public override void Validate()
    {
        _ = this.TaxExempt;
        if (
            !JsonElement.DeepEquals(
                this.TaxProvider,
                JsonSerializer.Deserialize<JsonElement>("\"stripe\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.AutomaticTaxEnabled;
    }

    public Stripe()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
    }

    public Stripe(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Stripe(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Stripe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Stripe(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class StripeFromRaw : IFromRaw<Stripe>
{
    public Stripe FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Stripe.FromRawUnchecked(rawData);
}
