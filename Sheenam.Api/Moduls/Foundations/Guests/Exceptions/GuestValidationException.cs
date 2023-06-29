//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Xeptions;

namespace Sheenam.Api.Moduls.Foundations.Guests.Exceptions
{
    public class GuestValidationException : Xeption
    {
        public GuestValidationException(Xeption innerException)
            : base(message: "Guest validation error occured, fix the errors and try again",
                 innerException)
        { }
    }
}
