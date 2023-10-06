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
    public partial class Measure : Form
    {
        public Measure()
        {
            InitializeComponent();
        }

        private void unitsOfMeasurementBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.unitsOfMeasurementBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finishKitchenDataSet);
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);
        }

        private void Measure_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "finishKitchenDataSet.UnitsOfMeasurement". При необходимости она может быть перемещена или удалена.
            this.unitsOfMeasurementTableAdapter.Fill(this.finishKitchenDataSet.UnitsOfMeasurement);

        }
    }
}
