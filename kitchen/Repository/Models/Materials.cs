using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Materials
    {
        public Materials()
        {
            Ingredients = new HashSet<Ingredients>();
            PurchaseMaterials = new HashSet<PurchaseMaterials>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("unitOfMeasurement")]
        public int? UnitOfMeasurement { get; set; }
        [Column("count")]
        public double? Count { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("cost")]
        public double? Cost { get; set; }

        [ForeignKey(nameof(UnitOfMeasurement))]
        [InverseProperty(nameof(UnitsOfMeasurement.Materials))]
        public virtual UnitsOfMeasurement UnitOfMeasurementNavigation { get; set; }
        [InverseProperty("MaterialNavigation")]
        public virtual ICollection<Ingredients> Ingredients { get; set; }
        [InverseProperty("MaterialNavigation")]
        public virtual ICollection<PurchaseMaterials> PurchaseMaterials { get; set; }
    }
}
