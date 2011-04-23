using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tilly2D
{
    public partial class NewMapForm : Form
    {
        public NewMapForm()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void CreateMap(object sender, EventArgs e)
        {
            this.Close();
        }

        public int MapSize
        {
            get { return (int)Math.Pow( 2.0, (mapSizeCombo.SelectedIndex + 5.0 )); }
        }

        public String MapName
        {
            get { return mapName.Text; }
        }
    }
}
