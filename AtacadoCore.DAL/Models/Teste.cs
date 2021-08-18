using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtacadoCore.DAL.Models
{
    [Table("Teste")]
    public partial class Teste
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataInclusao { get; set; }
    }
}
