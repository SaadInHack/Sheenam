//==================================================
// Copyright (c) Coalation of Good-Hearted Engineers
// Free to Use To Find Comfort And Peace
//==================================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sheenam.Api.Brockers.Storages
{
    public partial class StorageBrocker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBrocker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        public override void Dispose(){}
    }
}
