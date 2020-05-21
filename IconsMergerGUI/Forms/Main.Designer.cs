namespace IconsMergerGUI.Forms
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPacks = new System.Windows.Forms.Panel();
            this.dgMappedIcons = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMappedIcons = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnIconsImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIconsExport = new System.Windows.Forms.ToolStripButton();
            this.btnAutoMapExisting = new System.Windows.Forms.ToolStripButton();
            this.btnAutoMap = new System.Windows.Forms.ToolStripButton();
            this.btnMap = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgMappedIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPacks
            // 
            this.pnlPacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPacks.Location = new System.Drawing.Point(0, 0);
            this.pnlPacks.Name = "pnlPacks";
            this.pnlPacks.Size = new System.Drawing.Size(1158, 295);
            this.pnlPacks.TabIndex = 10;
            // 
            // dgMappedIcons
            // 
            this.dgMappedIcons.AllowDrop = true;
            this.dgMappedIcons.AllowUserToAddRows = false;
            this.dgMappedIcons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMappedIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMappedIcons.Location = new System.Drawing.Point(0, 0);
            this.dgMappedIcons.Name = "dgMappedIcons";
            this.dgMappedIcons.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgMappedIcons.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgMappedIcons.RowTemplate.Height = 30;
            this.dgMappedIcons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMappedIcons.Size = new System.Drawing.Size(1158, 311);
            this.dgMappedIcons.TabIndex = 11;
            this.dgMappedIcons.DataSourceChanged += new System.EventHandler(this.dgMappedIcons_DataSourceChanged);
            this.dgMappedIcons.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMappedIcons_CellValidating);
            this.dgMappedIcons.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMappedIcons_CellValueChanged);
            this.dgMappedIcons.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgMappedIcons_UserDeletingRow);
            this.dgMappedIcons.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgMappedIcons_DragDrop);
            this.dgMappedIcons.DragOver += new System.Windows.Forms.DragEventHandler(this.dgMappedIcons_DragOver);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlPacks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgMappedIcons);
            this.splitContainer1.Size = new System.Drawing.Size(1158, 610);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMappedIcons});
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMappedIcons
            // 
            this.lblMappedIcons.Name = "lblMappedIcons";
            this.lblMappedIcons.Size = new System.Drawing.Size(85, 17);
            this.lblMappedIcons.Text = "Mapped icons:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIconsImport,
            this.toolStripSeparator2,
            this.btnIconsExport,
            this.btnAutoMapExisting,
            this.btnAutoMap,
            this.btnMap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1182, 39);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnIconsImport
            // 
            this.btnIconsImport.Image = global::IconsMergerGUI.Properties.Resources.add_package;
            this.btnIconsImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIconsImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIconsImport.Name = "btnIconsImport";
            this.btnIconsImport.Size = new System.Drawing.Size(110, 36);
            this.btnIconsImport.Text = "Import Icons";
            this.btnIconsImport.Click += new System.EventHandler(this.btnIconsImport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnIconsExport
            // 
            this.btnIconsExport.Image = global::IconsMergerGUI.Properties.Resources.source_code;
            this.btnIconsExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIconsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIconsExport.Name = "btnIconsExport";
            this.btnIconsExport.Size = new System.Drawing.Size(121, 36);
            this.btnIconsExport.Text = "Generate Code";
            this.btnIconsExport.Click += new System.EventHandler(this.btnIconsExport_Click);
            // 
            // btnAutoMapExisting
            // 
            this.btnAutoMapExisting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAutoMapExisting.Image = global::IconsMergerGUI.Properties.Resources.table_link;
            this.btnAutoMapExisting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAutoMapExisting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoMapExisting.Name = "btnAutoMapExisting";
            this.btnAutoMapExisting.Size = new System.Drawing.Size(199, 36);
            this.btnAutoMapExisting.Text = "Auto Map With Existing Icons";
            this.btnAutoMapExisting.Click += new System.EventHandler(this.btnAutoMapExisting_Click);
            // 
            // btnAutoMap
            // 
            this.btnAutoMap.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAutoMap.Image = global::IconsMergerGUI.Properties.Resources.table_link;
            this.btnAutoMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAutoMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoMap.Name = "btnAutoMap";
            this.btnAutoMap.Size = new System.Drawing.Size(195, 36);
            this.btnAutoMap.Text = "Auto Map All Icons By Name";
            this.btnAutoMap.Click += new System.EventHandler(this.btnAutoMap_Click);
            // 
            // btnMap
            // 
            this.btnMap.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMap.Image = global::IconsMergerGUI.Properties.Resources.link;
            this.btnMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(98, 36);
            this.btnMap.Text = "Map Icons";
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 677);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IconMergerGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMappedIcons)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlPacks;
        private System.Windows.Forms.DataGridView dgMappedIcons;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMappedIcons;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMap;
        private System.Windows.Forms.ToolStripButton btnIconsImport;
        private System.Windows.Forms.ToolStripButton btnIconsExport;
        private System.Windows.Forms.ToolStripButton btnAutoMapExisting;
        private System.Windows.Forms.ToolStripButton btnAutoMap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

