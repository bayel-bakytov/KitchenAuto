using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Ingredients
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("product")]
        public int? Product { get; set; }
        [Column("material")]
        public int? Material { get; set; }
        [Column("count")]
        public double? Count { get; set; }

        [ForeignKey(nameof(Material))]
        [InverseProperty(nameof(Materials.Ingredients))]
        public virtual Materials MaterialNavigation { get; set; }
        [ForeignKey(nameof(Product))]
        [InverseProperty(nameof(Models.Products.Ingredients))]
        public virtual Products ProductNavigation { get; set; }
    }
}
