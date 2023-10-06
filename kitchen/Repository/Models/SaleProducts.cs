using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    [Table("Sale_products")]
    public partial class SaleProducts
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("product")]
        public int? Product { get; set; }
        [Column("count")]
        public int? Count { get; set; }
        [Column("price")]
        public double? Price { get; set; }
        [Column("sum")]
        public double? Sum { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("employee")]
        public int? Employee { get; set; }

        [ForeignKey(nameof(Employee))]
        [InverseProperty(nameof(Employees.SaleProducts))]
        public virtual Employees EmployeeNavigation { get; set; }
        [ForeignKey(nameof(Product))]
        [InverseProperty(nameof(Models.Products.SaleProducts))]
        public virtual Products ProductNavigation { get; set; }
    }
}
