using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kitchen.Repository.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("post")]
        [StringLength(30)]
        public string Post { get; set; }

        [InverseProperty("PostNavigation")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
