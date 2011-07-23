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
        int war = 0;
        int chance = 0;
        String wordSelected = "";
        char[] entries = new char[10];
        Boolean[] alph = new Boolean[1000];

        Object[] boneco = new Object[6];
        String[] palavras = new String[6];

        Button botaoClicado;

        public Form1()
        {
            InitializeComponent();
            startGame();
        }

        private void startGame() 
        {
            configureElements();
            selectRandomWord();
            showInitStatusGame();
        }

        private void showInitStatusGame()
        {
            cabeca.Text = "";
            for (int i = 0; i < boneco.Length; i++)
            {
                (boneco[i] as Button).Visible = false;
            }

            String underline = "";
            for (int i = 0; i < wordSelected.Length; i++)
            {
                underline += " _ ";
            }
            textBox2.Text = underline;
        }

        private void configureElements()
        {
            boneco[0] = cabeca;
            boneco[1] = corpo;
            boneco[2] = bracoesq;
            boneco[3] = bracodir;
            boneco[4] = pernaesq;
            boneco[5] = pernadir;

            palavras[0] = "CELULAR";
            palavras[1] = "CERVEJA";
            palavras[2] = "COMPUTADOR";
            palavras[3] = "RAFAEL";
            palavras[4] = "TIAGO";
            palavras[5] = "PEDRO";
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private Boolean hasOccurrence(int index, int[] positions)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] == index) return true;
            }
            return false;
        }

        private Boolean hasJoined(char c)
        {
            for (int i = 0; i < entries.Length; i++)
                if (entries[i] == c) return true;
            return false;
        }

        private void show(char c)
        {
            int[] positions = getPositions(c);
            String swap = "";
            for (int i = 0; i < wordSelected.Length; i++)
            {
                Boolean joined = hasJoined(wordSelected[i]);
                Boolean occur = hasOccurrence(i, positions);

                if (joined)
                {
                    swap += " " + wordSelected[i] + " "; continue;
                }

                if (wordSelected[i] != c && !occur)
                {
                    
                    swap += " _ "; continue;
                }
                //if (!occur && joined)
                //{
                //    swap += " _ "; continue;
                //}

                swap += " " + wordSelected[i] + " ";
            }
            textBox2.Text = swap;
            entries[war++] = c;
        }

        private int[] getPositions(char c)
        {
            String founds = "";
            for (int i = 0; i < wordSelected.Length; i++)
            {
                if (wordSelected[i] == c) founds += i;
            }

            int[] positions = new int[founds.Length]; 
            for (int i = 0; i < founds.Length; i++)
            {
                positions[i] = founds[i];
            }
            return positions;
            
        }

        private void selectRandomWord()
        {
            Random randObj = new Random();
            int index = randObj.Next(0, palavras.Length -1);
            wordSelected = palavras[index];
        }

        private void checkGame(char c)
        {
            if (hasChar(c))
            {
                show(c); return;
            }
            // metodo inserir parte do boneco
            if (++chance == 6) gameOver();
        }

        private void gameOver() {
            cabeca.Text = ":P";
        }   

        private Boolean hasChar(char c)
        {
            for (int i = 0; i < wordSelected.Length; i++)
                if (wordSelected[i] == c) return true;
            return false;
        }

        private void keyboardClick(Button button)
        {
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Red;

            char chara = Convert.ToChar(button.Text);
            checkGame(chara); 
        }

        private void Q_Click(object sender, EventArgs e)
        {
            botaoClicado = sender as Button;
            keyboardClick(botaoClicado);
        }

        private void A_Click(object sender, EventArgs e)
        {
            keyboardClick(A);
        }

        private void C_Click(object sender, EventArgs e)
        {
            keyboardClick(C);
        }

        private void T_Click(object sender, EventArgs e)
        {
            keyboardClick(T);
        }

        private void B_Click(object sender, EventArgs e)
        {
            keyboardClick(B);
        }

        private void Z_Click(object sender, EventArgs e)
        {
            keyboardClick(Z);
        }

        private void E_Click(object sender, EventArgs e)
        {
            keyboardClick(E);
        }

        private void L_Click(object sender, EventArgs e)
        {
            keyboardClick(L);
        }

        private void I_Click(object sender, EventArgs e)
        {
            keyboardClick(I);
        }

    }
}