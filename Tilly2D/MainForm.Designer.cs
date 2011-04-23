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
            this.layerDetails = new System.Windows.Forms.GroupBox();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.draw_panel)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tileDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TileDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
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
            this.toolStripStatusLabel_Zoom});
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
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
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
            // 
            // drawTimer
            // 
            this.drawTimer.Enabled = true;
            this.drawTimer.Interval = 16;
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
            this.tileTab.Size = new System.Drawing.Size(188, 396);
            this.tileTab.TabIndex = 3;
            // 
            // tileDetails
            // 
            this.tileDetails.Controls.Add(this.label_tile_details_tab);
            this.tileDetails.Controls.Add(this.label_tile_details_position);
            this.tileDetails.Controls.Add(this.label_tile_details_id);
            this.tileDetails.Controls.Add(this.pictureBox_TileDetails);
            this.tileDetails.Location = new System.Drawing.Point(12, 28);
            this.tileDetails.Name = "tileDetails";
            this.tileDetails.Size = new System.Drawing.Size(140, 145);
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
            this.layerCheckBox.Location = new System.Drawing.Point(12, 180);
            this.layerCheckBox.Name = "layerCheckBox";
            this.layerCheckBox.Size = new System.Drawing.Size(140, 137);
            this.layerCheckBox.TabIndex = 5;
            this.layerCheckBox.Click += new System.EventHandler(this.LayerChange);
            // 
            // layerDetails
            // 
            this.layerDetails.Location = new System.Drawing.Point(12, 326);
            this.layerDetails.Name = "layerDetails";
            this.layerDetails.Size = new System.Drawing.Size(140, 145);
            this.layerDetails.TabIndex = 5;
            this.layerDetails.TabStop = false;
            this.layerDetails.Text = "Layer Details";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 500);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.layerDetails);
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
        private System.Windows.Forms.GroupBox layerDetails;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_TileCoord;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Zoom;
        private System.Windows.Forms.PictureBox pictureBox_TileDetails;
        private System.Windows.Forms.Label label_tile_details_position;
        private System.Windows.Forms.Label label_tile_details_id;
        private System.Windows.Forms.Label label_tile_details_tab;
    }
}

