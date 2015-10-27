using ChickenScratch.Data.Repositories;
using System.Collections.Generic;

namespace ChickenScratch.Data
{
    public class AddressRepository : GenericRepository<ChickenScratchContext, Model.Address>, IAddressRepository
    {
        public AddressRepository(ChickenScratchContext context)
            : base(context)
        {
        }

        public Model.Address Insert(Model.Address address)
        {
            base.Add(address);
            return address;
        }

        public ICollection<Model.Address> Inserts(ICollection<Model.Address> addresses)
        {
            foreach (Model.Address address in addresses)
                this.Add(address);

            return addresses;
        }

        public Model.Address Update(Model.Address address)
        {
            base.Entry(address);
            return address;
        }

        public ICollection<Model.Address> Updates(ICollection<Model.Address> addresses)
        {
            foreach (Model.Address address in addresses)
                this.Update(address);

            return addresses;
        }

        public void Delete(Model.Address address)
        {
            base.Remove(address);
        }

        public void Deletes(ICollection<Model.Address> addresses)
        {
            foreach (Model.Address address in addresses)
                this.Delete(address);
        }
    }
}
