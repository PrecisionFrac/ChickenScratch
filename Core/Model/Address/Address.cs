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

        [DataMember(Name = "line_1")]
        [Column("line_1", Order = 2)]
        [StringLength(100)]
        [Required]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Create")]
        [NotNullValidator(MessageTemplate = "Cannot be null", Ruleset = "Update")]

        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Line1 length must be between 1 and 100", Ruleset = "Create")]
        [StringLengthValidator(
        1, RangeBoundaryType.Inclusive,
        100, RangeBoundaryType.Inclusive,
        MessageTemplate = "Line1 length must be between 1 and 100", Ruleset = "Update")]
        public String Line1 { get; set; }

        [DataMember(Name = "line_2")]
        [Column("line_2", Order = 3)]
        [StringLength(100)]

        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //100, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Line2 length must be between 0 and 100", Ruleset = "Create")]
        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //100, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Line2 length must be between 0 and 100", Ruleset = "Update")]
        public String Line2 { get; set; }

        [DataMember(Name = "line_3")]
        [Column("line_3", Order = 4)]
        [StringLength(100)]

        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //100, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Line3 length must be between 0 and 100", Ruleset = "Create")]
        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //100, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Line3 length must be between 0 and 100", Ruleset = "Update")]
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

        private String countryCodeArea;

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
        public String CountryCodeArea
        {
            get { return countryCodeArea; }
            set
            {
                //if (CountryCode != null)
                //    CountryCode.
                countryCodeArea = value;
            }
        }

        //[DataMember]
        //public Model.CountryCode CountryCode { get; set; }

        [DataMember(Name = "primary_phone")]
        [Column("primary_phone", Order = 8)]
        [StringLength(15)]

        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //15, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Primary Phone length must be between 0 and 15", Ruleset = "Create")]
        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //15, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Primary Phone length must be between 0 and 15", Ruleset = "Update")]
        public String PrimaryPhone { get; set; }

        [DataMember(Name = "primary_email")]
        [Column("primary_email", Order = 9)]
        [StringLength(100)]

        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //255, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Primary Email length must be between 0 and 255", Ruleset = "Create")]
        //[StringLengthValidator(
        //0, RangeBoundaryType.Inclusive,
        //255, RangeBoundaryType.Inclusive,
        //MessageTemplate = "Primary Email length must be between 0 and 255", Ruleset = "Update")]
        [RegexValidator(@"^[A-Z0-9._%-]+@(?:[A-Z0-9-]+\.)+[A-Z]{2,4}$", RegexOptions.IgnoreCase, Negated = false, Ruleset = "Create")]
        [RegexValidator(@"^[A-Z0-9._%-]+@(?:[A-Z0-9-]+\.)+[A-Z]{2,4}$", RegexOptions.IgnoreCase, Negated = false, Ruleset = "Update")]
        public String PrimaryEmail { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Model.Customer> Customers { get; set; }
    }
}
