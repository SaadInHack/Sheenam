using Sheenam.Api.Moduls.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        void Dispose();
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
