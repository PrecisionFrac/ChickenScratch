using ChickenScratch.Util.Services;

namespace ChickenScratch.Business
{
    public abstract class BusinessBase<T>
    {
        protected Response<T> response = null;

        public BusinessBase()
        {
            response = new Response<T>();
        }
    }
}
