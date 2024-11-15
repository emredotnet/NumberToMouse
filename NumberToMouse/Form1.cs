using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberToMouse
{
    public partial class Form1 : Form
    {
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static int sens;
        private static bool moveUp, moveDown, moveLeft, moveRight;
        private static bool leftClick, rightClick;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSens(500);
            trackBar1.Value = sens;
            _hookID = SetHook(_proc);
            Task.Run(() => MoveMouseContinuously());
            label2.Text = "Up => Numpad5\nDown => Numpad2\nLeft => Numpad1\nRight => Numpad3\nLeftClick => Numpad4\nRightClick => Numpad6\nCreated By Github: emredotnet";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (vkCode == (int)Keys.NumPad5) // Numpad5 -> Move Up
                    {
                        moveUp = true;
                        return (IntPtr)1;
                    }
                    if (vkCode == (int)Keys.NumPad2) // Numpad2 -> Move Down
                    {
                        moveDown = true;
                        return (IntPtr)1;
                    }
                    if (vkCode == (int)Keys.NumPad1) // Numpad1 -> Move Left
                    {
                        moveLeft = true;
                        return (IntPtr)1;
                    }
                    if (vkCode == (int)Keys.NumPad3) // Numpad3 -> Move Right
                    {
                        moveRight = true;
                        return (IntPtr)1;
                    }
                    if (vkCode == (int)Keys.NumPad4) // Numpad4 -> Left Click
                    {
                        leftClick = true;
                        return (IntPtr)1;
                    }
                    if (vkCode == (int)Keys.NumPad6) // Numpad6 -> Right Click
                    {
                        rightClick = true;
                        return (IntPtr)1;
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    if (vkCode == (int)Keys.NumPad5)
                        moveUp = false;
                    if (vkCode == (int)Keys.NumPad2)
                        moveDown = false;
                    if (vkCode == (int)Keys.NumPad1)
                        moveLeft = false;
                    if (vkCode == (int)Keys.NumPad3)
                        moveRight = false;
                    if (vkCode == (int)Keys.NumPad4)
                        leftClick = false;
                    if (vkCode == (int)Keys.NumPad6)
                        rightClick = false;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static void MoveMouseContinuously()
        {
            while (true)
            {
                if (moveUp || moveDown || moveLeft || moveRight || leftClick || rightClick)
                {
                    Point currentPos = Cursor.Position;

                    if (moveUp) currentPos.Y -= 1;
                    if (moveDown) currentPos.Y += 1;
                    if (moveLeft) currentPos.X -= 1;
                    if (moveRight) currentPos.X += 1;

                    Cursor.Position = currentPos;

                    if (leftClick)
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        leftClick = false;
                    }

                    if (rightClick)
                    {
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        rightClick = false;
                    }
                }

                Thread.Sleep(1000 / sens);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SetSens(trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetSens(500);
            trackBar1.Value = sens;
        }

        void SetSens(int value)
        {
            sens = value;
            label1.Text = $"sensivity : {sens}";
        }
    }
}
