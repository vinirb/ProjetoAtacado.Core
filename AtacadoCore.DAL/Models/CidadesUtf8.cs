using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Cidades_UTF8")]
    public partial class CidadesUtf8
    {
        [Required]
        [Column("CIDADE")]
        public string Cidade { get; set; }
        [Required]
        [Column("UF")]
        public string Uf { get; set; }
        [Column("CEP")]
        public int Cep { get; set; }
        [Key]
        [Column("IBGE")]
        public int Ibge { get; set; }
    }
}
