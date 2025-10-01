using System;

namespace Orb.Exceptions;

public class OrbInvalidDataException : OrbException
{
    public OrbInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
