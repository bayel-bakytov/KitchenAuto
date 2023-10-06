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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace kitchen
{
    public partial class SaleForm : Form
    {
        public SaleForm()
        {
            InitializeComponent();
        }
        int count;
        double selPrice, Total;
        private void SaleForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Sale_productsView". При необходимости она может быть перемещена или удалена.
            this.sale_productsViewTableAdapter.Fill(this.finishKitchenDataSet.Sale_productsView);
            initListBoxFinishProduct();
            initListBoxEmploees();
            initBudegt();
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
        public void clear() 
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            listBox1.ClearSelected();
            listBox2.ClearSelected();
        
        }
        public void update() 
        {
            this.sale_productsViewTableAdapter.Fill(this.finishKitchenDataSet.Sale_productsView);
            clear();
            initBudegt();
        }
        public void initBudegt()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                Repository.Models.Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                textBox4.Text = budget.Budget1.ToString();
            }
        }
        private void sale_productsViewDataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }
        //добавление
        private void button1_Click(object sender, EventArgs e)
        {
            
            using (KitchenDbContext context = new KitchenDbContext()) 
            {

                Products products = context.Products.FirstOrDefault(x => x.Name == listBox1.GetItemText(listBox1.SelectedItem));
                if (products.Count < count)
                {
                    MessageBox.Show(
                          "Недостаточно готовой продукции! Готово всего лишь " + products.Count,
                        "Сообщение",
                        MessageBoxButtons.OK);
                }
                else 
                {
                    Employees employees = context.Employees.FirstOrDefault(x => x.Name == listBox2.GetItemText(listBox2.SelectedItem));
                    DateTime date = dateTimePicker1.Value.Date;
                    SaleProducts saleProducts = new SaleProducts();
                    saleProducts.ProductNavigation = products;
                    saleProducts.EmployeeNavigation = employees;
                    saleProducts.Price = Convert.ToDouble(selPrice) ;
                    saleProducts.Count = count;
                    saleProducts.Date = date;
                    saleProducts.Sum = Convert.ToDouble(Total);
                    context.SaleProducts.Add(saleProducts);
                    Repository.Models.Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                    budget.Budget1 += Total;
                    products.Count -= count;
                    products.Sum = products.Count * products.Price;

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
                        salary1.month= date.Month;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) 
            {
                using (KitchenDbContext context = new KitchenDbContext())
                {
                    Products products = context.Products.FirstOrDefault(x => x.Name == listBox1.GetItemText(listBox1.SelectedItem));
                    selPrice = Convert.ToDouble(products.Price) * (1 + Convert.ToDouble(products.Percents) / 100);
                    textBox2.Text = Convert.ToDouble(selPrice).ToString();
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void sale_productsViewDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && listBox1.SelectedItem!=null)
            {
                count = Convert.ToInt32(textBox1.Text);
                selPrice = Convert.ToDouble(textBox2.Text);
                Total = count * selPrice;
                textBox3.Text = Total.ToString();
            }
            else 
            {
                textBox3.Text = "";
            }
            
        }
    }
}
