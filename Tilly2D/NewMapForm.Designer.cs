namespace Tilly2D
{
    partial class NewMapForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mapSizeCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map name";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(75, 6);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(197, 20);
            this.mapName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map size";
            // 
            // mapSizeCombo
            // 
            this.mapSizeCombo.FormattingEnabled = true;
            this.mapSizeCombo.Items.AddRange(new object[] {
            "32x32",
            "64x64",
            "128x128",
            "256x256"});
            this.mapSizeCombo.Location = new System.Drawing.Point(75, 32);
            this.mapSizeCombo.Name = "mapSizeCombo";
            this.mapSizeCombo.Size = new System.Drawing.Size(197, 21);
            this.mapSizeCombo.TabIndex = 3;
            this.mapSizeCombo.Text = "64x64";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateMap);
            // 
            // NewMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mapSizeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Map";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mapSizeCombo;
        private System.Windows.Forms.Button button1;
    }
}