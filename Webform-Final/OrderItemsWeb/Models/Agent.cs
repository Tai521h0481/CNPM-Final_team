//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderItemsWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agent()
        {
            this.OrderReceipts = new HashSet<OrderReceipt>();
        }
        
        public string AgentID { get; set; }
        public string AgentName { get; set; }
        public string AgentAccount { get; set; }
        public string AgentPassword { get; set; }
        public string AgentAddress { get; set; }
        public string AgentPhoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderReceipt> OrderReceipts { get; set; }
    }
}
