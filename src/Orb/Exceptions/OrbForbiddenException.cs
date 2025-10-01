using System.Net.Http;

namespace Orb.Exceptions;

public class OrbForbiddenException : Orb4xxException
{
    public OrbForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
