//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using System;
using Xeptions;

namespace Sheenam.Api.Moduls.Foundations.Guests.Exceptions
{
    public class FailedGuestStorageException : Xeption
    {
        public FailedGuestStorageException(Exception innerException)
            :base(message: "Failed guest storage error occurred, contact suppor",
                 innerException)
        {}
    }
}
