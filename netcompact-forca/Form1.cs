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
            int acertos = 0;
            String swap = "";
            for (int i = 0; i < wordSelected.Length; i++)
            {
                Boolean joined = hasJoined(wordSelected[i]);
                Boolean occur = hasOccurrence(i, positions);

                if (joined)
                {
                    acertos++;
                    swap += " " + wordSelected[i] + " "; continue;
                }

                if (wordSelected[i] != c && !occur)
                {
                    
                    swap += " _ "; continue;
                }

                swap += " " + wordSelected[i] + " ";
            }

            if (acertos == wordSelected.Length)
            {
                gameComplete();
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
            chance++;
            errou();
            if (chance == 6) gameOver();
        }

        private void errou()
        {
            Button parte = new Button();
            switch(chance)
            {
                case 1:
                    parte = cabeca;
                    break;
                case 2:
                    parte = corpo;
                    break;
                case 3:
                    parte = bracoesq;
                    break;
                case 4:
                    parte = bracodir;
                    break;
                case 5:
                    parte = pernaesq;
                    break;
                case 6:
                    parte = pernadir;
                    break;
                default:
                    break;
            }

            parte.Visible = true;
        }

        private void gameOver() {
            cabeca.Text = "X_X";
            MessageBox.Show("Que pena, voce perdeu!");
            resetGame();
            selectRandomWord();
        }

        private void gameComplete()
        {
            cabeca.Text = "O_O";
            MessageBox.Show("Parabens, voce ganhou!");
            resetGame();
            selectRandomWord();
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

        private void resetGame()
        {
            cabeca.Visible = false;
            cabeca.Text = "";
            corpo.Visible = false;
            bracoesq.Visible = false;
            bracodir.Visible = false;
            pernaesq.Visible = false;
            pernadir.Visible = false;
            textBox2.Text = "";

            Q.Enabled = true;
            W.Enabled = true;
            E.Enabled = true;
            R.Enabled = true;
            T.Enabled = true;
            Y.Enabled = true;
            U.Enabled = true;
            I.Enabled = true;
            O.Enabled = true;
            P.Enabled = true;
            A.Enabled = true;
            S.Enabled = true;
            D.Enabled = true;
            F.Enabled = true;
            G.Enabled = true;
            H.Enabled = true;
            J.Enabled = true;
            K.Enabled = true;
            L.Enabled = true;
            Z.Enabled = true;
            X.Enabled = true;
            C.Enabled = true;
            V.Enabled = true;
            B.Enabled = true;
            N.Enabled = true;
            M.Enabled = true;
            Q.BackColor = System.Drawing.SystemColors.Control;
            W.BackColor = System.Drawing.SystemColors.Control;
            E.BackColor = System.Drawing.SystemColors.Control;
            R.BackColor = System.Drawing.SystemColors.Control;
            T.BackColor = System.Drawing.SystemColors.Control;
            Y.BackColor = System.Drawing.SystemColors.Control;
            U.BackColor = System.Drawing.SystemColors.Control;
            I.BackColor = System.Drawing.SystemColors.Control;
            O.BackColor = System.Drawing.SystemColors.Control;
            P.BackColor = System.Drawing.SystemColors.Control;
            A.BackColor = System.Drawing.SystemColors.Control;
            S.BackColor = System.Drawing.SystemColors.Control;
            D.BackColor = System.Drawing.SystemColors.Control;
            F.BackColor = System.Drawing.SystemColors.Control;
            G.BackColor = System.Drawing.SystemColors.Control;
            H.BackColor = System.Drawing.SystemColors.Control;
            J.BackColor = System.Drawing.SystemColors.Control;
            K.BackColor = System.Drawing.SystemColors.Control;
            L.BackColor = System.Drawing.SystemColors.Control;
            Z.BackColor = System.Drawing.SystemColors.Control;
            X.BackColor = System.Drawing.SystemColors.Control;
            C.BackColor = System.Drawing.SystemColors.Control;
            V.BackColor = System.Drawing.SystemColors.Control;
            B.BackColor = System.Drawing.SystemColors.Control;
            N.BackColor = System.Drawing.SystemColors.Control;
            M.BackColor = System.Drawing.SystemColors.Control;
        }

        private void Q_Click(object sender, EventArgs e)
        {
            keyboardClick(Q);
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

        private void W_Click(object sender, EventArgs e)
        {
            keyboardClick(W);
        }

        private void R_Click(object sender, EventArgs e)
        {
            keyboardClick(R);
        }

        private void Y_Click(object sender, EventArgs e)
        {
            keyboardClick(Y);
        }

        private void U_Click(object sender, EventArgs e)
        {
            keyboardClick(U);
        }

        private void O_Click(object sender, EventArgs e)
        {
            keyboardClick(O);
        }

        private void P_Click(object sender, EventArgs e)
        {
            keyboardClick(P);
        }

        private void S_Click(object sender, EventArgs e)
        {
            keyboardClick(S);
        }

        private void D_Click(object sender, EventArgs e)
        {
            keyboardClick(D);
        }

        private void F_Click(object sender, EventArgs e)
        {
            keyboardClick(F);
        }

        private void G_Click(object sender, EventArgs e)
        {
            keyboardClick(G);
        }

        private void H_Click(object sender, EventArgs e)
        {
            keyboardClick(H);
        }

        private void J_Click(object sender, EventArgs e)
        {
            keyboardClick(J);
        }

        private void K_Click(object sender, EventArgs e)
        {
            keyboardClick(K);
        }

        private void X_Click(object sender, EventArgs e)
        {
            keyboardClick(X);
        }

        private void V_Click(object sender, EventArgs e)
        {
            keyboardClick(V);
        }

        private void N_Click(object sender, EventArgs e)
        {
            keyboardClick(N);
        }

        private void M_Click(object sender, EventArgs e)
        {
            keyboardClick(M);
        }
    }
}