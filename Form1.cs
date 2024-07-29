using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Central_Ghost_Pro
{
    public partial class MainWindow : Form
    {
        [DllImport("Gdi32")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public MainWindow()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://discord.gg/jGXF594ANF",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                IntPtr hWnd = FindWindow(null, "Roblox"); // Find the Roblox window
                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd); // Bring the Roblox window to the foreground
                    HoldKeyDown(Keys.LShiftKey); // Hold down the left shift key (sprint in Roblox)
                }
                else
                {
                    MessageBox.Show("Roblox window/process not found.");
                }
            }
            else
            {
                ReleaseKey(Keys.LShiftKey); // Release the left shift key when the checkbox is unchecked
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        static void HoldKeyDown(Keys key)
        {
            byte vk = (byte)key;
            byte scanCode = (byte)MapVirtualKey(vk, 0);
            keybd_event(vk, scanCode, 0, 0);
        }

        static void ReleaseKey(Keys key)
        {
            byte vk = (byte)key;
            byte scanCode = (byte)MapVirtualKey(vk, 0);
            keybd_event(vk, scanCode, KEYEVENTF_KEYUP, 0);
        }

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
namespace Borderlesstest
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

       

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
