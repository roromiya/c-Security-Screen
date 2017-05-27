using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;

namespace mook_SecurityScreen
{
    public partial class Form1 : Form
    {
        Rectangle fullScreen = Screen.PrimaryScreen.Bounds;
        int mXStart = 0;
        int mYStart = 0;
        bool LKTime = true;
        Random r = new Random();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProc Ipfn, IntPtr hMod, uint dwThredId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(int hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CallNextHookEx(int hhk, int nCode, int wParan, ref KBDLLHOOKSTRUCT IParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModulHndle(string IpModulName);

        public struct KBDLLHOOKSTRUCT
        {

            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static int _hookID = 0;
        public int frm2_hookID = 0;
        private delegate int LowLevelKeyboardProc(int nCode, int wParm, ref KBDLLHOOKSTRUCT IParam);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Timer.Enabled = true;
            this.LockTimer.Enabled = true;
            LKTime = true;
            Cursor.Hide();
            KillCtrlAltDelete();
            _hookID = SetHook(_proc);
            frm2_hookID = _hookID;
        }

        public static void KillCtrlAltDelete()
        {
            RegistryKey regkey;
            string keyValueInt = "1";
            string subKey = "Software\\Microsoft\\Windwos\\CurrentVersion\\Policies\\System";

            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt);
                regkey.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static int SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModulHndle(curModule.ModuleName), 0);
            }
        }

        private static int HookCallback(int nCode, int wParam, ref KBDLLHOOKSTRUCT IParam)
        {
            bool bReturn = false;
            switch(wParam)
            {
                case WM_KEYDOWN:
                case WM_KEYUP:
                case WM_SYSKEYDOWN:
                case WM_SYSKEYUP:bReturn = ((IParam.vkCode == 0x09) && (IParam.flags == 0x20)) || ((IParam.vkCode == 0x1B) && (IParam.flags == 0x20)) || ((IParam.vkCode == 0x1B) && (IParam.flags == 0x00)) || ((IParam.vkCode == 0x5B) && (IParam.flags == 0x01)) || ((IParam.vkCode == 0x5C) && (IParam.flags == 0x01)) || ((IParam.vkCode == 0x73) && (IParam.flags == 0x20));
                break;
            }
            if (bReturn == true)
                return 1;
            else
                return CallNextHookEx(0, nCode, wParam, ref IParam);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var w = r.Next(0, fullScreen.Width - 50);
            var h = r.Next(0, fullScreen.Height - 50);
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 10);
            Rectangle rectC = new Rectangle(1 * w, 1 * h, 100, 100);
            g.DrawArc(p, rectC, 0, 365);
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            LKTime = false;
            this.LockTimer.Enabled = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            StopScreenSaver();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            StopScreenSaver();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            StopScreenSaver();
        }

        private void StopScreenSaver()
        {
            if(LKTime == true)
            {
                Cursor.Show();
                Timer.Enabled = false;
                UnhookWindowsHookEx(_hookID);
                EnableCtrlAltDel();
                Application.Exit();
            }
            else
            {
                Cursor.Show();
                Form2 frm2 = new Form2();
                if(frm2.ShowDialog() == DialogResult.OK)
                {
                    mXStart = 0;
                    mYStart = 0;
                }
            }
        }

        public void EnableCtrlAltDel()
        {
            try
            {
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);

                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if((mXStart==0)&&(mYStart==0))
            {
                mXStart = e.X;
                mYStart = e.Y;
                return;
            }
            else if((e.X != mXStart)||(e.Y != mYStart))
                {
                StopScreenSaver();
            }
        }
    }
}
