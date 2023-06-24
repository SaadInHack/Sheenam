﻿//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Moq;
using Sheenam.Api.Brockers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Moduls.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.guestService = new GuestService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }


        private static Guest CreateRandomGuest() =>
            CreateGuestFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedExpection)
        {
            return actualException =>
                actualException.Message == expectedExpection.Message
                && actualException.InnerException.Message == expectedExpection.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedExpection.InnerException.Data);
        }

        private static Filler <Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler = new Filler<Guest>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}