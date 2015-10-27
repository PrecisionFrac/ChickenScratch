using System;
using System.Collections.Generic;
using System.Linq;

namespace ChickenScratch.Util.Extensions
{
    public static class CollectionExtension
    {
        public static Boolean IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();

            //if (enumerable == null)
            //{
            //    return true;
            //}
            ///* If this is a list, use the Count property for efficiency. 
            // * The Count property is O(1) while IEnumerable.Count() is O(N). */
            //var collection = enumerable as ICollection<T>;

            //if (collection != null)
            //{
            //    return collection.Count < 1;
            //}

            //return !enumerable.Any();
        }
    }
}
