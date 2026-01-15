using System.Net.Http;

namespace Orb.Exceptions;

public class OrbBadRequestException : Orb4xxException
{
    public OrbBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
