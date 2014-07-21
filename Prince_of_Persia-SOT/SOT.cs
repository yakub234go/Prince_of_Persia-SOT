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
using System.Media;

namespace Prince_of_Persia_SOT
{
    public partial class SOT : Form
    {
        public SOT()
        {
            InitializeComponent();
            timer1.Start();
        }

        SoundPlayer splay;
        Process[] processes;
        public void inf_h()
        {
            using (CheatEngine.Memory memory = new CheatEngine.Memory(processes[0]))
            {
                try
                {
                    IntPtr address1 = memory.GetAddress("POP.exe", (IntPtr)0x006DD0C8, new int[] { 0x33c, 0x234, 0x44, 0x19c });
                    uint health = 200;
                    memory.WriteUInt32(address1, health);
                }
                catch (SystemException se)
                {
                    Debug.WriteLine(se.ToString());
                }
            }
        }

        public void inf_r()
        {
            using (CheatEngine.Memory memory = new CheatEngine.Memory(processes[0]))
            {
                try
                {
                    IntPtr address1 = memory.GetAddress("POP.exe", (IntPtr)0x006DB4DC, new int[] { 0x30 });
                    IntPtr address2 = memory.GetAddress("POP.exe", (IntPtr)0x006EE74C, new int[] { 0x214, 0x19c, 0x218 });
                    uint rewindcloud = 10;
                    uint rewind = 9000000;
                    memory.WriteUInt32(address1, rewindcloud);
                    memory.WriteUInt32(address2, rewind);
                }
                catch (SystemException se)
                {
                    Debug.WriteLine(se.ToString());
                }
            }
        }

        public void inf_s()
        {
            using (CheatEngine.Memory memory = new CheatEngine.Memory(processes[0]))
            {
                try
                {
                    IntPtr address1 = memory.GetAddress("POP.exe", (IntPtr)0x006DB8A4, new int[] { 0x0 });
                    IntPtr address2 = memory.GetAddress("POP.exe", (IntPtr)0x006DB0F0, new int[] { 0x0 });
                    uint slowmotiontank = 10;
                    uint slowmotion = 0;
                    memory.WriteUInt32(address1, slowmotiontank);
                    memory.WriteUInt32(address2, slowmotion);
                }
                catch (SystemException se)
                {
                    Debug.WriteLine(se.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            processes = Process.GetProcessesByName("POP");
            if (processes.Length == 0)
            {
                label11.Text = "The game is not running!";
                label11.ForeColor = Color.Red;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                ghook.unhook();
            }
            else if (processes.Length > 0)
            {
                label11.ForeColor = Color.Green;
                label11.Text = "The game is running";
                if (label4.ForeColor==Color.Red)
                {
                    inf_h();
                }
                if (label6.ForeColor == Color.Red)
                {
                    inf_r();
                }
                if (label10.ForeColor == Color.Red)
                {
                    inf_s();
                }
            }
        }

        GlobalKeyboardHook ghook;
        private void SOT_Load(object sender, EventArgs e)
        {
            ghook = new GlobalKeyboardHook();
            ghook.KeyDown += new KeyEventHandler(ghook_keydown);
            ghook.HookedKeys.Add(Keys.F1);
            ghook.HookedKeys.Add(Keys.F2);
            ghook.HookedKeys.Add(Keys.F3);
            ghook.HookedKeys.Add(Keys.F4);
            ghook.hook();
        }

        string hotkey;
        public void ghook_keydown(object sender, KeyEventArgs e)
        {
            hotkey = e.KeyCode.ToString();
            if (hotkey == "F1")
            {
                if (label4.ForeColor == Color.Black)
                {
                    label3.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                }
                else if (label4.ForeColor == Color.Red)
                {
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                }
                System.Media.SystemSounds.Asterisk.Play();
            }
            if (hotkey == "F2")
            {
                if (label6.ForeColor == Color.Black)
                {
                    label5.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                }
                else if (label6.ForeColor == Color.Red)
                {
                    label5.ForeColor = Color.Black;
                    label6.ForeColor = Color.Black;
                }
                System.Media.SystemSounds.Asterisk.Play();
            }
            if (hotkey == "F3")
            {
                if (label10.ForeColor == Color.Black)
                {
                    label9.ForeColor = Color.Red;
                    label10.ForeColor = Color.Red;
                }
                else if (label10.ForeColor == Color.Red)
                {
                    label9.ForeColor = Color.Black;
                    label10.ForeColor = Color.Black;
                }
                System.Media.SystemSounds.Asterisk.Play();
            }
            if (hotkey == "F4")
            {
                foreach (Label l in tableLayoutPanel1.Controls)
                {
                    l.ForeColor = Color.Black;
                }
            }
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void SOT_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghook.unhook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrainerInstructions.ShowBox("Run the game, Run the trainer\nLoad the game\nPress Hotkey for desired cheat\n\n\nThank You && Happy Gaming", "Trainer Instructions");
            //MessageBox.Show("Run the game, Run the trainer\nLoad the game\nPress Hotkey for desired cheat\n\nThank You & Happy Gaming");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.youtube.com/watch?v=TWUK-fK7xD8");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cheatengine.org/");
        }
    }
}
