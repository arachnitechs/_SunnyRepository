//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDScan.Data.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class club
    {
        public club()
        {
            this.memberships = new HashSet<membership>();
        }
    
        public int clubid { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string stateprov { get; set; }
        public string zip { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    
        public virtual clubevent clubevent { get; set; }
        public virtual ICollection<membership> memberships { get; set; }
    }
}