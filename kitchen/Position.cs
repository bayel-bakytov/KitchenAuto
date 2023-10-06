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
    public partial class Position : Form
    {
        public Position()
        {
            InitializeComponent();
        }

        private void positionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.positionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);

        }

        private void Position_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Employees". При необходимости она может быть перемещена или удалена.
            //this.employeesTableAdapter.Fill(this.finishKitchenDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.finishKitchenDataSet.Positions);

        }
    }
}
