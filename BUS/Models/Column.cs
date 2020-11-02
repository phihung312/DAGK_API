using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUS.Models
{
    public partial class Column
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Name { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual BoardDetail BoardDetail { get; set; }
    }
}
