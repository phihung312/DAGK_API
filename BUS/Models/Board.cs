using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUS.Models
{
    public partial class Board
    {
        public Board()
        {
            BoardDetail = new HashSet<BoardDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Link { get; set; }
        public int? UserId { get; set; }

        [InverseProperty("Board")]
        public virtual ICollection<BoardDetail> BoardDetail { get; set; }
    }
}
