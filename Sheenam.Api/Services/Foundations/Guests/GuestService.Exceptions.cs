//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Sheenam.Api.Moduls.Foundations.Guests;
using Sheenam.Api.Moduls.Foundations.Guests.Exceptions;
using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();

        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            catch (NullGuestException nullGuestException)
            {
                
                throw CreateAndLogValidationException(nullGuestException);
            }
            catch(InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch(SqlException sqlException)
            {
                var failedGuestStorageException = 
                    new FailedGuestStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedGuestStorageException);
            }
        }
        private GuestValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guestValidationException =
                     new GuestValidationException(exception);

            this.loggingBroker.LogError(guestValidationException);

            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var guestDependencyException = new GuestDependencyException(exception);
            this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }
    }
}
