using System;
using System.Net.Http;

namespace Orb.Exceptions;

public class OrbIOException : OrbException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public OrbIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
