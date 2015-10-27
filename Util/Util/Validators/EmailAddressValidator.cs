using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;

namespace ChickenScratch.Util.Validators
{
    /// <summary>
    /// Regex validator that is specific to email addresses.
    /// </summary>
    public sealed class EmailAddressValidator : RegexValidator
    {
        private const string EmailPattern = @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
        /// </summary>
        public EmailAddressValidator()
            : this(false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddressValidator"/> class.
        /// </summary>
        /// <param name="allowNullOrEmptyString">if set to <c>true</c> [allow null or empty string].</param>
        /// <param name="negated">if set to <c>true</c> [negated].</param>
        public EmailAddressValidator(bool allowNullOrEmptyString, bool negated)
            : base(EmailPattern, negated)
        {
            AllowNullOrEmptyString = allowNullOrEmptyString;
        }

        /// <summary>
        /// Implements the validation logic for the receiver.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The object on the behalf of which the validation is performed.</param>
        /// <param name="key">The key that identifies the source of <paramref name="objectToValidate"/>.</param>
        /// <param name="validationResults">The validation results to which the outcome of the validation should be stored.</param>
        /// <remarks>
        /// The implementation for this method will perform type checking and converstion before forwarding the
        /// validation request to method <see cref="M:Microsoft.Practices.EnterpriseLibrary.Validation.Validator`1.DoValidate(`0,System.Object,System.String,Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults)"/>.
        /// </remarks>
        /// <see cref="M:Microsoft.Practices.EnterpriseLibrary.Validation.Validator.DoValidate(System.Object,System.Object,System.String,Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResults)"/>
        protected override void DoValidate(String objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if ((AllowNullOrEmptyString) && (string.IsNullOrEmpty(objectToValidate)))
                return;
            else
                base.DoValidate(objectToValidate, currentTarget, key, validationResults);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow null or empty string].
        /// </summary>
        /// <value>
        /// <c>true</c> if [allow null or empty string]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowNullOrEmptyString { get; set; }

        /// <summary>
        /// Gets the Default Message Template when the validator is negated.
        /// </summary>
        /// <value></value>
        protected override string DefaultNegatedMessageTemplate
        {
            get
            {
                return "Field should not be in email address format.";
            }
        }

        /// <summary>
        /// Gets the Default Message Template when the validator is non negated.
        /// </summary>
        /// <value></value>
        protected override string DefaultNonNegatedMessageTemplate
        {
            get
            {
                return "Field is not in email address format.";
            }
        }
    }
}
