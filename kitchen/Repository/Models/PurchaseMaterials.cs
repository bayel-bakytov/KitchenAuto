using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    [Table("Purchase_materials")]
    public partial class PurchaseMaterials
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("material")]
        public int? Material { get; set; }
        [Column("count")]
        public double? Count { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("employee")]
        public int? Employee { get; set; }

        [ForeignKey(nameof(Employee))]
        [InverseProperty(nameof(Employees.PurchaseMaterials))]
        public virtual Employees EmployeeNavigation { get; set; }
        [ForeignKey(nameof(Material))]
        [InverseProperty(nameof(Materials.PurchaseMaterials))]
        public virtual Materials MaterialNavigation { get; set; }
    }
}
