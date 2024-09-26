using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ServoControlApp
{
    public class cls_SerialCom
    {
        public static string str_Com_Port;
        public static string str_BoudRate;
        public static string str_StopBit;
        public static string str_parity;
        public static string str_DataBit;
 
        public static bool Serial;
        public static bool Can;



        public static SerialPort ServoMotor = new SerialPort();
       // public static SerialPort driver = new SerialPort();



        public static void SerialOpen()
        {
            /*
                   driver.PortName = "COM3";
            driver.BaudRate = Convert.ToInt32("200000");
            driver.Parity = Parity.None;
            driver.Open();
            */
            
            ServoMotor.PortName = str_Com_Port;
            ServoMotor.BaudRate = Convert.ToInt32(str_BoudRate);
            if (str_parity.Equals("none"))
            {
                ServoMotor.Parity = Parity.None;

            }
            else if (str_parity.Equals("even"))
            {
                ServoMotor.Parity = Parity.Even;

            }
            else if (str_parity.Equals("odd"))
            {
                ServoMotor.Parity = Parity.Odd;

            }
            else if (str_parity.Equals("mark"))
            {
                ServoMotor.Parity = Parity.Mark;

            }

            try
            {
                if (!ServoMotor.IsOpen)
                {
                    ServoMotor.Open();
                    ServoMotor.DiscardOutBuffer();
                    ServoMotor.DiscardInBuffer();
                    exoskeleton.str_ErrorCode += "Connected" + "\n";

                }
            }
            catch (Exception f)
            {

                Console.WriteLine("Err 3");
                exoskeleton.str_ErrorCode += "Err 3" + "\n";

            }

            if (ServoMotor.IsOpen)
            {
                if (!cls_Serial_Read_Write.b_EventStaring)
                {
                    cls_Serial_Read_Write.b_EventStaring = true;
                    if(Serial)
                    {
                        ServoMotor.DataReceived += new SerialDataReceivedEventHandler(cls_Serial_Read_Write.SerialRead);
                        Console.WriteLine("serial event");
                        cls_Serial_Read_Write.SerailWrite();
                    }
                    else if(Can)
                    {
                        Console.WriteLine("can event");
                        ServoMotor.DataReceived += new SerialDataReceivedEventHandler(cls_Can_Read_Write.CanRead);

                    }
                }


                cls_Serial_Read_Write.b_SerialReaded = false;
                cls_Serial_Read_Write.i_Total_Packet_Size_rece = 0;

               
             // cls_Serial_Read_Write.SerailWrite();


            }




        }
       
        /* public  static void ReceiveMessages(object sender, EventArgs e)
         {
             if (ServoMotor.IsOpen)
             {
                 i_ReadedDataSize = ServoMotor.BytesToRead;
               //  byte[] byt_ReaddedData = new byte[i_ReadedDataSize];
                 Console.WriteLine(ServoMotor.BytesToRead);
                 while (true)
                 {

                     if (ServoMotor.BytesToRead >= 8)
                     {
                         byte[] buffer = new byte[i_ReadedDataSize];
                         ServoMotor.Read(buffer, 0, i_ReadedDataSize);

                         int canId = BitConverter.ToInt32(buffer, 0);
                         byte[] data = new byte[4];
                         Array.Copy(buffer, 4, data, 0, 4);

                         Console.WriteLine($"CAN mesajı alındı: ID={canId}, Data={BitConverter.ToString(buffer)}");
                     }
                 }
             }
             else
             {
                 Console.WriteLine("Seri port kapalı. Mesaj alınamıyor.");
             }

         }
         */
     

     }
        
    }

       
    

