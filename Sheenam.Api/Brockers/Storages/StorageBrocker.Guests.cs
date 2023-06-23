//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheenam.Api.Moduls.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Brockers.Storages
{
    public partial class StorageBrocker
    {
        public DbSet<Guest> Guests{ get; set; }

        public async ValueTask<Guest> InsertGuestAsync(Guest guest)
        {
            using var broker = new StorageBrocker(this.configuration);

            EntityEntry<Guest> guestEntityEntry =
                await broker.Guests.AddAsync(guest);

            await broker.SaveChangesAsync();

            return guestEntityEntry.Entity;
        }
    }
}
