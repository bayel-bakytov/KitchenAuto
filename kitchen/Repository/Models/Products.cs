using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Products
    {
        public Products()
        {
            Ingredients = new HashSet<Ingredients>();
            Production = new HashSet<Production>();
            SaleProducts = new HashSet<SaleProducts>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("unitOfmeasurement")]
        public int? UnitOfmeasurement { get; set; }
        [Column("count")]
        public int? Count { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("sum")]
        public double? Sum { get; set; }
        [Column("percents")]
        public double? Percents { get; set; }

        [ForeignKey(nameof(UnitOfmeasurement))]
        [InverseProperty(nameof(UnitsOfMeasurement.Products))]
        public virtual UnitsOfMeasurement UnitOfmeasurementNavigation { get; set; }
        [InverseProperty("ProductNavigation")]
        public virtual ICollection<Ingredients> Ingredients { get; set; }
        [InverseProperty("ProductNavigation")]
        public virtual ICollection<Production> Production { get; set; }
        [InverseProperty("ProductNavigation")]
        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
    }
}
