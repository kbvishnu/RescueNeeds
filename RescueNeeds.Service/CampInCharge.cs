//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RescueNeeds.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class CampInCharge
    {
        public int CampInChargeID { get; set; }
        public Nullable<int> CampsID { get; set; }
        public Nullable<int> PersonID { get; set; }
    
        public virtual Camp Camp { get; set; }
        public virtual Person Person { get; set; }
    }
}
