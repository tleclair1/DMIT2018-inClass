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
    [Table("ManifestItems")]
    public class ManifestItem
    {
        [Key]
        public int ManifestItemID { get; set; }
        [Required]
        public int ShipmentID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public Int16 ShipQuantity { get; set; }
    }
}
