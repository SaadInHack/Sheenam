//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Xeptions;

namespace Sheenam.Api.Moduls.Foundations.Guests.Exceptions
{
    public class GuestDependencyValidationException : Xeption
    {
        public GuestDependencyValidationException(Xeption innerException)
            :base(message: "Geust dependency validation error occurred, fix the errors and try again",
                 innerException)
        {}
    }
}
