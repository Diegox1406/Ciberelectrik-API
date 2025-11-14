using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codcli")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomcli")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apepcli")]
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apemcli")]
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }

        [Required]
        [StringLength(20)]
        [Column("doccli")]
        [Display(Name = "Nro Documento")]
        public string documento { get; set; }

        [Required]
        [StringLength(100)]
        [Column("dircli")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [StringLength(7)]
        [Column("telcli")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [StringLength(9)]
        [Column("celcli")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required]
        [StringLength(60)]
        [Column("corcli")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [Column("estcli")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        // Clave foránea a Distrito
        [Required]
        [Column("coddis")]
        [Display(Name = "Distrito")]
        public int coddis { get; set; }

        [ForeignKey("coddis")]
        public virtual Distrito distrito { get; set; }

        // Clave foránea a TipoDocumento
        [Required]
        [Column("codtipd")]
        [Display(Name = "Tipo de Documento")]
        public int codtipd { get; set; }

        [ForeignKey("codtipd")]
        public virtual TipoDocumento tipoDocumento { get; set; }
    }
}