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

namespace kitchen.Repository
{
    public partial class SalaryByIdForm : Form
    {
         public int Month = 0; 
         public string str = ""; 


        public SalaryByIdForm()
        {
            InitializeComponent();
        }

        private void textBox1FIO_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (KitchenDbContext context = new KitchenDbContext())            
            {
                Employees employees = context.Employees.FirstOrDefault(x => x.Name == Convert.ToString(textBox1FIO.Text));
                Salary salary = context.Salary.FirstOrDefault(x => x.employee_Id == employees.Id
                && x.month == Convert.ToInt32(textBox1.Text)
                && x.year == Convert.ToInt32(textBox3.Text.ToString()));
                salary.salary1 = Convert.ToDouble(textBox2.Text);
                context.SaveChanges();
                SalaryForm salaryForm = new SalaryForm();
                //salaryForm.comboBox1.SelectedItem = str;
                //salaryForm.textBox3.Text = "2023";
                salaryForm.Show();
                this.Hide();
                
                //form.updateSalary();

            }
            MessageBox.Show("Успешное изменение");
        }

        private void SalaryByIdForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            SalaryForm salaryForm = new SalaryForm();
            salaryForm.Show();
        }
    }
}
