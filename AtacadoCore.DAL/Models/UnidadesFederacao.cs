using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("UnidadesFederacao")]
    public partial class UnidadesFederacao
    {
        public UnidadesFederacao()
        {
            Mesoregiaos = new HashSet<Mesoregiao>();
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Column("UFID")]
        public int Ufid { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Required]
        [Column("SiglaUF")]
        [StringLength(2)]
        public string SiglaUf { get; set; }
        [Column("RegiaoID")]
        public int RegiaoId { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime? Datainsert { get; set; }

        [ForeignKey(nameof(RegiaoId))]
        [InverseProperty("UnidadesFederacaos")]
        public virtual Regiao Regiao { get; set; }
        [InverseProperty(nameof(Mesoregiao.Uf))]
        public virtual ICollection<Mesoregiao> Mesoregiaos { get; set; }
        [InverseProperty(nameof(Municipio.Uf))]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
