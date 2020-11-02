using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUS.Models
{
    public partial class GoogleAccount
    {
        [Key]
        public int Id { get; set; }
        public int? GoogleId { get; set; }
        [StringLength(200)]
        public string Token { get; set; }
        public int? UserId { get; set; }
    }
}
