namespace RestaurantApp
{
    partial class OrderDetails
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
            this.dataGridViewComments = new System.Windows.Forms.DataGridView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.dataGridViewFines = new System.Windows.Forms.DataGridView();
            this.dataGridViewService = new System.Windows.Forms.DataGridView();
            this.restDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restDataSet = new RestaurantApp.restDataSet();
            this.restDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restDataSet1 = new RestaurantApp.restDataSet();
            this.labelFines = new System.Windows.Forms.Label();
            this.labelServices = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewComments
            // 
            this.dataGridViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewComments.AutoGenerateColumns = false;
            this.dataGridViewComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewComments.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComments.DataSource = this.restDataSet1BindingSource;
            this.dataGridViewComments.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewComments.Name = "dataGridViewComments";
            this.dataGridViewComments.Size = new System.Drawing.Size(776, 152);
            this.dataGridViewComments.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelInfo.Location = new System.Drawing.Point(315, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(105, 25);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "ERROR?";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewFines
            // 
            this.dataGridViewFines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFines.AutoGenerateColumns = false;
            this.dataGridViewFines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFines.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFines.DataSource = this.restDataSetBindingSource;
            this.dataGridViewFines.Location = new System.Drawing.Point(12, 270);
            this.dataGridViewFines.Name = "dataGridViewFines";
            this.dataGridViewFines.Size = new System.Drawing.Size(776, 75);
            this.dataGridViewFines.TabIndex = 2;
            // 
            // dataGridViewService
            // 
            this.dataGridViewService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewService.AutoGenerateColumns = false;
            this.dataGridViewService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewService.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewService.DataSource = this.restDataSetBindingSource;
            this.dataGridViewService.Location = new System.Drawing.Point(12, 371);
            this.dataGridViewService.Name = "dataGridViewService";
            this.dataGridViewService.Size = new System.Drawing.Size(776, 75);
            this.dataGridViewService.TabIndex = 3;
            // 
            // restDataSetBindingSource
            // 
            this.restDataSetBindingSource.DataSource = this.restDataSet;
            this.restDataSetBindingSource.Position = 0;
            // 
            // restDataSet
            // 
            this.restDataSet.DataSetName = "restDataSet";
            this.restDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // restDataSet1BindingSource
            // 
            this.restDataSet1BindingSource.DataSource = this.restDataSet1;
            this.restDataSet1BindingSource.Position = 0;
            // 
            // restDataSet1
            // 
            this.restDataSet1.DataSetName = "restDataSet";
            this.restDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelFines
            // 
            this.labelFines.AutoSize = true;
            this.labelFines.BackColor = System.Drawing.Color.Transparent;
            this.labelFines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFines.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFines.Location = new System.Drawing.Point(12, 248);
            this.labelFines.Name = "labelFines";
            this.labelFines.Size = new System.Drawing.Size(55, 20);
            this.labelFines.TabIndex = 4;
            this.labelFines.Text = "Fines:";
            // 
            // labelServices
            // 
            this.labelServices.AutoSize = true;
            this.labelServices.BackColor = System.Drawing.Color.Transparent;
            this.labelServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServices.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelServices.Location = new System.Drawing.Point(12, 348);
            this.labelServices.Name = "labelServices";
            this.labelServices.Size = new System.Drawing.Size(79, 20);
            this.labelServices.TabIndex = 5;
            this.labelServices.Text = "Services:";
            // 
            // OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackgroundImage = global::RestaurantApp.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelServices);
            this.Controls.Add(this.labelFines);
            this.Controls.Add(this.dataGridViewService);
            this.Controls.Add(this.dataGridViewFines);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.dataGridViewComments);
            this.Name = "OrderDetails";
            this.Text = "OrderDetails";
            this.Load += new System.EventHandler(this.OrderDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewComments;
        private System.Windows.Forms.BindingSource restDataSetBindingSource;
        private restDataSet restDataSet;
        private System.Windows.Forms.BindingSource restDataSet1BindingSource;
        private restDataSet restDataSet1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridViewFines;
        private System.Windows.Forms.DataGridView dataGridViewService;
        private System.Windows.Forms.Label labelFines;
        private System.Windows.Forms.Label labelServices;
    }
}