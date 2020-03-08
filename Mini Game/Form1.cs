using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mini_Game
{
    public class CActor
    {
        public int X, Y, W, H;
        public Bitmap img;
        public List<Bitmap> imgs;
        public int ID;
        public int GG;
    }




    public partial class Form1 : Form
    {
        Bitmap unSeen;
        Bitmap World;


        Random R = new Random();
        Random E = new Random();

        Random TT = new Random();
        Random FF = new Random();

        Random XX = new Random();
        Random YY = new Random();

        List<CActor> Hero = new List<CActor>();
        List<CActor> Gold = new List<CActor>();
        List<CActor> Bricks = new List<CActor>();
        List<CActor> Hook = new List<CActor>();


        Timer tt = new Timer();

        int flag=0;

        int StartX;
        int StartY;

        int flagline = 0;
        int HitGold = 0;
        int HitBrikcs = 0;
        int iHit = 0;


        int money = 0;
        int goal = 400;
        int time = 400;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            tt.Tick += new EventHandler(tt_Tick);
            tt.Start();

            

        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                flag = 1;
            }




        }

        void tt_Tick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                if (Hook[0].GG <= Hook[0].imgs.Count)
                {
                    Hook[0].GG++;
                }
                if (Hook[0].GG == Hook[0].imgs.Count)
                {
                    Hook[0].GG = 0;
                }
            }
            if (flag == 1)
            {
                if (Hero[0].ID <= Hero[0].imgs.Count)
                {
                    Hero[0].ID++;
                }
                if (Hero[0].ID == Hero[0].imgs.Count)
                {
                    Hero[0].ID = 0;
                }
                if (Hook[0].GG > 17)
                {
                    if (flagline == 0)
                    {
                        Hook[0].X -= 3;
                        Hook[0].Y += 3;
                    }
                }
                if (Hook[0].GG < 17 )
                {
                    if (flagline == 0)
                    {
                        Hook[0].X += 3;
                        Hook[0].Y += 3;
                    }
                }


                if (Hook[0].GG == 17)
                {
                    if (flagline == 0)
                    {
                        Hook[0].Y += 3;
                    }
                }

                if (Hook[0].GG > 17)
                {
                    if (HitGold == 0)
                    {
                        for (int i = 0; i < Gold.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Gold[i].X + Gold[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Gold[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Gold[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Gold[i].Y + Gold[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitGold = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].X += 3;
                        Gold[iHit].X += 3;
                        Hook[0].Y -= 3;
                        Gold[iHit].Y -= 3;
                        if (Gold[iHit].Y <= StartY)
                        {
                            Gold.RemoveAt(iHit);
                            money += 200;
                            HitGold = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }

                    if (HitBrikcs == 0)
                    {
                        for (int i = 0; i < Bricks.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Bricks[i].X + Bricks[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Bricks[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Bricks[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Bricks[i].Y + Bricks[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitBrikcs = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].X += 3;
                        Bricks[iHit].X += 3;
                        Hook[0].Y -= 3;
                        Bricks[iHit].Y -= 3;
                        if (Bricks[iHit].Y <= StartY)
                        {
                            Bricks.RemoveAt(iHit);
                            money -= 50;
                            HitBrikcs = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }
                }
                if (Hook[0].GG < 17)
                {
                    if (HitGold == 0)
                    {
                        for (int i = 0; i < Gold.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Gold[i].X + Gold[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Gold[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Gold[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Gold[i].Y + Gold[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitGold = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].X -= 3;
                        Gold[iHit].X -= 3;
                        Hook[0].Y -= 3;
                        Gold[iHit].Y -= 3;
                        if (Gold[iHit].Y <= StartY)
                        {
                            Gold.RemoveAt(iHit);
                            money += 200;
                            HitGold = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }

                    if (HitBrikcs == 0)
                    {
                        for (int i = 0; i < Bricks.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Bricks[i].X + Bricks[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Bricks[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Bricks[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Bricks[i].Y + Bricks[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitBrikcs = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].X -= 3;
                        Bricks[iHit].X -= 3;
                        Hook[0].Y -= 3;
                        Bricks[iHit].Y -= 3;
                        if (Bricks[iHit].Y <= StartY)
                        {
                            Bricks.RemoveAt(iHit);
                            money -= 50;
                            HitBrikcs = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }

                }
                if (Hook[0].GG == 17)
                {

                    if (HitGold == 0)
                    {
                        for (int i = 0; i < Gold.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Gold[i].X + Gold[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Gold[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Gold[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Gold[i].Y + Gold[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitGold = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].Y -= 3;
                        Gold[iHit].Y -= 3;
                        if (Gold[iHit].Y <= StartY)
                        {
                            Gold.RemoveAt(iHit);
                            money += 200;
                            HitGold = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }

                    if (HitBrikcs == 0)
                    {
                        for (int i = 0; i < Bricks.Count; i++)
                        {
                            if (Hook[0].X + (Hook[0].W) <= Bricks[i].X + Bricks[i].W &&
                                Hook[0].X + (Hook[0].W / 2) >= Bricks[i].X &&
                                Hook[0].Y + (Hook[0].H / 2) >= Bricks[i].Y &&
                                Hook[0].Y + (Hook[0].H / 2) <= Bricks[i].Y + Bricks[i].H)
                            {
                                flagline = 1;
                                iHit = i;
                                HitBrikcs = 1;
                            }
                        }
                    }
                    else
                    {
                        Hook[0].Y -= 3;
                        Bricks[iHit].Y -= 3;
                        if (Bricks[iHit].Y <= StartY)
                        {
                            Bricks.RemoveAt(iHit);
                            money -= 50;
                            HitBrikcs = 0;
                            Hook[0].X = StartX;
                            Hook[0].Y = StartY;
                            flag = 0;
                            flagline = 0;
                        }
                    }
                }
                

            }

            if (money == goal)
            {
                money = 0;
                goal += 200;
                for ( int i=0 ; i<Gold.Count ; i++ )
                {
                    Gold.RemoveAt(i);
                }
                for (int i = 0; i < Bricks.Count; i++)
                {
                    Bricks.RemoveAt(i);
                }
                MessageBox.Show("WIN");
                CreateGoldBricks();
              
            }
            if (time == 0)
            {
                tt.Stop();
                for (int i = 0; i < Gold.Count; i++)
                {
                    Gold.RemoveAt(i);
                }
                for (int i = 0; i < Bricks.Count; i++)
                {
                    Bricks.RemoveAt(i);
                }
                MessageBox.Show("LOSE");
            }

            time--;
            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {

            DrawDubb(this.CreateGraphics());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            unSeen = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            World = new Bitmap("BackGround.png");

            CreateHero();
            CreateGoldBricks();
            CreateHook();

            DrawDubb(this.CreateGraphics());
        }



        void CreateHero()
        {

            CActor pnn = new CActor();

            pnn.X = 700;
            pnn.Y = 60;
            pnn.W = 110;
            pnn.H = 130;

            

            pnn.imgs = new List<Bitmap>();
            for (int i = 0; i < 7; i++)
            {
                Bitmap pnm = new Bitmap("ID" + (i + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.imgs.Add(pnm);
            }
            pnn.ID = 0;

            Hero.Add(pnn);
        }

        void CreateHook()
        {
            CActor pnn = new CActor();

            pnn.X = 720;
            pnn.Y = Hero[0].Y + Hero[0].H ;
            pnn.W = 50;
            pnn.H = 50;

            StartX = pnn.X;
            StartY = pnn.Y;

            pnn.imgs = new List<Bitmap>();

            for (int i = 0; i < 24; i++)
            {
                Bitmap pnm = new Bitmap("Hook" + (i + 1) + ".PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.imgs.Add(pnm);
            }
            pnn.GG = 0;
            Hook.Add(pnn);
        }

        void CreateGoldBricks()
        {
           
            int v ;
            int f;
            int g;
            int h;


            v = TT.Next(0, 20);
            g = FF.Next(0, 10);

            for (int i = 0; i < v; i++)
            {
                CActor pnn = new CActor();
                int var2 = XX.Next(0, (this.Width));
                pnn.X = var2;
                pnn.Y = YY.Next(200, this.Height);
                pnn.W = 60;
                pnn.H = 40;
                f =R.Next(1,3);
                
                pnn.img = new Bitmap(f + ".png");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                Gold.Add(pnn);

                CActor pnn2 = new CActor();
                pnn2.X = var2;
                pnn2.Y = YY.Next(200, this.Height);
                pnn2.W = 60;
                pnn2.H = 40;
                f = R.Next(1,3);
                pnn2.img = new Bitmap(f + ".png");
                pnn2.img.MakeTransparent(pnn2.img.GetPixel(0, 0));
                Gold.Add(pnn2);
            }

            for (int i = 0; i < g; i++)
            {
                CActor pnn = new CActor();
                int var = XX.Next(0, (this.Width));
                pnn.X = var;
                pnn.Y = YY.Next(200, this.Height);
                pnn.W = 60;
                pnn.H = 40;
                h = E.Next(3, 5);
                pnn.img = new Bitmap(h + ".png");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                Bricks.Add(pnn);

                CActor pnn2 = new CActor();
                pnn2.X = var;
                pnn2.Y = YY.Next(200, this.Height);
                pnn2.W = 60;
                pnn2.H = 40;
                h = E.Next(3, 5);
                pnn2.img = new Bitmap(h + ".png");
                pnn2.img.MakeTransparent(pnn2.img.GetPixel(0, 0));
                Bricks.Add(pnn2);
            }
        }


        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(unSeen);
            DrawScene(g2);
            g.DrawImage(unSeen, 0, 0);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            g.DrawImage(World,new Rectangle(0,0,4000,1900),
                new Rectangle(0,0,this.ClientSize.Width,this.ClientSize.Height),
                GraphicsUnit.Pixel);
            Font FF = new Font("System", 20);

            g.DrawString("Goal" + "           " + goal, FF, Brushes.Green, 1150, 60);

            g.DrawString("Money" + "           " + money ,FF,Brushes.Green,450,60);
            g.DrawString("Time" + "           " + time, FF, Brushes.Green, 450, 100);




            Pen PP = new Pen(Color.Brown,4);

            if (flagline == 0)
            {
                g.DrawLine(PP, StartX, StartY, Hook[0].X, Hook[0].Y);
            }
            else
            {
                g.DrawLine(PP, StartX, StartY, Hook[0].X, Hook[0].Y);
            }

            for (int i = 0; i < Hero.Count; i++)
            {
                g.DrawImage(Hero[i].imgs[Hero[i].ID], Hero[i].X, Hero[i].Y, Hero[i].W, Hero[i].H);
            }   

            for (int i = 0; i < Hook.Count; i++)
            {
                g.DrawImage(Hook[i].imgs[Hook[i].GG], Hook[i].X, Hook[i].Y, Hook[i].W, Hook[i].H);
            }


            for (int i = 0; i < Gold.Count; i++)
            {
                g.DrawImage(Gold[i].img, Gold[i].X, Gold[i].Y, Gold[i].W, Gold[i].H);
            }

            for (int i = 0; i < Bricks.Count; i++)
            {
                g.DrawImage(Bricks[i].img, Bricks[i].X, Bricks[i].Y, Bricks[i].W, Bricks[i].H);
            }
            

        }

    }
}
