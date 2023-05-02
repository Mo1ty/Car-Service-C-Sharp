using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarServiceApp.Pages.parse
{
    public static class Pars
    {

        public static void parseID()
        {
            string fullSTR = Clipboard.GetText();
            string[] elements = fullSTR.Split(' ');
            Clipboard.SetText(elements[0]);
        }
        public static string parseIDNoCB(string a)
        {
            string[] elements = a.Split(' ');
            return elements[0];
        }
    }
}
