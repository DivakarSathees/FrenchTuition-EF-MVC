using System;

namespace Frenchtution.Exceptions
{

public class FrenchTuitionBookingException : Exception
{
    public FrenchTuitionBookingException(string message) : base(message)
    {
    }
}
}