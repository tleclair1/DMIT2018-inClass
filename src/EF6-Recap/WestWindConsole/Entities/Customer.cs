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
    [Table("Customers")]
    public class Customer
    {
        [Key, StringLength(5, ErrorMessage = "Customer ID must be less than 5 characters")]
        public string CustomerID { get; set; }
        [Required, StringLength(40, ErrorMessage = "Company Name must be less than 40 characters")]
        public string CompanyName { get; set; }
        [Required, StringLength(30, ErrorMessage = "Contact Name must be less than 30 characters")]
        public string ContactName { get; set; }
        [StringLength(30, ErrorMessage = "Contact Title must be less than 30 characters")]
        public string ContactTitle { get; set; }
        [Required, StringLength(50, ErrorMessage = "Contact Email must be less than 50 characters")]
        public string ContactEmail { get; set; }
        [Required, StringLength(60, ErrorMessage = "Address ID must be less than 60 characters")]
        public string AddressID { get; set; }
        [Required, StringLength(24, ErrorMessage = "Phone must be less than 24 characters")]
        public string Phone { get; set; }
        [Required, StringLength(24, ErrorMessage = "Fax must be less than 24 characters")]
        public string Fax { get; set; }
    }
}
