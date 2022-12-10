﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint
{
    public partial class Form1 : Form
    {
               
        static Random rnd = new Random();
        static int random = rnd.Next(2, 8);
        static int random_1 = rnd.Next(2, 8);
        const int mapSize = 10;
        const int cellSize = 50;
        int[,] map = new int[mapSize, mapSize];
        public Form1()
        {
            this.Text = "Labirintik";
            InitializeComponent();           
            Init();
        }

        public void Init()
        {
            map = new int[mapSize, mapSize] {
                { 0,0,0,0,2,0,0,0,0,0},
                { 0,1,1,0,1,0,1,1,1,0},
                { 0,0,1,0,1,0,1,0,1,0},
                { 0,1,1,1,1,1,0,0,1,0},
                { 0,1,0,0,0,1,1,1,1,0},
                { 0,1,0,0,0,0,0,0,0,0},
                { 0,1,1,1,1,1,1,1,1,0},
                { 0,0,0,0,0,0,0,0,1,0},
                { 0,0,0,0,0,1,1,1,1,0},
                { 0,0,0,0,0,3,0,0,0,0},
            };
            CreateMap();
            
        }
        
        public void CreateMap()
        {
            Random rnd_grass = new Random();

            random = rnd.Next(2, 8);
            random_1 = rnd.Next(2, 8);

            this.Width = (mapSize* cellSize) +15;
            this.Height = (mapSize* cellSize) + 15;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    PictureBox field = new PictureBox();
                    field.Image = Properties.Resources.Wall1;
                    field.SizeMode = PictureBoxSizeMode.StretchImage;
                    field.Size= new Size(cellSize, cellSize);
                    field.Location = new Point(i*cellSize, j*cellSize);


                    PictureBox start_grass = new PictureBox();
                    start_grass.Image = Properties.Resources.start_grass;
                    start_grass.SizeMode = PictureBoxSizeMode.StretchImage;
                    start_grass.Size = new Size(cellSize, cellSize);
                    start_grass.Location = new Point(i * cellSize, j * cellSize);

                    PictureBox grass = new PictureBox();
                    grass.Image = Properties.Resources.grass;  
                    grass.SizeMode = PictureBoxSizeMode.StretchImage;
                    grass.Size = new Size(cellSize, cellSize);
                    grass.Location = new Point(i * cellSize, j * cellSize);


                    PictureBox win_grass = new PictureBox();
                    win_grass.Image = Properties.Resources.win_grass;
                    win_grass.SizeMode = PictureBoxSizeMode.StretchImage;
                    win_grass.Size = new Size(cellSize, cellSize);
                    win_grass.Location = new Point(i * cellSize, j * cellSize);
                    win_grass.MouseEnter += Win_grass_MouseEnter;
                    /*
                    if (i == 0 && j== random)
                    {
                        this.Controls.Add(start_grass);
                    }
                    if (i == 9 && j == random_1)
                    {
                        this.Controls.Add(win_grass);
                    }
                    this.Controls.Add(field); */
                    if (map[i, j] == 3)
                    {
                        this.Controls.Add(win_grass);
                    }
                    if (map[i, j] == 2)
                    {
                        this.Controls.Add(start_grass);
                    }
                    if (map[i, j] == 1)
                    {
                        this.Controls.Add(grass);
                    }
                    if (map[i,j]==0)
                    {
                        this.Controls.Add(field);
                    }
                   
                }
            }
        }

        private void Win_grass_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Победа!!!", "Ура!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
        public void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X+ cellSize/2, this.Location.Y+((random * cellSize )+50));
        }
        */
        public void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X + cellSize / 2, this.Location.Y+250);
        }

    }
}