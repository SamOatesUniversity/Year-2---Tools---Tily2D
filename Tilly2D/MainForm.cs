﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Tilly2D
{
    public partial class MainForm : Form
    {
        private int m_tile_size = 32;
        private int m_grid_size = 64;

        private int start_x = 0;
        private int start_y = 0;

        private Device m_dev;
        private Sprite m_draw_sprite;
        private CSprite m_default_tile;
        private List<CSprite> m_sprite = new List<CSprite>();
        private List<CSprite> m_tile = new List<CSprite>();
        private CXml m_xml = new CXml();

        public MainForm()
        {
            InitializeComponent();
            for( int i = 0; i < 10; i++ )
                this.layerCheckBox.SetItemChecked(i, true);
            this.layerCheckBox.SetSelected(0, true);

            Tile.PictureBox = pictureBox_TileDetails;
        }

        public void InitializeDevice()
        {
            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;

            m_dev = new Device(0, DeviceType.Hardware, this.draw_panel, CreateFlags.SoftwareVertexProcessing, pp);
            m_dev.DeviceLost += new EventHandler(DeviceLost);
 
        }

        void DeviceLost(object sender, EventArgs e)
        {

        }

        public void CreateManagedResources()
        {
            m_xml.ReadGraphics(m_dev, m_sprite, tileTab);

            m_draw_sprite = new Sprite(m_dev);

            Texture default_tile = TextureLoader.FromFile(m_dev, "tile.bmp");
            Bitmap default_tile_bitmap = new Bitmap("tile.bmp");
            for (int y = 0; y < m_grid_size; y++)
            {
                for (int x = 0; x < m_grid_size; x++)
                {
                    CSprite new_tile = new CSprite(m_dev, default_tile, default_tile_bitmap);
                    new_tile.Location = new Point(x, y);
                    m_tile.Add(new_tile);
                }
            }

            m_default_tile = new CSprite(m_dev, default_tile, default_tile_bitmap);

            Tile.PictureBox.Image = m_default_tile.Bitmap;
        }

        void Draw()
        {
            m_dev.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            m_dev.BeginScene();

            int tile_count_x = (int)(draw_panel.Width / m_tile_size) + 1;
            int tile_count_y = (int)(draw_panel.Height / m_tile_size) + 1;

            tile_count_x = tile_count_x > m_grid_size ? m_grid_size : tile_count_x;
            tile_count_y = tile_count_y > m_grid_size ? m_grid_size : tile_count_y;

            int i = (start_y * m_grid_size) + start_x;
            for (int y = 0; y < tile_count_y; y++)
            {
                for (int x = 0; x < tile_count_x; x++)
                {
                    if (i < m_tile.Count)
                    {
                        m_tile[i].Draw(m_draw_sprite, m_tile_size);
                        i++;
                    }
                }
                i += m_grid_size - tile_count_x;
            }

            m_dev.EndScene();
            m_dev.Present();
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void Vertical_Scroll(object sender, ScrollEventArgs e)
        {
            int change = e.NewValue - e.OldValue;

            int i = 0;
            for (int y = 0; y < m_grid_size; y++)
            {
                for (int x = 0; x < m_grid_size; x++)
                {
                    m_tile[i].Location = new Point(m_tile[i].Location.X, m_tile[i].Location.Y - change);
                    i++;
                }
            }

            start_y += change;
        }

        private void Horizontal_Scroll(object sender, ScrollEventArgs e)
        {
            int change = e.NewValue - e.OldValue;

            if (change != 0)
            {
                int i = 0;
                for (int y = 0; y < m_grid_size; y++)
                {
                    for (int x = 0; x < m_grid_size; x++)
                    {
                        m_tile[i].Location = new Point(m_tile[i].Location.X - change, m_tile[i].Location.Y);
                        i++;
                    }
                }

                start_x += change;
            }
        }

        private void UpdateTile(int x, int y, bool left_click)
        {
            int tile_x = (x / m_tile_size) + start_x;
            int tile_y = (y / m_tile_size) + start_y;
            int tile_id = (tile_y * m_grid_size) + tile_x;

            if (tile_id < m_tile.Count && tile_id >= 0)
            {
                if (left_click)
                    m_tile[tile_id].Replace(m_sprite[Tile.Active]);
                else
                    m_tile[tile_id].Replace(m_default_tile);
            }
        }

        private void OnPanelClick(object sender, MouseEventArgs e)
        {
            UpdateTile(e.X, e.Y, e.Button == System.Windows.Forms.MouseButtons.Left);
        }

        private void OnPanelDrag(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                UpdateTile(e.X, e.Y, true);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                UpdateTile(e.X, e.Y, false);
            }

            int tile_x = (e.X / m_tile_size) + start_x;
            int tile_y = (e.Y / m_tile_size) + start_y;
            int tile_id = (tile_y * m_grid_size) + tile_x;
            if (tile_id >= 0 && tile_id < m_tile.Count)
            {
                toolStripStatusLabel_TileCoord.Text = "Tile[" + tile_id + "] : " + tile_x + ", " + tile_y;
                UpdateTileDetails(tile_x, tile_y, tile_id);
            }

        }

        private void UpdateTileDetails(int x, int y, int id)
        {
            Tile.PictureBox.Image = m_tile[id].Bitmap;
            label_tile_details_id.Text = "id : " + id;
            label_tile_details_position.Text = "position : " + x + " , " + y;
            label_tile_details_tab.Text = "tab : " + (m_tile[id].FileName.Substring(0, m_tile[id].FileName.LastIndexOf(".") > 0 ? m_tile[id].FileName.LastIndexOf(".") : m_tile[id].FileName.Length));
        }

        private void OnResize(object sender, EventArgs e)
        {
            //change scroll bars
        }

        private void Zoom(object sender, EventArgs e)
        {
            m_tile_size = zoomBar.Value * 8;

            toolStripStatusLabel_Zoom.Text = "          Zoom : x" + (m_tile_size / 32.0f);

        }    
    }
}
