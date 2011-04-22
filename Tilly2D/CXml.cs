using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tilly2D
{
    class CXml
    {
        const string m_graphics_location = "Game/Graphics.xml";

        //To store all xml nodes for files, sprites and animation
        List<XmlNode> m_file_nodes = new List<XmlNode>();
        List<XmlNode> m_sprite_nodes = new List<XmlNode>();
        List<XmlNode> m_animation_nodes = new List<XmlNode>();

        public void ReadGraphics(Device dev, List<CSprite> sprite_list, System.Windows.Forms.TabControl tab)
        {
            //The documnet reader itself
            XmlDocument doc = new XmlDocument();
            doc.Load(m_graphics_location);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//FileList"); 
  
            //Get the file nodes
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode file in node)
                {
                    if (file.NodeType == XmlNodeType.Element && file.Name == "file")
                    {
                        m_file_nodes.Add(file);

                        TabPage tp = new TabPage();
                        tp.Name = file.InnerText;
                        tp.Text = file.InnerText;
                        tab.TabPages.Add(tp);
                    }
                }
            }

            //Get the sprite nodes
            nodes = root.SelectNodes("//SpriteList");
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode sprite in node)
                {
                    if (sprite.NodeType == XmlNodeType.Element && sprite.Name == "sprite")
                    {
                        m_sprite_nodes.Add(sprite);
                        foreach( XmlNode file in m_file_nodes )
                        {
                            if (file.Attributes["id"].Value == sprite.Attributes["file"].Value)
                            {
                                sprite_list.Add(new CSprite(dev, file, sprite));
                                CButton new_button = new CButton(sprite_list.Count - 1, sprite_list, tab.TabPages[file.InnerText]);
                                break;
                            }
                        }             
                    }
                }
            }

            //Get the animation nodes
            nodes = root.SelectNodes("//AnimationList");
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode anim in node)
                {
                    if (anim.NodeType == XmlNodeType.Element && anim.Name == "animation")
                    {
                        m_animation_nodes.Add(anim);
                    }
                }
            }
        }
    }
}
