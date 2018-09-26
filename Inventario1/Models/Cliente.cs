namespace Inventario1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int id_cliente { get; set; }

        [StringLength(100)]
        [Required]
        public string nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string apellido { get; set; }

        [StringLength(25)]
        [Required]
        public string telefono { get; set; }

        [StringLength(100)]
        [Required]
        public string direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
