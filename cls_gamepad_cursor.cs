using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ServoControlApp.cls_gamepad;

namespace ServoControlApp
{
   
    static class cls_gamepad_cursor
    {
        public static int dwXpos;
        public static int dwYpos;
        public static void cursor_pos()
        {
            while(!exoskeleton.b_FormClosing)
            {
                if (dwXpos > 128)
                {
                   
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X + 1, Cursor.Position.Y);
                    

                }
                else if (dwXpos < 128)
                {
                   
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X - 1, Cursor.Position.Y);
                    

                }

                if (dwYpos > 128)
                {

                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X , Cursor.Position.Y+1);


                }
                else if (dwYpos < 128)
                {

                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X - 1, Cursor.Position.Y-1);


                }
                Thread.Sleep(5);
            }
           
        }
    }
}
