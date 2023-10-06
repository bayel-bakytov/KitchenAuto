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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BudgetForm budget = new BudgetForm();
            budget.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmploeesForm emploees = new EmploeesForm();
            emploees.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProductsForm products = new ProductsForm();
            products.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MaterialsForm materials = new MaterialsForm();
            materials.Show();
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IngredientsAll ingredient = new IngredientsAll();
            ingredient.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Position position = new Position();
            position.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Measure measure = new Measure();
            measure.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            saleForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProductionForm productionForm = new ProductionForm();
            productionForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SalaryForm salaryForm = new SalaryForm();
            salaryForm.Show();
        }
    }
}
