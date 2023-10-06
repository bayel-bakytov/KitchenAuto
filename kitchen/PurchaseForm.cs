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

namespace kitchen
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Purchase_materials". При необходимости она может быть перемещена или удалена.
            this.purchase_materialsTableAdapter.Fill(this.finishKitchenDataSet.Purchase_materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.purchase". При необходимости она может быть перемещена или удалена.
            this.purchaseTableAdapter.Fill(this.finishKitchenDataSet.purchase);
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            initBudegt();
        }
        public void update() 
        {
            this.purchase_materialsTableAdapter.Fill(this.finishKitchenDataSet.Purchase_materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.purchase". При необходимости она может быть перемещена или удалена.
            this.purchaseTableAdapter.Fill(this.finishKitchenDataSet.purchase);
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            initBudegt();
        }
        public void initBudegt() 
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                Repository.Models.Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                textBox1.Text = budget.Budget1.ToString();
            }
        }
        double budget, count, price;
        DateTime date;
        //добавление
        private void button1_Click(object sender, EventArgs e)
        {

            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    budget = Convert.ToDouble(textBox1.Text);
                    count = Convert.ToDouble(textBox2.Text);
                    price = Convert.ToDouble(textBox3.Text);
                    if (budget < count * price)
                    {
                        MessageBox.Show(
                          "Недостаточно бюджета",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );
                    }
                    else
                    {
                        PurchaseMaterials purchaseMaterials = new PurchaseMaterials();
                        int idMat = Convert.ToInt32(listBox1.GetItemText(listBox1.SelectedValue)) ;
                        Repository.Models.Materials Mat = context.Materials.FirstOrDefault(x => x.Id == idMat);
                        Mat.Price += price*count;
                        Mat.Count += count;
                        Mat.Cost = Mat.Price / Mat.Count;
                        purchaseMaterials.Price = price;
                        purchaseMaterials.Count = count;
                        purchaseMaterials.MaterialNavigation = Mat;
                        int idEmpl = Convert.ToInt32(listBox2.GetItemText(listBox2.SelectedValue));
                        Repository.Models.Employees emp = context.Employees.FirstOrDefault(x => x.Id == idEmpl);
                        purchaseMaterials.EmployeeNavigation= emp;
                        purchaseMaterials.Date = dateTimePicker1.Value.Date;
                        context.Add(purchaseMaterials);
                        //Materials materials = context.Materials.FirstOrDefault(x => x.Name == empId);
                        Repository.Models.Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                        budget.Budget1 -= price * count;

                        //salary
                        //Budget budget = context.Budget.FirstOrDefault(x => x.Id == 1);
                        date = dateTimePicker1.Value.Date;
                        Salary salary = context.Salary.FirstOrDefault(x => x.employee_Id == emp.Id && x.month == date.Month && x.year == date.Year);
                        if (salary != null)
                        {
                            salary.sale_Count++;
                            salary.sum_Count++;
                            salary.salary1 = (salary.sum_Count * budget.Bonus * 0.01 + 1) * emp.Salary;
                        }
                        else
                        {
                            Salary salary1 = new Salary();
                            salary1.employee_Id = emp.Id;
                            salary1.month = date.Month;
                            salary1.year = date.Year;
                            salary1.purchase_Count = 0;
                            salary1.production_Count = 0;
                            salary1.sale_Count = 1;
                            salary1.sum_Count = 1;
                            salary1.salary1 = (salary1.sum_Count * budget.Bonus * 0.01 + 1) * emp.Salary;
                            salary1.pay = false;
                            context.Add(salary1);
                        }



                        context.SaveChanges();
                        update();
                    }
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(
                         "Ошибка",
                       "Сообщение",
                       MessageBoxButtons.OK
                   );
                }

            }
        }
    }  
}
