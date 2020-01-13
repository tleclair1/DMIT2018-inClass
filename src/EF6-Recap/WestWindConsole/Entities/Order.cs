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
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int SalesRepID { get; set; }
        [Required, StringLength(5, ErrorMessage = "Customer ID must be less than 5 characters")]
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public decimal Freight { get; set; }
        [Required]
        public bool Shipped { get; set; }
        [StringLength(40, ErrorMessage = "Ship Name must be less than 40 characters")]
        public string ShipName { get; set; }
        public int ShipAddressID { get; set; }
        [StringLength(250, ErrorMessage = "Comments must be less than 250 characters")]
        public string Comments { get; set; }

    }
}
