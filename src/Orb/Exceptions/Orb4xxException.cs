using System.Net.Http;

namespace Orb.Exceptions;

public class Orb4xxException : OrbApiException
{
    public Orb4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
