using System.Net.Http;

namespace Orb.Exceptions;

public class Orb5xxException : OrbApiException
{
    public Orb5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
