using System.Drawing;
using System.Windows.Forms;

namespace WormSplatter
{
    public partial class Form1 : Form
    {
        
        private RedWorm redWorm;
        private BlueWorm blueWorm;
        private GreenWorm greenWorm;
        private GreyWorm greyWorm;
        //*/

        public Form1()
        {
            InitializeComponent();  
            
            CreateWormInterface(); //create the worm interface

            
            redWorm = new RedWorm();
            blueWorm = new BlueWorm();
            greenWorm = new GreenWorm();
            greyWorm = new GreyWorm();
            //Worm[] worms = { redWorm, blueWorm, greenWorm, greyWorm };
            //*/


        }

        abstract class Worm //Abstraction to hide non-descript worms
        {          

            private int length = 100; //initial value
            public int Length //encapsulation
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < 0)
                    {
                        length = 0;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }
            public virtual void Splat() //polymorphism :)
            {
                int RandNum = new Random().Next(0, 81); //random number between 0 and 80
                Length -= RandNum;
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
                System.Diagnostics.Debug.WriteLine("New Length: " + Length);
            }

        }

        class RedWorm : Worm //70
        {
            private int length = 100;
            public int Length
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < 70)
                    {
                        length = 70;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }

            public override void Splat()
            {
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }


        }

        class BlueWorm : Worm //10
        {
            private int length = 100;
            public int Length
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < 10)
                    {
                        length = 10;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }
            public override void Splat()
            {
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }
        }

        class GreenWorm : Worm//50
        {
            private int length = 100;
            public int Length
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < 50)
                    {
                        length = 50;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }
            public override void Splat()
            {
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }
        }

        class GreyWorm : Worm //20
        {
            private int length = 100;
            public int Length
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < 20)
                    {
                        length = 20;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }
            public override void Splat()
            {
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            redWorm.Splat();
            System.Diagnostics.Debug.WriteLine("New Length: " + redWorm.Length);

        }

        private void CreateWormInterface()
        {
            List<Worm> worms = new List<Worm>();

            for (int i = 0; i < 5; i++)
            {
                worms.Add(new RedWorm());
                worms.Add(new BlueWorm());
                worms.Add(new GreenWorm());
                worms.Add(new GreyWorm());
            }

            int xGap = 150;
            int yGap = 100;
            int columns = 5;

            for (int i = 0; i < worms.Count; i++)
            {
                int row = i / columns;  
                int column = i % columns; 
                int xOffset = column * xGap; 
                int yOffset = row * yGap; 

                CreateWormPanel(worms[i], xOffset, yOffset);
            }
        }

        private void CreateWormPanel(Worm worm, int xOffset, int yOffset)
        {
            Panel wPanel = new Panel();
            this.Controls.Add(wPanel);

            wPanel.Location = new Point(50 + xOffset, 50 + yOffset);
            wPanel.AutoSize = true;
            wPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wPanel.BorderStyle = BorderStyle.FixedSingle;

            // Worm graphic setup
            TextBox wIcon = new TextBox();
            wPanel.Controls.Add(wIcon);
            wIcon.Text = "~";                  
            wIcon.Font = new Font(wIcon.Font.FontFamily, 20, FontStyle.Bold);
            wIcon.Location = new Point(14, 0);
            wIcon.Size = new Size(50, 5);
            wIcon.TextAlign = HorizontalAlignment.Center;
            wIcon.BorderStyle = BorderStyle.None;
            wIcon.BackColor = SystemColors.Control;
            wIcon.ReadOnly = true;

            switch (worm) //chooses worm colour based on input 
            {
                case RedWorm:
                    wIcon.ForeColor = System.Drawing.Color.Red;
                    break;
                case BlueWorm:
                    wIcon.ForeColor = System.Drawing.Color.Blue;
                    break;
                case GreenWorm:
                    wIcon.ForeColor = System.Drawing.Color.Green;
                    break;
                case GreyWorm:
                    wIcon.ForeColor = System.Drawing.Color.Gray;
                    break;
                default:

                    break;
            }


            // length display
            TextBox wLength = new TextBox();
            wPanel.Controls.Add(wLength);
            wLength.Text = worm switch //switch case changes the displayed length text based on the worm colour
            {
                RedWorm rw => rw.Length.ToString(),
                BlueWorm bw => bw.Length.ToString(), 
                GreenWorm gw => gw.Length.ToString(),
                GreyWorm gwm => gwm.Length.ToString(), 
                _ => "n/a"
            };
            wLength.Location = new Point(14, 40);
            wLength.Size = new Size(50, 20);
            wLength.TextAlign = HorizontalAlignment.Center;
            wLength.BorderStyle = BorderStyle.None;
            wLength.ReadOnly = true;

            // splat button
            Button splatButton = new Button();
            wPanel.Controls.Add(splatButton);
            splatButton.Text = "Splat";
            splatButton.AutoSize = true;
            splatButton.Location = new Point(5, 60);
            splatButton.Size = new Size(70, 30);

            //button logic
            splatButton.Click += (s, args) =>
            {
                switch (worm)
                {
                    case RedWorm rw:
                        rw.Splat();
                        wLength.Text = rw.Length.ToString();
                        break;

                    case BlueWorm bw:
                        bw.Splat();
                        wLength.Text = bw.Length.ToString();
                        break;

                    case GreenWorm gw:
                        gw.Splat();
                        wLength.Text = gw.Length.ToString(); 
                        break;

                    case GreyWorm gwm:
                        gwm.Splat();
                        wLength.Text = gwm.Length.ToString();
                        break;

                    default:                        
                        break;
                }
            };
        }
    }
}
