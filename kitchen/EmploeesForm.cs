using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using kitchen.Repository;
using kitchen.Repository.Models;
using System.Data.Entity;

namespace kitchen
{
    public partial class EmploeesForm : Form
    {
        public EmploeesForm()
        {
            InitializeComponent();
        }

        /*private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);

        }*/
        public void update() 
        {
            this.emloyeesPostTableAdapter.Fill(this.finishKitchenDataSet.EmloyeesPost);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
        }
        private void Emploees_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.EmloyeesPost". При необходимости она может быть перемещена или удалена.
            this.emloyeesPostTableAdapter.Fill(this.finishKitchenDataSet.EmloyeesPost);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.EmloyeesPost". При необходимости она может быть перемещена или удалена.
            initListBoxPost();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void employeesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.EmloyeesPost". При необходимости она может быть перемещена или удалена.
            this.emloyeesPostTableAdapter.Fill(this.finishKitchenDataSet.EmloyeesPost);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.EmloyeesPost". При необходимости она может быть перемещена или удалена.

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
        }

        private void emloyeesPostDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string name, post, adress, phone;
        double sel;
        int empId;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void clear() 
        {
            textBox1.Clear();
            listBox1.SelectedItem= null;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }
        
        //сохранение
        private void button1_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    Employees employees = context.Employees.Include(x => x.PostNavigation).FirstOrDefault(x => x.Id == empId);
                    string text = listBox1.GetItemText(listBox1.SelectedItem);
                    Positions pos = context.Positions.FirstOrDefault(x => x.Post == text);
                    employees.PostNavigation= pos;
                    employees.Name = textBox1.Text;
                    employees.Salary= Convert.ToInt32(textBox2.Text);
                    employees.Phone = textBox4.Text;
                    employees.Address = textBox3.Text;
                    context.SaveChanges();
                    update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                          "Ошибка",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );

                }
                emloyeesPostDataGridView.Refresh();
            }
            emloyeesPostDataGridView.Refresh();
            clear();
        }
        //добавление
        private void button2_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    var value = ((ListIstem)listBox1.SelectedItem).Value;
                    var post = context.Positions.FirstOrDefault(x => x.Id == value);
                    Employees employees = new Employees();
                    string text = listBox1.GetItemText(listBox1.SelectedItem);
                    Positions positions = context.Positions.FirstOrDefault(x => x.Post == text);
                    employees.PostNavigation= positions;
                    employees.Name = textBox1.Text;
                    employees.Salary = Convert.ToInt32(textBox2.Text);
                    employees.Phone = textBox4.Text;
                    employees.Address = textBox3.Text;
                    context.Add(employees);
                    context.SaveChanges();
                    update();
                    clear();
                    context.SaveChanges();
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
        //очистка
        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        //Удаление

        private void button3_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    /*MessageBox.Show(
                          "Успешное удаление",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );*/
                    var empl = context.Employees.FirstOrDefault(x => x.Id == empId);
                    context.Remove(empl);
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

        
        private void emloyeesPostDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in emloyeesPostDataGridView.SelectedRows)
            {
                name = Convert.ToString(row.Cells[0].Value);
                post= Convert.ToString(row.Cells[1].Value);
                sel = Convert.ToDouble(row.Cells[3].Value);
                adress= Convert.ToString(row.Cells[4].Value);
                phone = Convert.ToString(row.Cells[5].Value);


                textBox1.Text = name;
                textBox2.Text = sel.ToString();
                textBox3.Text = adress;
                textBox4.Text = phone;

                listBox1.SelectedIndex = listBox1.FindString(post);



                empId = Convert.ToInt32(row.Cells[2].Value);
                //textBox1.Text=empId.ToString();
                using (KitchenDbContext context = new KitchenDbContext()) 
                {

                }

                
            }

        }
        public void initListBoxPost()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<Positions> post = context.Positions.ToList();

                foreach (Positions pi in post)
                {
                    listBox1.Items.Add(new ListIstem
                    {
                        Name = pi.Post,
                        Value = pi.Id
                    }
                    );

                }
            }
        }
    }
}
