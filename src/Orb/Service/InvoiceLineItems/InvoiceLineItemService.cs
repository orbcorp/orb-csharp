using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.InvoiceLineItems;

namespace Orb.Service.InvoiceLineItems;

public sealed class InvoiceLineItemService : IInvoiceLineItemService
{
    readonly IOrbClient _client;

    public InvoiceLineItemService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<InvoiceLineItemCreateResponse> Create(InvoiceLineItemCreateParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<InvoiceLineItemCreateResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
