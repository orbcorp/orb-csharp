using System.Net.Http;

namespace Orb.Exceptions;

public class OrbUnauthorizedException : Orb4xxException
{
    public OrbUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
