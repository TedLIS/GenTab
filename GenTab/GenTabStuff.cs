using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
namespace GenTab
{
    public class GenTabStuff
    {
        public static string[] players = new string[8];
        public static int[] armies = new int[8];
        public static int[] colors = new int[8];
        public static int[] teams = new int[8];
        public static int[] money = new int[8];
        public static int[] energy = new int[8];
        public static int[] rank = new int[8];
        public static string player_name = "";

        static int pbase = 0;
        static uint readed = 0;
        public static string playerownername = "";
        public static bool isinomatch = false;


        public static void GenTabMain(IntPtr processHandle)
        {

            if (getaddrfromptr("00A47F64") == 0)
            {
                isinomatch = false;
            }
            else if (getaddrfromptr("00A47F64") == 1)
            {
                isinomatch = true;
            }

            
            getplayerarmies();
            getplayercolors();
            getplayernames();
            getplayermoney();
            getplayerenergy();
            getplayerrank();
            getplayerteams();
            if (isinomatch)
            {
                getplayername();
            }
            else
            {
                
            }
        }

        static void getplayermoney()
        {
            string playermonyebase = "00A2BAA0";
            for (int i = 0; i < 8; i++)
                money[i] = getaddrfromptr("", getaddrfromptr("", getaddrfromptr(playermonyebase) + 12 + (i * 4)) + 56);
        }

        static void getplayerenergy()
        {
            string playerenergybase = "00A2BAA0";
            for (int i = 0; i < 8; i++)

                energy[i] = GetValFromMulOffsets(playerenergybase, new int[] { 12 + (i * 4), 132 });
        }

        static void getplayerrank()
        {
            string playerrankbase = "00A2BAA0";
            for (int i = 0; i < 8; i++)

                rank[i] = GetValFromMulOffsets(playerrankbase, new int[] { 12 + (i * 4), 396 });
        }

        static void getplayernames()
        {
            string playernamesbase = "00A2C2B8";
            players[0] = getstringfromaddr(GetValFromMulOffsets(playernamesbase, new int[] { 20, 40 }) + 4, 32);
            players[1] = getstringfromaddr(GetValFromMulOffsets(playernamesbase, new int[] { 232 }) + 4, 32);
            players[2] = getstringfromaddr(GetValFromMulOffsets(playernamesbase, new int[] { 20, 232 }) + 4, 32);
            for (int i = 0; i < 5; i++)
                players[3 + i] = getstringfromaddr(GetValFromMulOffsets(playernamesbase, new int[] { 28 + (i * 4), 136 }) + 4, 32);
        }

        static void getplayerarmies()
        {
            string playerarmybase = "00A2E0EC"; // 00A2E064
            for (int i = 0; i < 8; i++)
                armies[i] = GetValFromMulOffsets(playerarmybase, new int[] { 60, 116 + (96 * i) });
        }

        static void getplayercolors()
        {
            string playerarmybase = "00A2E0EC";
            for (int i = 0; i < 8; i++)
                colors[i] = GetValFromMulOffsets(playerarmybase, new int[] { 60, 108 + (96 * i) });
        }

        static void getplayername()
        {
            string playernamebase = "0053C224";
            player_name = getstringfromaddr(GetValFromMulOffsets(playernamebase, new int[] { 1604, 40 }) + 3788, 32);

        }

        static void getplayerteams()
        {
            string playerarmybase = "00A2E0EC";
            for (int i = 0; i < 8; i++)
                teams[i] = GetValFromMulOffsets(playerarmybase, new int[] { 60, 120 + (96 * i) });
        }

        static int GetValFromMulOffsets(string basehex, int[] offs)
        {
            int val = getaddrfromptr(basehex);
            
            for (int i = 0; i < offs.Length; i++)
            {
                val = getaddrfromptr("", val + offs[i]);
            }
            return val;
        }

        static string getstringfromaddr(int addr, int size)
        {
            byte[] buf = new byte[32];
            GenTab.ReadProcessMemory(GenTab.processHandle, (IntPtr)addr, buf, 32, ref readed);
            playerownername = Encoding.Unicode.GetString(buf);

            bool nullchar = false;
            int lengt = 0;
            for (int i = 0; i < 31; i++)
            {
                if (nullchar)
                {
                    buf[i] = 0;
                }
                else
                if (buf[i] == 0 && buf[i + 1] == 0)
                {
                    lengt = i + 1;
                    buf[i] = 0;
                    nullchar = true;
                }
            }
            byte[] newline = new byte[lengt];
            for (int i = 0; i < lengt; i++)
            {
                newline[i] = buf[i];
            }
            string output = Encoding.Unicode.GetString(newline);
            return output;
        }

        static int getaddrfromptr(string hexaddr = "", int addr = 0)
        {
            
            byte[] buf = new byte[4];
            if (addr == 0)
            {
                int add = 0;
                if (GenTab.isgenerals)
                    add = 136;
                GenTab.ReadProcessMemory(GenTab.processHandle, (IntPtr)(int.Parse(hexaddr, System.Globalization.NumberStyles.HexNumber) - add), buf, 4, ref readed);
            }
            else
                GenTab.ReadProcessMemory(GenTab.processHandle, (IntPtr)(addr), buf, 4, ref readed);
            int ret = BitConverter.ToInt32(buf, 0);
            return ret;
        }
        
    }
}
