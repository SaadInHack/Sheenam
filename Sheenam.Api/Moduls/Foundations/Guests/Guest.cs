//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use Comfort And Peace
//==================================================

using System;

namespace Sheenam.Api.Moduls.Foundations.Guests
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DataOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public GenderType Gender { get; set; }

    }
}
