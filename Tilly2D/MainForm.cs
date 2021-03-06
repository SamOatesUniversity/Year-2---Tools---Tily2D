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
        private int m_max_layers = 10;

        private int m_start_x = 0;
        private int m_start_y = 0;

        private Device m_dev;
        private Sprite m_draw_sprite;
        private CSprite m_default_tile;
        private List<CSprite> m_sprite = new List<CSprite>();
        private List<List<CSprite>> m_tile = new List<List<CSprite>>();
        private List<CSprite> m_base_layer = new List<CSprite>();
        private CXml m_xml = new CXml();

        private List<int> m_layer_type = new List<int>();
        private List<String> m_layer_name = new List<string>();

        private bool m_first_click = false;
        private Point m_start_box_position, m_old_position;
        private List<CSprite> m_old_tiles = new List<CSprite>();

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

            m_xml.ReadGraphics(m_dev, m_sprite, tileTab);

            CreateNewMap(false);
        }

        void DeviceLost(object sender, EventArgs e)
        {
            
        }

        public void CreateManagedResources()
        {
            toolStripProgressBar.Value = 0;

            m_draw_sprite = new Sprite(m_dev);

            toolStripProgressBar.Value += 10;

            for (int i = 0; i < m_max_layers; i++)
            {
                m_layer_name.Add(layerCheckBox.Items[i].ToString());
                m_layer_type.Add(2);
                m_tile.Add(new List<CSprite>());
                toolStripProgressBar.Value += 1;
            }

            Texture default_tile = TextureLoader.FromFile(m_dev, "tile.bmp");
            Bitmap default_tile_bitmap = new Bitmap("tile.bmp");

            toolStripProgressBar.Value += 10;

            for (int y = 0; y < m_grid_size; y++)
            {
                for (int x = 0; x < m_grid_size; x++)
                {
                    CSprite new_tile = new CSprite(m_dev, default_tile, default_tile_bitmap);
                    new_tile.Location = new Point(x, y);
                    m_base_layer.Add(new_tile);
                }
            }
            toolStripProgressBar.Value += 15;

            for (int l = 0; l < m_max_layers; l++)
            {
                for (int y = 0; y < m_grid_size; y++)
                {
                    for (int x = 0; x < m_grid_size; x++)
                    {
                        CSprite new_tile = new CSprite();
                        new_tile.Location = new Point(x, y);
                        m_tile[l].Add(new_tile);
                    }
                }
                toolStripProgressBar.Value += 5;
            }

            m_default_tile = new CSprite();

            toolStripProgressBar.Value += 5;

            Tile.PictureBox.Image = m_default_tile.Bitmap;
        }

        private void DestoryManagedResources()
        {
            toolStripProgressBar.Value = 0;
            m_draw_sprite.Dispose();

            toolStripProgressBar.Value += 10;

            m_base_layer.Clear();

            for (int l = 1; l < m_max_layers; l++)
            {
                m_tile[l].Clear();
                toolStripProgressBar.Value += 5;
            }
            m_tile.Clear();

            toolStripProgressBar.Value += 30;

            GC.Collect();

            toolStripProgressBar.Value += 10;
        }

        void Draw()
        {
            if (m_tile.Count == 0) return;

            m_dev.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            m_dev.BeginScene();

            int tile_count_x = (int)(draw_panel.Width / m_tile_size) + 1;
            int tile_count_y = (int)(draw_panel.Height / m_tile_size) + 1;

            tile_count_x = tile_count_x > m_grid_size ? m_grid_size : tile_count_x;
            tile_count_y = tile_count_y > m_grid_size ? m_grid_size : tile_count_y;

            //draw base tiles
            int i = (m_start_y * m_grid_size) + m_start_x;
            for (int y = 0; y < tile_count_y; y++)
            {
                for (int x = 0; x < tile_count_x; x++)
                {
                    if (i < m_base_layer.Count)
                    {
                        m_base_layer[i].Draw(m_draw_sprite, m_tile_size);
                        i++;
                    }
                }
                i += m_grid_size - tile_count_x;
            }

            //draw users tiles
            for (int l = 0; l < m_max_layers; l++)
            {
                if (layerCheckBox.GetItemChecked(l))
                {
                    i = (m_start_y * m_grid_size) + m_start_x;
                    for (int y = 0; y < tile_count_y; y++)
                    {
                        for (int x = 0; x < tile_count_x; x++)
                        {
                            if (i < m_tile[l].Count)
                            {
                                m_tile[l][i].Draw(m_draw_sprite, m_tile_size);
                                i++;
                            }
                        }
                        i += m_grid_size - tile_count_x;
                    }
                }
            }

            m_dev.EndScene();
            m_dev.Present();
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Draw();

            string[] type = {"none", "pickup", "change", "power-up", "mob-generator", "replace", "exit", "teleport"};
            labelTileType.Text = "type : " + type[m_sprite[Tile.Active].Type];

            labelTileBlocking.Text = m_sprite[Tile.Active].Blocking ? "blocking : true" : "blocking : false";

            pictureBox_SelectedTile.Image = m_sprite[Tile.Active].Bitmap;
        }

        private void Vertical_Scroll(object sender, ScrollEventArgs e)
        {
            int change = e.NewValue - e.OldValue;

            if (change != 0)
            {
                for (int l = 0; l < m_max_layers; l++)
                {
                    int i = 0;
                    for (int y = 0; y < m_grid_size; y++)
                    {
                        for (int x = 0; x < m_grid_size; x++)
                        {
                            m_tile[l][i].Location = new Point(m_tile[l][i].Location.X, m_tile[l][i].Location.Y - change);
                            i++;
                        }
                    }
                }
                int c = 0;
                for (int y = 0; y < m_grid_size; y++)
                {
                    for (int x = 0; x < m_grid_size; x++)
                    {
                        m_base_layer[c].Location = new Point(m_base_layer[c].Location.X, m_base_layer[c].Location.Y - change);
                        c++;
                    }
                }
            }

            m_start_y += change;
        }

        private void Horizontal_Scroll(object sender, ScrollEventArgs e)
        {
            int change = e.NewValue - e.OldValue;

            if (change != 0)
            {
                for (int l = 0; l < m_max_layers; l++)
                {
                    int i = 0;
                    for (int y = 0; y < m_grid_size; y++)
                    {
                        for (int x = 0; x < m_grid_size; x++)
                        {
                            m_tile[l][i].Location = new Point(m_tile[l][i].Location.X - change, m_tile[l][i].Location.Y);
                            i++;
                        }
                    }
                }
                int c = 0;
                for (int y = 0; y < m_grid_size; y++)
                {
                    for (int x = 0; x < m_grid_size; x++)
                    {
                        m_base_layer[c].Location = new Point(m_base_layer[c].Location.X - change, m_base_layer[c].Location.Y);
                        c++;
                    }
                }
                m_start_x += change;
            }
        }

        private void UpdateTile(int x, int y, bool left_click)
        {
            int tile_x = (x / m_tile_size) + m_start_x;
            int tile_y = (y / m_tile_size) + m_start_y;
            int tile_id = (tile_y * m_grid_size) + tile_x;

            if (tile_id < m_tile[Tile.ActiveLayer].Count &&
                tile_id >= 0 &&
                layerCheckBox.GetItemChecked(Tile.ActiveLayer)
                && tile_x >= 0 && tile_y >= 0)
            {
                if (left_click)
                    m_tile[Tile.ActiveLayer][tile_id].Replace(m_sprite[Tile.Active]);
                else
                    m_tile[Tile.ActiveLayer][tile_id].Replace(m_default_tile);
            }
        }

        private void OnPanelClick(object sender, MouseEventArgs e)
        {
            if (pointToolStripButton.Checked)
            {
                UpdateTile(e.X, e.Y, e.Button == System.Windows.Forms.MouseButtons.Left);
            }
            else //box mode drawing
            {
                m_first_click = !m_first_click;
                if (m_first_click)
                {
                    m_start_box_position = new Point(e.X, e.Y);
                    m_old_position = m_start_box_position;
                    m_old_tiles.Clear();
                }
            }
        }

        private void OnPanelDrag(object sender, MouseEventArgs e)
        {
            if (pointToolStripButton.Checked)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    UpdateTile(e.X, e.Y, true);
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    UpdateTile(e.X, e.Y, false);
                }
            }
            else
            {
                if (m_first_click && e.Button != System.Windows.Forms.MouseButtons.None)
                {
                    Point end_position = new Point(e.X, e.Y);

                    int min_x = Math.Min(m_start_box_position.X, m_old_position.X);
                    int min_y = Math.Min(m_start_box_position.Y, m_old_position.Y);
                    int max_x = Math.Max(m_start_box_position.X, m_old_position.X);
                    int max_y = Math.Max(m_start_box_position.Y, m_old_position.Y);

                    int start_tile_x = (min_x / m_tile_size) + m_start_x;
                    int start_tile_y = (min_y / m_tile_size) + m_start_y;
                    int end_tile_x = (max_x / m_tile_size) + m_start_x;
                    int end_tile_y = (max_y / m_tile_size) + m_start_y;

                    for (int y = start_tile_y; y <= end_tile_y; y++)
                    {
                        for (int x = start_tile_x; x <= end_tile_x; x++)
                        {
                            foreach (CSprite tile in m_old_tiles)
                            {
                                if (tile.Location == new Point(x, y))
                                {
                                    int tile_id = (y * m_grid_size) + x;
                                    m_tile[Tile.ActiveLayer][tile_id].Replace(m_default_tile);
                                }
                            }
                        }
                    }

                    m_old_tiles.Clear();

                    min_x = Math.Min( m_start_box_position.X, end_position.X );
                    min_y = Math.Min(m_start_box_position.Y, end_position.Y);
                    max_x = Math.Max(m_start_box_position.X, end_position.X);
                    max_y = Math.Max(m_start_box_position.Y, end_position.Y);

                    start_tile_x = (min_x / m_tile_size) + m_start_x;
                    start_tile_y = (min_y / m_tile_size) + m_start_y;
                    end_tile_x = (max_x / m_tile_size) + m_start_x;
                    end_tile_y = (max_y / m_tile_size) + m_start_y;

                    for (int y = start_tile_y; y <= end_tile_y; y++)
                    {
                        for (int x = start_tile_x; x <= end_tile_x; x++)
                        {
                            int tile_id = (y * m_grid_size) + x;
                            m_old_tiles.Add(m_tile[Tile.ActiveLayer][tile_id]);
                            m_tile[Tile.ActiveLayer][tile_id].Replace(m_sprite[Tile.Active]);
                        }
                    }

                    m_old_position = end_position;
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.None && m_first_click)
                {
                    m_first_click = false; 
                    Point end_position = new Point(e.X, e.Y);
                }
            }

            int tile_x1 = (e.X / m_tile_size) + m_start_x;
            int tile_y1 = (e.Y / m_tile_size) + m_start_y;
            int tile_id1 = (tile_y1 * m_grid_size) + tile_x1;
            if (tile_id1 >= 0 && tile_id1 < m_tile[Tile.ActiveLayer].Count && tile_x1 >= 0)
            {
                toolStripStatusLabel_TileCoord.Text = "Tile[" + tile_id1 + "] : " + tile_x1 + ", " + tile_y1;
                UpdateTileDetails(tile_x1, tile_y1, tile_id1);
            }
        }

        private void UpdateTileDetails(int x, int y, int id)
        {
            Tile.PictureBox.Image = m_tile[Tile.ActiveLayer][id].Bitmap;
            label_tile_details_id.Text = "id : " + id;
            label_tile_details_position.Text = "position : " + x + " , " + y;

            String tab = "--";
            if( m_tile[Tile.ActiveLayer][id].FileName != null )
                tab = m_tile[Tile.ActiveLayer][id].FileName.Substring(0, m_tile[Tile.ActiveLayer][id].FileName.LastIndexOf(".") > 0 ? m_tile[Tile.ActiveLayer][id].FileName.LastIndexOf(".") : m_tile[Tile.ActiveLayer][id].FileName.Length);

            label_tile_details_tab.Text = "tab : " + tab;

            string[] type = { "none", "pickup", "change", "power-up", "mob-generator", "replace", "exit", "teleport" };
            labelTileDetailsType.Text = "type : " + type[m_tile[Tile.ActiveLayer][id].Type];

            labelTileDetailsBlocking.Text = m_tile[Tile.ActiveLayer][id].Blocking ? "blocking : true" : "blocking : false";
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

        private void LayerChange(object sender, EventArgs e)
        {
            int selected = ((CheckedListBox)sender).SelectedIndex;
            Tile.ActiveLayer = selected;

            layerCheckBox.SetItemChecked(selected, !layerCheckBox.GetItemChecked(selected));
            textBoxLayerName.Text = layerCheckBox.Items[selected].ToString();
            
 
            if (m_layer_type.Count > 0)
                comboBoxLayerType.SelectedIndex = m_layer_type[selected];
        }

        private void CreateNewMap(bool destroy)
        {
            NewMapForm form = new NewMapForm();
            form.ShowDialog();

            if (form.CreateNewMap || !destroy)
            {
                m_grid_size = form.MapSize;
                if (destroy) DestoryManagedResources();
                CreateManagedResources();

                layerCheckBox.SelectedIndex = 0;
                Tile.ActiveLayer = 0;
            }
        }

        private void NewMap(object sender, EventArgs e)
        {
            CreateNewMap(true);
        }

        private void OnClickHealth(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://samoatesgames.com/project-uni-ATD.html"); 
        }

        private void OnOpenMap(object sender, EventArgs e)
        {
            if (OpenMapFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_xml.prepareMap(OpenMapFileDialog.FileName, ref m_grid_size);
                DestoryManagedResources();
                CreateManagedResources();
                m_xml.LoadMap(OpenMapFileDialog.FileName, m_tile, m_sprite, ref layerCheckBox, ref m_layer_type);
                textBoxLayerName.Text = layerCheckBox.SelectedItem.ToString();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveMapFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_xml.saveMap(saveMapFileDialog.FileName, m_tile, m_sprite, m_grid_size, layerCheckBox, m_layer_type);
            }
        }

        private void Layer_Name_Changed(object sender, EventArgs e)
        {
            layerCheckBox.Items[layerCheckBox.SelectedIndex] = textBoxLayerName.Text;
        }

        private void OnDrawLayerTypeChanged(object sender, EventArgs e)
        {
            m_layer_type[Tile.ActiveLayer] = comboBoxLayerType.SelectedIndex;
        }

        private void launchGameToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveMapFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_xml.saveMap(saveMapFileDialog.FileName, m_tile, m_sprite, m_grid_size, layerCheckBox, m_layer_type);

                System.Diagnostics.ProcessStartInfo GameProcessInfo = new System.Diagnostics.ProcessStartInfo("GGame.exe");
                GameProcessInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory() + "\\Game\\";
                System.Diagnostics.Process GameProcess = System.Diagnostics.Process.Start(GameProcessInfo);
            }
        }

        private void DrawModeChange_Click(object sender, EventArgs e)
        {
            if (((ToolStripButton)sender).Checked == false)
            {
                pointToolStripButton.Checked = false;
                boxToolStripButton.Checked = false;
                ((ToolStripButton)sender).Checked = true;
            }
        }
    }
}
