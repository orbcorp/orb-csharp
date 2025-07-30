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
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<InvoiceLineItemCreateResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }
}
