using System.Net.Http;

namespace Orb.Exceptions;

public class OrbUnprocessableEntityException : Orb4xxException
{
    public OrbUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
