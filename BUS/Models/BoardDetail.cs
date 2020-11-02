using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUS.Models
{
    public partial class BoardDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        public int? ColumnId { get; set; }
        public int? BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("BoardDetail")]
        public virtual Board Board { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Column.BoardDetail))]
        public virtual Column IdNavigation { get; set; }
    }
}
