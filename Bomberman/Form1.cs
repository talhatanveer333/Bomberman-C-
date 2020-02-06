


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bomberman
{
    public partial class Form1 : Form
    {
        //variables
        char move;
        int b_x = 0;
        int b_y = 0;
        static int num_of_enemies = 200;
        PictureBox[] boundry = new PictureBox[93];
        PictureBox[] stage = new PictureBox[40];
        PictureBox[] bomb = new PictureBox[100];
        PictureBox[] enemy_pic = new PictureBox[num_of_enemies];
        int bomb_index = -1;
        int temp_index = 0;
        Semaphore sem = new Semaphore(1, 1);
        int enemy_index = 0;
        //int[] enemies = new int[num_of_enemies];
        int[] direction = new int[num_of_enemies];
        int temp_enemy_index = 0;
        Random rand = new Random();
        PointF[] enemy_pos = new PointF[num_of_enemies];
        int min_diistance = 150;
        int max_speed = 6;
        PictureBox exp = new PictureBox();
        static int num_of_bombs=100;
        PointF[] bomb_pos = new PointF[num_of_bombs];




        //functions

        private double GetDistance(PointF point1, PointF point2)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(point2.X - point1.X);
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(a * a + b * b);
        }
        private double GetDistanceX(PointF point1, PointF point2)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(point2.X - point1.X);

            return Math.Sqrt(a * a);
        }
        private double GetDistanceY(PointF point1, PointF point2)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(b * b);
        }


        private void add_image()
        {
            Controls.Add(bomb[temp_index]);

        }
        private void remove_image()
        {
            bomb[temp_index].Location = new System.Drawing.Point(1000, 0);
            bomb[temp_index].Size = new System.Drawing.Size(0, 0);
            Controls.Remove(bomb[temp_index]);

        }
        private void explosion()
        {
            bomb[temp_index].BackgroundImage = global::Bomberman.Properties.Resources.explosion;
            bomb[temp_index].Size = new System.Drawing.Size(60, 60);

        }
        public void bomb_work()
        {
            //sem.WaitOne();
            bomb_index++;
            //sem.Release();

            int my_index = bomb_index;
            int x = this.sprite.Location.X + 1;
            int y = this.sprite.Location.Y + 2;

            bomb[my_index] = new PictureBox();
            bomb[my_index].BackgroundImage = global::Bomberman.Properties.Resources.bomb;
            bomb[my_index].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            bomb[my_index].Location = new System.Drawing.Point(x, y);
            bomb[my_index].Size = new System.Drawing.Size(33, 33);
            temp_index = my_index;
            this.Invoke(new MethodInvoker(add_image));
            Thread.Sleep(4000);
            temp_index = my_index;
            this.Invoke(new MethodInvoker(explosion));
            Thread.Sleep(2000);
            temp_index = my_index;
            this.Invoke(new MethodInvoker(remove_image));
            


        }

        private void win_cond()
        {
            if (sprite.Bounds.IntersectsWith(gate_pic.Bounds))
            {
                game_over.Text = "Win!!!";
                game_over.ForeColor = System.Drawing.Color.Green;
                game_over.Show();
                Controls.Remove(sprite);
                //Application.Exit();
            }
        }



        void moving()
        {
            bool left = false, right = false, up = false, down = false;
            if (move == 'a')
            {
                win_cond();
                bool flag = true;
                for (int i = 0; i < 133; i++)
                {
                    if (i < 93)
                    {
                        if (sprite.Bounds.IntersectsWith(boundry[i].Bounds))
                        {
                            if (i > 77 && i < 92)
                            {
                                flag = false; sprite.Left += 3; break;
                            }
                            else
                            {
                                flag = false; sprite.Left -= 3; break;
                            }
                        }

                    }
                    else // stage 
                    {
                        if (sprite.Bounds.IntersectsWith(stage[i - 93].Bounds))
                        {
                            PointF sp = new PointF();
                            PointF st = new PointF();
                            sp.X = sprite.Location.X;
                            sp.Y = sprite.Location.Y;
                            st.X = stage[i - 93].Location.X;
                            st.Y = stage[i - 93].Location.Y;
                            //conditions
                            //conditions
                            if (GetDistanceX(sp, st) < 65)
                            {
                                if (sp.X < st.X)
                                { left = true; }
                                else
                                { right = true; }
                            }


                        }//stage bounds

                    }
                }



                if (flag)
                    sprite.Left -= 3;
                if (left == true)
                {
                    sprite.Left -= 3;
                    left = false;
                }
                if (right == true)
                {
                    sprite.Left += 3;
                    right = false;
                }

            }
            else if (move == 'w')
            {
                win_cond();
                bool flag = true;
                for (int i = 0; i < 133; i++)
                {
                    if (i < 93)
                    {
                        if (sprite.Bounds.IntersectsWith(boundry[i].Bounds))
                        {
                            if (i < 30)
                            {
                                flag = false; sprite.Top += 3; break;
                            }
                            else
                            {
                                flag = false; sprite.Top -= 3; break;
                            }
                        }
                    }
                    else // stage 
                    {
                        if (sprite.Bounds.IntersectsWith(stage[i - 93].Bounds))
                        {
                            PointF sp = new PointF();
                            PointF st = new PointF();
                            sp.X = sprite.Location.X;
                            sp.Y = sprite.Location.Y;
                            st.X = stage[i - 93].Location.X;
                            st.Y = stage[i - 93].Location.Y;
                            //conditions

                            if (GetDistanceY(sp, st) < 65)
                            {
                                if (sp.Y < st.Y)
                                { up = true; break; }
                                else
                                { down = true; break; }
                            }

                        }//stage bounds

                    }
                }
                ////////////////////
                if (flag)
                    sprite.Top -= 3;

                if (up == true)
                {
                    sprite.Top -= 3;
                    up = false;
                }
                if (down == true)
                {
                    sprite.Top += 3;
                    down = false;
                }

            }
            else if (move == 'd')
            {
                win_cond();
                bool flag = true;
                for (int i = 0; i < 133; i++)
                {
                    if (i < 93)
                    {
                        if (sprite.Bounds.IntersectsWith(boundry[i].Bounds))
                        {
                            if (i > 30 && i < 46)
                            {
                                flag = false; sprite.Left -= 3; break;
                            }
                            else
                            {
                                flag = false; sprite.Left += 3; break;
                            }
                        }

                    }
                    else // stage 
                    {
                        if (sprite.Bounds.IntersectsWith(stage[i - 93].Bounds))
                        {
                            PointF sp = new PointF();
                            PointF st = new PointF();
                            sp.X = sprite.Location.X;
                            sp.Y = sprite.Location.Y;
                            st.X = stage[i - 93].Location.X;
                            st.Y = stage[i - 93].Location.Y;
                            //conditions
                            if (GetDistanceX(sp, st) < 65)
                            {
                                if (sp.X < st.X)
                                { left = true; }
                                else
                                { right = true; }
                            }

                        }//stage bounds


                    }//stage else
                }//loop
                ///////////////////
                if (flag)
                    sprite.Left += 3;
                if (left == true)
                {
                    sprite.Left -= 3;
                    left = false;
                }
                if (right == true)
                {
                    sprite.Left += 3;
                    right = false;
                }

            }
            else if (move == 's')
            {
                win_cond();
                bool flag = true;
                for (int i = 0; i < 133; i++)
                {
                    if (i < 93)
                    {
                        if (sprite.Bounds.IntersectsWith(boundry[i].Bounds))
                        {
                            if (i > 46 && i < 77)
                            {
                                flag = false; sprite.Top -= 3; break;
                            }
                            else
                            {
                                flag = false; sprite.Top += 3; break;
                            }
                        }

                    }
                    else // stage 
                    {
                        if (sprite.Bounds.IntersectsWith(stage[i - 93].Bounds))
                        {
                            PointF sp = new PointF();
                            PointF st = new PointF();
                            sp.X = sprite.Location.X;
                            sp.Y = sprite.Location.Y;
                            st.X = stage[i - 93].Location.X;
                            st.Y = stage[i - 93].Location.Y;
                            //conditions

                            if (GetDistanceY(sp, st) < 65)
                            {
                                if (sp.Y < st.Y)
                                { up = true; break; }
                                else
                                { down = true; break; }
                            }

                        }//stage bounds

                    }
                }
                //////////////
                if (flag)
                    sprite.Top += 3;

                if (up == true)
                {
                    sprite.Top -= 3;
                    up = false;
                }
                if (down == true)
                {
                    sprite.Top += 3;
                    down = false;
                }

            }
            else if (move == ' ')
            {

                ////////////////////
                Thread thread = new Thread(new ThreadStart(bomb_work));
                thread.Start();
            }
            else if (move == '0')//just checking the enemy
            {
                enemy_index++;
                //enemies[enemy_index] = enemy_index;
                b_x = 730;
                b_y = 28;
                Thread enemy = new Thread(new ThreadStart(enemy_func));
                enemy.Start();
            }
            else if (move == 'p')// just checking
            {
                direction[0] = rand.Next(4);
                if (direction[0] > 3)
                    direction[0] = 0;
            }

        }



        void boundrey_set()
        {
            int num = 93;
            for (int i = 0; i < num; i++)
            {
                //boundry
                boundry[i] = new PictureBox();
                boundry[i].BackgroundImage = global::Bomberman.Properties.Resources.conceete;
                boundry[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                boundry[i].Location = new System.Drawing.Point(b_x, b_y);
                boundry[i].Size = new System.Drawing.Size(26, 26);
                this.Controls.Add(boundry[i]);
                if (i < 30)
                    b_x += 26;
                else if (i > 30 && i < 46)
                    b_y += 26;
                else if (i > 46 && i < 77)
                    b_x -= 26;
                else if (i > 77 && i < 92)
                    b_y -= 26;
                /////////////////////

            }



        }

        void stage_set()
        {
            b_x = 90;
            b_y = 100;
            int num = 40;
            bool line1 = false, line2 = false, line3 = false, line4 = false;
            for (int i = 0; i < num; i++)
            {

                if (i < 8)
                {
                    if (line1 == false)
                    {
                        b_x = 5;
                        b_y = 80;
                        line1 = true;
                    }
                    b_x += 85;
                }
                else if (i >= 8 && i <= 15)
                {
                    if (line2 == false)
                    {
                        b_x = 5;
                        b_y += 100;
                        line2 = true;
                    }
                    b_x += 85;
                }
                else if (i >= 16 && i <= 23)
                {
                    if (line3 == false)
                    {
                        b_x = 5;
                        b_y += 100;
                        line3 = true;
                    }
                    b_x += 85;
                }

                /////////////////////

                //stage
                stage[i] = new PictureBox();
                stage[i].BackgroundImage = global::Bomberman.Properties.Resources.conceete;
                stage[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                stage[i].Location = new System.Drawing.Point(b_x, b_y);
                stage[i].Size = new System.Drawing.Size(35, 35);
                this.Controls.Add(stage[i]);


            }



        }



        public Form1()
        {
            InitializeComponent();
            boundrey_set();
            stage_set();
            for (int i = 0; i < num_of_enemies; i++)
            {
                enemy_pos[i] = new PointF();
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            move = e.KeyChar;
            moving();
        }

        ///////////////////
        private void add_enemy_image()
        {
            Controls.Add(enemy_pic[temp_enemy_index]);

        }
        private void remove_enemy_image()
        {
            enemy_pic[temp_enemy_index].Location = new System.Drawing.Point(1000, 0);
            enemy_pic[temp_enemy_index].Size = new System.Drawing.Size(0, 0);
            Controls.Remove(enemy_pic[temp_enemy_index]);


        }

        void enemy_func()
        {


            int my_index = enemy_index;
            ////////////////
            enemy_pic[my_index] = new PictureBox();
            enemy_pic[my_index].BackgroundImage = global::Bomberman.Properties.Resources.dragon;
            enemy_pic[my_index].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            enemy_pic[my_index].Location = new System.Drawing.Point(b_x, b_y);//730,28
            enemy_pic[my_index].Size = new System.Drawing.Size(45, 45);
            temp_enemy_index = my_index;
            this.Invoke(new MethodInvoker(add_enemy_image));
            
            this.Invoke(new MethodInvoker(movingtimer.Start));
            

        }

        private void enemy_release()
        {


            for (int i = 0; i < num_of_enemies; i++)
            {
                Thread.Sleep(2000);
                enemy_index++;
                b_x = 730;
                b_y = 28;
                Thread enemy = new Thread(new ThreadStart(enemy_func));
                enemy.Start();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // releasing enemies
            b_x = 735;
            b_y = 28;
            //Thread thread = new Thread(new ThreadStart(bomb_work));
            //thread.Start();            
            Thread enemy_zero = new Thread(new ThreadStart(enemy_func));
            enemy_zero.Start();
            Thread enemy_rel = new Thread(new ThreadStart(enemy_release));
            //enemy_index++;
            enemy_rel.Start();  // just uncomment it to have multiple enemies
        }

        private void movingtimer_Tick(object sender, EventArgs e)
        {
            PointF sprite_pos = new PointF();

            int normal_speed = 3;
            bool inter = false;


            for (int i = 0; i <= enemy_index; i++)//universal loop
            {
                ///  nechy wala sara kuch unit enemy k liye hai
                ///  
                sprite_pos.X = sprite.Location.X;
                sprite_pos.Y = sprite.Location.Y;
                enemy_pos[i].X = enemy_pic[i].Location.X;
                enemy_pos[i].Y = enemy_pic[i].Location.Y;
                



                for (int j = 0; j < 233; j++)
                {
                    ////////////
                    if (j <= bomb_index)
                    {
                        if (enemy_pic[i].Bounds.IntersectsWith(bomb[j].Bounds))
                        {
                            if (bomb[j].Size == new System.Drawing.Size(60, 60))
                            {
                                //bomb[j].Size = new System.Drawing.Size(0, 0);
                                //bomb[j].Location = new Point(0, 0);
                                enemy_pic[i].Size = new System.Drawing.Size(0, 0);
                                enemy_pic[i].Location = new Point(0, 1000);
                                Controls.Remove(enemy_pic[i]);
                                //Controls.Remove(bomb[j]);
                            }
                        }
                    }
                    ///////////////
                    if (j < 93)
                    {
                        //deciding direction
                        if (enemy_pic[i].Bounds.IntersectsWith(boundry[j].Bounds))
                        {
                            inter = true;//signal
                            if (j < 30 && direction[i] == 0)
                            {
                                if (i % 2 == 0)
                                { direction[i] = 3; break; }
                                else
                                { direction[i] = 1; break; }

                            }
                            else if ((j > 30 && j < 46) && direction[i] == 3)
                            {
                                if (i % 2 == 0)
                                { direction[i] = 2; break; }
                                else
                                { direction[i] = 0; break; }
                            }
                            else if ((j > 46 && j < 77) && direction[i] == 2)
                            {
                                if (i % 2 == 0)
                                { direction[i] = 1; break; }
                                else
                                { direction[i] = 3; break; }
                            }
                            else if ((j > 77 && j < 92) && direction[i] == 1)
                            {
                                if (i % 2 == 0)
                                { direction[i] = 0; break; }
                                else
                                { direction[i] = 2; break; }
                            }

                        }
                    }
                    else if(j > 93 && j < 133) // stage 
                    {
                        if (enemy_pic[i].Bounds.IntersectsWith(stage[j - 93].Bounds))
                        {
                            inter = true;//signal
                            if (direction[i] == 0)
                            {
                                enemy_pic[i].Top += 3;
                                direction[i] = 1;
                            }
                            else if (direction[i] == 1)
                            {
                                enemy_pic[i].Left += 3;
                                direction[i] = 2;
                            }
                            else if (direction[i] == 2)
                            {
                                enemy_pic[i].Top -= 3;
                                direction[i] = 3;
                            }
                            else if (direction[i] == 3)
                            {
                                enemy_pic[i].Left -= 3;
                                direction[i] = 0;
                            }


                        }//stage bounds

                    }
                    
                }
                //////// oper wali directions boundary aur bricks ne decide ki hain


                if (GetDistance(sprite_pos, enemy_pos[i]) < min_diistance)//AI Scenes
                {
                    if ((GetDistanceX(sprite_pos, enemy_pos[i]) < 3) && (sprite_pos.Y < enemy_pos[i].Y))
                        direction[i] = 0;
                    else if ((GetDistanceX(sprite_pos, enemy_pos[i]) < 3) && (sprite_pos.Y > enemy_pos[i].Y))
                        direction[i] = 2;
                    else if ((GetDistanceY(sprite_pos, enemy_pos[i]) < 3) && (sprite_pos.X < enemy_pos[i].X))
                        direction[i] = 1;
                    else if ((GetDistanceX(sprite_pos, enemy_pos[i]) < 3) && (sprite_pos.X > enemy_pos[i].X))
                        direction[i] = 3;
                    else if (sprite_pos.X < enemy_pos[i].X)
                        direction[i] = 1;
                    else if (sprite_pos.X > enemy_pos[i].X)
                        direction[i] = 3;
                    else if (sprite_pos.Y < enemy_pos[i].Y)
                        direction[i] = 0;
                    else if (sprite_pos.Y > enemy_pos[i].Y)
                        direction[i] = 2;
                }


                ///// moving in directions
                if (direction[i] == 0)
                {
                    if (GetDistance(sprite_pos, enemy_pos[i]) < min_diistance && (inter == false))
                    {
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X, enemy_pic[i].Location.Y - max_speed);
                    }
                    else
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X, enemy_pic[i].Location.Y - normal_speed);
                }
                else if (direction[i] == 1)
                {
                    if (GetDistance(sprite_pos, enemy_pos[i]) < min_diistance && (inter == false))
                    {
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X - max_speed, enemy_pic[i].Location.Y);
                    }
                    else
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X - normal_speed, enemy_pic[i].Location.Y);
                }
                else if (direction[i] == 2)
                {
                    if (GetDistance(sprite_pos, enemy_pos[i]) < min_diistance && (inter == false))
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X, enemy_pic[i].Location.Y + max_speed);
                    else
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X, enemy_pic[i].Location.Y + normal_speed);
                }
                else if (direction[i] == 3)
                {
                    if (GetDistance(sprite_pos, enemy_pos[i]) < min_diistance && (inter == false))
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X + max_speed, enemy_pic[i].Location.Y);
                    else
                        enemy_pic[i].Location = new Point(enemy_pic[i].Location.X + normal_speed, enemy_pic[i].Location.Y);
                }
                inter = false;

                //sprite collision with enemy
                if (enemy_pic[i].Bounds.IntersectsWith(sprite.Bounds))
                {
                    
                    Controls.Remove(sprite);
                    game_over.Show();
                    
                }



                ///bomb check
    //            for (int k = 0; k < bomb_index; k++)
      //          {

                    //bomb_pos[k].X = bomb[k].Location.X;
                    //bomb_pos[k].Y = bomb[k].Location.Y;

                    /////////
                    
                    //if (GetDistance(enemy_pos[i], bomb_pos[k]) < 30)
                    //if (enemy_pic[i].Bounds.IntersectsWith(bomb[k].Bounds))
                    //{
                    //    bomb[k].Size = new System.Drawing.Size(0, 0);
                    //    bomb[k].Location = new Point(0, 0);
                    //    enemy_pic[i].Size = new System.Drawing.Size(0, 0);
                    //    enemy_pic[i].Location = new Point(0, 1000);
                    //    Controls.Remove(enemy_pic[i]);
                    //    Controls.Remove(bomb[k]);
                    //}
        //        }

            }//i wali IF

        }

        

    }

}
