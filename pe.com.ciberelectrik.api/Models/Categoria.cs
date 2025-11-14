using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codcat")]
        public int codigo { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Nombre")]
        [Column("nomcat")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Estado")]
        [Column("estcat")]
        public bool estado { get; set; }
    }
}