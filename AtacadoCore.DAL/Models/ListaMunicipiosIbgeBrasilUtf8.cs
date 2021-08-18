using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Lista_Municipios_IBGE_Brasil_UTF8")]
    public partial class ListaMunicipiosIbgeBrasilUtf8
    {
        [Required]
        [Column("ConcatUF_Mun")]
        public string ConcatUfMun { get; set; }
        [Column("IBGE")]
        public int Ibge { get; set; }
        [Key]
        [Column("IBGE7")]
        public int Ibge7 { get; set; }
        [Required]
        [Column("UF")]
        public string Uf { get; set; }
        [Required]
        public string Município { get; set; }
        [Required]
        public string Região { get; set; }
        [Column("População_2010")]
        public int? População2010 { get; set; }
        [Required]
        public string Porte { get; set; }
        public string Capital { get; set; }
    }
}
