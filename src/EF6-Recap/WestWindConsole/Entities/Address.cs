using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindConsole.Entities
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int AddressID { get;set; }
        [Required, StringLength(60, ErrorMessage = "Address must be less than 60 characters")]
        [Column("Address")] // Tell EF that the database column name is "Address"
        public string StreetAddress { get; set; }
        [Required, StringLength(15, ErrorMessage = "City must be less than 15 characters")]
        public string City { get; set; }
        [StringLength(15, ErrorMessage = "Region must be less than 15 characters")]
        public string Region { get; set; }
        [StringLength(10, ErrorMessage = "Postal code must be less than 10 characters")]
        public string PostalCode { get; set; }
        [Required, StringLength(15, ErrorMessage = "Country must be less than 15 characters")]
        public string Country { get; set; }

        #region Navigation Properties
        public virtual ICollection<Supplier> Suppliers { get; set; } = new 
            HashSet<Supplier>();
        #endregion
    }
}
