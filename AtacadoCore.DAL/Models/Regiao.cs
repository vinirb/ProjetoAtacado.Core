using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Regiao")]
    public partial class Regiao
    {
        public Regiao()
        {
            UnidadesFederacaos = new HashSet<UnidadesFederacao>();
        }

        [Key]
        [Column("RegiaoID")]
        public int RegiaoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(2)]
        public string SiglaRegiao { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime? Datainsert { get; set; }

        [InverseProperty(nameof(UnidadesFederacao.Regiao))]
        public virtual ICollection<UnidadesFederacao> UnidadesFederacaos { get; set; }
    }
}
