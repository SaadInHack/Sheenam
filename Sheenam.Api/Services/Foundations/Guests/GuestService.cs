//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Sheenam.Api.Brockers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Moduls.Foundations.Guests;
using Sheenam.Api.Moduls.Foundations.Guests.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            try
            {
                if (guest is null)
                {
                    throw new NullGuestException();
                }
                return await this.storageBroker.InsertGuestAsync(guest);
            }
            catch (NullGuestException nullGuestException)
            {
                var guestValidationException =
                     new GuestValidationException(nullGuestException);

                this.loggingBroker.LogError(guestValidationException);

                throw guestValidationException;
            }
        }

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
