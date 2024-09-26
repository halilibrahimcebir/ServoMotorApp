using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ServoControlApp.exoskeleton;

namespace ServoControlApp
{

    public static class cls_gamepad
    {
       
        [DllImport("winmm.dll")]
        public static extern int joyGetNumDevs();

        [DllImport("winmm.dll")]
        public static extern int joyGetPosEx(int uJoyID, ref JOYINFOEX pji);
        public struct JOYINFOEX
        {
            public uint dwSize;
            public uint dwFlags;
            public uint dwXpos;
            public uint dwYpos;
            public uint dwZpos;
            public uint dwRpos;
            public uint dwUpos;
            public uint dwVpos;
            public uint dwButtons;
            public uint dwButtonNumber;
            public uint dwPOV;
            public uint dwReserved1;
            public uint dwReserved2;
        }
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x04;
        public static void Gamepad_Reader()
        {
            int numDevices = joyGetNumDevs();
            Console.WriteLine("Bağlı joystick sayısı: " + numDevices);
            
          
            // Joystick verilerini almak için bir döngü başlatın
            while (!exoskeleton.b_FormClosing)
            {
                // Joystick verilerini almak için JOYINFOEX yapısı oluşturun
                JOYINFOEX joyInfo = new JOYINFOEX();
                joyInfo.dwSize = (uint)Marshal.SizeOf(typeof(JOYINFOEX));
                joyInfo.dwFlags = 0x1FF;

                // İlk joystick cihazı için verileri al
                if (joyGetPosEx(0, ref joyInfo) == 0)
                {
                    // Joystick pozisyonlarını yazdır
                    Console.WriteLine("X: " + joyInfo.dwXpos);
                    Console.WriteLine("Y: " + joyInfo.dwYpos);
                    cls_gamepad_cursor.dwXpos =Convert.ToInt16( joyInfo.dwXpos);

                    cls_gamepad_cursor.dwYpos = Convert.ToInt16(joyInfo.dwYpos);

                    Console.WriteLine("Z: " + joyInfo.dwZpos);
                    Console.WriteLine("Buttons: " + joyInfo.dwButtons);
                    Console.WriteLine("POV: " + joyInfo.dwPOV);
                    switch (joyInfo.dwPOV)
                    {
                        case 0:
                            SendKeys.SendWait("{UP}");   // Yukarı yön tuşu
                        Thread.Sleep(120);                           // Thread.Sleep(1000);
                            break;
                        case 18000:
                            SendKeys.SendWait("{DOWN}"); // Aşağı yön tuşu
                            Thread.Sleep(120);                          //  Thread.Sleep(1000);
                            break;
                        case 27000:
                            SendKeys.SendWait("{LEFT}"); // Sol yön tuşu
                            Thread.Sleep(120);                         //  Thread.Sleep(1000);
                            break;
                        case 9000:
                            SendKeys.SendWait("{RIGHT}");// Sağ yön tuşu
                            Thread.Sleep(120);                           //  Thread.Sleep(1000);
                            break;

                    }

                    switch (joyInfo.dwButtons)
                    {
                        case 0:
                            MouseClickRemoved();
                            break;
                        case 4:

                            MouseClick();
                            Thread.Sleep(120);
                            break;
                        case 32:
                            SendKeys.SendWait("{TAB}");// Sağ yön tuşu
                            Thread.Sleep(120);
                            break;
                        case 128:
                          //  Process.Start(@"C:\\Windows\System32\osk.exe");

                            Console.WriteLine("Sanal klavye açıldı.");
                            break;

                        case 8:
                            //  Process.Start(@"C:\\Windows\System32\osk.exe");
                            SendKeys.SendWait("{ENTER}");// Sağ yön tuşu
                            Console.WriteLine("Sanal klavye açıldı.");
                            break;
                    }

                    // Küçük bir gecikme ekle
                    System.Threading.Thread.Sleep(70);
                }
            }
        }
        static void MouseClick()
        {
            // Sol tuşa basılı olduğunu simüle et
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            Thread.Sleep(100); // Küçük bir bekleme süresi ekleyerek tıklamanın daha belirgin olmasını sağla
                               // Sol tuşa basılı olmadığını simüle et
           
        }
        static void MouseClickRemoved()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }



    }
}
