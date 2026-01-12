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

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint is used to update customer details given an `external_customer_id`
/// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)). Note that the
/// resource and semantics of this endpoint exactly mirror [Update Customer](update-customer).
/// </summary>
public sealed record class CustomerUpdateByExternalIDParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public NewAccountingSyncConfiguration? AccountingSyncConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NewAccountingSyncConfiguration>(
                "accounting_sync_configuration"
            );
        }
        init { this._rawBodyData.Set("accounting_sync_configuration", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("additional_emails");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "additional_emails",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will automatically attempt
    /// to charge a saved payment method, if available. This parameter defaults to
    /// `True` when a payment provider is provided on customer creation.
    /// </summary>
    public bool? AutoCollection
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("auto_collection");
        }
        init { this._rawBodyData.Set("auto_collection", value); }
    }

    /// <summary>
    /// Used to determine if invoices for this customer will be automatically issued.
    /// If true, invoices will be automatically issued. If false, invoices will require
    /// manual approval.If `null` is specified, the customer's auto issuance setting
    /// will be inherited from the account-level setting.
    /// </summary>
    public bool? AutoIssuance
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("auto_issuance");
        }
        init { this._rawBodyData.Set("auto_issuance", value); }
    }

    public AddressInput? BillingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AddressInput>("billing_address");
        }
        init { this._rawBodyData.Set("billing_address", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string used for the customer's invoices and balance.
    /// If not set at creation time, will be set at subscription creation time.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// A valid customer email, to be used for invoicing and notifications.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("email");
        }
        init { this._rawBodyData.Set("email", value); }
    }

    public bool? EmailDelivery
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("email_delivery");
        }
        init { this._rawBodyData.Set("email_delivery", value); }
    }

    /// <summary>
    /// The external customer ID. This can only be set if the customer has no existing
    /// external customer ID. Since this action may change usage quantities for all
    /// existing subscriptions, it is disallowed if the customer has issued invoices
    /// with usage line items and subject to the same restrictions as backdated subscription creation.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawBodyData.Set("external_customer_id", value); }
    }

    /// <summary>
    /// The hierarchical relationships for this customer.
    /// </summary>
    public CustomerHierarchyConfig? Hierarchy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerHierarchyConfig>("hierarchy");
        }
        init { this._rawBodyData.Set("hierarchy", value); }
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The full name of the customer
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Payment configuration for the customer, applicable when using Orb Invoicing
    /// with a supported payment provider such as Stripe.
    /// </summary>
    public CustomerUpdateByExternalIDParamsPaymentConfiguration? PaymentConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerUpdateByExternalIDParamsPaymentConfiguration>(
                "payment_configuration"
            );
        }
        init { this._rawBodyData.Set("payment_configuration", value); }
    }

    /// <summary>
    /// This is used for creating charges or invoices in an external system via Orb.
    /// When not in test mode: - the connection must first be configured in the Orb
    /// webapp.  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`,
    /// `bill.com`, `netsuite`), any product mappings must first be configured with
    /// the Orb team.
    /// </summary>
    public ApiEnum<string, CustomerUpdateByExternalIDParamsPaymentProvider>? PaymentProvider
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, CustomerUpdateByExternalIDParamsPaymentProvider>
            >("payment_provider");
        }
        init { this._rawBodyData.Set("payment_provider", value); }
    }

    /// <summary>
    /// The ID of this customer in an external payments solution, such as Stripe.
    /// This is used for creating charges or invoices in the external system via Orb.
    /// </summary>
    public string? PaymentProviderID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("payment_provider_id");
        }
        init { this._rawBodyData.Set("payment_provider_id", value); }
    }

    public NewReportingConfiguration? ReportingConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<NewReportingConfiguration>(
                "reporting_configuration"
            );
        }
        init { this._rawBodyData.Set("reporting_configuration", value); }
    }

    public AddressInput? ShippingAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AddressInput>("shipping_address");
        }
        init { this._rawBodyData.Set("shipping_address", value); }
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration? TaxConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerUpdateByExternalIDParamsTaxConfiguration>(
                "tax_configuration"
            );
        }
        init { this._rawBodyData.Set("tax_configuration", value); }
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
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CustomerTaxID>("tax_id");
        }
        init { this._rawBodyData.Set("tax_id", value); }
    }

    public CustomerUpdateByExternalIDParams() { }

    public CustomerUpdateByExternalIDParams(
        CustomerUpdateByExternalIDParams customerUpdateByExternalIDParams
    )
        : base(customerUpdateByExternalIDParams)
    {
        this.ID = customerUpdateByExternalIDParams.ID;

        this._rawBodyData = new(customerUpdateByExternalIDParams._rawBodyData);
    }

    public CustomerUpdateByExternalIDParams(
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
    CustomerUpdateByExternalIDParams(
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
    public static CustomerUpdateByExternalIDParams FromRawUnchecked(
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/external_customer_id/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
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
}

/// <summary>
/// Payment configuration for the customer, applicable when using Orb Invoicing with
/// a supported payment provider such as Stripe.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CustomerUpdateByExternalIDParamsPaymentConfiguration,
        CustomerUpdateByExternalIDParamsPaymentConfigurationFromRaw
    >)
)]
public sealed record class CustomerUpdateByExternalIDParamsPaymentConfiguration : JsonModel
{
    /// <summary>
    /// Provider-specific payment configuration.
    /// </summary>
    public IReadOnlyList<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>? PaymentProviders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>
            >("payment_providers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>?>(
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

    public CustomerUpdateByExternalIDParamsPaymentConfiguration() { }

    public CustomerUpdateByExternalIDParamsPaymentConfiguration(
        CustomerUpdateByExternalIDParamsPaymentConfiguration customerUpdateByExternalIDParamsPaymentConfiguration
    )
        : base(customerUpdateByExternalIDParamsPaymentConfiguration) { }

    public CustomerUpdateByExternalIDParamsPaymentConfiguration(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateByExternalIDParamsPaymentConfiguration(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUpdateByExternalIDParamsPaymentConfigurationFromRaw.FromRawUnchecked"/>
    public static CustomerUpdateByExternalIDParamsPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomerUpdateByExternalIDParamsPaymentConfigurationFromRaw
    : IFromRawJson<CustomerUpdateByExternalIDParamsPaymentConfiguration>
{
    /// <inheritdoc/>
    public CustomerUpdateByExternalIDParamsPaymentConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerUpdateByExternalIDParamsPaymentConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider,
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderFromRaw
    >)
)]
public sealed record class CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
    : JsonModel
{
    /// <summary>
    /// The payment provider to configure.
    /// </summary>
    public required ApiEnum<
        string,
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
    > ProviderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
                >
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

    public CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider() { }

    public CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider(
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider customerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider
    )
        : base(customerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider) { }

    public CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderFromRaw.FromRawUnchecked"/>
    public static CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider(
        ApiEnum<
            string,
            CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
        > providerType
    )
        : this()
    {
        this.ProviderType = providerType;
    }
}

class CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderFromRaw
    : IFromRawJson<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider>
{
    /// <inheritdoc/>
    public CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProvider.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// The payment provider to configure.
/// </summary>
[JsonConverter(
    typeof(CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderTypeConverter)
)]
public enum CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType
{
    Stripe,
}

sealed class CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderTypeConverter
    : JsonConverter<CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType>
{
    public override CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" =>
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe,
            _ => (CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerUpdateByExternalIDParamsPaymentConfigurationPaymentProviderProviderType.Stripe =>
                    "stripe",
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
/// When not in test mode: - the connection must first be configured in the Orb webapp.
///  - if the provider is an invoicing provider (`stripe_invoice`, `quickbooks`,
/// `bill.com`, `netsuite`), any product mappings must first be configured with the
/// Orb team.
/// </summary>
[JsonConverter(typeof(CustomerUpdateByExternalIDParamsPaymentProviderConverter))]
public enum CustomerUpdateByExternalIDParamsPaymentProvider
{
    Quickbooks,
    BillCom,
    StripeCharge,
    StripeInvoice,
    Netsuite,
}

sealed class CustomerUpdateByExternalIDParamsPaymentProviderConverter
    : JsonConverter<CustomerUpdateByExternalIDParamsPaymentProvider>
{
    public override CustomerUpdateByExternalIDParamsPaymentProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quickbooks" => CustomerUpdateByExternalIDParamsPaymentProvider.Quickbooks,
            "bill.com" => CustomerUpdateByExternalIDParamsPaymentProvider.BillCom,
            "stripe_charge" => CustomerUpdateByExternalIDParamsPaymentProvider.StripeCharge,
            "stripe_invoice" => CustomerUpdateByExternalIDParamsPaymentProvider.StripeInvoice,
            "netsuite" => CustomerUpdateByExternalIDParamsPaymentProvider.Netsuite,
            _ => (CustomerUpdateByExternalIDParamsPaymentProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerUpdateByExternalIDParamsPaymentProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomerUpdateByExternalIDParamsPaymentProvider.Quickbooks => "quickbooks",
                CustomerUpdateByExternalIDParamsPaymentProvider.BillCom => "bill.com",
                CustomerUpdateByExternalIDParamsPaymentProvider.StripeCharge => "stripe_charge",
                CustomerUpdateByExternalIDParamsPaymentProvider.StripeInvoice => "stripe_invoice",
                CustomerUpdateByExternalIDParamsPaymentProvider.Netsuite => "netsuite",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CustomerUpdateByExternalIDParamsTaxConfigurationConverter))]
public record class CustomerUpdateByExternalIDParamsTaxConfiguration : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewAvalaraTaxConfiguration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewTaxJarConfiguration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewSphereConfiguration value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationStripe value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CustomerUpdateByExternalIDParamsTaxConfiguration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewAvalaraTaxConfiguration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewAvalara(out var value)) {
    ///     // `value` is of type `NewAvalaraTaxConfiguration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewAvalara([NotNullWhen(true)] out NewAvalaraTaxConfiguration? value)
    {
        value = this.Value as NewAvalaraTaxConfiguration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewTaxJarConfiguration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewTaxJar(out var value)) {
    ///     // `value` is of type `NewTaxJarConfiguration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewTaxJar([NotNullWhen(true)] out NewTaxJarConfiguration? value)
    {
        value = this.Value as NewTaxJarConfiguration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NewSphereConfiguration"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewSphere(out var value)) {
    ///     // `value` is of type `NewSphereConfiguration`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewSphere([NotNullWhen(true)] out NewSphereConfiguration? value)
    {
        value = this.Value as NewSphereConfiguration;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomerUpdateByExternalIDParamsTaxConfigurationNumeral"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNumeral(out var value)) {
    ///     // `value` is of type `CustomerUpdateByExternalIDParamsTaxConfigurationNumeral`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNumeral(
        [NotNullWhen(true)] out CustomerUpdateByExternalIDParamsTaxConfigurationNumeral? value
    )
    {
        value = this.Value as CustomerUpdateByExternalIDParamsTaxConfigurationNumeral;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomerUpdateByExternalIDParamsTaxConfigurationAnrok"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAnrok(out var value)) {
    ///     // `value` is of type `CustomerUpdateByExternalIDParamsTaxConfigurationAnrok`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAnrok(
        [NotNullWhen(true)] out CustomerUpdateByExternalIDParamsTaxConfigurationAnrok? value
    )
    {
        value = this.Value as CustomerUpdateByExternalIDParamsTaxConfigurationAnrok;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CustomerUpdateByExternalIDParamsTaxConfigurationStripe"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStripe(out var value)) {
    ///     // `value` is of type `CustomerUpdateByExternalIDParamsTaxConfigurationStripe`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStripe(
        [NotNullWhen(true)] out CustomerUpdateByExternalIDParamsTaxConfigurationStripe? value
    )
    {
        value = this.Value as CustomerUpdateByExternalIDParamsTaxConfigurationStripe;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (NewAvalaraTaxConfiguration value) => {...},
    ///     (NewTaxJarConfiguration value) => {...},
    ///     (NewSphereConfiguration value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationStripe value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NewAvalaraTaxConfiguration> newAvalara,
        System::Action<NewTaxJarConfiguration> newTaxJar,
        System::Action<NewSphereConfiguration> newSphere,
        System::Action<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral> numeral,
        System::Action<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok> anrok,
        System::Action<CustomerUpdateByExternalIDParamsTaxConfigurationStripe> stripe
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
            case CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value:
                numeral(value);
                break;
            case CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value:
                anrok(value);
                break;
            case CustomerUpdateByExternalIDParamsTaxConfigurationStripe value:
                stripe(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CustomerUpdateByExternalIDParamsTaxConfiguration"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (NewAvalaraTaxConfiguration value) => {...},
    ///     (NewTaxJarConfiguration value) => {...},
    ///     (NewSphereConfiguration value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value) => {...},
    ///     (CustomerUpdateByExternalIDParamsTaxConfigurationStripe value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NewAvalaraTaxConfiguration, T> newAvalara,
        System::Func<NewTaxJarConfiguration, T> newTaxJar,
        System::Func<NewSphereConfiguration, T> newSphere,
        System::Func<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral, T> numeral,
        System::Func<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok, T> anrok,
        System::Func<CustomerUpdateByExternalIDParamsTaxConfigurationStripe, T> stripe
    )
    {
        return this.Value switch
        {
            NewAvalaraTaxConfiguration value => newAvalara(value),
            NewTaxJarConfiguration value => newTaxJar(value),
            NewSphereConfiguration value => newSphere(value),
            CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value => numeral(value),
            CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value => anrok(value),
            CustomerUpdateByExternalIDParamsTaxConfigurationStripe value => stripe(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CustomerUpdateByExternalIDParamsTaxConfiguration"
            ),
        };
    }

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewAvalaraTaxConfiguration value
    ) => new(value);

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewTaxJarConfiguration value
    ) => new(value);

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        NewSphereConfiguration value
    ) => new(value);

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationNumeral value
    ) => new(value);

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationAnrok value
    ) => new(value);

    public static implicit operator CustomerUpdateByExternalIDParamsTaxConfiguration(
        CustomerUpdateByExternalIDParamsTaxConfigurationStripe value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of CustomerUpdateByExternalIDParamsTaxConfiguration"
            );
        }
        this.Switch(
            (newAvalara) => newAvalara.Validate(),
            (newTaxJar) => newTaxJar.Validate(),
            (newSphere) => newSphere.Validate(),
            (numeral) => numeral.Validate(),
            (anrok) => anrok.Validate(),
            (stripe) => stripe.Validate()
        );
    }

    public virtual bool Equals(CustomerUpdateByExternalIDParamsTaxConfiguration? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class CustomerUpdateByExternalIDParamsTaxConfigurationConverter
    : JsonConverter<CustomerUpdateByExternalIDParamsTaxConfiguration?>
{
    public override CustomerUpdateByExternalIDParamsTaxConfiguration? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? taxProvider;
        try
        {
            taxProvider = element.GetProperty("tax_provider").GetString();
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
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "taxjar":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewTaxJarConfiguration>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "sphere":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<NewSphereConfiguration>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "numeral":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "anrok":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "stripe":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<CustomerUpdateByExternalIDParamsTaxConfigurationStripe>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new CustomerUpdateByExternalIDParamsTaxConfiguration(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomerUpdateByExternalIDParamsTaxConfiguration? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerUpdateByExternalIDParamsTaxConfigurationNumeral,
        CustomerUpdateByExternalIDParamsTaxConfigurationNumeralFromRaw
    >)
)]
public sealed record class CustomerUpdateByExternalIDParamsTaxConfigurationNumeral : JsonModel
{
    public required bool TaxExempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_exempt");
        }
        init { this._rawData.Set("tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("tax_provider");
        }
        init { this._rawData.Set("tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
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

    /// <inheritdoc/>
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

    public CustomerUpdateByExternalIDParamsTaxConfigurationNumeral()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

    public CustomerUpdateByExternalIDParamsTaxConfigurationNumeral(
        CustomerUpdateByExternalIDParamsTaxConfigurationNumeral customerUpdateByExternalIDParamsTaxConfigurationNumeral
    )
        : base(customerUpdateByExternalIDParamsTaxConfigurationNumeral) { }

    public CustomerUpdateByExternalIDParamsTaxConfigurationNumeral(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"numeral\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateByExternalIDParamsTaxConfigurationNumeral(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUpdateByExternalIDParamsTaxConfigurationNumeralFromRaw.FromRawUnchecked"/>
    public static CustomerUpdateByExternalIDParamsTaxConfigurationNumeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerUpdateByExternalIDParamsTaxConfigurationNumeral(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class CustomerUpdateByExternalIDParamsTaxConfigurationNumeralFromRaw
    : IFromRawJson<CustomerUpdateByExternalIDParamsTaxConfigurationNumeral>
{
    /// <inheritdoc/>
    public CustomerUpdateByExternalIDParamsTaxConfigurationNumeral FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerUpdateByExternalIDParamsTaxConfigurationNumeral.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerUpdateByExternalIDParamsTaxConfigurationAnrok,
        CustomerUpdateByExternalIDParamsTaxConfigurationAnrokFromRaw
    >)
)]
public sealed record class CustomerUpdateByExternalIDParamsTaxConfigurationAnrok : JsonModel
{
    public required bool TaxExempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_exempt");
        }
        init { this._rawData.Set("tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("tax_provider");
        }
        init { this._rawData.Set("tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
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

    /// <inheritdoc/>
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

    public CustomerUpdateByExternalIDParamsTaxConfigurationAnrok()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
    }

    public CustomerUpdateByExternalIDParamsTaxConfigurationAnrok(
        CustomerUpdateByExternalIDParamsTaxConfigurationAnrok customerUpdateByExternalIDParamsTaxConfigurationAnrok
    )
        : base(customerUpdateByExternalIDParamsTaxConfigurationAnrok) { }

    public CustomerUpdateByExternalIDParamsTaxConfigurationAnrok(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"anrok\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateByExternalIDParamsTaxConfigurationAnrok(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUpdateByExternalIDParamsTaxConfigurationAnrokFromRaw.FromRawUnchecked"/>
    public static CustomerUpdateByExternalIDParamsTaxConfigurationAnrok FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerUpdateByExternalIDParamsTaxConfigurationAnrok(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class CustomerUpdateByExternalIDParamsTaxConfigurationAnrokFromRaw
    : IFromRawJson<CustomerUpdateByExternalIDParamsTaxConfigurationAnrok>
{
    /// <inheritdoc/>
    public CustomerUpdateByExternalIDParamsTaxConfigurationAnrok FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerUpdateByExternalIDParamsTaxConfigurationAnrok.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CustomerUpdateByExternalIDParamsTaxConfigurationStripe,
        CustomerUpdateByExternalIDParamsTaxConfigurationStripeFromRaw
    >)
)]
public sealed record class CustomerUpdateByExternalIDParamsTaxConfigurationStripe : JsonModel
{
    public required bool TaxExempt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("tax_exempt");
        }
        init { this._rawData.Set("tax_exempt", value); }
    }

    public JsonElement TaxProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("tax_provider");
        }
        init { this._rawData.Set("tax_provider", value); }
    }

    /// <summary>
    /// Whether to automatically calculate tax for this customer. When null, inherits
    /// from account-level setting. When true or false, overrides the account setting.
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

    /// <inheritdoc/>
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

    public CustomerUpdateByExternalIDParamsTaxConfigurationStripe()
    {
        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
    }

    public CustomerUpdateByExternalIDParamsTaxConfigurationStripe(
        CustomerUpdateByExternalIDParamsTaxConfigurationStripe customerUpdateByExternalIDParamsTaxConfigurationStripe
    )
        : base(customerUpdateByExternalIDParamsTaxConfigurationStripe) { }

    public CustomerUpdateByExternalIDParamsTaxConfigurationStripe(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.TaxProvider = JsonSerializer.Deserialize<JsonElement>("\"stripe\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerUpdateByExternalIDParamsTaxConfigurationStripe(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomerUpdateByExternalIDParamsTaxConfigurationStripeFromRaw.FromRawUnchecked"/>
    public static CustomerUpdateByExternalIDParamsTaxConfigurationStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CustomerUpdateByExternalIDParamsTaxConfigurationStripe(bool taxExempt)
        : this()
    {
        this.TaxExempt = taxExempt;
    }
}

class CustomerUpdateByExternalIDParamsTaxConfigurationStripeFromRaw
    : IFromRawJson<CustomerUpdateByExternalIDParamsTaxConfigurationStripe>
{
    /// <inheritdoc/>
    public CustomerUpdateByExternalIDParamsTaxConfigurationStripe FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomerUpdateByExternalIDParamsTaxConfigurationStripe.FromRawUnchecked(rawData);
}
