using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Budget
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("budget")]
        public double? Budget1 { get; set; }
        [Column("bonus")]
        public int? Bonus { get; set; }
    }
}
