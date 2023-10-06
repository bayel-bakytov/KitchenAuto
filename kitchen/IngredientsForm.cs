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
    public partial class IngredientsForm : Form
    {
        public IngredientsForm()
        {
            InitializeComponent();
        }

        private void ingredientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ingredientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.IngredientsAll". При необходимости она может быть перемещена или удалена.
            this.ingredientsAllTableAdapter.Fill(this.finishKitchenDataSet.IngredientsAll);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Ingr". При необходимости она может быть перемещена или удалена.
            this.ingrTableAdapter.Fill(this.finishKitchenDataSet.Ingr);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Ingredients". При необходимости она может быть перемещена или удалена.
            this.ingredientsTableAdapter.Fill(this.finishKitchenDataSet.Ingredients);
        }

        private void Ingredients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.IngredientsAll". При необходимости она может быть перемещена или удалена.
            this.ingredientsAllTableAdapter.Fill(this.finishKitchenDataSet.IngredientsAll);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.finishKitchenDataSet.Materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.finishKitchenDataSet.Products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Ingr". При необходимости она может быть перемещена или удалена.
            this.ingrTableAdapter.Fill(this.finishKitchenDataSet.Ingr);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Ingredients". При необходимости она может быть перемещена или удалена.
            this.ingredientsTableAdapter.Fill(this.finishKitchenDataSet.Ingredients);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IngredientsAll ingredientsAll=new IngredientsAll();
            ingredientsAll.Show();
        }
    }
}
