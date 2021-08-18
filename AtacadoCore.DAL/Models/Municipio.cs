using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Municipio")]
    public partial class Municipio
    {
        [Key]
        [Column("MunicipioID")]
        public int MunicipioId { get; set; }
        [Column("IBGE6")]
        public int Ibge6 { get; set; }
        [Column("IBGE7")]
        public int Ibge7 { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Column("MicroregiaoID")]
        public int MicroregiaoId { get; set; }
        [Column("UFID")]
        public int Ufid { get; set; }
        public int? Populacao { get; set; }
        [Column("CEP")]
        public int? Cep { get; set; }
        [Column("SiglaUF")]
        [StringLength(2)]
        public string SiglaUf { get; set; }

        [ForeignKey(nameof(MesoregiaoId))]
        [InverseProperty("Municipios")]
        public virtual Mesoregiao Mesoregiao { get; set; }
        [ForeignKey(nameof(MicroregiaoId))]
        [InverseProperty("Municipios")]
        public virtual Microregiao Microregiao { get; set; }
        [ForeignKey(nameof(Ufid))]
        [InverseProperty(nameof(UnidadesFederacao.Municipios))]
        public virtual UnidadesFederacao Uf { get; set; }
    }
}
