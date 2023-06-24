//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================


using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Api.Moduls.Foundations.Guests;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldAddGuestAdd()
        {
            // Given
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest returningGuest = inputGuest;
            Guest expectedGuest = returningGuest.DeepClone();


            this.storageBrokerMock.Setup(broker => 
                broker.InsertGuestAsync(inputGuest))
                .ReturnsAsync(returningGuest);
            // when
            Guest actualGuest = 
                await this.guestService.AddGuestAsync(inputGuest);

            // then

            actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertGuestAsync(inputGuest),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
