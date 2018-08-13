//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collection.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Invoice
    {
        public int InvoiceId { get; set; }

        [Required]
        [Display(Name = "Invoice NO")]
        public int InvoiceNo { get; set; }

        [Required]
        [Display(Name = "Issue Date")]
       
        public System.DateTime IssueDate { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Collection Date")]
        public System.DateTime CollectDate { get; set; }

        [Required]
        [Display(Name = " Actual Collection Date")]
        public System.DateTime ActCollectDate { get; set; }

        [Display(Name = "Suspended")]
        public Nullable<bool> Suspended { get; set; }

        [Display(Name = "Collected")]
        public Nullable<bool> Collected { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public Nullable<int> Cus_id { get; set; }
    
        public virtual Comment Comment { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
