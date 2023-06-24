//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Moduls.Foundations.Guests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public ValueTask<Guest> AddGuestAsync(Guest guest) =>
            throw new NotImplementedException();



        public Guest AddGuestAsync()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is GuestService service &&
                   EqualityComparer<IStorageBroker>.Default.Equals(storageBroker, service.storageBroker);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
