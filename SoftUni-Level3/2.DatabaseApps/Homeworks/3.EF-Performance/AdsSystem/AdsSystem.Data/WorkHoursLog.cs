//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdsSystem.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHoursLog
    {
        public int WorkHoursLogID { get; set; }
        public string LogCommand { get; set; }
        public Nullable<int> OldHours { get; set; }
        public Nullable<System.DateTime> OldDate { get; set; }
        public Nullable<int> OldEmployeeID { get; set; }
        public string OldTask { get; set; }
        public Nullable<double> OldWorkHours { get; set; }
        public string OldComment { get; set; }
        public Nullable<int> NewWorkHoursID { get; set; }
        public Nullable<System.DateTime> NewDate { get; set; }
        public Nullable<int> NewEmployeeID { get; set; }
        public string NewTask { get; set; }
        public Nullable<double> NewHours { get; set; }
        public string NewComment { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
    }
}
