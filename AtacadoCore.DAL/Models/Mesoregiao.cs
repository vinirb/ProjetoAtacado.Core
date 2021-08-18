using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Mesoregiao")]
    public partial class Mesoregiao
    {
        public Mesoregiao()
        {
            Microregiaos = new HashSet<Microregiao>();
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("UFID")]
        public int Ufid { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime? Datainsert { get; set; }

        [ForeignKey(nameof(Ufid))]
        [InverseProperty(nameof(UnidadesFederacao.Mesoregiaos))]
        public virtual UnidadesFederacao Uf { get; set; }
        [InverseProperty(nameof(Microregiao.Mesoregiao))]
        public virtual ICollection<Microregiao> Microregiaos { get; set; }
        [InverseProperty(nameof(Municipio.Mesoregiao))]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
