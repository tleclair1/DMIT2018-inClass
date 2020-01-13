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
    [Table("Territories")]
    public class Territory
    {
        [Key, StringLength(20, ErrorMessage = "Territory ID must be less than 20 characters")]
        public string TerritoryID { get; set; }
        [Required, StringLength(50, ErrorMessage = "Territory Description must be less than 50 characters")]
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
