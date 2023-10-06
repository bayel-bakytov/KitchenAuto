using kitchen.Repository;
using kitchen.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitchen
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
            InitMeasure();

        }

        private void productsUnitBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
        }



        public void InitMeasure()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<UnitsOfMeasurement> unitsOfMeasurements = context.UnitsOfMeasurement.ToList();
                foreach (UnitsOfMeasurement m in unitsOfMeasurements)
                {
                    listBox1.Items.Add(new ListIstem
                    {
                        Name = m.Name,
                        Value = m.Id
                    }
                    );
                }
            }
        }
        int prodId;
        string prodName, measure;
        double price, sum, count, percents;
        //Добавление
        private void button2_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                try 
                {
                    Products products = new Products();
                    products.Name = Convert.ToString(textBox1.Text);
                    products.Count = Convert.ToInt32(textBox2.Text);
                    string meas = listBox1.SelectedItem.ToString();
                    UnitsOfMeasurement unitsOfMeasurement = context.UnitsOfMeasurement.FirstOrDefault(x => x.Name == meas);
                    products.UnitOfmeasurementNavigation = unitsOfMeasurement;
                    products.Price = 0;
                    products.Percents = Convert.ToDouble(textBox5.Text);
                    products.Sum = 0;
                    context.Add(products);
                    context.SaveChanges();
                    update();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                          "Ошибка",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );
                }
            }
        }
        //очистка

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        //удаление
        private void button4_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                try 
                {
                    Products products = context.Products.FirstOrDefault(x => x.Id == prodId);
                    context.Products.Remove(products);
                    context.SaveChanges();
                    update();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                          "Ошибка",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );
                }

            }
        }

        //выбор
        private void productsUnitDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                foreach (DataGridViewRow row in productsUnitDataGridView.SelectedRows)
                {
                    prodId = Convert.ToInt32(row.Cells[0].Value);
                    prodName = Convert.ToString(row.Cells[1].Value);
                    measure = Convert.ToString(row.Cells[2].Value);
                    count = Convert.ToDouble(row.Cells[3].Value);
                    price = Convert.ToDouble(row.Cells[4].Value);
                    sum = Convert.ToDouble(row.Cells[5].Value);
                    percents = Convert.ToDouble(row.Cells[6].Value);
                    textBox1.Text = prodName;
                    listBox1.SelectedIndex = listBox1.FindString(measure);
                    textBox2.Text = count.ToString();
                    textBox3.Text = price.ToString();
                    textBox4.Text = sum.ToString();
                    textBox5.Text = percents.ToString();
                }
            }
        }
        public void update() 
        {
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.ProductsUnit". При необходимости она может быть перемещена или удалена.
            this.productsUnitTableAdapter.Fill(this.finishKitchenDataSet.ProductsUnit);
            InitMeasure();
        }
        
        public void clear() 
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            listBox1.SelectedItem= null;
        }
       //сохраниние
        private void button1_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try 
                {
                    Products products = context.Products.Include(x => x.UnitOfmeasurementNavigation).FirstOrDefault(x => x.Id == prodId);
                    string meas = listBox1.SelectedItem.ToString();
                    UnitsOfMeasurement unitsOfMeasurement = context.UnitsOfMeasurement.FirstOrDefault(x => x.Name == meas);
                    products.UnitOfmeasurementNavigation = unitsOfMeasurement;
                    products.Name = Convert.ToString(textBox1.Text);
                    products.Count = Convert.ToInt32(textBox2.Text);
                    products.Percents = Convert.ToDouble(textBox5.Text);
                    products.Sum = products.Count * products.Price;
                    context.SaveChanges();
                    update();
                    clear();
                }
                catch(Exception ex)
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
