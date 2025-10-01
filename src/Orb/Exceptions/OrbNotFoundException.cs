using System.Net.Http;

namespace Orb.Exceptions;

public class OrbNotFoundException : Orb4xxException
{
    public OrbNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
