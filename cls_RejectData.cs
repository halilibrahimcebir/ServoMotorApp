using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoControlApp
{


    public  class cls_RejectData
    {
        public static string[] strA_Received_Data_str = new string[20];
       
        public static int[] iA_bytecount = new int[20];
       public static byte[] ReadedData = new byte[cls_Serial_Read_Write.i_Total_Packet_Size_rece];
        public static string noluyo;
        public static void fncReject_Received_Data()
        {
            if (cls_SerialCom.ServoMotor.IsOpen)
            {


                if (noluyo != null)
                {
                    ReadedData = System.Text.Encoding.ASCII.GetBytes(noluyo);
                    noluyo = null;
                }

               
                int q = 0;
                int lf = -1;
                for (int i = 0; i < ReadedData.Length; i++)
                {
                    // Console.WriteLine(ReadedData[i]);
                    // Received_Data_str[0] += readed[i].ToString();
                    // Console.WriteLine(byt_ReaddedData[i]);
                    if (ReadedData[i] == 10)
                    {

                        //  Console.WriteLine("LF" + i.ToString());
                        q = q + 1;
                        iA_bytecount[q] = (i - lf) - 2;
                        lf = i;



                    }

                }
                
               
                //  Console.WriteLine("bytcoun" + iA_bytecount[3].ToString() + "bytcoun" + iA_bytecount[1].ToString() + "bytcoun" + iA_bytecount[2].ToString());
                byte[] data_1 = new byte[iA_bytecount[1]];
                byte[] data_2 = new byte[iA_bytecount[2]];
                byte[] data_3 = new byte[iA_bytecount[3]];
                byte[] data_4 = new byte[iA_bytecount[4]];
                byte[] data_5 = new byte[iA_bytecount[5]];
                byte[] data_6 = new byte[iA_bytecount[6]];
                byte[] data_7 = new byte[iA_bytecount[7]];
                byte[] data_8 = new byte[iA_bytecount[8]];
                byte[] data_9 = new byte[iA_bytecount[9]];
                byte[] data_10 = new byte[iA_bytecount[10]];
                byte[] data_11 = new byte[iA_bytecount[11]];
                byte[] data_12 = new byte[iA_bytecount[12]];
                byte[] data_13 = new byte[iA_bytecount[13]];
                byte[] data_14 = new byte[iA_bytecount[14]];
                byte[] data_15 = new byte[iA_bytecount[15]];
                int t = 0;
                int k = 0;
             //   Console.WriteLine(ReadedData.Length.ToString() + "byte lenght");

                for (int i = 0; i < ReadedData.Length; i++)
                {
                    if (ReadedData[i] == 10)
                    {
                        t = t + 1;
                        k = 0;
                    }
                    if (ReadedData[i] != 10 && ReadedData[i] != 13)
                    {

                        if (t == 0)
                        {
                            data_1[k] = ReadedData[i];
                           //  Console.WriteLine(data_1[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;

                        }
                        if (t == 1)
                        {
                            data_2[k] = ReadedData[i];
                           //  Console.WriteLine(data_1[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;


                        }
                        if (t == 2)
                        {
                            data_3[k] = ReadedData[i];
                         //    Console.WriteLine(data_1[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;


                        }
                        if (t == 3)
                        {
                            data_4[k] = ReadedData[i];
                            // Console.WriteLine(data_1[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;



                        }
                        if (t == 4)
                        {
                            data_5[k] = ReadedData[i];
                            //  Console.WriteLine(data_4[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;

                        }
                        if (t == 5)
                        {
                            data_6[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;

                        }
                        if (t == 6)
                        {
                            data_7[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;

                        }
                        if (t == 7)
                        {
                            data_8[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;

                        }
                        if (t == 8)
                        {
                            data_9[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }
                        if (t == 9)
                        {
                            data_10[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }
                        if (t == 10)
                        {
                            data_11[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }
                        if (t == 11)
                        {
                            data_12[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }
                        if (t == 12)
                        {
                            data_13[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }
                        if (t == 13)
                        {
                            data_14[k] = ReadedData[i];
                            // Console.WriteLine(data_[k].ToString());
                            //  Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                            k = k + 1;
                        }



                    }


                }

             //   Console.WriteLine(ReadedData.Length.ToString() + "byte lenght");
                strA_Received_Data_str[0] = System.Text.Encoding.ASCII.GetString(data_1);
                strA_Received_Data_str[1] = System.Text.Encoding.ASCII.GetString(data_2);
                strA_Received_Data_str[2] = System.Text.Encoding.ASCII.GetString(data_3);
                strA_Received_Data_str[3] = System.Text.Encoding.ASCII.GetString(data_4);
                strA_Received_Data_str[4] = System.Text.Encoding.ASCII.GetString(data_5);
                strA_Received_Data_str[5] = System.Text.Encoding.ASCII.GetString(data_6);

                strA_Received_Data_str[6] = System.Text.Encoding.ASCII.GetString(data_7);
                strA_Received_Data_str[7] = System.Text.Encoding.ASCII.GetString(data_8);
                strA_Received_Data_str[8] = System.Text.Encoding.ASCII.GetString(data_9);
                strA_Received_Data_str[9] = System.Text.Encoding.ASCII.GetString(data_10);
                strA_Received_Data_str[10] = System.Text.Encoding.ASCII.GetString(data_11);
                strA_Received_Data_str[11] = System.Text.Encoding.ASCII.GetString(data_12);
                strA_Received_Data_str[12] = System.Text.Encoding.ASCII.GetString(data_13);
                strA_Received_Data_str[13] = System.Text.Encoding.ASCII.GetString(data_14);
                strA_Received_Data_str[14] = System.Text.Encoding.ASCII.GetString(data_15);

                Console.WriteLine(strA_Received_Data_str[0]+"data 1");
                Console.WriteLine(strA_Received_Data_str[1]);
                Console.WriteLine(strA_Received_Data_str[2]);
                Console.WriteLine(strA_Received_Data_str[3]);
                Console.WriteLine(strA_Received_Data_str[4]);
                Console.WriteLine(strA_Received_Data_str[5]);
                Console.WriteLine(strA_Received_Data_str[6]);
                Console.WriteLine(strA_Received_Data_str[7]);
                Console.WriteLine(strA_Received_Data_str[8]);
                Console.WriteLine(strA_Received_Data_str[9]);
                Console.WriteLine(strA_Received_Data_str[10]);
                Console.WriteLine(strA_Received_Data_str[11]);
                Console.WriteLine(strA_Received_Data_str[12]);
                Console.WriteLine(strA_Received_Data_str[13]);
                Console.WriteLine(strA_Received_Data_str[14]);




                try
                {
                    if (cls_Serial_Read_Write.b_Free_Code)
                    {

                        exoskeleton.received_value = true;

                        string[] num_1 = new string[2];
                        int z_1 = 0;
                        num_1 = strA_Received_Data_str[0].Split('.');
                        num_1[0] = num_1[0] + ",";
                        foreach (char c in num_1[1])
                        {
                            z_1 = z_1 + 1;
                            if (z_1 < 2)
                            {
                                num_1[0] += c;
                            }
                        }

                        exoskeleton.str_CurrentValue = num_1[0];

                        string[] num_2 = new string[2];
                        int z_2 = 0;
                        num_2 = strA_Received_Data_str[1].Split('.');
                        num_2[0] = num_2[0] + ",";
                        foreach (char c in num_2[1])
                        {
                            z_2 = z_2 + 1;
                            if (z_2 < 2)
                            {
                                num_2[0] += c;
                            }
                        }
                        exoskeleton.str_pos_estimated = num_2[0];




                        string[] num_3 = new string[2];
                        int z_3 = 0;
                        num_3 = strA_Received_Data_str[2].Split('.');
                        num_3[0] = num_3[0] + ",";
                        foreach (char c in num_3[1])
                        {
                            z_3 = z_3 + 1;
                            if (z_3 < 2)
                            {
                                num_3[0] += c;
                            }
                        }
                        exoskeleton.str_Vel_Estimated = num_3[0];



                        exoskeleton.str_ContolMode = strA_Received_Data_str[3];
                        exoskeleton.str_InputMode = strA_Received_Data_str[4];
                        exoskeleton.str_AxisiMode = strA_Received_Data_str[5];
                        exoskeleton.str_Reply_free_prot = strA_Received_Data_str[6];
                        cls_Serial_Read_Write.b_Free_Code = false;



                    }
                    else if (cls_Serial_Read_Write.b_For_Config)
                    {

                        
                             exoskeleton.received_value = true;
                             string[] num_1 = new string[2];
                             int z_1 = 0;
                             num_1 = strA_Received_Data_str[0].Split('.');
                             num_1[0] = num_1[0] + ",";

                             foreach (char c in num_1[1])
                             {
                                 z_1 = z_1 + 1;
                                 if (z_1 < 2)
                                 {
                                     num_1[0] += c;
                                 }
                             }

                             exoskeleton.str_CurrentValue = num_1[0];

                             string[] num_2 = new string[2];
                             int z_2 = 0;
                             num_2 = strA_Received_Data_str[1].Split('.');
                             num_2[0] = num_2[0] + ",";
                             foreach (char c in num_2[1])
                             {
                                 z_2 = z_2 + 1;
                                 if (z_2 < 2)
                                 {
                                     num_2[0] += c;
                                 }
                             }
                             exoskeleton.str_pos_estimated = num_2[0];




                             string[] num_3 = new string[2];
                             int z_3 = 0;
                             num_3 = strA_Received_Data_str[2].Split('.');
                             num_3[0] = num_3[0] + ",";
                             foreach (char c in num_3[1])
                             {
                                 z_3 = z_3 + 1;
                                 if (z_3 < 2)
                                 {
                                     num_3[0] += c;
                                 }
                             }

                             exoskeleton.str_Vel_Estimated = num_3[0];
                        
                        exoskeleton.str_ContolMode = strA_Received_Data_str[3];
                            exoskeleton.str_InputMode = strA_Received_Data_str[4];
                            exoskeleton.str_AxisiMode = strA_Received_Data_str[5];
                        
                        

                        exoskeleton.str_TrapTraj_Vel_lim = strA_Received_Data_str[6];
                            exoskeleton.str_TrapTraj_acc_lim = strA_Received_Data_str[7];
                            exoskeleton.str_TrapTraj_dec_lim = strA_Received_Data_str[8];
                            exoskeleton.str_TrapTraj_inertia = strA_Received_Data_str[9];

                      
                            exoskeleton.i_current_lim = strA_Received_Data_str[10];
                            exoskeleton.i_vel_limit = strA_Received_Data_str[11];
                            exoskeleton.i_ramp_rate = strA_Received_Data_str[12];
                            exoskeleton.i_torque_const = strA_Received_Data_str[13];





                        cls_Serial_Read_Write.b_For_Config = false;





                    }
                    else if (cls_Serial_Read_Write.b_ScanErr)
                    {
                        exoskeleton.received_value = true;
                        exoskeleton.err_General = strA_Received_Data_str[0];
                        exoskeleton.err_Motor = strA_Received_Data_str[1];
                        exoskeleton.err_Encoder = strA_Received_Data_str[2];
                        exoskeleton.err_Controller = strA_Received_Data_str[3];
                        cls_Serial_Read_Write.b_ScanErr = false;
                    }
                    else
                    {
                        exoskeleton.received_value = true;
                        string[] num_1 = new string[2];
                        int z_1 = 0;
                        num_1 = strA_Received_Data_str[0].Split('.');
                        num_1[0] = num_1[0] + ",";
                        foreach (char c in num_1[1])
                        {
                            z_1 = z_1 + 1;
                            if (z_1 < 2)
                            {
                                num_1[0] += c;
                            }
                        }

                        exoskeleton.str_CurrentValue = num_1[0];

                        string[] num_2 = new string[2];
                        int z_2 = 0;
                        num_2 = strA_Received_Data_str[1].Split('.');
                        num_2[0] = num_2[0] + ",";
                        foreach (char c in num_2[1])
                        {
                            z_2 = z_2 + 1;
                            if (z_2 < 2)
                            {
                                num_2[0] += c;
                            }
                        }
                        exoskeleton.str_pos_estimated = num_2[0];
                        Console.WriteLine(num_2[0] + "pos estimated");



                        string[] num_3 = new string[2];
                        int z_3 = 0;
                        num_3 = strA_Received_Data_str[2].Split('.');

                        num_3[0] = num_3[0] + ",";
                        foreach (char c in num_3[1])
                        {
                            z_3 = z_3 + 1;
                            if (z_3 < 2)
                            {
                                num_3[0] += c;
                            }
                        }
                        exoskeleton.str_Vel_Estimated = num_3[0];
                        exoskeleton.str_ContolMode = strA_Received_Data_str[3];
                        exoskeleton.str_InputMode = strA_Received_Data_str[4];
                        exoskeleton.str_AxisiMode = strA_Received_Data_str[5];
                        cls_Serial_Read_Write.b_AxisModeSet = false;
                        cls_Serial_Read_Write.b_ControlModeSet = false;
                        cls_Serial_Read_Write.b_InputModeSet = false;
                        cls_Serial_Read_Write.b_ScanErr = false;
                    }









                }

                catch
                {
                    Console.WriteLine("Err 11");
                }
            }
            


        }

        



    }
}
