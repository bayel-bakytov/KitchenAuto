using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitchen.Repository.Models
{
    [Table("Salary")]
    public class Salary
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("employee_Id")]
        public int? employee_Id { get; set; }
        [Column("year")]
        public int? year { get; set; }
        [Column("month")]
        public int? month { get; set; }
        /*[Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }*/
        [Column("purchase_Count")]
        public int? purchase_Count { get; set; }
        [Column("production_Count")]
        public int? production_Count { get; set; }
        [Column("sale_Count")]
        public int? sale_Count { get; set; }
        [Column("sum_Count")]
        public int? sum_Count { get; set; }
        [Column("salary")]
        public double? salary1 { get; set; }
        [Column("pay")]
        public bool? pay { get; set; }

        //==========
        [ForeignKey(nameof(employee_Id))]
        public virtual Employees Empl { get; set; }
        /*[ForeignKey(nameof(employee_Id))]
        [InverseProperty(nameof(Employees.Salaries))]
        public virtual Employees EmployeeNavigation { get; set; }*/

        /*[ForeignKey(nameof(employee_Id))]
        [InverseProperty(nameof(Employees.Salary))]
        public virtual Employees EmployeeNavigation { get; set; }*/


        /*[ForeignKey(nameof(Material))]
        [InverseProperty(nameof(Materials.PurchaseMaterials))]
        public virtual Materials MaterialNavigation { get; set; }*/
    }
}
