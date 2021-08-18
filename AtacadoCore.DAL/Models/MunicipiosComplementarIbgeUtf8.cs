using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Municipios_ComplementarIBGE_UTF8")]
    public partial class MunicipiosComplementarIbgeUtf8
    {
        [Key]
        [Column("MunicipioID")]
        public int MunicipioId { get; set; }
        [Column("CodigoIBGE")]
        public int CodigoIbge { get; set; }
        [Required]
        public string Nome { get; set; }
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Column("MicroregiaoID")]
        public int MicroregiaoId { get; set; }
        [Column("UFID")]
        public int Ufid { get; set; }
        public DateTime DataInsert { get; set; }
    }
}
