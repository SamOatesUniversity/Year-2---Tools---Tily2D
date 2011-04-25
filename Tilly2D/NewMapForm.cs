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
        private bool m_create_map = false;

        public NewMapForm()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            m_create_map = false;
        }

        private void CreateMap(object sender, EventArgs e)
        {
            m_create_map = true;
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

        public bool CreateNewMap
        {
            get { return m_create_map; }
        }
    }
}
