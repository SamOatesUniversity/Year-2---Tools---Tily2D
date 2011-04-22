using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Tilly2D
{
    class CButton
    {
        private Button m_button;
        private int m_sprite_id;

        public CButton(int id, List<CSprite> sprite_list)
        {
            m_sprite_id = id;

            m_button = new Button();
            m_button.Location = new System.Drawing.Point();
            m_button.Size = new System.Drawing.Size( 32, 32 );
            m_button.Image = sprite_list[id].Bitmap;
            m_button.Click += OnClick;

        }

        public void OnClick(object sender, EventArgs e)
        {
            Tile.Active = m_sprite_id;
        }

        public System.Drawing.Point Location
        {
            get { return m_button.Location; }
            set { m_button.Location = value; }
        }

        public Button Button
        {
            get { return m_button; }
        }
    }
}
