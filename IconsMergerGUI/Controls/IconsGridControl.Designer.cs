namespace IconsMergerGUI.Controls
{
    partial class IconsGridControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgIcons = new System.Windows.Forms.DataGridView();
            this.IconId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblPackName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgIcons)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(0, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(278, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgIcons
            // 
            this.dgIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgIcons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIcons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IconId,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewImageColumn3});
            this.dgIcons.Location = new System.Drawing.Point(0, 52);
            this.dgIcons.MultiSelect = false;
            this.dgIcons.Name = "dgIcons";
            this.dgIcons.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgIcons.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgIcons.RowTemplate.Height = 30;
            this.dgIcons.RowTemplate.ReadOnly = true;
            this.dgIcons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgIcons.Size = new System.Drawing.Size(278, 233);
            this.dgIcons.TabIndex = 4;
            this.dgIcons.SelectionChanged += new System.EventHandler(this.dgIcons_SelectionChanged);
            this.dgIcons.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgIcons_MouseDown);
            this.dgIcons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgIcons_MouseMove);
            // 
            // IconId
            // 
            this.IconId.DataPropertyName = "Id";
            this.IconId.HeaderText = "Id";
            this.IconId.Name = "IconId";
            this.IconId.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "Image";
            this.dataGridViewImageColumn3.HeaderText = "Image";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 50;
            // 
            // lblPackName
            // 
            this.lblPackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPackName.Location = new System.Drawing.Point(0, 0);
            this.lblPackName.Margin = new System.Windows.Forms.Padding(0);
            this.lblPackName.Name = "lblPackName";
            this.lblPackName.Size = new System.Drawing.Size(278, 23);
            this.lblPackName.TabIndex = 7;
            this.lblPackName.Text = "label1";
            this.lblPackName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconsGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPackName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgIcons);
            this.Name = "IconsGridControl";
            this.Size = new System.Drawing.Size(278, 288);
            ((System.ComponentModel.ISupportInitialize)(this.dgIcons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgIcons;
        private System.Windows.Forms.DataGridViewTextBoxColumn IconId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label lblPackName;
    }
}
