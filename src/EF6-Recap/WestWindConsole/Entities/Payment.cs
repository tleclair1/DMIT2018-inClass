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
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public Int32 Amount { get; set; }
        [Required]
        public Int16 PaymentTypeID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int TransactionID { get; set; }
        public DateTime ClearDate { get; set; }
    }
}
