using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tilly2D
{
    class CSprite
    {
        private Texture m_file_texture;
        private Rectangle m_source;
        private int m_id, m_file;
        private Point m_location;
        private String m_file_name;

        private Bitmap m_image;

        public CSprite( Device dev, XmlNode file, XmlNode sprite )
        {
            m_file_name = file.InnerText;

            m_image = new Bitmap("Game\\" + m_file_name);

            m_file_texture = TextureLoader.FromFile(dev, "Game\\" + m_file_name);
            m_file = Convert.ToInt32(file.Attributes["id"].Value);

            m_source = new Rectangle(Convert.ToInt32(sprite.Attributes["x"].Value), 
                                     Convert.ToInt32(sprite.Attributes["y"].Value), 
                                     Convert.ToInt32(sprite.Attributes["w"].Value),
                                     Convert.ToInt32(sprite.Attributes["h"].Value));
            m_id = Convert.ToInt32(sprite.Attributes["id"].Value);

            m_location = new Point();
        }

        public CSprite(Device dev, String location)
        {
            m_file_name = location;

            m_file_texture = TextureLoader.FromFile(dev, location);
            m_file = 0;

            m_source = new Rectangle(0, 0,
                                     m_file_texture.GetSurfaceLevel(0).Description.Width,
                                     m_file_texture.GetSurfaceLevel(0).Description.Height);
            m_id = 0;

            m_location = new Point();
        }

        public CSprite(Device dev, Texture texture)
        {
            m_file_name = "";

            m_file_texture = texture;
            m_file = 0;

            m_source = new Rectangle(0, 0,
                                     m_file_texture.GetSurfaceLevel(0).Description.Width,
                                     m_file_texture.GetSurfaceLevel(0).Description.Height);
            m_id = 0;

            m_location = new Point();
        }

        public void Draw( Sprite sprite, int grid_size )
        {
            sprite.Begin(SpriteFlags.AlphaBlend);
            sprite.Draw2D(m_file_texture, m_source, new Rectangle(0, 0, grid_size, grid_size), new Point((int)(m_location.X * (grid_size / (grid_size / 32.0f))),
                                                                                                          (int)(m_location.Y * (grid_size / (grid_size / 32.0f)))), Color.White);                        
            sprite.End();
        }

        public void Release()
        {
            m_file_texture.Dispose();
        }

        public Point Location
        {
            get { return m_location; }
            set { m_location = value; }
        }

        public int FileId
        {
            get { return m_file; }
        }

        public String FileName
        {
            get { return m_file_name; }
        }

        public Size Size
        {
            get { return new Size(m_source.Width, m_source.Height); }
        }

        public Bitmap Bitmap
        {
            get { return m_image; }
        }
    }
}
