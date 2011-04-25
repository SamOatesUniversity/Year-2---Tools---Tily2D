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

        public void saveMap(string location, List<List<CSprite>> m_tile, List<CSprite> m_sprite, int grid_size, CheckedListBox layers_checkbox)
        {
            XmlDocument doc = new XmlDocument();

            XmlNode GameElement = doc.CreateNode(XmlNodeType.Element, "Game", "");
            doc.AppendChild(GameElement);

            XmlAttribute GameAttribute = doc.CreateAttribute("name");
            GameAttribute.Value = "Gauntlet";
            GameElement.Attributes.Append(GameAttribute);

            XmlNode GameDataElement = doc.CreateNode(XmlNodeType.Element, "GameData", "");
            GameElement.AppendChild(GameDataElement);

            XmlNode ScrollArea = doc.CreateNode(XmlNodeType.Element, "scroll_area", "");
            XmlAttribute TripWndX = doc.CreateAttribute("TripWndX");
            TripWndX.Value = grid_size.ToString();
            XmlAttribute TripWndY = doc.CreateAttribute("TripWndY");
            TripWndY.Value = grid_size.ToString();

            ScrollArea.Attributes.Append(TripWndX);
            ScrollArea.Attributes.Append(TripWndY);
            GameDataElement.AppendChild(ScrollArea);

            XmlNode Level = doc.CreateNode(XmlNodeType.Element, "Level", "");
            GameElement.AppendChild(Level);

            XmlAttribute LevelId = doc.CreateAttribute("id");
            LevelId.Value = (1).ToString(); // level id
            Level.Attributes.Append(LevelId);

            XmlAttribute LevelName = doc.CreateAttribute("name");
            LevelName.Value = "level_name"; // level name
            Level.Attributes.Append(LevelName);

            XmlNode StartPosition = doc.CreateNode(XmlNodeType.Element, "startposition", "");
            Level.AppendChild(StartPosition);

            XmlAttribute StartPositionX = doc.CreateAttribute("x");
            StartPositionX.Value = (210).ToString(); // start x
            StartPosition.Attributes.Append(StartPositionX);

            XmlAttribute StartPositionY = doc.CreateAttribute("y");
            StartPositionY.Value = (210).ToString(); // start x
            StartPosition.Attributes.Append(StartPositionY);

            XmlNode MapList = doc.CreateNode(XmlNodeType.Element, "MapList", "");
            Level.AppendChild(MapList);

            int layerCount = 0;

            foreach (List<CSprite> layer in m_tile)
            {
                XmlNode Map = doc.CreateNode(XmlNodeType.Element, "map", "");
                MapList.AppendChild(Map);

                XmlAttribute MapName = doc.CreateAttribute("name");
                MapName.Value = layers_checkbox.Items[layerCount].ToString();
                Map.Attributes.Append(MapName);

                XmlAttribute MapLayer = doc.CreateAttribute("z_depth");
                MapLayer.Value = (layerCount + 1).ToString();
                Map.Attributes.Append(MapLayer);

                XmlAttribute MapWidth = doc.CreateAttribute("width");
                MapWidth.Value = grid_size.ToString();
                Map.Attributes.Append(MapWidth);

                XmlAttribute MapHeight = doc.CreateAttribute("height");
                MapHeight.Value = grid_size.ToString();
                Map.Attributes.Append(MapHeight);

                XmlAttribute MapXsz = doc.CreateAttribute("xsz");
                MapXsz.Value = "32";
                Map.Attributes.Append(MapXsz);

                XmlAttribute MapYsz = doc.CreateAttribute("ysz");
                MapYsz.Value = "32";
                Map.Attributes.Append(MapYsz);

                XmlAttribute DrawType = doc.CreateAttribute("drawtype");
                DrawType.Value = "2";
                Map.Attributes.Append(DrawType);

                foreach (CSprite sprite in layer)
                {
                    //<tile  sp="22" x="17" y="0" />
                    if (sprite.Id > 0)
                    {
                        XmlNode Tile = doc.CreateNode(XmlNodeType.Element, "tile", "");
                        Map.AppendChild(Tile);

                        XmlAttribute SpriteID = doc.CreateAttribute("sp");
                        SpriteID.Value = sprite.Id.ToString();
                        Tile.Attributes.Append(SpriteID);

                        XmlAttribute SpriteX = doc.CreateAttribute("x");
                        SpriteX.Value = sprite.Location.X.ToString();
                        Tile.Attributes.Append(SpriteX);

                        XmlAttribute SpriteY = doc.CreateAttribute("y");
                        SpriteY.Value = sprite.Location.Y.ToString();
                        Tile.Attributes.Append(SpriteY);
                    }
                }

                layerCount++;
            }

            doc.Save(location);
        }

        public void prepareMap(String file_location, ref int grid_size)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file_location);
            XmlElement root = doc.DocumentElement;

            XmlNode area = root.SelectSingleNode("//scroll_area");

            grid_size = Convert.ToInt32(area.Attributes["TripWndX"].Value);
        }

        public void LoadMap(String file_location, List<List<CSprite>> m_tile, List<CSprite> m_sprite, ref CheckedListBox layers_checkbox)
        {
            //resize, replace with new sprite.

            XmlDocument doc = new XmlDocument();
            doc.Load(file_location);
            XmlElement root = doc.DocumentElement;

            XmlNode level_node = root.SelectSingleNode("//Level");

            XmlNodeList map_list = root.SelectNodes("//map");

            foreach (XmlNode map in map_list)
            {
                int layer = Convert.ToInt32(map.Attributes["z_depth"].Value) - 1;
                layers_checkbox.Items[layer] = map.Attributes["name"].Value;
                foreach (XmlNode tile in map.ChildNodes)
                {
                    if (tile.Name == "tile")
                    {
                        int sprite_id = Convert.ToInt32( tile.Attributes["sp"].Value );
                        int sprite_x = Convert.ToInt32( tile.Attributes["x"].Value );
                        int sprite_y = Convert.ToInt32( tile.Attributes["y"].Value );
                        
                        foreach( CSprite sprite in m_sprite )
                        {
                            if( sprite.Id == sprite_id )
                            {
                                foreach (CSprite ctile in m_tile[layer])
                                {
                                    if (ctile.Location == new System.Drawing.Point(sprite_x, sprite_y))
                                    {
                                        ctile.Replace( sprite );
                                    }
                                }
                            }
                        }
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
