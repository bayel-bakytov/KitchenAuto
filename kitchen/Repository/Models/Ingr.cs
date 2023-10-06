using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Ingr
    {
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("count")]
        public double? Count { get; set; }
        [Column("unit")]
        [StringLength(20)]
        public string Unit { get; set; }
    }
}
