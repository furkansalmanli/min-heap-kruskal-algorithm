using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using AnalysisOfAlgorithms;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {   
        
        System.Drawing.Graphics grafiknesne;
        Graphics nokta;
        
        Pen kalem = new Pen(Color.Black, 1);
        SolidBrush firca = new SolidBrush(Color.Red);
     
        int x, y;
        Random q = new Random();
        ArrayList xler = new ArrayList();
        ArrayList yler = new ArrayList();
        ArrayList uzakliklar = new ArrayList();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tane = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < tane; i++)
            {
                nokta = this.CreateGraphics();
                x = q.Next(155, 560);
                y = q.Next(12, 331);
                xler.Add(x);
                yler.Add(y);
                nokta.DrawEllipse(kalem, x, y, 10, 10);
             

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tane = Convert.ToInt32(textBox1.Text);
            int kume = Convert.ToInt32(textBox2.Text);
            Person[] people = new Person[tane*tane];
            int c = 0;
            for (int i = 0; i < tane; i++)
            {
                for(int j = 0; j < tane; j++)
                {
                    int xlercikarma = Convert.ToInt32(xler[i]) - Convert.ToInt32(xler[j]);
                    int ylercikarma = Convert.ToInt32(yler[i]) - Convert.ToInt32(yler[j]);
                    int uzaklik = Convert.ToInt32(Math.Sqrt((xlercikarma * xlercikarma) + (ylercikarma * ylercikarma)));
                    Person p = new Person();
                    p.ID = uzaklik;
                    p.Name = i.ToString();
                    p.Surname = j.ToString();
                    people[c] = p;
                    Console.WriteLine(p);
                    c++;
                }
                
            }
            object[] sortedPeople = Heap.Sort(people);
            foreach (var item in sortedPeople)
            {
                listBox1.Items.Add(item);
            }
            if (kume > tane)
            {
                MessageBox.Show("KÜME SAYISI NOKTA SAYISINDAN FAZLA OLAMAZ");
            }
            else
            {
               for (int i = 0; i < sortedPeople.Length; i++)
                {
                  
                    for (int x = 0; x < people.Length; x++)
                    {
                        if (people[x].ID == Convert.ToInt32((Person)sortedPeople[i]))
                        {
                            int x1 = Convert.ToInt32(xler[Convert.ToInt32(people[x].Name)]);
                            int y1 = Convert.ToInt32(yler[Convert.ToInt32(people[x].Name)]);
                            nokta.FillRectangle(firca, new Rectangle(x1, y1, 50, 40));

                        }


                    }
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            
            e.Graphics.FillRectangle(firca, new Rectangle(10, 20, 50, 40));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
    class Points
    {
        public int x1 { get; set; }
        public int y1 { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x1, y1);
        }
    }
}
