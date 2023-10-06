using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Production = new HashSet<Production>();
            PurchaseMaterials = new HashSet<PurchaseMaterials>();
            SaleProducts = new HashSet<SaleProducts>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column("post")]
        public int? Post { get; set; }
        [Column("salary")]
        public int? Salary { get; set; }
        [Column("address")]
        [StringLength(40)]
        public string Address { get; set; }
        [Column("phone")]
        [StringLength(12)]
        public string Phone { get; set; }

        [ForeignKey(nameof(Post))]
        [InverseProperty(nameof(Positions.Employees))]
        public virtual Positions PostNavigation { get; set; }
        [InverseProperty("EmployeeNavigation")]
        public virtual ICollection<Production> Production { get; set; }
        [InverseProperty("EmployeeNavigation")]
        public virtual ICollection<PurchaseMaterials> PurchaseMaterials { get; set; }
        [InverseProperty("EmployeeNavigation")]
        public virtual ICollection<SaleProducts> SaleProducts { get; set; }
        //============================
         /*[InverseProperty("EmployeeNavigation")]
         public virtual ICollection<Salary> Salaries { get; set; }*/
    }
}
