using System;
using System.Net.Http;

namespace Orb.Exceptions;

public class OrbException : Exception
{
    public OrbException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected OrbException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
