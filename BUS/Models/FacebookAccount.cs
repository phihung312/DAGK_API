using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUS.Models
{
    public partial class FacebookAccount
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FacebookId { get; set; }
        [StringLength(200)]
        public string Token { get; set; }
    }
}
