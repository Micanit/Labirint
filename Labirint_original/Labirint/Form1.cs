using System;
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
        int min;
        int sec;
        int ms;
        static Random rnd = new Random();
        static int random = rnd.Next(0, 11);
        static int random_1 = rnd.Next(2, 8);
        const int mapSize = 20;
        const int cellSize = 35;
        int[,] map = new int[mapSize, mapSize];
        //
       
        public Form1()
        {
            this.Text = "Labirintik";
            InitializeComponent();           
            Init();

            timer1.Interval = 500;
            min = 0;
            sec = 0;
            ms = 0;

            label2.Text = "00";
            label3.Visible = true;
            label2.Text = "00";

        }

        public void Init()
        {
            /* map = new int[mapSize, mapSize] {
                 { 0,0,0,0,2,0,0,0,0,0,0},
                 { 0,1,1,0,1,0,1,1,1,0,0},
                 { 0,0,1,0,1,0,1,0,1,0,0},
                 { 0,1,1,1,1,1,0,0,1,0,0},
                 { 0,1,0,0,0,1,1,1,1,0,0},
                 { 0,1,0,0,0,0,0,0,0,0,0},
                 { 0,1,1,1,1,1,1,1,1,0,0},
                 { 0,0,0,0,0,0,0,0,1,0,0},
                 { 0,0,0,0,0,1,1,1,1,0,0},
                 { 0,0,0,0,0,3,0,0,0,0,0},
                 { 0,0,0,0,0,3,0,0,0,0,0},
                 { 0,0,0,0,0,3,0,0,0,0,0},
             };*/
            CreateLabirint();
            CreateMap();
            
        }
        public void CreateLabirint()
        {
            Random random1 = new Random();
            int chanse = 35;
            int start_sprite_index = 2;
            int end_sprite_index = 3;
            int y = 1;
            int x = 1;
            int current_index = map[x, y];
            int road_sprite_index = 1;
            
            map[x,y] = start_sprite_index;

            //MessageBox.Show("ИЗНАЧАЛЬНЫЙ Y: " + y.ToString() + " ИЗНАЧАЛЬНЫЙ X: " + x.ToString());
            while (x != mapSize-2)
            {
                if (random1.Next(0, 101) <= chanse)
                {
                    if (random1.Next(0, 101) <= chanse)
                    {
                        if (map[x + 1, y] == 0 && map[x + 1, y + 1] == 0 && map[x + 1, y - 1] == 0 )
                        {
                            x++;
                            if (x<1 || x>mapSize-2)
                            {
                                x--;
                            }
                            map[x, y] = road_sprite_index;


                        }
                        else
                        {
                            if (map[x - 1, y] == 0 && map[x - 1, y + 1] == 0 && map[x - 1, y - 1] == 0)
                            {
                                x--;
                                if (x < 1 || x > mapSize - 2)
                                {
                                    x++;
                                }
                                map[x, y] = road_sprite_index;
                            }
                        }
                    }
                    else
                    {

                        if (random1.Next(0, 101) >= chanse)
                        {
                            if (map[x, y + 1] == 0 && map[x + 1, y + 1] == 0 && map[x - 1, y + 1] == 0)
                            {
                                y++;
                                if (y<1 || y > mapSize-2)
                                {
                                    y--;
                                }
                                map[x, y] = road_sprite_index;
                            }
                        }
                        else
                        {
                            if (map[x, y - 1] == 0 && map[x + 1, y - 1] == 0 && map[x - 1, y - 1] == 0)
                            {
                                y--;
                                if (y < 1 || y > mapSize - 2)
                                {
                                    y++;
                                }
                                map[x, y] = road_sprite_index;
                            }
                        }
                    }
                }
                //MessageBox.Show("Y: " + y.ToString() + "  X: " + x.ToString());
            }
            map[x, y] = end_sprite_index;
           
            //MessageBox.Show("Y: " + y.ToString() + "  X: " + x.ToString());
            
            
            
        }
        public void CreateMap()
        {
            Random rnd_grass = new Random();

            random = rnd.Next(2, 8);
            random_1 = rnd.Next(2, 8);

            this.Width = (mapSize* cellSize) +15;
            this.Height = (mapSize* cellSize) + 39;
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
                    
                    //map[0, rnd.Next(0, mapSize)] = this.Controls.Add(start_grass);

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
            Cursor.Position = new Point(this.Location.X + cellSize*4 / 2, this.Location.Y+ cellSize*4 / 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
                button1.Enabled = true;
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
                button2.Enabled = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            min = 0;
            sec = 0;
            ms = 0;
            label2.Text = "00";
            label4.Text = "00";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(label3.Visible)
            {
                if(sec<59)
                {
                    sec++;
                    if (sec < 10)
                        label4.Text = "0" + sec.ToString();
                    else
                        label4.Text = sec.ToString();
                }
                else
                {
                    if(min<59)
                    {
                        min++;
                        if(min<10)
                            label2.Text = "0" + min.ToString();
                        else
                            label2.Text = min.ToString();

                        sec = 0;
                        label4.Text = "00";
                    }
                    else
                    {
                        min = 0;
                        label2.Text = "00";                 
                    }
                    
                }
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
