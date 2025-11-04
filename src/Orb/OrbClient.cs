using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services.Alerts;
using Orb.Services.Beta;
using Orb.Services.Coupons;
using Orb.Services.CreditNotes;
using Orb.Services.Customers;
using Orb.Services.DimensionalPriceGroups;
using Orb.Services.Events;
using Orb.Services.InvoiceLineItems;
using Orb.Services.Invoices;
using Orb.Services.Items;
using Orb.Services.Metrics;
using Orb.Services.Plans;
using Orb.Services.Prices;
using Orb.Services.SubscriptionChanges;
using Orb.Services.Subscriptions;
using Orb.Services.TopLevel;

namespace Orb;

public sealed class OrbClient : IOrbClient
{
    readonly ClientOptions _options = new();

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    readonly Lazy<ITopLevelService> _topLevel;
    public ITopLevelService TopLevel
    {
        get { return _topLevel.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    readonly Lazy<ICouponService> _coupons;
    public ICouponService Coupons
    {
        get { return _coupons.Value; }
    }

    readonly Lazy<ICreditNoteService> _creditNotes;
    public ICreditNoteService CreditNotes
    {
        get { return _creditNotes.Value; }
    }

    readonly Lazy<ICustomerService> _customers;
    public ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IInvoiceLineItemService> _invoiceLineItems;
    public IInvoiceLineItemService InvoiceLineItems
    {
        get { return _invoiceLineItems.Value; }
    }

    readonly Lazy<IInvoiceService> _invoices;
    public IInvoiceService Invoices
    {
        get { return _invoices.Value; }
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }

    readonly Lazy<IMetricService> _metrics;
    public IMetricService Metrics
    {
        get { return _metrics.Value; }
    }

    readonly Lazy<IPlanService> _plans;
    public IPlanService Plans
    {
        get { return _plans.Value; }
    }

    readonly Lazy<IPriceService> _prices;
    public IPriceService Prices
    {
        get { return _prices.Value; }
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly Lazy<IAlertService> _alerts;
    public IAlertService Alerts
    {
        get { return _alerts.Value; }
    }

    readonly Lazy<IDimensionalPriceGroupService> _dimensionalPriceGroups;
    public IDimensionalPriceGroupService DimensionalPriceGroups
    {
        get { return _dimensionalPriceGroups.Value; }
    }

    readonly Lazy<ISubscriptionChangeService> _subscriptionChanges;
    public ISubscriptionChangeService SubscriptionChanges
    {
        get { return _subscriptionChanges.Value; }
    }

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource cts = new(this.Timeout);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new OrbIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw OrbExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new OrbIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public OrbClient()
    {
        _topLevel = new(() => new TopLevelService(this));
        _beta = new(() => new BetaService(this));
        _coupons = new(() => new CouponService(this));
        _creditNotes = new(() => new CreditNoteService(this));
        _customers = new(() => new CustomerService(this));
        _events = new(() => new EventService(this));
        _invoiceLineItems = new(() => new InvoiceLineItemService(this));
        _invoices = new(() => new InvoiceService(this));
        _items = new(() => new ItemService(this));
        _metrics = new(() => new MetricService(this));
        _plans = new(() => new PlanService(this));
        _prices = new(() => new PriceService(this));
        _subscriptions = new(() => new SubscriptionService(this));
        _alerts = new(() => new AlertService(this));
        _dimensionalPriceGroups = new(() => new DimensionalPriceGroupService(this));
        _subscriptionChanges = new(() => new SubscriptionChangeService(this));
    }
}
