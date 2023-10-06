using kitchen.Repository;
using kitchen.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitchen
{
    public partial class BudgetForm : Form
    {
        public BudgetForm()
        {
            InitializeComponent();
        }

        private void budgetBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.budgetBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);

        }

        private void Budget_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Budget". При необходимости она может быть перемещена или удалена.
            this.budgetTableAdapter.Fill(this.finishKitchenDataSet.Budget);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.budgetBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                double bonus =Convert.ToDouble(bonusTextBox.Text) ;
                List<Salary> salaries = context.Salary.Where(x => x.pay == false).ToList();
                foreach (Salary salary in salaries) 
                {
                    Employees employees = context.Employees.FirstOrDefault(x => x.Id == salary.employee_Id);
                    salary.salary1 = employees.Salary * (1 + salary.sum_Count * bonus/100);
                }
                context.SaveChanges();
            }
        }
    }
}
