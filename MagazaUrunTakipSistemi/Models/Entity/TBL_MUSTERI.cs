//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazaUrunTakipSistemi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_MUSTERI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MUSTERI()
        {
            this.TBL_SATISLAR = new HashSet<TBL_SATISLAR>();
        }
    
        public int id { get; set; }

        [Required(ErrorMessage = "name field cannot be empty")]
        [StringLength(20, ErrorMessage = "name cannot be more than 30 char")]
        public string musteriadi { get; set; }

        [Required(ErrorMessage = "surname field cannot be empty")]
        [StringLength(30, ErrorMessage = "surname cannot be more than 30 char")]
        public string musterisoyadi { get; set; }
        public string musterisehir { get; set; }


        public Nullable<decimal> musteribakiye { get; set; }
        public Nullable<bool> status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SATISLAR> TBL_SATISLAR { get; set; }
    }
}
