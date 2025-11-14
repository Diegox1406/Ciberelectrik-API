using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("tipodocumento")]
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        [Column("codtipd")]
        public int codigo { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre del Documento")]
        [Column("nomtipd")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Column("esttipd")]
        public bool estado { get; set; }
    }
}