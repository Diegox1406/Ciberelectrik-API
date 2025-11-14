using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codrol")]
        public int codigo { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre del Rol")]
        [Column("nomrol")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estrol")]
        public bool estado { get; set; }
    }
}