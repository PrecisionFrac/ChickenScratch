using ChickenScratch.Data.Repositories;
using System.Collections.Generic;

namespace ChickenScratch.Data.Customer
{
    public interface IAddressRepository : IGenericRepository<Model.Address>
    {
        Model.Address Insert(Model.Address address);

        ICollection<Model.Address> Inserts(ICollection<Model.Address> address);

        Model.Address Update(Model.Address address);

        ICollection<Model.Address> Updates(ICollection<Model.Address> addresses);

        void Delete(Model.Address address);

        void Deletes(ICollection<Model.Address> addresses);
    }
}
