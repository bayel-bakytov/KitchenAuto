using kitchen.Repository.Models;
using kitchen.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.Entity;





using Microsoft.EntityFrameworkCore;

//using System.Data.Entity;

using System.Net.NetworkInformation;
using kitchen.FinishKitchenDataSetTableAdapters;

namespace kitchen
{
    public partial class ProductionForm : Form
    {
        public ProductionForm()
        {
            InitializeComponent();
        }

        private void ProductionForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.productionView1". При необходимости она может быть перемещена или удалена.
            this.productionView1TableAdapter.Fill(this.finishKitchenDataSet.productionView1);
            initListBoxFinishProduct();
            initListBoxEmploees();
        }
        public void initListBoxFinishProduct()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<Repository.Models.Products> fiP = context.Products.ToList();

                foreach (Repository.Models.Products pi in fiP)
                {
                    listBox1.Items.Add(new ListIstem
                    {
                        Name = pi.Name,
                        Value = pi.Id
                    }
                    );

                }
            }
        }
        public void initListBoxEmploees()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<Repository.Models.Employees> emp = context.Employees.ToList();

                foreach (Repository.Models.Employees e in emp)
                {
                    listBox2.Items.Add(new ListIstem
                    {
                        Name = e.Name,
                        Value = e.Id
                    }
                    );

                }
            }
        }
        public void update() 
        {
            this.productionView1TableAdapter.Fill(this.finishKitchenDataSet.productionView1);
            clear();
        }
        public void clear() 
        {
            textBox1.Clear();
            listBox1.ClearSelected();
            listBox2.ClearSelected();
        }
        string product;
        double countmat, difference;
        bool flag=true;
        DateTime date;
        //произвести
        private void button1_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                product = listBox1.GetItemText(listBox1.SelectedItem);
                Products products = new Products();
                products = context.Products.FirstOrDefault(x => x.Name == product);
                
                List<Ingredients> Ingredients = context.Ingredients.Include(x => x.MaterialNavigation).Where(y => y.Product == products.Id).ToList();
                foreach (Ingredients Ing in Ingredients) 
                {
                    countmat = Convert.ToDouble(Ing.Count) * Convert.ToInt32(textBox1.Text);
                    if (Ing.MaterialNavigation.Count < countmat) 
                    {
                        difference = countmat - Convert.ToDouble(Ing.MaterialNavigation.Count) ;
                        flag = false;
                        MessageBox.Show(
                         "Недостаточно материала: " + Ing.MaterialNavigation.Name.ToString() 
                         + " в кол-ве: " + difference.ToString(),
                       "Сообщение",
                       MessageBoxButtons.OK
                        );
                    }
                }
                if (flag) 
                {
                    Employees employees = context.Employees.FirstOrDefault(x => x.Name == listBox2.GetItemText(listBox2.SelectedItem));
                    Production production = new Production();
                    production.ProductNavigation = products;
                    production.Count= Convert.ToInt32(textBox1.Text);
                    production.Date = dateTimePicker1.Value.Date;
                    production.EmployeeNavigation = employees;
                    context.Add(production);
                    products.Count += Convert.ToInt32(textBox1.Text);
                    products.Sum = products.Count * products.Price;
                    foreach (Ingredients Ing in Ingredients)
                    {
                        countmat = Convert.ToDouble(Ing.Count) * Convert.ToInt32(textBox1.Text);
                        Ing.MaterialNavigation.Count -= countmat;
                        Ing.MaterialNavigation.Price -= countmat * Ing.MaterialNavigation.Cost;
                    }

                    //salary
                    Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                    date = dateTimePicker1.Value.Date;
                    Salary salary = context.Salary.FirstOrDefault(x => x.employee_Id == employees.Id && x.month == date.Month && x.year == date.Year);
                    if (salary != null)
                    {
                        salary.sale_Count++;
                        salary.sum_Count++;
                        salary.salary1 = (salary.sum_Count * budget.Bonus * 0.01 + 1) * employees.Salary;
                    }
                    else
                    {
                        Salary salary1 = new Salary();
                        salary1.employee_Id = employees.Id;
                        salary1.month = date.Month;
                        salary1.year = date.Year;
                        salary1.purchase_Count = 0;
                        salary1.production_Count = 0;
                        salary1.sale_Count = 1;
                        salary1.sum_Count = 1;
                        salary1.salary1 = (salary1.sum_Count * budget.Bonus * 0.01 + 1) * employees.Salary;
                        salary1.pay = false;
                        context.Add(salary1);
                    }

                    context.SaveChanges();
                    update();
                }
            }
        }
    }
}
