using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tilly2D
{
    class CButtonContainer
    {
        private List<CButton> m_button = new List<CButton>();

        public void Add(CButton button, Control parent)
        {
            m_button.Add(button);

            int x_pos = (int)((parent.Width / 4.0f) * (m_button.Count-1)) - 1;
            int y_pos = 0;

            while (x_pos > (parent.Width - (parent.Width / 4.0f))) 
            {
                y_pos += 36;
                x_pos -= parent.Width;
            }

            button.Location = new System.Drawing.Point(x_pos, y_pos);
            parent.Controls.Add(button.Button);
        }
    }
}
