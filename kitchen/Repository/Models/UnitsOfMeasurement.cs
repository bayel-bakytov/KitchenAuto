using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class UnitsOfMeasurement
    {
        public UnitsOfMeasurement()
        {
            Materials = new HashSet<Materials>();
            Products = new HashSet<Products>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(20)]
        public string Name { get; set; }

        [InverseProperty("UnitOfMeasurementNavigation")]
        public virtual ICollection<Materials> Materials { get; set; }
        [InverseProperty("UnitOfmeasurementNavigation")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
