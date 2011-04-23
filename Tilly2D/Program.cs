using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tilly2D
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (MainForm main_form = new MainForm())
            {
                main_form.InitializeDevice();
                Application.EnableVisualStyles();
                Application.Run(main_form);
            }
        }
    }
}
