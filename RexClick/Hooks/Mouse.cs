using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rex.Hooks
{
    public class Mouse
    {
        delegate void DoStuff(string stuff);
        public static bool block;
        public static BUTTON now;
        public enum BUTTON
        {
            LEFTDOWN = 0,
            LEFTUP = 1,
            RIGHTDOWN = 2,
            RIGHTUP = 3,
            MOUSEWHEEL = 4,
            MOUSEMOVE = 5
        }

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public static void Hook()
        {
            block = false;
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                switch ((MouseMessages)wParam)
                {
                    case MouseMessages.WM_LBUTTONDOWN:
                        now = BUTTON.LEFTDOWN;
                        break;
                    case MouseMessages.WM_LBUTTONUP:
                        now = BUTTON.LEFTUP;
                        break;
                    case MouseMessages.WM_RBUTTONDOWN:
                        now = BUTTON.RIGHTDOWN;
                        break;
                    case MouseMessages.WM_RBUTTONUP:
                        now = BUTTON.RIGHTUP;
                        break;
                    case MouseMessages.WM_MOUSEWHEEL:
                        now = BUTTON.MOUSEWHEEL;
                        break;
                    case MouseMessages.WM_MOUSEMOVE:
                        now = BUTTON.MOUSEMOVE;
                        break;
                }
            }
            if (!block)
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            else
                return (IntPtr)1;
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        /// <summary>
        /// bouton gauche de la souris enfoncé
        /// </summary>
        public static void LeftDown()
        {
            //Mouse actions
            uint MOUSEEVENTF_LEFTDOWN = 0x02;
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        }
        /// <summary>
        /// bouton gauche de la souris désenfoncé
        /// </summary>
        public static void LeftUp()
        {
            uint MOUSEEVENTF_LEFTUP = 0x04;
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        /// <summary>
        /// bouton droit de la souris enfoncé
        /// </summary>
        public static void RightDown()
        {
            uint MOUSEEVENTF_RIGHTDOWN = 0x08;
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN, X, Y, 0, 0);
        }
        /// <summary>
        /// bouton droit de la souris désenfoncé
        /// </summary>
        public static void RightUp()
        {
            uint MOUSEEVENTF_RIGHTUP = 0x10;
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }

        #region dllimports
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        static extern int ShowCursor(bool bShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
}