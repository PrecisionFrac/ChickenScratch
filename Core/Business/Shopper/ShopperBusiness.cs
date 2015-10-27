using ChickenScratch.Data;
using ChickenScratch.Data.Customer;
using ChickenScratch.Util.Services;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;

namespace ChickenScratch.Business
{
    public class ShopperBusiness : BusinessBase<Model.Shopper>, IShopperBusiness<Model.Shopper>
    {
        public ShopperBusiness()
            : base()
        {
        }

        public Response<Model.Shopper> Create(Model.Shopper entity)
        {
            IShopperRepository shopperRepository = null;
            IAddressRepository addressRepository = null;
            Validator<Model.Shopper> validator = ValidationFactory.CreateValidator<Model.Shopper>("Create");
            Validator<Model.Address> validatorAddress = ValidationFactory.CreateValidator<Model.Address>("Create");

            try
            {
                #region Validation

                if (!validator.Validate(entity).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validator.Validate(entity))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }

                if (!validatorAddress.Validate(entity).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validatorAddress.Validate(entity))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }

                #endregion Validation

                using (var ctx = new ChickenScratchContext())
                {
                    // Set default
                    entity.FromDate = DateTime.UtcNow;
                    entity.LastActivity = DateTime.MinValue;

                    // Create Customer
                    shopperRepository = new ShopperRepository(ctx);
                    shopperRepository.Insert(entity);

                    // Create Adrress
                    addressRepository = new AddressRepository(ctx);
                    addressRepository.Add(entity.Address);

                    shopperRepository.Save();

                    response.Result = entity;
                    response.Status = ResponseStatus.Success;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
