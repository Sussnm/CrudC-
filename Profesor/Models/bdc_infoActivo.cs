namespace Profesor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bdc_infoActivo
    {
        public int ID { get; set; }

        public int? fk_centroCosto { get; set; }

        public int? fk_area { get; set; }

        public int? fk_cuenta_activo { get; set; }

        public int? fk_nom_cuenta_activo { get; set; }

        public int? fk_cuenta_pasivo { get; set; }

        public int? fk_nom_cuenta_pasivo { get; set; }

        public int? fk_clase { get; set; }

        public int? fk_subclase { get; set; }

        [StringLength(255)]
        public string denominacion { get; set; }

        [StringLength(255)]
        public string subdenominacion { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [StringLength(255)]
        public string marca { get; set; }

        [StringLength(255)]
        public string modelo { get; set; }

        [StringLength(255)]
        public string num_serie { get; set; }

        [StringLength(255)]
        public string ubicación { get; set; }

        [StringLength(255)]
        public string cod_barras { get; set; }

        [StringLength(255)]
        public string estado { get; set; }

        [StringLength(255)]
        public string fk_traspaso { get; set; }

        [StringLength(255)]
        public string fk_financiamiento { get; set; }

        [StringLength(50)]
        public string fech_compra { get; set; }

        public double? n_factura { get; set; }

        [StringLength(255)]
        public string obs_general { get; set; }

        public virtual bdc_area bdc_area { get; set; }

        public virtual bdc_centroCosto bdc_centroCosto { get; set; }

        public virtual bdc_clase bdc_clase { get; set; }

        public virtual bdc_cuenta_activo bdc_cuenta_activo { get; set; }

        public virtual bdc_cuenta_pasivo bdc_cuenta_pasivo { get; set; }

        public virtual bdc_nom_cuenta_activo bdc_nom_cuenta_activo { get; set; }

        public virtual bdc_nom_cuenta_pasivo bdc_nom_cuenta_pasivo { get; set; }

        public virtual bdc_subclase bdc_subclase { get; set; }
    }
}
