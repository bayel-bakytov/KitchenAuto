﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class ProductionView
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("product")]
        [StringLength(30)]
        public string Product { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("count")]
        public int? Count { get; set; }
        public double? Total { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("employee")]
        [StringLength(30)]
        public string Employee { get; set; }
    }
}
