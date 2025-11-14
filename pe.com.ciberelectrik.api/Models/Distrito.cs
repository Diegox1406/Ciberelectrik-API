using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("distrito")]
    public class Distrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("coddis")]
        public int codigo { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre del Distrito")]
        [Column("nomdis")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("estdis")]
        public bool estado { get; set; }
    }
}