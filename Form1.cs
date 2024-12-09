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
              
            //needed to prevent constructor being grumpy about nullable objects
            redWorm = new RedWorm();
            blueWorm = new BlueWorm();
            greenWorm = new GreenWorm();
            greyWorm = new GreyWorm();
            //*/
        }

        abstract class Worm //Abstraction to prevent non-descript worms from being created
        {
            private int length = 100; //initial value
            public int Length //encapsulation to protect the length value // worms inherit length
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < DeadValue) //
                    {
                        length = DeadValue;
                    }
                    else
                    {
                        length = value;
                    }
                }
            }

            public abstract int DeadValue { get; } //worm types can inherit but then override to allow for a protected inherited value (length) //example of inheritance, encapsulation and abstraction

            public virtual void Splat(int SplatVal) //takes integer (percent)
            {
                Length -= (Length * SplatVal / 100);// e.g. |100% - (100% * 50 / 100) = 50%|
                System.Diagnostics.Debug.WriteLine("Splat Value: " + SplatVal);
            }
        }

        class RedWorm : Worm //70
        {
            public override int DeadValue => 70;
        }

        class BlueWorm : Worm //10
        {
            public override int DeadValue => 10;
        }

        class GreenWorm : Worm//50
        {
            public override int DeadValue => 50;
        }

        class GreyWorm : Worm //20
        {
            public override int DeadValue => 20;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //title
        }

        private void CreateWormInterface()
        {
            List<Worm> wormsL = new List<Worm>(); //I wanted to implement it dynamically instead of hardcode to allow it to be easily adjustable and modular
            Type[] wormTypes = new Type[] { typeof(RedWorm), typeof(BlueWorm), typeof(GreenWorm), typeof(GreyWorm) }; //worm colour array

            foreach (Type wormType in wormTypes) //this makes it so that they are display in groups of colour as opposed to sequence of colour
            {
                for (int i = 0; i < 5; i++)
                {
                    Worm wormColour = (Worm)Activator.CreateInstance(wormType); //!--converting null literal or possible null value to non nullable type
                    wormsL.Add(wormColour);
                }
            }

            int xGap = 150;
            int yGap = 100;
            int columns = 5;

            for (int i = 0; i < wormsL.Count; i++)
            {
                int row = i / columns;
                int column = i % columns;
                int xOffset = column * xGap;
                int yOffset = row * yGap;

                CreateWormPanel(wormsL[i], xOffset, yOffset);
            }
        }

        private void CreateWormPanel(Worm worm, int xOffset, int yOffset) //individual worm modules makes it easer to create one and reproduce it
        {
            Panel wPanel = new Panel();
            this.Controls.Add(wPanel);

            wPanel.Location = new Point(50 + xOffset, 50 + yOffset);
            wPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
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

            switch (worm) //colour based on case 
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

                int RandNum = new Random().Next(0, 81);//random number between 0 and 80 // 0<y<81
                switch (worm)
                {
                    case RedWorm rw:
                        rw.Splat(RandNum);
                        wLength.Text = rw.Length.ToString();
                        if (rw.Length <= rw.DeadValue) wIcon.Text = "X"; //

                        break;

                    case BlueWorm bw:
                        bw.Splat(RandNum);
                        wLength.Text = bw.Length.ToString();
                        if (bw.Length <= bw.DeadValue) wIcon.Text = "X"; //
                        break;

                    case GreenWorm gw:
                        gw.Splat(RandNum);
                        wLength.Text = gw.Length.ToString();
                        if (gw.Length <= gw.DeadValue) wIcon.Text = "X"; //
                        break;

                    case GreyWorm gwm:
                        gwm.Splat(RandNum);
                        wLength.Text = gwm.Length.ToString();
                        if (gwm.Length <= gwm.DeadValue) wIcon.Text = "X"; //
                        break;

                    default:
                        break;
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PAGE RESET
            this.Controls.Clear(); //delete literally everything

            InitializeComponent();           
            CreateWormInterface();

            redWorm = new RedWorm();
            blueWorm = new BlueWorm();
            greenWorm = new GreenWorm();
            greyWorm = new GreyWorm();
        }
    }
}
