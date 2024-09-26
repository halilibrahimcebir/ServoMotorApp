using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServoControlApp
{
    public static class cls_Can_Read_Write
    {

        public static byte[] str_Motr_Err_1 = new byte[] { 0xaa, 0xd8, 03, 02, 00, 00, 00, 00, 00, 00 ,00, 00, 85 };
        public static byte[] str_Encoder_Err_1 = new byte[] { 0xaa, 0xd8, 04, 02, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] str_Sensorless_Err_1 = new byte[] { 0xaa, 0xd8, 05, 02 , 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] GetIq_measured = new byte[] { 0xaa, 0xd8, 0x14, 02, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Sensorless_Estimate_1 = new byte[] { 0xaa, 0xd8, 15, 02, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Encoder_Estimated_1 = new byte[] { 0xaa, 0xd8, 0x009, 02, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Encoder_Count_1 = new byte[] { 0xaa, 0xd8, 0x0a, 02, 00, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Vbus_Voltage_1 = new byte[] { 0xaa, 0xd8, 0X17, 02, 00, 00, 00, 00, 00, 00, 00, 00, 85 };

        public static byte[] Set_Axis_Node_Id_1 = new byte[] { 0xaa, 0xc8, 06, 02 };
        public static byte[] Set_Axis_RequestState_1 = new byte[] { 0xaa, 0xc8, 0x07, 02};
        public static byte[] Set_Controller_Mode_1 = new byte[] { 0xaa, 0xc8, 0x0b, 02 };
        public static byte[] Set_ınput_Pos_1 = new byte[] { 0xaa, 0xc8, 0x0c, 02};
        public static byte[] Set_ınput_Vel_1 = new byte[] { 0xaa, 0xc8, 0x0d, 02};
        public static byte[] Set_ınput_Torque_1 = new byte[] { 0xaa, 0xc8, 0x0e, 02 };
        public static byte[] Set_Vel_Current_lim_1 = new byte[] { 0xaa, 0xc8, 0x0f, 02,};
        public static byte[] Set_Trap_Traj_Vel_lim_1 = new byte[] { 0xaa, 0xc8, 0x11, 02 };
        public static byte[] Set_Trap_Traj_Accel_Dec_lim_1 = new byte[] { 0xaa, 0xc8, 0x12, 02 };
        public static byte[] Set_inertia_1 = new byte[] { 0xaa, 0xc8, 13, 02 };
        public static byte[] Reboot_1 = new byte[] { 0xaa, 0xc8, 0x16, 02 };
        public static byte[] Clear_Error_1 = new byte[] { 0xaa, 0xc8, 18, 02 };
        public static byte[] Set_Vel_Gain_1 = new byte[] { 0xaa, 0xc8, 0x1A, 02 };
        public static byte[] Set_Pos_Gain_1 = new byte[] { 0xaa, 0xc8, 0x1B, 02 };


        public static byte[] str_Motr_Err_2 = new byte[] { 0xaa, 0xd8, 03, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] str_Encoder_Err_2 = new byte[] { 0xaa, 0xd8, 04, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] str_Sensorless_Err_2 = new byte[] { 0xaa, 0xd8, 05, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] GetIq_measured_2 = new byte[] { 0xaa, 0xd8, 0x14, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Encoder_Estimated_2 = new byte[] { 0xaa, 0xd8, 0x09, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Encoder_Count_2 = new byte[] { 0xaa, 0xd8, 0x0a, 03, 00, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Sensorless_Estimate_2 = new byte[] { 0xaa, 0xd8, 05, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };
        public static byte[] Get_Vbus_Voltage_2 = new byte[] { 0xaa, 0xd8, 0X17, 03, 00, 00, 00, 00, 00, 00, 00, 00, 85 };

        public static byte[] Set_Axis_Node_Id_2 = new byte[] { 0xaa, 0xc8, 06, 03 };
        public static byte[] Set_Axis_RequestState_2 = new byte[] { 0xaa, 0xc8, 07, 03 };
        public static byte[] Set_Controller_Mode_2 = new byte[] { 0xaa, 0xc8, 0x0b, 03 };
        public static byte[] Set_ınput_Pos_2 = new byte[] { 0xaa, 0xc8, 0x0c, 03 };
        public static byte[] Set_ınput_Vel_2 = new byte[] { 0xaa, 0xc8, 0x0d, 03 };
        public static byte[] Set_ınput_Torque_2 = new byte[] { 0xaa, 0xc8, 0x0e, 03 };
        public static byte[] Set_Vel_Current_lim_2 = new byte[] { 0xaa, 0xc8, 0x0f, 03 };
        public static byte[] Set_Trap_Traj_Vel_lim_2 = new byte[] { 0xaa, 0xc8, 0x009, 03 };
        public static byte[] Set_Trap_Traj_Accel_Dec_lim_2 = new byte[] { 0xaa, 0xc8, 0x0a, 03 };
        public static byte[] Set_inertia_2 = new byte[] { 0xaa, 0xc8, 0x0a, 03 };
        public static byte[] Reboot_2 = new byte[] { 0xaa, 0xc8, 0x16, 03 };

        public static byte[] Clear_Error_2 = new byte[] { 0xaa, 0xc8, 0x18, 03 };
        public static byte[] Set_Vel_Gain_2 = new byte[] { 0xaa, 0xc8, 0x1A, 03 };
        public static byte[] Set_Pos_Gain_2 = new byte[] { 0xaa, 0xc8, 0x1B, 03 };
        public static int i_ReadedDataSize;
        public static void CanWrite(byte[] command)
        {
            byte[] result = command.Concat(exoskeleton.will_send_data).ToArray();
           
            Console.WriteLine("can wrtited"+ command[0] + command[1]+ command[3] + command[4] + command[5] + command[6] + command[7] + command[8]);
            cls_SerialCom.ServoMotor.Write(command, 0, command.Length);


        }
        public static void CanRead(object sender, EventArgs e)
        {
            
            i_ReadedDataSize = cls_SerialCom.ServoMotor.BytesToRead;
          //  Console.WriteLine("can read" + i_ReadedDataSize.ToString());
            byte[] byt_ReaddedData = new byte[i_ReadedDataSize];
           
            string[] DatasData;
            // byte[] byt_ReaddedData = new byte[i_ReadedDataSize];
            if (i_ReadedDataSize > 0)
            {
                cls_SerialCom.ServoMotor.Read(byt_ReaddedData, 0, i_ReadedDataSize);
                foreach(byte b in byt_ReaddedData)
                {
                 //   Console.WriteLine(b.ToString());
                }
             
               // cls.AddReplyinCantable(byt_ReaddedData);
          //      Console.WriteLine("Reply Reply");
                ConvertHex(byt_ReaddedData);
             
            }

        }
        public static void ConvertHex(byte[] hex_value)
        {
            exoskeleton cls = new exoskeleton();
            int b = 0;
            string[] ReadedCan =new string[100];
           byte[] ReadedCan_byte = new byte[100];
            int Datapoint=0;
            foreach (byte a in hex_value)
            {
                ReadedCan_byte[b] = a;
                b = b + 1;
                if (b==13)
                {
                
                  
                    b = 0;
              
                    cls.AddReplyinCantable(ReadedCan_byte);
               
                }
              

            }
         //   Console.WriteLine(Datapoint.ToString()+"Gelen Toplam Paket Sayısı");
          
         
            // byte[] data_1 = { hex_value[4], hex_value[5], hex_value[6], hex_value[7] };


            //string hexValue=""; // Örnek onaltılık değer: 3.14
            // string hexString_1 = BitConverter.ToString(data_1).Replace("-", "");
            //string hexString_2 = " ";

            // Onaltılık değeri 32 bitlik float türüne dönüştür

        }
        static byte[] HexStringToBytes(string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}
