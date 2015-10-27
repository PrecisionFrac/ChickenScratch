using ChickenScratch.Data;
using ChickenScratch.Data.Customer;
using ChickenScratch.Model;
using ChickenScratch.Util.Services;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Linq;

namespace ChickenScratch.Business
{
    public class CustomerBusiness : BusinessBase<Model.Customer>, ICustomerBusiness
    {
        public CustomerBusiness()
            : base()
        {
        }

        public Response<Model.Customer> Create(Model.Customer customer)
        {
            ICustomerRepository customerRepository = null;
            IAddressRepository addressRepository = null;
            Validator<Model.Customer> validator = ValidationFactory.CreateValidator<Model.Customer>("Create");
            Validator<Model.Address> validatorAddress = ValidationFactory.CreateValidator<Model.Address>("Create");

            try
            {
                #region Validation

                if (!validator.Validate(customer).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validator.Validate(customer))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }

                if (customer.Addresses == null || customer.Addresses.Count == 0)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    response.Validations.Add("Address", "Address must have onde");

                    return response;
                }
                else
                {
                    foreach (Model.Address address in customer.Addresses)
                    {
                        if (!validatorAddress.Validate(address).IsValid)
                        {
                            response.Status = ResponseStatus.ErrorValidation;
                            response.ErrorValue = (int)ErrorCode.InvalidData;

                            foreach (var result in validatorAddress.Validate(address))
                            {
                                if (!response.Validations.ContainsKey(result.Key))
                                    response.Validations.Add(result.Key, result.Message);
                            }

                            return response;
                        }
                    }
                }

                #endregion Validation

                using (var ctx = new ChickenScratchContext())
                {
                    // Set default
                    customer.FromDate = DateTime.UtcNow;
                    customer.ToDate = DateTime.UtcNow.AddYears(1);

                    // Create Customer
                    customerRepository = new CustomerRepository(ctx);
                    customerRepository.Add(customer);

                    // Create Adrress
                    addressRepository = new AddressRepository(ctx);
                    addressRepository.Inserts(customer.Addresses);

                    customerRepository.Save();

                    response.Result = customer;
                    response.Status = ResponseStatus.Success;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response<Model.Customer> Update(Model.Customer customer)
        {
            ICustomerRepository customerRepository = null;
            IAddressRepository addressRepository = null;
            Validator<Model.Customer> validator = ValidationFactory.CreateValidator<Model.Customer>("Update");
            Validator<Model.Address> validatorAddress = ValidationFactory.CreateValidator<Model.Address>("Update");

            try
            {
                #region Validation

                if (!validator.Validate(customer).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validator.Validate(customer))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }

                foreach (Model.Address address in customer.Addresses)
                {
                    if (!validatorAddress.Validate(address).IsValid)
                    {
                        response.Status = ResponseStatus.ErrorValidation;
                        response.ErrorValue = (int)ErrorCode.InvalidData;

                        foreach (var result in validatorAddress.Validate(address))
                        {
                            if (!response.Validations.ContainsKey(result.Key))
                                response.Validations.Add(result.Key, result.Message);
                        }

                        return response;
                    }
                }

                #endregion Validation

                using (var ctx = new ChickenScratchContext())
                {
                    // Set default
                    //customer.FromDate = DateTime.UtcNow;
                    //customer.ToDate = DateTime.UtcNow.AddYears(1);

                    // Create Customer
                    customerRepository = new CustomerRepository(ctx);
                    customerRepository.Update(customer);

                    // Create Adrress
                    addressRepository = new AddressRepository(ctx);
                    addressRepository.Updates(customer.Addresses);

                    customerRepository.Save();

                    response.Result = customer;
                    response.Status = ResponseStatus.Success;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Response<Model.Customer> Delete(Model.Customer customer)
        {
            ICustomerRepository customerRepository = null;
            IAddressRepository addressRepository = null;
            Validator<Model.Customer> validator = ValidationFactory.CreateValidator<Model.Customer>("Delete");

            try
            {
                #region Validation

                if (!validator.Validate(customer).IsValid)
                {
                    response.Status = ResponseStatus.ErrorValidation;
                    response.ErrorValue = (int)ErrorCode.InvalidData;

                    foreach (var result in validator.Validate(customer))
                    {
                        if (!response.Validations.ContainsKey(result.Key))
                            response.Validations.Add(result.Key, result.Message);
                    }

                    return response;
                }

                #endregion Validation

                using (var ctx = new ChickenScratchContext())
                {
                    customerRepository = new CustomerRepository(ctx);

                    // Find Customer
                    customer = customerRepository.GetBy(customer);

                    if (customer == null)
                    {
                        response.Validations.Add("Customer", "Customer does not exist");
                        response.ErrorValue = (Int32)ErrorCode.InvalidCustomerId;
                        return response;
                    }

                    // Delete Customer
                    customerRepository.Delete(customer);

                    if (customer.Addresses.Count > 0)
                    {
                        addressRepository = new AddressRepository(ctx);

                        // Delete Adrress(es)
                        foreach (Model.Address address in customer.Addresses)
                        {
                            addressRepository.Delete(address);
                        }
                    }

                    customerRepository.Save();

                    response.Result = customer;
                    response.Status = ResponseStatus.Success;

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
