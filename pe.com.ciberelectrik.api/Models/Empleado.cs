using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codemp")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomemp")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apepemp")]
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apememp")]
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }

        [Required]
        [StringLength(20)]
        [Column("docemp")]
        [Display(Name = "Nro Documento")]
        public string documento { get; set; }

        [Required]
        [StringLength(100)]
        [Column("diremp")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [StringLength(7)]
        [Column("telemp")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [StringLength(9)]
        [Column("celemp")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required]
        [StringLength(60)]
        [Column("coremp")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [StringLength(20)]
        [Column("usuemp")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [StringLength(20)]
        [Column("claemp")]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Column("estemp")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Required]
        [Column("coddis")]
        [Display(Name = "Distrito")]
        public int coddis { get; set; }

        [ForeignKey("coddis")]
        public virtual Distrito distrito { get; set; }

        [Required]
        [Column("codrol")]
        [Display(Name = "Rol")]
        public int codrol { get; set; }

        [ForeignKey("codrol")]
        public virtual Rol rol { get; set; }

        [Required]
        [Column("codtipd")]
        [Display(Name = "Tipo de Documento")]
        public int codtipd { get; set; }

        [ForeignKey("codtipd")]
        public virtual TipoDocumento tipoDocumento { get; set; }
    }
}