using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ChickenScratch.Data
{
    public class ChickenScratchContext : DbContext
    {
        public DbSet<Model.Customer> Customers { get; set; }

        public DbSet<Model.Address> Addresses { get; set; }

        public ChickenScratchContext()
                : base("ChickenScratchConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static ChickenScratchContext Create()
        {
            return new ChickenScratchContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            CreateManyToMany(modelBuilder);
        }

        private void CreateManyToMany(DbModelBuilder modelBuilder)
        {
            try
            {
                //modelBuilder.Entity<Model.CustomerAddress>()
                //         .HasKey(ca => new { ca.CustomerId, ca.AddressId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Init Data

        public void InitData()
        {
            //using (var ctx = new ChickenScratchContext())
            //{
            //    ctx.SaveChanges();
            //}
        }
    }

    #endregion Init Data
}