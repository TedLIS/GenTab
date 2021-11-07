using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace GenTab
{
    public partial class GenTab : Form
    {
        [DllImport("Kernel32.dll", SetLastError = true)] static public extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)] public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UInt32 nSize, ref UInt32 lpNumberOfBytesRead);
        [DllImport("kernel32.dll")] public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("user32.dll")] private static extern bool SetProcessDPIAware();


        static Process game = null;
        public static IntPtr processHandle = (IntPtr)0;
        static bool Hooked = false;
        public static bool isgenerals = false;
        private Settings Settingsform = null;

        public enum EnumGenerals
        {
            Observer = -2,
            Random = -1,
            USA = 2,
            China = 3,
            GLA = 4,
            SWG = 5,
            Laser = 6,
            Air = 7,
            Tank = 8,
            Inf = 9,
            Nuke = 10,
            Tox = 11,
            Demo = 12,
            Stealth = 13,
            Boss = 14
        }

        public enum EnumColors
        {
            Random = -1,
            Gold = 0,
            Red = 1,
            Blue = 2,
            Green = 3,
            Orange = 4,
            Cyan = 5,
            Purple = 6,
            Pink = 7
        }

        public enum EnumTeams
        {
            None = -1,
            Team1 = 0,
            Team2 = 1,
            Team3 = 2,
            Team4 = 3,
        }

        public GenTab()
        {

            InitializeComponent();
            //label1.Text = "# Color  Armies    Players      Teams  Money   Energy Rank";
            CheckForIllegalCrossThreadCalls = false;// Разрешить управление другими потоками
            CheckForGameThread.RunWorkerAsync();
            OperateWithStreamGUI.RunWorkerAsync();
        }

        private void CheckForGameThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                game = GetGameProc();
                if (game != null)
                {
                    if (GenTabStuff.isinomatch)
                    {
                        GameInfo.Text = "Now displaying match info.";
                        Modifier.Enabled = false;
                    }
                    else
                    {
                        if (!Hooked)
                        {
                            GameInfo.Text = "Generals Runnings, PID:" + game.Id;
                            Modifier.Enabled = true;
                        }
                        else
                        {
                            GameInfo.Text = "Waiting for match start";
                            Modifier.Enabled = false;
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (OperateWithGensThread.IsBusy)
                            OperateWithGensThread.CancelAsync();
                        GameInfo.Text = "Generals not running";
                        Hooked = false;
                        Modifier.Enabled = false;
                        processHandle = (IntPtr)0;
                    }
                    catch (Exception excc) { }
                }
            }
        }


        private void Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                processHandle = OpenProcess(0x1F0FFF, false, game.Id);

                if (processHandle == (IntPtr)0)
                {
                    MessageBox.Show("Cannot handle game!");
                    return;
                }

                Hooked = true;
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
            OperateWithGensThread.RunWorkerAsync();

        }
        public static Process GetGameProc() // найти процесс игры
        {
            Process[] processes = Process.GetProcessesByName("game.dat");
            if (processes.Count() >= 1)
            {
                isgenerals = false;
                return processes[0];
            }
            processes = Process.GetProcessesByName("generals");
            if (processes.Count() >= 1)
            {
                if (processes[0].PagedMemorySize64 > 50000000)
                {
                    isgenerals = true;
                    return processes[0];
                }
                else
                    return null;
            }
            else
                return null;
        }


        public static byte[] StringToByteArray(string hex) // Строку в HEX переводим в BYTE Array
        {
            hex = hex.Replace(" ", "");
            hex = hex.Replace("-", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        static string lastname = "";
        private void OperateWithGensThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(500);
                GenTabStuff.GenTabMain(processHandle);
                lastname = GenTabStuff.players[1];
                Players.Items.Clear();
                Players.Items.Add("# Color  Armies    Players      Teams  Money   Energy Rank");
                for (int i = 1; i < 9; i++)
                    Players.Items.Add(i + " " + ((EnumColors)GenTabStuff.colors[i - 1]).ToString().PadRight(6) + " " + ((EnumGenerals)GenTabStuff.armies[i - 1]).ToString().PadRight(10) + (GenTabStuff.players[i - 1] + "").PadRight(12) + " " + ((EnumTeams)GenTabStuff.teams[i - 1]).ToString().Replace("Team", "Team ").PadRight(6) + " " + GenTabStuff.money[i - 1].ToString().PadRight(8) + GenTabStuff.energy[i - 1].ToString().PadRight(6) + " " + GenTabStuff.rank[i - 1]).ToString().PadRight(4);
            }
        }

        private void GenTab_Load(object sender, EventArgs e)
        {
            SetProcessDPIAware();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settingsform = new Settings();
            Settingsform.Show();


        }

        public static bool TournamentCheckBox = false;
        public static string[] TournamentNickName = new string[] { "", "" };
        public static int[] TournamentCounters = new int[] { 0, 0 };
        public static int[] TournamentColors = new int[2];
        public static string[] TournamentGenerals = new string[] { "", "" };

        private void OperateWithStreamGUI_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(100);

            }
        }


        private void Player2Plus_Click(object sender, EventArgs e)
        {
            TournamentCounters[1]++;
        }

        private void Player2Minus_Click(object sender, EventArgs e)
        {
            if (TournamentCounters[1] != 0)
                TournamentCounters[1]--;
        }

        private void Player1Plus_Click(object sender, EventArgs e)
        {
            TournamentCounters[0]++;
        }

        private void Player1Minus_Click(object sender, EventArgs e)
        {
            if (TournamentCounters[0] != 0)
                TournamentCounters[0]--;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GUI1v1_Click(object sender, EventArgs e)
        {
            TournamentNickName[0] = textBox1.Text;
            TournamentNickName[1] = textBox2.Text;
            new Menu2players().Show();
        }
    }
}
