﻿using System;
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
        int i = 0;
        String word = "";
        Boolean[] alph = new Boolean[1000];

        Object[] boneco = new Object[6];
        String[] palavras = new String[6];

        Button botaoClicado;

        /*boneco[0] = cabeca;
        boneco[1] = corpo;
        boneco[2] = bracoesq;
        boneco[3] = bracodir;
        boneco[4] = pernaesq;
        boneco[5] = pernadir;

        palavra[0] = "CELULAR";
        palavra[1] = "CERVEJA";
        palavra[2] = "COMPUTADOR";
        palavra[3] = "RAFAEL";
        palavra[4] = "TIAGO";
        palavra[5] = "PEDRO";*/

        public Form1()
        {
            InitializeComponent();
            textBox2.Focus();
             
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void show(char c)
        {
            Console.WriteLine(Convert.ToString(c));
            textBox2.Text = Convert.ToString(c);
            
        }

        private void checkGame(char c)
        {
            if (hasChar(c))
            {
                show(c); return;
            }
            if (++i == 6) gameOver();
        }

        private void gameOver() {
            cabeca.Text = ":P";
        }   

        private Boolean hasChar(char c)
        {
            for (int i = 0; i < word.Length; i++)
                if (word[i] == c) return true;
            return false;
        }

        private void keyboardClick(Button button)
        {
            //char shar = Convert.ToChar(button.Text);
            //checkGame(shar);

            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Red;

            string text = button.Text;
            char[] characters = text.ToCharArray();
            
        }

        private void Q_Click(object sender, EventArgs e)
        {

            botaoClicado = sender as Button;
            keyboardClick(botaoClicado);

        }

    }
}