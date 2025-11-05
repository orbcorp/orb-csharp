using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Prices.ExternalPriceID;
using Models = Orb.Models;

namespace Orb.Services.Prices.ExternalPriceID;

public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    public IExternalPriceIDService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalPriceIDService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ExternalPriceIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Models::Price> Update(ExternalPriceIDUpdateParams parameters)
    {
        HttpRequest<ExternalPriceIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Models::Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Models::Price> Fetch(ExternalPriceIDFetchParams parameters)
    {
        HttpRequest<ExternalPriceIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Models::Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }
}
