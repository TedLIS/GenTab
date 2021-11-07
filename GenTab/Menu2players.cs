using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace GenTab
{
    public partial class Menu2players : Form
    {
        public Menu2players()
        {
            InitializeComponent();
            
        }

        private void Menu2players_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 800;
            progressBar1.Value = 435;
            progressBar2.Maximum = 800;
            progressBar2.Value = 735;
            this.BackColor = Color.FromArgb(0, 0, 0);
            label5.BackColor = Color.FromArgb(0, 0, 0);
            label9.BackColor = Color.FromArgb(0, 0, 0);
            label3.BackColor = Color.FromArgb(0, 0, 0);
            label4.BackColor = Color.FromArgb(0, 0, 0);
            ThreadGUI1v1.RunWorkerAsync();
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
            this.Opacity = 0.90;
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public static Color[] colors = new Color[] { Color.Gold, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Cyan, Color.Purple, Color.Pink };

        private void ThreadGUI1v1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(100);
                label3.Text = GenTab.TournamentNickName[0];
                label4.Text = GenTab.TournamentNickName[1];
                if (GenTabStuff.isinomatch)
                {
                    int player1id = 0;
                    int player2id = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        if (GenTabStuff.players[i] == GenTab.TournamentNickName[0])
                        {
                            player1id = i;
                        }
                        if (GenTabStuff.players[i] == GenTab.TournamentNickName[1])
                        {
                            player2id = i;
                        }
                    }
                    label5.Text = "$"+ GenTabStuff.money[player1id];
                    label9.Text = "$" + GenTabStuff.money[player1id];

                    if (GenTabStuff.armies[player1id] != -1)
                        pictureBox1.Image = Image.FromFile("./Generals/" + ((GenTab.EnumGenerals)GenTabStuff.armies[player1id]).ToString() + ".png");
                    if (GenTabStuff.armies[player2id] != -1)
                        pictureBox2.Image = Image.FromFile("./Generals/" + ((GenTab.EnumGenerals)GenTabStuff.armies[player2id]).ToString() + ".png");
                    label1.BackColor = colors[GenTabStuff.colors[player1id]];
                    label2.BackColor = colors[GenTabStuff.colors[player2id]];
                }
                else
                {

                }

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
