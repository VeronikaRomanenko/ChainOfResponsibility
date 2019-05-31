using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChainOfResponsibility
{
    public partial class Form1 : Form
    {
        Coin coin_5 = new Coin_5();
        Coin coin_10 = new Coin_10();
        Coin coin_25 = new Coin_25();
        Coin coin_50 = new Coin_50();
        Coin coin_100 = new Coin_100();
        public Form1()
        {
            InitializeComponent();
            coin_5.Successor = coin_10;
            coin_10.Successor = coin_25;
            coin_25.Successor = coin_50;
            coin_50.Successor = coin_100;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            coin_5.HandleRequest(int.Parse(txbWeight.Text), int.Parse(txbDiameter.Text));
            txbSum.Text = $"{Sum.sum} коп.";
        }
    }
    public static class Sum
    {
        public static int sum = 0;
    }
    abstract class Coin
    {
        public Coin Successor { get; set; }
        public abstract void HandleRequest(int weight, int diameter);
    }
    class Coin_5 : Coin
    {
        public override void HandleRequest(int weight, int diameter)
        {
            if (Math.Abs(10 - weight) <= 1 && Math.Abs(5 - diameter) <= 1)
            {
                MessageBox.Show("Монета номиналом 5 коп. принята");
                Sum.sum += 5;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(weight, diameter);
            }
            else
            {
                MessageBox.Show("Монета не принята");
            }
        }
    }
    class Coin_10 : Coin
    {
        public override void HandleRequest(int weight, int diameter)
        {
            if (Math.Abs(15 - weight) <= 1 && Math.Abs(8 - diameter) <= 1)
            {
                MessageBox.Show("Монета номиналом 10 коп. принята");
                Sum.sum += 10;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(weight, diameter);
            }
            else
            {
                MessageBox.Show("Монета не принята");
            }
        }
    }
    class Coin_25 : Coin
    {
        public override void HandleRequest(int weight, int diameter)
        {
            if (Math.Abs(20 - weight) <= 1 && Math.Abs(11 - diameter) <= 1)
            {
                MessageBox.Show("Монета номиналом 25 коп. принята");
                Sum.sum += 25;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(weight, diameter);
            }
            else
            {
                MessageBox.Show("Монета не принята");
            }
        }
    }
    class Coin_50 : Coin
    {
        public override void HandleRequest(int weight, int diameter)
        {
            if (Math.Abs(25 - weight) <= 1 && Math.Abs(14 - diameter) <= 1)
            {
                MessageBox.Show("Монета номиналом 50 коп. принята");
                Sum.sum += 50;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(weight, diameter);
            }
            else
            {
                MessageBox.Show("Монета не принята");
            }
        }
    }
    class Coin_100 : Coin
    {
        public override void HandleRequest(int weight, int diameter)
        {
            if (Math.Abs(30 - weight) <= 1 && Math.Abs(17 - diameter) <= 1)
            {
                MessageBox.Show("Монета номиналом 1 грн. принята");
                Sum.sum += 100;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(weight, diameter);
            }
            else
            {
                MessageBox.Show("Монета не принята");
            }
        }
    }
}
