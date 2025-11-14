using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("ticketpedido")]
    public class TicketPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("nroped")]
        [Display(Name = "N° Pedido")]
        public int nroped { get; set; }

        [Required]
        [Column("fecped")]
        [Display(Name = "Fecha del Pedido")]
        [DataType(DataType.Date)]
        public DateTime fechaPedido { get; set; }

        // Clave foránea a Empleado
        [Required]
        [Column("codemp")]
        [Display(Name = "Empleado")]
        public int codemp { get; set; }

        [ForeignKey("codemp")]
        public virtual Empleado empleado { get; set; }

        // Clave foránea a Cliente
        [Required]
        [Column("codcli")]
        [Display(Name = "Cliente")]
        public int codcli { get; set; }

        [ForeignKey("codcli")]
        public virtual Cliente cliente { get; set; }

        [Required]
        [Column("estped")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}