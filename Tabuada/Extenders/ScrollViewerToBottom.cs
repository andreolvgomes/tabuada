using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tabuada.Extenders
{
    public class ScrollViewerToBottom
    {


        public static bool GetScrollToBottom(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollToBottomProperty);
        }

        public static void SetScrollToBottom(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollToBottomProperty, value);
        }

        // Using a DependencyProperty as the backing store for ScrollToBottom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollToBottomProperty =
            DependencyProperty.RegisterAttached("ScrollToBottom", typeof(bool), typeof(ScrollViewerToBottom), new PropertyMetadata(false, new PropertyChangedCallback(OnPropertyChangedCallback)));

        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Visual visual = (d as Visual);
            if (visual == null) return;
            ScrollViewer scrollViewer = visual.GetFindVisual(typeof(ScrollViewer)) as ScrollViewer;
            if (scrollViewer != null) 
                scrollViewer.ScrollChanged += new ScrollChangedEventHandler(ScrollViewer_ScrollChanged);
        }

        private static void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange > 0) (sender as ScrollViewer).ScrollToBottom();
        }
    }
}
