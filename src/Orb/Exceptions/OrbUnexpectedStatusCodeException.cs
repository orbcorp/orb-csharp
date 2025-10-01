using System.Net.Http;

namespace Orb.Exceptions;

public class OrbUnexpectedStatusCodeException : OrbApiException
{
    public OrbUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
