//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolTrackerAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToolHistory
    {
        public int ToolHistoryId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime Borrowed { get; set; }
        public Nullable<System.DateTime> Returned { get; set; }
        public string AssetNum { get; set; }
    }
}
