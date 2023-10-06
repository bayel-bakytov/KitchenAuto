namespace kitchen
{
    partial class IngredientsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label productLabel;
            System.Windows.Forms.Label materialLabel;
            System.Windows.Forms.Label countLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngredientsForm));
            this.finishKitchenDataSet = new kitchen.FinishKitchenDataSet();
            this.ingredientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsTableAdapter = new kitchen.FinishKitchenDataSetTableAdapters.IngredientsTableAdapter();
            this.tableAdapterManager = new kitchen.FinishKitchenDataSetTableAdapters.TableAdapterManager();
            this.ingredientsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ingredientsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialListBox = new System.Windows.Forms.ListBox();
            this.materialsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.ingrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingrTableAdapter = new kitchen.FinishKitchenDataSetTableAdapters.IngrTableAdapter();
            this.productsTableAdapter = new kitchen.FinishKitchenDataSetTableAdapters.ProductsTableAdapter();
            this.materialsTableAdapter = new kitchen.FinishKitchenDataSetTableAdapters.MaterialsTableAdapter();
            this.ingredientsAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientsAllTableAdapter = new kitchen.FinishKitchenDataSetTableAdapters.IngredientsAllTableAdapter();
            this.ingredientsAllDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            iDLabel = new System.Windows.Forms.Label();
            productLabel = new System.Windows.Forms.Label();
            materialLabel = new System.Windows.Forms.Label();
            countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.finishKitchenDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingNavigator)).BeginInit();
            this.ingredientsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsAllDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(41, 58);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(23, 16);
            iDLabel.TabIndex = 1;
            iDLabel.Text = "ID:";
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Location = new System.Drawing.Point(41, 83);
            productLabel.Name = "productLabel";
            productLabel.Size = new System.Drawing.Size(55, 16);
            productLabel.TabIndex = 3;
            productLabel.Text = "product:";
            // 
            // materialLabel
            // 
            materialLabel.AutoSize = true;
            materialLabel.Location = new System.Drawing.Point(41, 185);
            materialLabel.Name = "materialLabel";
            materialLabel.Size = new System.Drawing.Size(58, 16);
            materialLabel.TabIndex = 5;
            materialLabel.Text = "material:";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Location = new System.Drawing.Point(41, 290);
            countLabel.Name = "countLabel";
            countLabel.Size = new System.Drawing.Size(42, 16);
            countLabel.TabIndex = 7;
            countLabel.Text = "count:";
            // 
            // finishKitchenDataSet
            // 
            this.finishKitchenDataSet.DataSetName = "FinishKitchenDataSet";
            this.finishKitchenDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingredientsBindingSource
            // 
            this.ingredientsBindingSource.DataMember = "Ingredients";
            this.ingredientsBindingSource.DataSource = this.finishKitchenDataSet;
            // 
            // ingredientsTableAdapter
            // 
            this.ingredientsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BudgetTableAdapter = null;
            this.tableAdapterManager.EmployeesTableAdapter = null;
            this.tableAdapterManager.IngredientsTableAdapter = this.ingredientsTableAdapter;
            this.tableAdapterManager.MaterialsTableAdapter = null;
            this.tableAdapterManager.PositionsTableAdapter = null;
            this.tableAdapterManager.ProductionTableAdapter = null;
            this.tableAdapterManager.ProductsTableAdapter = null;
            this.tableAdapterManager.Purchase_materialsTableAdapter = null;
            this.tableAdapterManager.SalaryTableAdapter = null;
            this.tableAdapterManager.Sale_productsTableAdapter = null;
            this.tableAdapterManager.UnitsOfMeasurementTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = kitchen.FinishKitchenDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ingredientsBindingNavigator
            // 
            this.ingredientsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.ingredientsBindingNavigator.BindingSource = this.ingredientsBindingSource;
            this.ingredientsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.ingredientsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.ingredientsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ingredientsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.ingredientsBindingNavigatorSaveItem});
            this.ingredientsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.ingredientsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.ingredientsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.ingredientsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.ingredientsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.ingredientsBindingNavigator.Name = "ingredientsBindingNavigator";
            this.ingredientsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.ingredientsBindingNavigator.Size = new System.Drawing.Size(1345, 31);
            this.ingredientsBindingNavigator.TabIndex = 0;
            this.ingredientsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 28);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // ingredientsBindingNavigatorSaveItem
            // 
            this.ingredientsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ingredientsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("ingredientsBindingNavigatorSaveItem.Image")));
            this.ingredientsBindingNavigatorSaveItem.Name = "ingredientsBindingNavigatorSaveItem";
            this.ingredientsBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 28);
            this.ingredientsBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.ingredientsBindingNavigatorSaveItem.Click += new System.EventHandler(this.ingredientsBindingNavigatorSaveItem_Click);
            // 
            // iDTextBox
            // 
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ingredientsBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(105, 55);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(230, 22);
            this.iDTextBox.TabIndex = 2;
            // 
            // productListBox
            // 
            this.productListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ingredientsBindingSource, "product", true));
            this.productListBox.DataSource = this.productsBindingSource;
            this.productListBox.DisplayMember = "name";
            this.productListBox.FormattingEnabled = true;
            this.productListBox.ItemHeight = 16;
            this.productListBox.Location = new System.Drawing.Point(105, 83);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(230, 84);
            this.productListBox.TabIndex = 4;
            this.productListBox.ValueMember = "ID";
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this.finishKitchenDataSet;
            // 
            // materialListBox
            // 
            this.materialListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ingredientsBindingSource, "material", true));
            this.materialListBox.DataSource = this.materialsBindingSource;
            this.materialListBox.DisplayMember = "name";
            this.materialListBox.FormattingEnabled = true;
            this.materialListBox.ItemHeight = 16;
            this.materialListBox.Location = new System.Drawing.Point(105, 185);
            this.materialListBox.Name = "materialListBox";
            this.materialListBox.Size = new System.Drawing.Size(230, 84);
            this.materialListBox.TabIndex = 6;
            this.materialListBox.ValueMember = "ID";
            // 
            // materialsBindingSource
            // 
            this.materialsBindingSource.DataMember = "Materials";
            this.materialsBindingSource.DataSource = this.finishKitchenDataSet;
            // 
            // countTextBox
            // 
            this.countTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ingredientsBindingSource, "count", true));
            this.countTextBox.Location = new System.Drawing.Point(105, 287);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(230, 22);
            this.countTextBox.TabIndex = 8;
            // 
            // ingrBindingSource
            // 
            this.ingrBindingSource.DataMember = "Ingr";
            this.ingrBindingSource.DataSource = this.finishKitchenDataSet;
            // 
            // ingrTableAdapter
            // 
            this.ingrTableAdapter.ClearBeforeFill = true;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // materialsTableAdapter
            // 
            this.materialsTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientsAllBindingSource
            // 
            this.ingredientsAllBindingSource.DataMember = "IngredientsAll";
            this.ingredientsAllBindingSource.DataSource = this.finishKitchenDataSet;
            // 
            // ingredientsAllTableAdapter
            // 
            this.ingredientsAllTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientsAllDataGridView
            // 
            this.ingredientsAllDataGridView.AutoGenerateColumns = false;
            this.ingredientsAllDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ingredientsAllDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.ingredientsAllDataGridView.DataSource = this.ingredientsAllBindingSource;
            this.ingredientsAllDataGridView.Location = new System.Drawing.Point(389, 43);
            this.ingredientsAllDataGridView.Name = "ingredientsAllDataGridView";
            this.ingredientsAllDataGridView.RowHeadersWidth = 51;
            this.ingredientsAllDataGridView.RowTemplate.Height = 24;
            this.ingredientsAllDataGridView.Size = new System.Drawing.Size(682, 403);
            this.ingredientsAllDataGridView.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "product";
            this.dataGridViewTextBoxColumn1.HeaderText = "product";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "material";
            this.dataGridViewTextBoxColumn2.HeaderText = "material";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "count";
            this.dataGridViewTextBoxColumn3.HeaderText = "count";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Редактировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IngredientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ingredientsAllDataGridView);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDTextBox);
            this.Controls.Add(productLabel);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(materialLabel);
            this.Controls.Add(this.materialListBox);
            this.Controls.Add(countLabel);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.ingredientsBindingNavigator);
            this.Name = "IngredientsForm";
            this.Text = "Ingredients";
            this.Load += new System.EventHandler(this.Ingredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.finishKitchenDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsBindingNavigator)).EndInit();
            this.ingredientsBindingNavigator.ResumeLayout(false);
            this.ingredientsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientsAllDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FinishKitchenDataSet finishKitchenDataSet;
        private System.Windows.Forms.BindingSource ingredientsBindingSource;
        private FinishKitchenDataSetTableAdapters.IngredientsTableAdapter ingredientsTableAdapter;
        private FinishKitchenDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator ingredientsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton ingredientsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.ListBox productListBox;
        private System.Windows.Forms.ListBox materialListBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.BindingSource ingrBindingSource;
        private FinishKitchenDataSetTableAdapters.IngrTableAdapter ingrTableAdapter;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private FinishKitchenDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.BindingSource materialsBindingSource;
        private FinishKitchenDataSetTableAdapters.MaterialsTableAdapter materialsTableAdapter;
        private System.Windows.Forms.BindingSource ingredientsAllBindingSource;
        private FinishKitchenDataSetTableAdapters.IngredientsAllTableAdapter ingredientsAllTableAdapter;
        private System.Windows.Forms.DataGridView ingredientsAllDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
    }
}