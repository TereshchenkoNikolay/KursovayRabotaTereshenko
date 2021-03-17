using Equipment_accounting.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Equipment_accounting
{
    public class Helper
    {
        public static uchet_evmEntities Connction = new uchet_evmEntities();
        public static users CurrentUser = new users();


        public static void GoNext(Window nextWindow, Window oldWindow)
        {
            nextWindow.Show();
            nextWindow.WindowState = WindowState.Normal;
            oldWindow.Close();

        }

        public static void GoNextM(Window nextWindow, Window oldWindow)
        {
            nextWindow.Show();
            nextWindow.WindowState = WindowState.Maximized;
            oldWindow.Close();
        }
        public static void ShowW(Window nextWindow)
        {
            nextWindow.Show();
            nextWindow.WindowState = WindowState.Normal;
        }
    }
}
