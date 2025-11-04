using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices.ExternalPriceID;

public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    readonly IOrbClient _client;

    public ExternalPriceIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Price> Update(ExternalPriceIDUpdateParams parameters)
    {
        HttpRequest<ExternalPriceIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Price> Fetch(ExternalPriceIDFetchParams parameters)
    {
        HttpRequest<ExternalPriceIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }
}
