using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace ChickenScratch.Model
{
    [DataContract]
    [Table("Addresses")]
    public class Address : ModelBase
    {
        [DataMember(Name = "address_id")]
        [Key]
        [Column("address_id", Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Update")]
        [NotNullValidator(MessageTemplate = "Cannot be null.", Ruleset = "Delete")]
        public Int32 AddressId { get; set; }

        [DataMember(Name = "address_1")]
        [Column("line_1", Order = 2)]
        [StringLength(100)]
        [Required(ErrorMessage = "Line 1 no can not be empty")]

        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Update")]

        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Line 1 length must be between 1 and 100", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Line 1 length must be between 1 and 100", Ruleset = "Update")]
        public String Line1 { get; set; }

        [DataMember(Name = "address_2")]
        [Column("line_2", Order = 3)]
        [StringLength(100)]
        public String Line2 { get; set; }

        [DataMember(Name = "address_3")]
        [Column("line_3", Order = 4)]
        [StringLength(100)]
        public String Line3 { get; set; }

        [DataMember(Name = "town_city")]
        [Column("town_city", Order = 5)]
        [StringLength(50)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Update")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        50, RangeBoundaryType.Inclusive,
        MessageTemplate = "Town City length must be between 1 and 50", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        50, RangeBoundaryType.Inclusive,
        MessageTemplate = "Town City length must be between 1 and 50", Ruleset = "Update")]
        public String Town_City { get; set; }

        [DataMember(Name = "state_province")]
        [Column("state_province", Order = 6)]
        [StringLength(10)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Update")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        10, RangeBoundaryType.Inclusive,
        MessageTemplate = "State Province length must be between 1 and 10", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        10, RangeBoundaryType.Inclusive,
        MessageTemplate = "State Province length must be between 1 and 10", Ruleset = "Update")]
        public String State_Province { get; set; }

        [DataMember(Name = "country_code")]
        [Column("country_code", Order = 7)]
        [StringLength(10)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Update")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        10, RangeBoundaryType.Inclusive,
        MessageTemplate = "Country Code length must be between 1 and 10", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        10, RangeBoundaryType.Inclusive,
        MessageTemplate = "Country Code length must be between 1 and 10", Ruleset = "Update")]
        public String CountryCode { get; set; }


        [DataMember(Name = "primary_phone")]
        [Column("primary_phone", Order = 8)]
        [StringLength(15)]
        public String PrimaryPhone { get; set; }

        [DataMember(Name = "primary_email")]
        [Column("primary_email", Order = 9)]
        [StringLength(100)]
        [RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase, Negated = false, Ruleset = "Email", ErrorMessage = "Email invalid")]
        public String PrimaryEmail { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Model.Customer> Customers { get; set; }
    }
}
