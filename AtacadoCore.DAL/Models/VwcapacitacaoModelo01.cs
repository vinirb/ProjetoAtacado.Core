using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Keyless]
    public partial class VwcapacitacaoModelo01
    {
        [Column("CEP")]
        public int Cep { get; set; }
        [Column("IBGE6")]
        public int Ibge6 { get; set; }
        [Column("IBGE7")]
        public int Ibge7 { get; set; }
        [Required]
        [Column("UF")]
        public string Uf { get; set; }
        [Required]
        [Column("NOME_MUNICIPIO")]
        public string NomeMunicipio { get; set; }
        [Column("POPULACAO")]
        public int? Populacao { get; set; }
        [Column("MunicipioID")]
        public int MunicipioId { get; set; }
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Column("MicroregiaoID")]
        public int MicroregiaoId { get; set; }
        [Column("UFID")]
        public int Ufid { get; set; }
    }
}
