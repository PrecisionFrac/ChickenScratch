using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ChickenScratch.Model
{
    [DataContract]
    [Table("Customers")]
    public class Customer : ModelBase
    {

        //[System.ComponentModel.DataAnnotations.Required(
        //ErrorMessage = "You must specify a value for the product ID.")]
        //[System.ComponentModel.DataAnnotations.StringLength(6,
        //ErrorMessage = "Product ID must be 6 characters.")]
        //[System.ComponentModel.DataAnnotations.RegularExpression("[A-Z]{2}[0-9]{4}",
        //ErrorMessage = "Product ID must be 2 capital letters and 4 numbers.")]

        [DataMember]
        [Key]
        [Column("customer_id", Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Delete")]
        public Int32 CustomerId { get; set; }

        [DataMember]
        [Column("customer_name", Order = 2)]
        [StringLength(100)]
        [Required]

        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]

        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Name length must be between 1 and 100", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Name length must be between 1 and 100", Ruleset = "Update")]
        public String Name { get; set; }

        [DataMember]
        [Column("customer_tokensecret", Order = 3)]
        [Required]
        [StringLength(255)]

        [NotNullValidator(MessageTemplate = "Cannot be null!", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null!", Ruleset = "Update")]

        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        255, RangeBoundaryType.Inclusive,
        MessageTemplate = "Name length must be between 1 and 255 - CREATE", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        255, RangeBoundaryType.Inclusive,
        MessageTemplate = "Name length must be between 1 and 255", Ruleset = "Update")]
        public String TokenSecret { get; set; }

        [DataMember]
        [Column("customer_status", Order = 4)]
        [StringLength(1)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]
        public String Status { get; set; }

        [DataMember]
        [Column("customer_from_date", Order = 5)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]
        public DateTime FromDate { get; set; }

        [DataMember]
        [Column("customer_to_date", Order = 6)]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]
        public DateTime ToDate { get; set; }

        [DataMember]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Create")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}