using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Production
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("product")]
        public int? Product { get; set; }
        [Column("count")]
        public int? Count { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [Column("employee")]
        public int? Employee { get; set; }

        [ForeignKey(nameof(Employee))]
        [InverseProperty(nameof(Employees.Production))]
        public virtual Employees EmployeeNavigation { get; set; }
        [ForeignKey(nameof(Product))]
        [InverseProperty(nameof(Models.Products.Production))]
        public virtual Products ProductNavigation { get; set; }
    }
}
