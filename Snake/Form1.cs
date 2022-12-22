using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        bool Snake_Right = true;
        bool Snake_Left = false;
        bool Snake_Up = false;
        bool Snake_Down = false;

        bool Snake_Head_Right = true;
        bool Snake_Head_Left = false;
        bool Snake_Head_Up = false;
        bool Snake_Head_Down = false;

        PictureBox[] Snake_Array = new PictureBox[1];
        PictureBox Bait = new PictureBox();

        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();

            var p = new PictureBox();
            Snake_Array[0] = p;
            p.Name = "Snake_pictureBox" + 0;
            p.BackColor = Color.Green;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Size = new Size(50, 50);
            p.Location = new Point(350, 150);
            p.Visible = true;
            this.Main_panel1.Controls.Add(p);


            int random_x = rnd.Next(0, 20);
            int random_y = rnd.Next(0, 10);

            Bait.Name = "Bait_pictureBox1";
            Bait.BackColor = Color.Red;

            Bait.Size = new Size(50, 50);
            Bait.Location = new Point(random_x * 50, random_y * 50);
            Bait.Visible = true;
            this.Main_panel1.Controls.Add(Bait);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && !Snake_Left && !Snake_Head_Left)
            {
                Snake_Left = false;
                Snake_Up = false;
                Snake_Down = false;
                Snake_Right = true;
            }
            else if (e.KeyCode == Keys.Left && !Snake_Right && !Snake_Head_Right)
            {
                Snake_Right = false;
                Snake_Up = false;
                Snake_Down = false;
                Snake_Left = true;
            }
            else if (e.KeyCode == Keys.Up && !Snake_Down && !Snake_Head_Down)
            {
                Snake_Left = false;
                Snake_Down = false;
                Snake_Right = false;
                Snake_Up = true;
            }
            else if (e.KeyCode == Keys.Down && !Snake_Up && !Snake_Head_Up)
            {
                Snake_Left = false;
                Snake_Up = false;
                Snake_Right = false;
                Snake_Down = true;
            }
        }

        private void Snake_timer1_Tick(object sender, EventArgs e)
        {
            int Snake_old_x_location = Snake_Array[0].Location.X;
            int Snake_old_y_location = Snake_Array[0].Location.Y;

            if (Snake_Right)
            {
                Snake_Head_Left = false;
                Snake_Head_Up = false;
                Snake_Head_Down = false;
                Snake_Head_Right = true;

                Snake_Array[0].Left = Snake_Array[0].Left + 50;
                if (Snake_Array[0].Left == 1000)
                {
                    Snake_Array[0].Left = 0;
                }
            }
            else if (Snake_Left)
            {
                Snake_Head_Up = false;
                Snake_Head_Down = false;
                Snake_Head_Right = false;
                Snake_Head_Left = true;

                Snake_Array[0].Left = Snake_Array[0].Left - 50;
                if (Snake_Array[0].Left == -50)
                {
                    Snake_Array[0].Left = 950;
                }
            }
            else if (Snake_Up)
            {
                Snake_Head_Left = false;
                Snake_Head_Down = false;
                Snake_Head_Right = false;
                Snake_Head_Up = true;

                Snake_Array[0].Top = Snake_Array[0].Top - 50;
                if (Snake_Array[0].Top == -50)
                {
                    Snake_Array[0].Top = 450;
                }
            }
            else if (Snake_Down)
            {
                Snake_Head_Left = false;
                Snake_Head_Right = false;
                Snake_Head_Up = false;
                Snake_Head_Down = true;

                Snake_Array[0].Top = Snake_Array[0].Top + 50;

                if (Snake_Array[0].Top == 500)
                {
                    Snake_Array[0].Top = 0;
                }
            }

            if (Snake_Array.Length > 1)
            {
                for (int i = 1; i < Snake_Array.Length; i++)
                {
                    int new_location_x = Snake_old_x_location;
                    int new_location_y = Snake_old_y_location;
                    Snake_old_x_location = Snake_Array[i].Location.X;
                    Snake_old_y_location = Snake_Array[i].Location.Y;
                    Snake_Array[i].Location = new Point(new_location_x, new_location_y);
                }
            }
            if (Snake_Array[0].Bounds.IntersectsWith(Bait.Bounds))
            {
                Snake_Array = ArraySizeIncreaseWithSameValues(Snake_Array);

                var p = new PictureBox();
                Snake_Array[Snake_Array.Length - 1] = p;
                p.Name = "Snake_pictureBox" + (Snake_Array.Length - 1);
                p.BackColor = Color.White;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Size = new Size(50, 50);
                p.Location = new Point(Bait.Location.X, Bait.Location.Y);
                p.Visible = true;
                this.Main_panel1.Controls.Add(p);

                change_Location_of_Bait();

            }

        }

        public void change_Location_of_Bait()
        {
            int[] x_locations = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            int[] y_locations = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] x_y_locations = new string[200];

            int k = 0;

            for (int i = 0; i < x_locations.Length; i++)
            {
                for (int j = 0; j < y_locations.Length; j++)
                {
                    x_y_locations[k] = x_locations[i] + "-" + y_locations[j];
                    k++;
                }
            }

            for (int i = 0; i <Snake_Array.Length; i++)
            {
                if (x_y_locations.Contains((Snake_Array[i].Location.X / 50)+"-"+ (Snake_Array[i].Location.Y / 50)))
                {
                    x_y_locations = x_y_locations.Except(new string[] { (Snake_Array[i].Location.X / 50) + "-" + (Snake_Array[i].Location.Y / 50) }).ToArray();
                }
            }
            int random_x_y = rnd.Next(0, x_y_locations.Length);

            if (x_y_locations.Length !=0)
            {
                string[] random_x_y_array = x_y_locations[random_x_y].Split('-');

                Bait.Location = new Point(Convert.ToInt32(random_x_y_array[0])*50, Convert.ToInt32(random_x_y_array[1]) * 50);
            }
            else
            {
                Snake_timer1.Enabled = false;
                MessageBox.Show("Tebrikler..!");
            }

        }

        public PictureBox[] ArraySizeIncreaseWithSameValues(PictureBox[] array)
        {
            PictureBox[] newarray = new PictureBox[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newarray[i] = array[i];
            }
            return newarray;
        }
    }
}
