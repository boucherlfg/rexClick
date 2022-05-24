using System;
using System.Runtime.InteropServices;

namespace Rex.Hooks
{
    public static class Screen
    {
        public enum MonitorState
        {
            On = -1,
            Off = 2,
            Standby = 1
        }
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        // The two dll imports below will handle the window hiding.

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);


        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static IntPtr handle = GetConsoleWindow();

        public static void HideWindow()
        {
            ShowWindow(handle, SW_HIDE);
        }
        public static void ShowWindow()
        {
            ShowWindow(handle, SW_SHOW);
        }

        public static void SetMonitorState(bool state)
        {
            var s = state ? MonitorState.On : MonitorState.Off;
            SendMessage(0xFFFF, 0x112, 0xF170, (int)s);
        }
        public static int MonitorCount
        {
            get
            {
                int monCount = 0;
                MonitorEnumProc callback = (IntPtr hDesktop, IntPtr hdc, ref Rect prect, int d) => ++monCount > 0;
                EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, callback, 0);
                return monCount;
            }
        }

        [DllImport("user32")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lpRect, MonitorEnumProc callback, int dwData);

        private delegate bool MonitorEnumProc(IntPtr hDesktop, IntPtr hdc, ref Rect pRect, int dwData);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}