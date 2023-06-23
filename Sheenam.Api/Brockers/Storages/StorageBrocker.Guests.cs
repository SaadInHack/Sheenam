//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Moduls.Foundations.Guests;

namespace Sheenam.Api.Brockers.Storages
{
    public partial class StorageBrocker
    {
        public DbSet<Guest> Guests{ get; set; }
    }
}
