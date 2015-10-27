using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ChickenScratch.Model
{
    [DataContract]
    [Table("Customer_Addresses")]
    public class CustomerAddress : ModelBase
    {
        [Column("customer_id", Order = 1, TypeName = "INT")]
        [DataMember]
        public Int32 CustomerId { get; set; }

        [Column("address_id", Order = 2, TypeName = "INT")]
        [DataMember]
        public Int32 AddressId { get; set; }

        [DataMember]
        [Column("date_address_from", Order = 3)]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [Required]
        public DateTime FromDate { get; set; }

        [DataMember]
        [Column("date_address_to", Order = 4)]
        [NotNullValidator(MessageTemplate = "Cannot be null!")]
        [Required]
        public DateTime ToDate { get; set; }

        [IgnoreDataMember]
        public virtual Model.Customer Customer { get; set; }

        [DataMember]
        public virtual Model.Address Address { get; set; }
    }
}
