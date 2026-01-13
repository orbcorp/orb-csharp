using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services;

namespace Orb;

/// <inheritdoc/>
public sealed class OrbClient : IOrbClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    readonly Lazy<IOrbClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrbClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IOrbClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrbClient(modifier(this._options));
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

    readonly Lazy<ICreditBlockService> _creditBlocks;
    public ICreditBlockService CreditBlocks
    {
        get { return _creditBlocks.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public OrbClient()
    {
        _options = new();

        _withRawResponse = new(() => new OrbClientWithRawResponse(this._options));
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
        _creditBlocks = new(() => new CreditBlockService(this));
    }

    public OrbClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class OrbClientWithRawResponse : IOrbClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? WebhookSecret
    {
        get { return this._options.WebhookSecret; }
        init { this._options.WebhookSecret = value; }
    }

    /// <inheritdoc/>
    public IOrbClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrbClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<ITopLevelServiceWithRawResponse> _topLevel;
    public ITopLevelServiceWithRawResponse TopLevel
    {
        get { return _topLevel.Value; }
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }

    readonly Lazy<ICouponServiceWithRawResponse> _coupons;
    public ICouponServiceWithRawResponse Coupons
    {
        get { return _coupons.Value; }
    }

    readonly Lazy<ICreditNoteServiceWithRawResponse> _creditNotes;
    public ICreditNoteServiceWithRawResponse CreditNotes
    {
        get { return _creditNotes.Value; }
    }

    readonly Lazy<ICustomerServiceWithRawResponse> _customers;
    public ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IInvoiceLineItemServiceWithRawResponse> _invoiceLineItems;
    public IInvoiceLineItemServiceWithRawResponse InvoiceLineItems
    {
        get { return _invoiceLineItems.Value; }
    }

    readonly Lazy<IInvoiceServiceWithRawResponse> _invoices;
    public IInvoiceServiceWithRawResponse Invoices
    {
        get { return _invoices.Value; }
    }

    readonly Lazy<IItemServiceWithRawResponse> _items;
    public IItemServiceWithRawResponse Items
    {
        get { return _items.Value; }
    }

    readonly Lazy<IMetricServiceWithRawResponse> _metrics;
    public IMetricServiceWithRawResponse Metrics
    {
        get { return _metrics.Value; }
    }

    readonly Lazy<IPlanServiceWithRawResponse> _plans;
    public IPlanServiceWithRawResponse Plans
    {
        get { return _plans.Value; }
    }

    readonly Lazy<IPriceServiceWithRawResponse> _prices;
    public IPriceServiceWithRawResponse Prices
    {
        get { return _prices.Value; }
    }

    readonly Lazy<ISubscriptionServiceWithRawResponse> _subscriptions;
    public ISubscriptionServiceWithRawResponse Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly Lazy<IAlertServiceWithRawResponse> _alerts;
    public IAlertServiceWithRawResponse Alerts
    {
        get { return _alerts.Value; }
    }

    readonly Lazy<IDimensionalPriceGroupServiceWithRawResponse> _dimensionalPriceGroups;
    public IDimensionalPriceGroupServiceWithRawResponse DimensionalPriceGroups
    {
        get { return _dimensionalPriceGroups.Value; }
    }

    readonly Lazy<ISubscriptionChangeServiceWithRawResponse> _subscriptionChanges;
    public ISubscriptionChangeServiceWithRawResponse SubscriptionChanges
    {
        get { return _subscriptionChanges.Value; }
    }

    readonly Lazy<ICreditBlockServiceWithRawResponse> _creditBlocks;
    public ICreditBlockServiceWithRawResponse CreditBlocks
    {
        get { return _creditBlocks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var idempotencyHeaderValue = string.Format("stainless-csharp-retry-{0}", Guid.NewGuid());
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(
                        request,
                        retries,
                        idempotencyHeaderValue,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw OrbExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new OrbIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        string idempotencyHeaderValue,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        if (!requestMessage.Headers.Contains("Idempotency-Key"))
        {
            requestMessage.Headers.Add("Idempotency-Key", idempotencyHeaderValue);
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
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
        catch (HttpRequestException e)
        {
            throw new OrbIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (apiBackoff != null && apiBackoff < TimeSpan.FromMinutes(1))
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is OrbIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public OrbClientWithRawResponse()
    {
        _options = new();

        _topLevel = new(() => new TopLevelServiceWithRawResponse(this));
        _beta = new(() => new BetaServiceWithRawResponse(this));
        _coupons = new(() => new CouponServiceWithRawResponse(this));
        _creditNotes = new(() => new CreditNoteServiceWithRawResponse(this));
        _customers = new(() => new CustomerServiceWithRawResponse(this));
        _events = new(() => new EventServiceWithRawResponse(this));
        _invoiceLineItems = new(() => new InvoiceLineItemServiceWithRawResponse(this));
        _invoices = new(() => new InvoiceServiceWithRawResponse(this));
        _items = new(() => new ItemServiceWithRawResponse(this));
        _metrics = new(() => new MetricServiceWithRawResponse(this));
        _plans = new(() => new PlanServiceWithRawResponse(this));
        _prices = new(() => new PriceServiceWithRawResponse(this));
        _subscriptions = new(() => new SubscriptionServiceWithRawResponse(this));
        _alerts = new(() => new AlertServiceWithRawResponse(this));
        _dimensionalPriceGroups = new(() => new DimensionalPriceGroupServiceWithRawResponse(this));
        _subscriptionChanges = new(() => new SubscriptionChangeServiceWithRawResponse(this));
        _creditBlocks = new(() => new CreditBlockServiceWithRawResponse(this));
    }

    public OrbClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
