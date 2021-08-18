using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("subcategoria")]
    public partial class Subcategorium
    {
        public Subcategorium()
        {
            Produtos = new HashSet<Produto>();
        }

        [Key]
        [Column("subcatid")]
        public int Subcatid { get; set; }
        [Column("catid")]
        public int Catid { get; set; }
        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime Datainsert { get; set; }

        [ForeignKey(nameof(Catid))]
        [InverseProperty(nameof(Categorium.Subcategoria))]
        public virtual Categorium Cat { get; set; }
        [InverseProperty(nameof(Produto.Subcat))]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
