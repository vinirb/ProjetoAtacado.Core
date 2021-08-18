using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("categoria")]
    public partial class Categorium
    {
        public Categorium()
        {
            Subcategoria = new HashSet<Subcategorium>();
        }

        [Key]
        [Column("catid")]
        public int Catid { get; set; }
        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime Datainsert { get; set; }

        [InverseProperty(nameof(Subcategorium.Cat))]
        public virtual ICollection<Subcategorium> Subcategoria { get; set; }
    }
}
