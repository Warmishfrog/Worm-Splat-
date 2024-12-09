using System.Windows.Forms;

namespace WormSplatter
{
    public partial class Form1 : Form
    {
        private RedWorm redWorm;
        private BlueWorm blueWorm;
        private GreenWorm greenWorm;
        private GreyWorm greyWorm;

        public Form1()
        {
            InitializeComponent();

            redWorm = new RedWorm();
            blueWorm = new BlueWorm();
            greenWorm = new GreenWorm();
            greyWorm = new GreyWorm();
            //Worm[] worms = { redWorm, blueWorm, greenWorm, greyWorm };

            List<Worm> worms = new List<Worm>();

            for (int i = 0; i < 5; i++)
            {
                worms.Add(new RedWorm());
                worms.Add(new BlueWorm());
                worms.Add(new GreenWorm());
                worms.Add(new GreyWorm());
            }


        }



        abstract class Worm //Abstraction to hide non-descript worms
        {
            private int deadvalue;
            public int DeadValue
            {
                get
                {
                    return deadvalue;
                }
                set
                {
                    deadvalue = value;
                }
            }

            private int length = 100; //initial value
            public int Length //encapsulation
            {
                get //read
                {
                    return length;
                }
                set //write
                {
                    if (value < DeadValue)
                    {
                        length = DeadValue;
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

        class RedWorm : Worm
        {

            public override void Splat()
            {
                DeadValue = 70;
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }


        }

        class BlueWorm : Worm
        {
            public override void Splat()
            {
                DeadValue = 10;
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }
        }

        class GreenWorm : Worm
        {
            public override void Splat()
            {
                DeadValue = 50;
                int RandNum = new Random().Next(0, 81);
                Length -= RandNum; //random number between 0 and 80
                System.Diagnostics.Debug.WriteLine("Random Number Generated: " + RandNum);
            }
        }

        class GreyWorm : Worm
        {
            public override void Splat()
            {
                DeadValue = 20;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
