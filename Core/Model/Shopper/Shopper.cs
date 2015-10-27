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
    [Table("Shoppers")]
    public class Shopper : ModelBase//<Customer>
    {
        [DataMember]
        [Key]
        [Column("shopper_id", Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int32 ShopperId { get; set; }

        [DataMember]
        [Column("shopper_name", Order = 2)]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive, /* Lower Bound */
        100, RangeBoundaryType.Inclusive, /* Upper Bound */
        MessageTemplate = "Name length must be between 1 and 100")]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [StringLength(100)]
        [Required]
        public String Name { get; set; }

        [DataMember]
        [Column("shopper_opt_in", Order = 3)]
        [StringLength(1)]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [Required]
        public Boolean OptIn { get; set; }

        [DataMember]
        [Column("shopper_status", Order = 4)]
        [StringLength(1)]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [Required]
        public String Status { get; set; }

        [DataMember]
        [Column("shopper_from_date", Order = 5)]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [Required]
        public DateTime FromDate { get; set; }

        [DataMember]
        [Column("shopper_last_activity", Order = 6)]
        public DateTime LastActivity { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        public bool IsValid()
        {
            return Validate().IsValid;
        }

        public virtual ValidationResults Validate()
        {
            return Validation.Validate<Shopper>(this);
        }
    }
}
