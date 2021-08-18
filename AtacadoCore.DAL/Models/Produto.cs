using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("produto")]
    public partial class Produto
    {
        [Key]
        [Column("produtoid")]
        public int Produtoid { get; set; }
        [Column("subcatid")]
        public int Subcatid { get; set; }
        [Column("catid")]
        public int Catid { get; set; }
        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime Datainsert { get; set; }

        [ForeignKey(nameof(Subcatid))]
        [InverseProperty(nameof(Subcategorium.Produtos))]
        public virtual Subcategorium Subcat { get; set; }
    }
}
