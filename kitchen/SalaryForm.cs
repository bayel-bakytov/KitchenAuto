using kitchen.Repository;
using kitchen.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace kitchen
{
    public partial class SalaryForm : Form
    {
        
        public SalaryForm()
        {
            InitializeComponent();
        }

        private void SalaryForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.salare_view". При необходимости она может быть перемещена или удалена.
            this.salare_viewTableAdapter.Fill(this.finishKitchenDataSet.salare_view);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM/yyyy";
            this.textBox3.Text = "2023";
            this.comboBox1.SelectedItem = "Май";
            //dateTimePicker1.ShowUpDown = true;
            update();
           
        }

        public void updateSalary() {
            this.salare_viewTableAdapter.Fill(this.finishKitchenDataSet.salare_view);
            update();
        }
        public void bezdelniki() 
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                List<int> employeesSalary = new List<int>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Employees em = context.Employees.FirstOrDefault(x => x.Name == Convert.ToString(row.Cells[0].Value));
                    employeesSalary.Add(Convert.ToInt32(em.Id));

                }
                List<Employees> newemployees = context.Employees.Where(p => !employeesSalary.Contains(p.Id)).ToList();
                foreach (Employees employees in newemployees) 
                {
                    Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                    Salary salary1 = new Salary();
                    salary1.employee_Id = employees.Id;
                    salary1.month = comboBox1.SelectedIndex+1;
                    salary1.year = Convert.ToInt32(this.textBox3.Text);
                    salary1.purchase_Count = 0;
                    salary1.production_Count = 0;
                    salary1.sale_Count = 0;
                    salary1.sum_Count = 0;
                    salary1.salary1 = (salary1.sum_Count * budget.Bonus * 0.01 + 1) * employees.Salary;
                    salary1.pay = false;
                    context.Add(salary1);
                }
                context.SaveChanges();
                update();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (budg < total)
            {
                MessageBox.Show(
                          "Недостаточно денег в бюджете!",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );
            }
            else {
                using (KitchenDbContext context = new KitchenDbContext())
                {
                    Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                    budget.Budget1 -= total;
                    List<Salary> salaries = new List<Salary>();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        salaries.Add(context.Salary
                     .Include(x => x.Empl).FirstOrDefault(x => x.Id == Convert.ToInt32(row.Cells[9].Value)));
                    }
                    foreach (Salary s in salaries) 
                    {
                        s.pay = true;                   
                    }
                    context.SaveChanges();
                    update();

                }
            }
            
        }

        double total=0;
        public void allSalary() 
        {
            total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[8].Value) == false) {
                    total += Convert.ToDouble(row.Cells[7].Value);
                }
            }
            textBox1.Text = total.ToString();
        }
        double budg;
        public void initialBudget() 
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                Budget budget= context.Budget.FirstOrDefault(x=>x.Id==1);
                budg = Convert.ToDouble(budget.Budget1);
                textBox2.Text = budg.ToString();    
            }
        }
        public void update()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                var month = comboBox1.SelectedIndex+1;
                var year = Convert.ToInt32(this.textBox3.Text.ToString());
                List<Salary> salaries= context.Salary
                    .Include(x => x.Empl).Where(x => x.month == month && x.year == year).ToList();

                dataGridView1.DataSource = salaries.Select(
                    x => new
                    {
                        employee = x.Empl.Name,
                        Purchase = x.purchase_Count,
                        Production = x.production_Count,
                        Sale = x.sale_Count,
                        Sum = x.sum_Count,
                        salary = x.Empl.Salary,
                        bonus = x.salary1 - x.Empl.Salary,
                        TotalSalary = x.salary1,
                        pay = x.pay,
                        id = x.Id
                    }).ToList();
                dataGridView1.Columns["id"].Visible = false;
                allSalary();
                initialBudget();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            update();
            //bezdelniki();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bezdelniki();
        }
        
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string name="";
            double sum=0;
            bool pay=false;
            bool isNull = false;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                isNull=true;
                name = Convert.ToString(row.Cells[0].Value);
                sum = Convert.ToDouble(row.Cells[7].Value);
                pay = Convert.ToBoolean(row.Cells[8].Value);
            }
            if (pay)
            {
                MessageBox.Show(
                          "Зарплата уже выдана!",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );
            }
            else if(isNull) {
                  
                SalaryByIdForm salaryByIdForm = new SalaryByIdForm();
                //salaryByIdForm.Owner = this;
                salaryByIdForm.Show();
                var month = comboBox1.SelectedIndex +1;
                var year = Convert.ToInt32(textBox3.Text.ToString());
                salaryByIdForm.textBox1FIO.Text = name;
                salaryByIdForm.str = comboBox1.SelectedItem.ToString();
                salaryByIdForm.textBox2.Text = sum.ToString();
                salaryByIdForm.Month = comboBox1.SelectedIndex;
                salaryByIdForm.textBox3.Text = year.ToString();
                salaryByIdForm.textBox1.Text = month.ToString();
                Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void salare_viewBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
