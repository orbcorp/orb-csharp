using Http = System.Net.Http;
using InvoiceLineItems = Orb.Models.InvoiceLineItems;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.InvoiceLineItems;

public sealed class InvoiceLineItemService : IInvoiceLineItemService
{
    readonly Orb::IOrbClient _client;

    public InvoiceLineItemService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<InvoiceLineItems::InvoiceLineItemCreateResponse> Create(
        InvoiceLineItems::InvoiceLineItemCreateParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<InvoiceLineItems::InvoiceLineItemCreateResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
