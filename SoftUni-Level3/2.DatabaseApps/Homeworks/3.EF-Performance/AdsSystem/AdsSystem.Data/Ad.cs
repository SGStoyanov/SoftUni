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
    
    public partial class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageDataURL { get; set; }
        public string OwnerId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> TownId { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
    
        public virtual AdStatus AdStatus { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Category Category { get; set; }
        public virtual Town Town { get; set; }
    }
}
