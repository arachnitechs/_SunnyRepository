//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDScan.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class @event
    {
        public int eventid { get; set; }
        public int clubid { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public Nullable<double> fee { get; set; }
        public string memo { get; set; }
    
        public virtual club club { get; set; }
    }
}