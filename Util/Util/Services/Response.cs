using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ChickenScratch.Util.Services
{
    [DataContract]
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T result)
            : this(result, ResponseStatus.Success, String.Empty)
        {
        }

        public Response(T result, ResponseStatus status)
               : this(result, status, String.Empty)
        {
        }

        public Response(T result, ResponseStatus status, String message)
            : this(result, status, message, null)
        {
        }

        public Response(T result, ResponseStatus status, String message, Exception exception)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
            this.Exception = exception;
        }

        private ResponseStatus status;

        [DataMember]
        public ResponseStatus Status
        {
            get
            {
                if (Validations.Count > 0)
                    this.status = ResponseStatus.ErrorValidation;
                else if (Exception != null)
                    this.status = ResponseStatus.Error;

                return status;
            }

            set
            {
                status = value;
            }
        }

        [DataMember]
        public String Message { get; set; }

        [DataMember]
        public T Result { get; set; }

        public Exception Exception { get; set; }

        private Dictionary<String, String> validations;
        [DataMember]
        public Dictionary<String, String> Validations
        {
            get
            {
                if (validations == null)
                    validations = new Dictionary<string, string>();
                return validations;
            }
            set { validations = value; }
        }

        [DataMember]
        public Int32 ErrorValue { get; set; }

        #region Error

        public void SetError()
        {
            this.Status = ResponseStatus.Error;
        }

        public void SetError(Exception ex)
        {
            this.Exception = ex;
            this.Message = ex.Message;
            this.Status = ResponseStatus.Error;
        }

        public void SetError(Exception ex, ErrorCode errorCode)
        {
            this.Exception = ex;
            this.Message = ex.Message;
            this.ErrorValue = (Int32)errorCode;
            this.Status = ResponseStatus.Error;
        }

        #endregion Error
    }

    public enum ErrorCode : short
    {
        // -90 - record not created, database returned error condition		
        Database = -90,

        // -91 - record not created, invalid data passed
        InvalidData = -91,

        // - 92 - record not created, invalid customer_id
        InvalidCustomerId = -92
    }
}
