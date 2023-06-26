//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using System;
using Xeptions;

namespace Sheenam.Api.Moduls.Foundations.Guests.Exceptions
{
    public class AlreadyExistGuestException : Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            :base(message: "Guest already exist", innerException)
        {}
    }
}