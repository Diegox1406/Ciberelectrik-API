using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.api.Models
{
    [Table("detalleticketpedido")]
    public class DetalleTicketPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("nrodet")]
        [Display(Name = "N° Detalle")]
        public int numeroDetalle { get; set; }

        [Required]
        [Column("canent")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required]
        [Column("preent")]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal precio { get; set; }

        // Clave foránea a TicketPedido
        [Required]
        [Column("nroped")]
        [Display(Name = "N° Pedido")]
        public int nroped { get; set; }

        [ForeignKey("nroped")]
        public virtual TicketPedido ticketPedido { get; set; }

        // Clave foránea a Producto
        [Required]
        [Column("codpro")]
        [Display(Name = "Producto")]
        public int codpro { get; set; }

        [ForeignKey("codpro")]
        public virtual Producto producto { get; set; }
    }
}