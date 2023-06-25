//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Sheenam.Api.Moduls.Foundations.Guests;
using Sheenam.Api.Moduls.Foundations.Guests.Exceptions;
using System;
using System.Data;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotNull(guest);

            Validate(
                  (Rule: IsInvalid(guest.Id), Parameter: nameof(Guest.Id)),
                  (Rule: IsInvalid(guest.FirstName), Parameter: nameof(Guest.FirstName)),
                  (Rule: IsInvalid(guest.LastName), Parameter: nameof(Guest.LastName)),
                  (Rule: IsInvalid(guest.DataOfBirth), Parameter: nameof(Guest.DataOfBirth)),
                  (Rule: IsInvalid(guest.Email), Parameter: nameof(Guest.Email)),
                  (Rule: IsInvalid(guest.Address), Parameter: nameof(Guest.Address)));
        }

        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static void Validate(params (dynamic Rule, string Parametr)[] validations)
        {
            var invalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidGuestException.UpsertDataList(
                       key: parametr,
                       value: rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();
        }
    }
}
