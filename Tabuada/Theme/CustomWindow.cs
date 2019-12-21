using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace Tabuada.Theme
{
    public class CustomWindow : Window  
    {
        public bool CanMinimize
        {
            get { return (bool)GetValue(CanMinimizeProperty); }
            set { SetValue(CanMinimizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanMinimize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanMinimizeProperty =
            DependencyProperty.Register("CanMinimize", typeof(bool), typeof(CustomWindow), new PropertyMetadata(false));


        private IntPtr handle;

        public CustomWindow()
        {
            this.DataContext = this;

            this.SourceInitialized += (sender, e) =>
            {
                handle = new WindowInteropHelper(this).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WndProc));
            };

            this.DefaultStyleKey = typeof(CustomWindow);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return IntPtr.Zero;
        }

        private void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = NativeMethods.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {
                MONITORINFO monitorInfo = new MONITORINFO();
                NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;

                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            FrameworkElement captionBorder = (FrameworkElement)this.GetTemplateChild("PART_WindowCaption");
            FrameworkElement captionTitle = (FrameworkElement)this.GetTemplateChild("PART_WindowTitle");

            Button buttonClose = this.GetTemplateChild("btnClose") as Button;            
            Button buttonMinimize = this.GetTemplateChild("btnMinimize") as Button;            

            captionBorder.MouseLeftButtonDown += new MouseButtonEventHandler(WindowMove);
            captionTitle.MouseLeftButtonDown += new MouseButtonEventHandler(WindowMove);

            buttonMinimize.Click += new RoutedEventHandler(ButtonbtnMinimize_Click);
            buttonClose.Click += new RoutedEventHandler(ButtonClose_Click);
        }

        private void ButtonbtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
