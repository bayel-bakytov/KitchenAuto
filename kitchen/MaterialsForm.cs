using kitchen.Repository;
using kitchen.Repository.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class MaterialsForm : Form
    {
        public MaterialsForm()
        {
            InitializeComponent();
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.MaterialOfUnit". При необходимости она может быть перемещена или удалена.
            this.materialOfUnitTableAdapter.Fill(this.finishKitchenDataSet.MaterialOfUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
            initListBoxUnit();

        }
        public void update()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.MaterialOfUnit". При необходимости она может быть перемещена или удалена.
            this.materialOfUnitTableAdapter.Fill(this.finishKitchenDataSet.MaterialOfUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
        }
        private void materialsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void materialsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {


        }

        private void materialsBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.materialsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.MaterialOfUnit". При необходимости она может быть перемещена или удалена.
            this.materialOfUnitTableAdapter.Fill(this.finishKitchenDataSet.MaterialOfUnit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
        }
        public void initListBoxUnit()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<Repository.Models.UnitsOfMeasurement> unitsList = context.UnitsOfMeasurement.ToList();

                foreach (Repository.Models.UnitsOfMeasurement u in unitsList)
                {
                    listBox1.Items.Add(new ListIstem
                    {
                        Name = u.Name,
                        Value = u.Id
                    }
                    );

                }
            }
        }
        public void clear()
        {
            textBox1.Clear();
            listBox1.SelectedItem = null;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        int matId;
        string matName, unit;
        double count, price, cost;
        //добавление
        private void button3_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    var value = ((ListIstem)listBox1.SelectedItem).Value;
                    var un = context.UnitsOfMeasurement.FirstOrDefault(x => x.Id == value);
                    Materials mat = new Materials();
                    string text = listBox1.GetItemText(listBox1.SelectedItem);
                    UnitsOfMeasurement unitsOfMeasurement = context.UnitsOfMeasurement.FirstOrDefault(x => x.Name == text);
                    mat.UnitOfMeasurementNavigation = unitsOfMeasurement;
                    mat.Name = textBox1.Text;
                    mat.Count = Convert.ToDouble(textBox2.Text);
                    mat.Price = Convert.ToDouble(textBox3.Text);
                    mat.Cost = Convert.ToDouble(textBox3.Text) / Convert.ToDouble(textBox2.Text);
                    context.Add(mat);
                    context.SaveChanges();
                    update();
                    clear();

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
        //удаление
        private void button2_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    /*DialogResult result = MessageBox.Show(
                    "Удалить запись?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                    if (result == DialogResult.Yes) 
                    {
                    }
                     */

                    var mat = context.Materials.FirstOrDefault(x => x.Id == matId);
                    context.Remove(mat);
                    context.SaveChanges();
                    update();
                    clear();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double count = Convert.ToDouble(textBox2.Text);     
        }

        //очистка
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        //сохранение
        private void button1_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    Materials mat = context.Materials.Include(x => x.UnitOfMeasurementNavigation).FirstOrDefault(x => x.Id == matId);
                    string text = listBox1.GetItemText(listBox1.SelectedItem);
                    Repository.Models.UnitsOfMeasurement un = context.UnitsOfMeasurement.FirstOrDefault(x => x.Name == text);
                    mat.UnitOfMeasurementNavigation = un;
                    mat.Name = Convert.ToString(textBox1.Text);
                    mat.Count = Convert.ToDouble(textBox2.Text);
                    mat.Price = Convert.ToDouble(textBox3.Text);
                    mat.Cost = Convert.ToDouble(textBox4.Text);
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
            materialOfUnitDataGridView.Refresh();
        }

        private void materialOfUnitDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                foreach (DataGridViewRow row in materialOfUnitDataGridView.SelectedRows)
                {
                    /*count = Convert.ToDouble(row.Cells[2].Value);
                    material = Convert.ToString(row.Cells[1].Value);
                    ingredId = Convert.ToInt32(row.Cells[3].Value);
                    listBox2.SelectedIndex = listBox2.FindString(material);
                    textBox1.Text = count.ToString();*/
                    matId = Convert.ToInt32(row.Cells[0].Value);
                    matName = Convert.ToString(row.Cells[1].Value);
                    unit = Convert.ToString(row.Cells[2].Value);
                    count = Convert.ToDouble(row.Cells[3].Value);
                    price = Convert.ToDouble(row.Cells[4].Value);
                    cost = Convert.ToDouble(row.Cells[5].Value);
                    textBox1.Text = matName;
                    listBox1.SelectedIndex = listBox1.FindString(unit);
                    textBox2.Text = count.ToString();
                    textBox3.Text = price.ToString();
                    textBox4.Text = cost.ToString();
                }
            }
        }
    }
}
