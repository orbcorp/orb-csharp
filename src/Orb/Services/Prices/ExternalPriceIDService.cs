using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

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

    public async Task<Price> Update(
        ExternalPriceIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPriceIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response.Deserialize<Price>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Price> Fetch(
        ExternalPriceIDFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPriceIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response.Deserialize<Price>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }
}
