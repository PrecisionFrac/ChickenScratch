using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenScratch.Data.Migrations
{
    public class ChickenScratchInitializer : CreateDatabaseIfNotExists<ChickenScratchContext>
    {
        public ChickenScratchInitializer()
        {

        }

        protected override void Seed(ChickenScratchContext context)
        {
            //foreach (var enumValue in Enum.GetValues(typeof(Profile.ProfileType)))
            //{
            //    var id = (short)enumValue;
            //    var val = enumValue.ToString();

            //    if (!context.Profiles.Any(p => p.ProfileId == id))
            //        context.Profiles.Add(
            //            new Profile { ProfileId = id, Name = val, DateCreated = DateTime.UtcNow, DateLastUpdated = DateTime.UtcNow }
            //        );
            //}

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
