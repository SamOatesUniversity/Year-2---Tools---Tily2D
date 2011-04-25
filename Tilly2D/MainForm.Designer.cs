namespace Tilly2D
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.draw_panel = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_TileCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Zoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.tileTab = new System.Windows.Forms.TabControl();
            this.tileDetails = new System.Windows.Forms.GroupBox();
            this.label_tile_details_tab = new System.Windows.Forms.Label();
            this.label_tile_details_position = new System.Windows.Forms.Label();
            this.label_tile_details_id = new System.Windows.Forms.Label();
            this.pictureBox_TileDetails = new System.Windows.Forms.PictureBox();
            this.layerCheckBox = new System.Windows.Forms.CheckedListBox();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLayerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTileType = new System.Windows.Forms.Label();
            this.pictureBox_SelectedTile = new System.Windows.Forms.PictureBox();
            this.labelTileDetailsType = new System.Windows.Forms.Label();
            this.labelTileBlocking = new System.Windows.Forms.Label();
            this.labelTileDetailsBlocking = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.draw_panel)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tileDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedTile)).BeginInit();
            this.SuspendLayout();
            // 
            // draw_panel
            // 
            this.draw_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.draw_panel.Location = new System.Drawing.Point(158, 28);
            this.draw_panel.MinimumSize = new System.Drawing.Size(480, 390);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(480, 443);
            this.draw_panel.TabIndex = 0;
            this.draw_panel.TabStop = false;
            this.draw_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnPanelClick);
            this.draw_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnPanelDrag);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_TileCoord,
            this.toolStripStatusLabel_Zoom,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(838, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel_TileCoord
            // 
            this.toolStripStatusLabel_TileCoord.Name = "toolStripStatusLabel_TileCoord";
            this.toolStripStatusLabel_TileCoord.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel_TileCoord.Text = "Tile[0] : 0, 0";
            // 
            // toolStripStatusLabel_Zoom
            // 
            this.toolStripStatusLabel_Zoom.Name = "toolStripStatusLabel_Zoom";
            this.toolStripStatusLabel_Zoom.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel_Zoom.Text = "          Zoom : x1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "            ";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(838, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.NewMap);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OnOpenMap);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.OnClickHealth);
            // 
            // drawTimer
            // 
            this.drawTimer.Enabled = true;
            this.drawTimer.Interval = 1;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // tileTab
            // 
            this.tileTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileTab.Location = new System.Drawing.Point(643, 28);
            this.tileTab.Multiline = true;
            this.tileTab.Name = "tileTab";
            this.tileTab.SelectedIndex = 0;
            this.tileTab.Size = new System.Drawing.Size(188, 278);
            this.tileTab.TabIndex = 3;
            // 
            // tileDetails
            // 
            this.tileDetails.Controls.Add(this.labelTileDetailsBlocking);
            this.tileDetails.Controls.Add(this.labelTileDetailsType);
            this.tileDetails.Controls.Add(this.label_tile_details_tab);
            this.tileDetails.Controls.Add(this.label_tile_details_position);
            this.tileDetails.Controls.Add(this.label_tile_details_id);
            this.tileDetails.Controls.Add(this.pictureBox_TileDetails);
            this.tileDetails.Location = new System.Drawing.Point(12, 28);
            this.tileDetails.Name = "tileDetails";
            this.tileDetails.Size = new System.Drawing.Size(140, 122);
            this.tileDetails.TabIndex = 4;
            this.tileDetails.TabStop = false;
            this.tileDetails.Text = "Tile Details";
            // 
            // label_tile_details_tab
            // 
            this.label_tile_details_tab.AutoSize = true;
            this.label_tile_details_tab.Location = new System.Drawing.Point(6, 54);
            this.label_tile_details_tab.Name = "label_tile_details_tab";
            this.label_tile_details_tab.Size = new System.Drawing.Size(37, 13);
            this.label_tile_details_tab.TabIndex = 3;
            this.label_tile_details_tab.Text = "tab : --";
            // 
            // label_tile_details_position
            // 
            this.label_tile_details_position.AutoSize = true;
            this.label_tile_details_position.Location = new System.Drawing.Point(44, 38);
            this.label_tile_details_position.Name = "label_tile_details_position";
            this.label_tile_details_position.Size = new System.Drawing.Size(73, 13);
            this.label_tile_details_position.TabIndex = 2;
            this.label_tile_details_position.Text = "position : -- , --";
            // 
            // label_tile_details_id
            // 
            this.label_tile_details_id.AutoSize = true;
            this.label_tile_details_id.Location = new System.Drawing.Point(44, 19);
            this.label_tile_details_id.Name = "label_tile_details_id";
            this.label_tile_details_id.Size = new System.Drawing.Size(30, 13);
            this.label_tile_details_id.TabIndex = 1;
            this.label_tile_details_id.Text = "id : --";
            // 
            // pictureBox_TileDetails
            // 
            this.pictureBox_TileDetails.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_TileDetails.Name = "pictureBox_TileDetails";
            this.pictureBox_TileDetails.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_TileDetails.TabIndex = 0;
            this.pictureBox_TileDetails.TabStop = false;
            // 
            // layerCheckBox
            // 
            this.layerCheckBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layerCheckBox.FormattingEnabled = true;
            this.layerCheckBox.Items.AddRange(new object[] {
            "Layer One",
            "Layer Two",
            "Layer Three",
            "Layer Four",
            "Layer Five",
            "Layer Six",
            "Layer Seven",
            "Layer Eight",
            "Layer Nine",
            "Layer Ten"});
            this.layerCheckBox.Location = new System.Drawing.Point(12, 156);
            this.layerCheckBox.Name = "layerCheckBox";
            this.layerCheckBox.Size = new System.Drawing.Size(140, 152);
            this.layerCheckBox.TabIndex = 5;
            this.layerCheckBox.Click += new System.EventHandler(this.LayerChange);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(622, 28);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(21, 443);
            this.vScrollBar.TabIndex = 6;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Vertical_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(158, 454);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(464, 21);
            this.hScrollBar.TabIndex = 7;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Horizontal_Scroll);
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomBar.Location = new System.Drawing.Point(646, 430);
            this.zoomBar.Maximum = 16;
            this.zoomBar.Minimum = 1;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(185, 45);
            this.zoomBar.TabIndex = 8;
            this.zoomBar.Value = 4;
            this.zoomBar.Scroll += new System.EventHandler(this.Zoom);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zoom";
            // 
            // OpenMapFileDialog
            // 
            this.OpenMapFileDialog.Filter = "Xml files|*.xml";
            this.OpenMapFileDialog.Title = "Open map xml file";
            // 
            // saveMapFileDialog
            // 
            this.saveMapFileDialog.Filter = "Xml Files|*.xml";
            this.saveMapFileDialog.Title = "Save map";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Layer Name";
            // 
            // textBoxLayerName
            // 
            this.textBoxLayerName.Location = new System.Drawing.Point(12, 327);
            this.textBoxLayerName.Name = "textBoxLayerName";
            this.textBoxLayerName.Size = new System.Drawing.Size(140, 20);
            this.textBoxLayerName.TabIndex = 11;
            this.textBoxLayerName.Text = "Layer One";
            this.textBoxLayerName.TextChanged += new System.EventHandler(this.Layer_Name_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Layer Draw Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Empty",
            "Fill",
            "Copy",
            "Transparent"});
            this.comboBox1.Location = new System.Drawing.Point(12, 375);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "Copy";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelTileBlocking);
            this.groupBox1.Controls.Add(this.labelTileType);
            this.groupBox1.Controls.Add(this.pictureBox_SelectedTile);
            this.groupBox1.Location = new System.Drawing.Point(643, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Tile Properties";
            // 
            // labelTileType
            // 
            this.labelTileType.AutoSize = true;
            this.labelTileType.Location = new System.Drawing.Point(44, 19);
            this.labelTileType.Name = "labelTileType";
            this.labelTileType.Size = new System.Drawing.Size(60, 13);
            this.labelTileType.TabIndex = 1;
            this.labelTileType.Text = "type : none";
            // 
            // pictureBox_SelectedTile
            // 
            this.pictureBox_SelectedTile.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_SelectedTile.Name = "pictureBox_SelectedTile";
            this.pictureBox_SelectedTile.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_SelectedTile.TabIndex = 0;
            this.pictureBox_SelectedTile.TabStop = false;
            // 
            // labelTileDetailsType
            // 
            this.labelTileDetailsType.AutoSize = true;
            this.labelTileDetailsType.Location = new System.Drawing.Point(6, 74);
            this.labelTileDetailsType.Name = "labelTileDetailsType";
            this.labelTileDetailsType.Size = new System.Drawing.Size(42, 13);
            this.labelTileDetailsType.TabIndex = 4;
            this.labelTileDetailsType.Text = "type : --";
            // 
            // labelTileBlocking
            // 
            this.labelTileBlocking.AutoSize = true;
            this.labelTileBlocking.Location = new System.Drawing.Point(44, 38);
            this.labelTileBlocking.Name = "labelTileBlocking";
            this.labelTileBlocking.Size = new System.Drawing.Size(78, 13);
            this.labelTileBlocking.TabIndex = 2;
            this.labelTileBlocking.Text = "blocking : false";
            // 
            // labelTileDetailsBlocking
            // 
            this.labelTileDetailsBlocking.AutoSize = true;
            this.labelTileDetailsBlocking.Location = new System.Drawing.Point(6, 96);
            this.labelTileDetailsBlocking.Name = "labelTileDetailsBlocking";
            this.labelTileDetailsBlocking.Size = new System.Drawing.Size(62, 13);
            this.labelTileDetailsBlocking.TabIndex = 5;
            this.labelTileDetailsBlocking.Text = "blocking : --";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.layerCheckBox);
            this.Controls.Add(this.tileDetails);
            this.Controls.Add(this.tileTab);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.draw_panel);
            this.MinimumSize = new System.Drawing.Size(854, 538);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tilly2D";
            this.Resize += new System.EventHandler(this.OnResize);
            ((System.ComponentModel.ISupportInitialize)(this.draw_panel)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tileDetails.ResumeLayout(false);
            this.tileDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SelectedTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox draw_panel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.TabControl tileTab;
        private System.Windows.Forms.GroupBox tileDetails;
        private System.Windows.Forms.CheckedListBox layerCheckBox;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_TileCoord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Zoom;
        private System.Windows.Forms.PictureBox pictureBox_TileDetails;
        private System.Windows.Forms.Label label_tile_details_position;
        private System.Windows.Forms.Label label_tile_details_id;
        private System.Windows.Forms.Label label_tile_details_tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog OpenMapFileDialog;
        private System.Windows.Forms.SaveFileDialog saveMapFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox_SelectedTile;
        private System.Windows.Forms.Label labelTileType;
        private System.Windows.Forms.Label labelTileDetailsType;
        private System.Windows.Forms.Label labelTileBlocking;
        private System.Windows.Forms.Label labelTileDetailsBlocking;
    }
}

