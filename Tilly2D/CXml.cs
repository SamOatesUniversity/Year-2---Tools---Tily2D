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

        List<CButtonContainer> m_button_list = new List<CButtonContainer>();

        public void LoadMap(String file_location, List<List<CSprite>> m_tile, List<CSprite> m_sprite)
        {
            foreach( List<CSprite> tile in m_tile )
            {
                tile.Clear();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(file_location);
            XmlElement root = doc.DocumentElement;

            XmlNode level_node = root.SelectSingleNode("//Level");

            XmlNodeList map_list = root.SelectNodes("//map");

            foreach (XmlNode map in map_list)
            {
                int layer = Convert.ToInt32(map.Attributes["z_depth"].Value) - 1;
                foreach (XmlNode tile in map.ChildNodes)
                {
                    if (tile.Name == "tile")
                    {
                        int sprite_id = Convert.ToInt32( tile.Attributes["sp"].Value );
                        int sprite_x = Convert.ToInt32( tile.Attributes["x"].Value );
                        int sprite_y = Convert.ToInt32( tile.Attributes["y"].Value );

                        CSprite new_tile = new CSprite();
                        foreach (CSprite sp in m_sprite)
                        {
                            if (sp.Id == sprite_id)
                            {
                                new_tile = sp;
                                new_tile.Location = new System.Drawing.Point(sprite_x, sprite_y);
                            }
                        }

                        m_tile[layer].Add(new_tile);
                    }
                }
            }

        }

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

                        String tab_title = file.InnerText;
                        tab_title = tab_title.Substring(0, tab_title.LastIndexOf("."));

                        TabPage tp = new TabPage();
                        tp.Name = file.InnerText;
                        tp.Text = tab_title;
                        tab.TabPages.Add(tp);
                        m_button_list.Add(new CButtonContainer());
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
                                CSprite new_sprite = new CSprite(dev, file, sprite);
                                bool is_new_sprite = true;
                                foreach (CSprite sp in sprite_list)
                                    if (sp.isEqual(new_sprite)) is_new_sprite = false;

                                if (is_new_sprite)
                                {
                                    sprite_list.Add(new_sprite);
                                    CButton new_button = new CButton(sprite_list.Count - 1, sprite_list);
                                    int tab_id = 0;
                                    while (tab.TabPages[file.InnerText] != tab.TabPages[tab_id])
                                        tab_id++;
                                    m_button_list[tab_id].Add(new_button, tab.TabPages[tab_id]);
                                    break;
                                }
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
