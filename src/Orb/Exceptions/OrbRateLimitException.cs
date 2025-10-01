using System.Net.Http;

namespace Orb.Exceptions;

public class OrbRateLimitException : Orb4xxException
{
    public OrbRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
