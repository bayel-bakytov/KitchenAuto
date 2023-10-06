using kitchen.Repository;
using kitchen.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kitchen
{
    public partial class IngredientsAll : Form
    {
        public IngredientsAll()
        {
            InitializeComponent();
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
        public void initListBoxMaterials()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                List<Repository.Models.Materials> materialsList = context.Materials.ToList();

                foreach (Repository.Models.Materials m in materialsList)
                {
                    listBox2.Items.Add(new ListIstem
                    {
                        Name = m.Name,
                        Value = m.Id
                    }
                    );

                }
            }
        }

        public void update()
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {

                var value = ((ListIstem)listBox1.SelectedItem).Value;

                List<Ingredients> ingred = context.Ingredients
                        .Include(x => x.MaterialNavigation)
                        .Include(x => x.ProductNavigation)
                    .Where(x => x.Product == value).ToList();



                Console.WriteLine(value);

                dataGridView1.DataSource = ingred.Select(
                    x => new
                    {
                        product = x.ProductNavigation.Name,
                        material = x.MaterialNavigation.Name,
                        count = x.Count,
                        id = x.Id
                    }).ToList();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["product"].Visible = false;

            }
        }

        
        private void IngredientsAll_Load(object sender, EventArgs e)
        {
            initListBoxFinishProduct();
            initListBoxMaterials();
        }
        double count;
        string material;
        int ingredId;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    count = Convert.ToDouble(row.Cells[2].Value);
                    material = Convert.ToString(row.Cells[1].Value);
                    ingredId = Convert.ToInt32(row.Cells[3].Value);
                    listBox2.SelectedIndex = listBox2.FindString(material);
                    textBox1.Text = count.ToString();
                }
                
            }
        }
        double costProduct = 0;
        double costMat;

        private void button2_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext()) 
            {
                try
                {
                    Ingredients ingred = context.Ingredients.Include(x => x.MaterialNavigation).FirstOrDefault(x => x.Id == ingredId);
                    string text = listBox2.GetItemText(listBox2.SelectedItem);
                    Repository.Models.Materials Mat = context.Materials.FirstOrDefault(x => x.Name == text);
                    ingred.MaterialNavigation = Mat;
                    ingred.Count = Convert.ToDouble(textBox1.Text);


                    Products products = context.Products.Include(x => x.Ingredients).ThenInclude(y => y.MaterialNavigation).
                        FirstOrDefault(x => x.Id == ingred.Product);
                    foreach (Ingredients ingr in products.Ingredients)
                    {
                        costMat = Convert.ToDouble(ingr.MaterialNavigation.Cost);
                        costProduct += costMat * Convert.ToDouble(ingr.Count);
                    }
                    products.Price = costProduct;
                    products.Sum = costProduct * products.Count;
                    costProduct = 0;



                    context.SaveChanges();
                    update();
                    listBox2.SelectedItem = null;
                    textBox1.Clear();


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
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.SelectedItem=null;
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    var value = ((ListIstem)listBox1.SelectedItem).Value;
                    var product = context.Products.FirstOrDefault(x => x.Id == value);
                    Ingredients ingred = new Ingredients();
                    string text = listBox1.GetItemText(listBox2.SelectedItem);
                    Repository.Models.Materials Mat = context.Materials.FirstOrDefault(x => x.Name == text);
                    ingred.MaterialNavigation = Mat;
                    ingred.Count = Convert.ToDouble(textBox1.Text);
                    ingred.ProductNavigation = product;
                    
                    context.Add(ingred);
                    Products products = context.Products.Include(x => x.Ingredients).ThenInclude(y => y.MaterialNavigation).FirstOrDefault(x => x.Id == ingred.Product);
                    foreach (Ingredients ingr in products.Ingredients)
                    {
                        costMat = Convert.ToDouble(ingr.MaterialNavigation.Cost);
                        costProduct += costMat * Convert.ToDouble(ingr.Count);
                    }
                    products.Price = costProduct;
                    products.Sum = costProduct * products.Count;
                    costProduct = 0;

                    context.SaveChanges();
                    update();
                    listBox2.SelectedItem = null;
                    textBox1.Clear();
                    /*MessageBox.Show(
                          "Успешное добавление",
                        "Сообщение",
                        MessageBoxButtons.OK
                    );*/
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

        private void button4_Click(object sender, EventArgs e)
        {
            using (KitchenDbContext context = new KitchenDbContext())
            {
                try
                {
                    var ingr = context.Ingredients.Include(y => y.MaterialNavigation).FirstOrDefault(x => x.Id == ingredId);
                    
                    Products products = context.Products.FirstOrDefault(x => x.Id == ingr.Product);
                    products.Price -= Convert.ToDouble(ingr.MaterialNavigation.Cost) * Convert.ToDouble(ingr.Count);
                    products.Sum = products.Price * products.Count;
                    context.Remove(ingr);
                    context.SaveChanges();
                    update();
                    listBox2.SelectedItem = null;
                    textBox1.Clear();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
    

