using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //   Program.kurnik.picie = new SemaphoreSlim(1, 1);

            //        textBox1.Text = Program.agents.Count().ToString();
            jajko();
            textBox1.Text = Program.agents.Count().ToString();
            // MessageBox.Show("Liczba jajek to: "+ Program.agents.Count().ToString());
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            
           
        }
        void jajko()
        {
            JajkoAgent jajko = new JajkoAgent(Program.i, 10);
            Program.i++;


            Program.agents.Add(jajko);

            List<Agent> lista = new List<Agent>();
            lista.Add(jajko);
            Program.RunThreads(lista);

            return;
        }
        void kura()
        {
            KuraAgent kura = new KuraAgent(Program.i, 10);
            Program.i++;
            Program.kury.Add(kura);
            List<Agent> lista = new List<Agent>();
            lista.Add(kura);

            Program.RunThreads(lista);
            

            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            kura();
            textBox2.Text = Program.kury.Count().ToString();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            
            comboBox1.DataSource = Program.kury;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Width == 500)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
              //  this.ControlBox = false;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            else {
                //   this.ControlBox = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.Width = 500;
                this.Height = 500;
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {


            Program.rolnik.Update();
            
            Program.agents.AsParallel().ToList().ForEach(jajko => jajko.Update());
            
            Program.kury.AsParallel().ToList().ForEach(kura => kura.Update());
            textBox1.Text = Program.agents.Count().ToString();
            textBox2.Text = Program.kury.Count().ToString();

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.DataSource = Program.kury;
            
            Program.kurnik.Update();
          
            

        }
    }
}
