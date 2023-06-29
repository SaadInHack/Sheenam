//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Xeptions;

namespace Sheenam.Api.Moduls.Foundations.Guests.Exceptions
{
    public class GuestDependencyException : Xeption
    {
        public GuestDependencyException(Xeption innerXeption)
          : base(message: "Guest dependecy error occurred, contact support",
             innerXeption)
        { }
    }
}
