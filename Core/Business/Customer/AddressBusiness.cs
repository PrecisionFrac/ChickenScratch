using ChickenScratch.Data;
using ChickenScratch.Util.Extensions;
using ChickenScratch.Util.Services;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ChickenScratch.Business
{
    public class AddressBusiness : BusinessBase<Model.Address>, IAddressBusiness
    {
        public AddressBusiness()
        {

        }

        //public Response<List<Model.Address>> Create(IEnumerable<Model.Address> addresses)
        //{
        //    Response<List<Model.Address>> response = null;

        //    if (addresses.IsNullOrEmpty())
        //    {
        //        response = new Response<List<Model.Address>>();
        //        response.Result = new List<Model.Address>();

        //        foreach (Model.Address address in addresses)
        //        {
        //            var resp = Create(address);
        //            response.Result.Add(resp.Result);
        //        }
        //    }

        //    return response;
        //}

        public Response<Model.Address> Create(Model.Address address)
        {
            IAddressRepository addressRepository = null;
            Validator<Model.Address> validator = ValidationFactory.CreateValidator<Model.Address>("Create");

            try
            {
                #region Validation

                if (!validator.Validate(address).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validator.Validate(address))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }
                else // Validate Email
                {
                    if (!address.PrimaryEmail.IsNullOrEmpty())
                    {
                        Validator<Model.Address> valEmail = ValidationFactory.CreateValidator<Model.Address>("Email");

                        if (!valEmail.Validate(address).IsValid)
                        {
                            response.Status = ResponseStatus.ErrorValidation;
                            response.ErrorValue = (int)ErrorCode.InvalidData;

                            foreach (var result in valEmail.Validate(address))
                            {
                                if (!response.Validations.ContainsKey(result.Key))
                                    response.Validations.Add(result.Key, result.Message);
                            }

                            return response;
                        }
                    }
                }

                #endregion Validation

                #region Create

                using (var ctx = new ChickenScratchContext())
                {
                    addressRepository = new AddressRepository(ctx);
                    addressRepository.Insert(address);

                    addressRepository.Save();

                    response.Result = address;
                    response.Status = ResponseStatus.Success;
                }

                #endregion Create

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
