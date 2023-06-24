//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using System;

namespace Sheenam.Api.Brockers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
