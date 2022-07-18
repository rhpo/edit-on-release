using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace editOnRelease
{
    internal class Program
    {
        public static bool isF = false;
        public static bool isLM = false;

        public const string EDIT_KEY = "f"; // Replace f with the key you edit with.
        public const string TOGGLE_HARVESTING_TOOL = "a";  // Replace a with the key toggle the pickaxe with, remove it if you don't want this to be pressed.

        static void Main()
        {
            var hook = Hook.GlobalEvents();
            hook.KeyDown += Hook_KeyDown;
            hook.MouseUp += Hook_MouseUp;
            Application.Run();
            hook.Dispose();
        }
        static void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == EDIT_KEY.ToUpper())
            {
                isF = !isF;
            }
        }
        static void Hook_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLM = true;
            }
            if (isF && isLM)
            {
                SendKeys.SendWait(EDIT_KEY);
                SendKeys.SendWait(TOGGLE_HARVESTING_TOOL);
                isF = isLM = false;
            }
        }
    }
}
