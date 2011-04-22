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

        public CButton(int id, List<CSprite> sprite_list, Control parent)
        {
            m_sprite_id = id;

            m_button = new Button();
            m_button.Location = new System.Drawing.Point();
            m_button.Size = sprite_list[id].Size;
            m_button.Image = sprite_list[id].Bitmap;
            m_button.Click += OnClick;
            parent.Controls.Add(m_button);

        }

        public void OnClick(object sender, EventArgs e)
        {
            //DO MAGIC SHIZZ
            Tile.Active = m_sprite_id;
        }
    }
}
