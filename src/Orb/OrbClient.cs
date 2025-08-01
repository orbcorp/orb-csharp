using Alerts = Orb.Services.Alerts;
using Beta = Orb.Services.Beta;
using Coupons = Orb.Services.Coupons;
using CreditNotes = Orb.Services.CreditNotes;
using Customers = Orb.Services.Customers;
using Events = Orb.Services.Events;
using Http = System.Net.Http;
using InvoiceLineItems = Orb.Services.InvoiceLineItems;
using Invoices = Orb.Services.Invoices;
using Items = Orb.Services.Items;
using Metrics = Orb.Services.Metrics;
using Plans = Orb.Services.Plans;
using Prices = Orb.Services.Prices;
using SubscriptionChanges = Orb.Services.SubscriptionChanges;
using System = System;
using TopLevel = Orb.Services.TopLevel;

namespace Orb;

public sealed class OrbClient : IOrbClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

    System::Lazy<System::Uri> _baseUrl = new(() =>
        new System::Uri(
            System::Environment.GetEnvironmentVariable("ORB_BASE_URL")
                ?? "https://api.withorb.com/v1"
        )
    );
    public System::Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    System::Lazy<string> _apiKey = new(() =>
        System::Environment.GetEnvironmentVariable("ORB_API_KEY")
        ?? throw new System::ArgumentNullException(nameof(APIKey))
    );
    public string APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    readonly System::Lazy<TopLevel::ITopLevelService> _topLevel;
    public TopLevel::ITopLevelService TopLevel
    {
        get { return _topLevel.Value; }
    }

    readonly System::Lazy<Beta::IBetaService> _beta;
    public Beta::IBetaService Beta
    {
        get { return _beta.Value; }
    }

    readonly System::Lazy<Coupons::ICouponService> _coupons;
    public Coupons::ICouponService Coupons
    {
        get { return _coupons.Value; }
    }

    readonly System::Lazy<CreditNotes::ICreditNoteService> _creditNotes;
    public CreditNotes::ICreditNoteService CreditNotes
    {
        get { return _creditNotes.Value; }
    }

    readonly System::Lazy<Customers::ICustomerService> _customers;
    public Customers::ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly System::Lazy<Events::IEventService> _events;
    public Events::IEventService Events
    {
        get { return _events.Value; }
    }

    readonly System::Lazy<InvoiceLineItems::IInvoiceLineItemService> _invoiceLineItems;
    public InvoiceLineItems::IInvoiceLineItemService InvoiceLineItems
    {
        get { return _invoiceLineItems.Value; }
    }

    readonly System::Lazy<Invoices::IInvoiceService> _invoices;
    public Invoices::IInvoiceService Invoices
    {
        get { return _invoices.Value; }
    }

    readonly System::Lazy<Items::IItemService> _items;
    public Items::IItemService Items
    {
        get { return _items.Value; }
    }

    readonly System::Lazy<Metrics::IMetricService> _metrics;
    public Metrics::IMetricService Metrics
    {
        get { return _metrics.Value; }
    }

    readonly System::Lazy<Plans::IPlanService> _plans;
    public Plans::IPlanService Plans
    {
        get { return _plans.Value; }
    }

    readonly System::Lazy<Prices::IPriceService> _prices;
    public Prices::IPriceService Prices
    {
        get { return _prices.Value; }
    }

    readonly System::Lazy<global::Orb.Services.Subscriptions.ISubscriptionService> _subscriptions;
    public global::Orb.Services.Subscriptions.ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly System::Lazy<Alerts::IAlertService> _alerts;
    public Alerts::IAlertService Alerts
    {
        get { return _alerts.Value; }
    }

    readonly System::Lazy<global::Orb.Services.DimensionalPriceGroups.IDimensionalPriceGroupService> _dimensionalPriceGroups;
    public global::Orb.Services.DimensionalPriceGroups.IDimensionalPriceGroupService DimensionalPriceGroups
    {
        get { return _dimensionalPriceGroups.Value; }
    }

    readonly System::Lazy<SubscriptionChanges::ISubscriptionChangeService> _subscriptionChanges;
    public SubscriptionChanges::ISubscriptionChangeService SubscriptionChanges
    {
        get { return _subscriptionChanges.Value; }
    }

    public OrbClient()
    {
        _topLevel = new(() => new TopLevel::TopLevelService(this));
        _beta = new(() => new Beta::BetaService(this));
        _coupons = new(() => new Coupons::CouponService(this));
        _creditNotes = new(() => new CreditNotes::CreditNoteService(this));
        _customers = new(() => new Customers::CustomerService(this));
        _events = new(() => new Events::EventService(this));
        _invoiceLineItems = new(() => new InvoiceLineItems::InvoiceLineItemService(this));
        _invoices = new(() => new Invoices::InvoiceService(this));
        _items = new(() => new Items::ItemService(this));
        _metrics = new(() => new Metrics::MetricService(this));
        _plans = new(() => new Plans::PlanService(this));
        _prices = new(() => new Prices::PriceService(this));
        _subscriptions = new(() => new global::Orb.Services.Subscriptions.SubscriptionService(this)
        );
        _alerts = new(() => new Alerts::AlertService(this));
        _dimensionalPriceGroups = new(() =>
            new global::Orb.Services.DimensionalPriceGroups.DimensionalPriceGroupService(this)
        );
        _subscriptionChanges = new(() => new SubscriptionChanges::SubscriptionChangeService(this));
    }
}
