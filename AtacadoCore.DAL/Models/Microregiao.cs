using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Microregiao")]
    public partial class Microregiao
    {
        public Microregiao()
        {
            Municipios = new HashSet<Municipio>();
        }

        [Key]
        [Column("MicroregiaoID")]
        public int MicroregiaoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column("MesoregiaoID")]
        public int MesoregiaoId { get; set; }
        [Column("datainsert", TypeName = "datetime")]
        public DateTime? Datainsert { get; set; }

        [ForeignKey(nameof(MesoregiaoId))]
        [InverseProperty("Microregiaos")]
        public virtual Mesoregiao Mesoregiao { get; set; }
        [InverseProperty(nameof(Municipio.Microregiao))]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
