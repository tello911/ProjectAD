//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Detail()
        {
            this.Orders = new HashSet<Order>();
            this.Payments = new HashSet<Payment>();
        }
    
        public int detailorderid { get; set; }
        public double detailtotalprice { get; set; }
        public string detailshipname { get; set; }
        public string detailshipaddress { get; set; }
        public string detailcontact { get; set; }
        public System.DateTime detailorderdate { get; set; }
        public int detailcourierid { get; set; }
        public int detailuserid { get; set; }
    
        public virtual Shipping Shipping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
