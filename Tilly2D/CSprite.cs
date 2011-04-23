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
        private XmlNode m_sprite_node;

        public CSprite()
        {
            m_file_name = null;
            m_sprite_node = null;

            m_file_texture = null;
            m_file = -1;

            m_source = new Rectangle(0, 0, 32, 32);
            m_id = -1;

            m_location = new Point();

            m_image = null;
        }

        public CSprite( Device dev, XmlNode file, XmlNode sprite )
        {
            m_file_name = file.InnerText;
            m_sprite_node = sprite;

            m_file_texture = TextureLoader.FromFile(dev, "Game\\" + m_file_name);
            m_file = Convert.ToInt32(file.Attributes["id"].Value);

            m_source = new Rectangle(Convert.ToInt32(sprite.Attributes["x"].Value), 
                                     Convert.ToInt32(sprite.Attributes["y"].Value), 
                                     Convert.ToInt32(sprite.Attributes["w"].Value),
                                     Convert.ToInt32(sprite.Attributes["h"].Value));
            m_id = Convert.ToInt32(sprite.Attributes["id"].Value);

            m_location = new Point();

            Rectangle destRect = new Rectangle(0, 0, 32, 32);  
            m_image = new System.Drawing.Bitmap(32, 32);
            Bitmap full_image = new Bitmap("Game\\" + m_file_name);
            Graphics gfx = Graphics.FromImage(m_image);
            gfx.DrawImage(full_image, destRect, m_source, GraphicsUnit.Pixel);

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

            Rectangle destRect = new Rectangle(0, 0, 32, 32);
            m_image = new System.Drawing.Bitmap(32, 32);
            Bitmap full_image = new Bitmap(m_file_name);
            Graphics gfx = Graphics.FromImage(m_image);
            gfx.DrawImage(full_image, destRect, m_source, GraphicsUnit.Pixel);
        }

        public CSprite(Device dev, Texture texture, Bitmap bitmap)
        {
            m_file_name = "--";

            m_image = bitmap;

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
            if (m_file_texture != null)
            {
                sprite.Begin(SpriteFlags.AlphaBlend);
                sprite.Draw2D(m_file_texture, m_source, new Rectangle(0, 0, grid_size, grid_size), new Point((int)((float)m_location.X * ((float)grid_size / ((float)grid_size / (float)m_source.Width))),
                                                                                                              (int)(float)(m_location.Y * ((float)grid_size / ((float)grid_size / (float)m_source.Height)))), Color.White);
                sprite.End();
            }
        }

        public void Release()
        {
            m_file_texture.Dispose();
        }

        public void Replace(CSprite sprite)
        {
            m_file_texture = sprite.Texture;
            m_source = sprite.Source;
            m_image = sprite.Bitmap;
            m_file_name = sprite.FileName;
        }

        public Rectangle Source
        {
            get { return m_source; }
        }

        public Texture Texture
        {
            get { return m_file_texture; }
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

        public bool isEqual(CSprite against)
        {
            if (m_source == against.Source &&
                m_file == against.FileId)
                return true;

            return false;
        }
    }
}
