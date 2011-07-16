using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace netcompact_forca
{
    public partial class Form1 : Form
    {

        Boolean[] alph = new Boolean[1000]; 

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            char key = (char)e.KeyValue;
            if ( possui(key) )
                errou();
        }

        private Boolean possui(char c)
        {
            if (!alph[c]) alph[c] = true;
            Console.WriteLine(alph[c] + ":" + c);
            return alph[c];
        }

        private void errou()
        {

        }

    }
}