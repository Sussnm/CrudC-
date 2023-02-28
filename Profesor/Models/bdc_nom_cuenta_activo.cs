namespace Profesor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bdc_nom_cuenta_activo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bdc_nom_cuenta_activo()
        {
            bdc_infoActivo = new HashSet<bdc_infoActivo>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string nom_cuenta_activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bdc_infoActivo> bdc_infoActivo { get; set; }
    }
}
