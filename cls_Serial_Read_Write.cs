using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServoControlApp
{
    public static class cls_Serial_Read_Write
    {
        public static string str_FreeCode;
        public static string str_AxisModeSet;
        public static string str_ControlModeSet;
        public static string str_InputModeSet;
        public static string str_Velocity_Control;
        public static string str_DriveTrapTraj;
        public static string str_Start_To_Calibration;
        public static string str_updateconfig;
        public static string StatsusData_Write;
        public static string StatusData_Read;
        public static string str_GraphCommand;
        public static string Deneme_gelen_data;
       
        public static bool b_For_Graph;
        public static bool b_For_Config;
        public static bool b_Free_Code;
   
        public static bool b_AxisModeSet;
        public static bool b_ControlModeSet;
        public static bool b_InputModeSet;
        public static bool port_Status;
        public static bool b_DriveVelocity;
        public static bool b_DriveTrapTraj;
        public static bool b_For_Velocity_Control;
        public static bool b_EventStaring;
        public static bool b_SerialReaded;
        public static int i_Total_Packet_Must_Be = 0;
        public static int i_Total_Packet_Size_rece = 0;
        public static int i_ReadedDataSize;


        public static int Tried_Transfer;
        public static bool b_ScanErr;
        public static int i_MotorNum;
        public static void SerailWrite()
        {
            Console.WriteLine("serial");

            int NoReply = 0;






            if (Tried_Transfer > 2)
            {
                cls_SerialCom.ServoMotor.Write("sr" + "\n");
                Tried_Transfer = 0;
                exoskeleton.str_ErrorCode += "Rebooting" + "\n";
                Console.WriteLine("Rebooting");


            }
            else
            {
               b_SerialReaded = true;
            }
            while (!exoskeleton.b_FormClosing)
            {
                string str_TrapTrajInfo = "r axis" + i_MotorNum.ToString() + ".trap_traj.config.vel_limit" + "\n" + "r axis" + i_MotorNum.ToString() + ".trap_traj.config.accel_limit" + "\n" + "r axis" + i_MotorNum.ToString() + ".trap_traj.config.decel_limit" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.inertia";
                string str_Std_code = "r axis" + i_MotorNum.ToString() + ".motor.current_control.Iq_setpoint" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.pos_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.vel_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.control_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.input_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".current_state" + "\n";
                /*  if (exoskeleton.MasterMot==1)
                  {
                       str_Std_code = "r axis" + i_MotorNum.ToString() + ".motor.current_control.Iq_setpoint" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.pos_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.vel_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.control_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.input_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".current_state" + "\n"+ "w axis1.controller.input_pos " + "axis" + i_MotorNum.ToString() + ".encoder.pos_estimate" + "\n";

                  }
                  else if(exoskeleton.MasterMot == 2)
                  {
                       str_Std_code = "r axis" + i_MotorNum.ToString() + ".motor.current_control.Iq_setpoint" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.pos_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".encoder.vel_estimate" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.control_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.input_mode" + "\n" + "r axis" + i_MotorNum.ToString() + ".current_state" + "\n" + "w axis0.controller.input_pos " + "axis" + i_MotorNum.ToString() + ".encoder.pos_estimate" + "\n";

                  }*/
                string str_ForConfigData = "r axis" + i_MotorNum.ToString() + ".motor.config.current_lim" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.vel_limit" + "\n" + "r axis" + i_MotorNum.ToString() + ".controller.config.vel_ramp_rate" + "\n" + "r axis" + i_MotorNum.ToString() + ".motor.config.torque_constant";
                string str_ScanErr = "r axis" + i_MotorNum.ToString() + ".error" + "\n" + "r axis" + i_MotorNum.ToString() + ".motor.error" + " \n" + "r axis" + i_MotorNum.ToString() + ".encoder.error" + " \n" + "r axis" + i_MotorNum.ToString() + ".controller.error" + "\n";

                // Thread.Sleep(100);
                //Console.WriteLine("write ");


                if (!cls_SerialCom.ServoMotor.IsOpen)
                {
                    // ServoMotor.Close();
                    exoskeleton.str_ErrorCode += "Err 4" + "\n";
                    Console.WriteLine("Err 4");
                    break;
                }
                try

                {

                    if (b_SerialReaded)
                    {
                        NoReply = 0;
                     i_Total_Packet_Size_rece = 0;
                        b_SerialReaded = false;
                        if (b_Free_Code)
                        {
                            cls_SerialCom.ServoMotor.Write(str_Std_code + str_FreeCode + "\n");
                            str_FreeCode = null;

                        i_Total_Packet_Must_Be = 6;

                        }
                        else if (b_For_Config)
                        {



                            if (str_updateconfig != null)
                            {
                                cls_SerialCom.ServoMotor.Write(str_updateconfig + "\n");
                                str_updateconfig = null;


                                exoskeleton.str_ErrorCode += "Saving" + "\n";
                                cls_SerialCom.ServoMotor.Write("ss" + "\n");

                            }
                            else
                            {

                                Console.WriteLine("writed");
                               i_Total_Packet_Must_Be = 14;
                                Console.WriteLine(str_Std_code + str_TrapTrajInfo + "\n" + str_ForConfigData + "\n");
                                cls_SerialCom.ServoMotor.Write(str_Std_code + str_TrapTrajInfo + "\n" + str_ForConfigData + "\n");
                            }

                        }
                        else if (b_AxisModeSet)
                        {


                            i_Total_Packet_Must_Be = 6;
                            cls_SerialCom.ServoMotor.Write(str_Std_code + str_AxisModeSet);
                            Console.WriteLine("Axis Mode" + str_AxisModeSet);
                        }
                        else if (b_ControlModeSet)
                        {

                            i_Total_Packet_Must_Be = 6;
                            cls_SerialCom.ServoMotor.Write(str_Std_code + str_ControlModeSet);
                            Console.WriteLine("Control Mode" + str_ControlModeSet);
                        }
                        else if (b_InputModeSet)
                        {

                            i_Total_Packet_Must_Be = 6;
                            cls_SerialCom.ServoMotor.Write(str_Std_code + str_InputModeSet);
                            Console.WriteLine("Input Mode" + str_InputModeSet);
                        }
                        else if (b_ScanErr)
                        {
                            i_Total_Packet_Must_Be = 4;
                            Console.WriteLine(str_ScanErr);
                            cls_SerialCom.ServoMotor.Write(str_ScanErr);
                        }
                        else
                        {
                            Console.WriteLine(str_Std_code);
                            i_Total_Packet_Must_Be = 6;
                            cls_SerialCom.ServoMotor.Write(str_Std_code);
                        }

                    }
                    else
                    {
                        NoReply = NoReply + 1;
                        Thread.Sleep(500);




                        Console.WriteLine("Err Cevap Bekleniyor");
                        if (NoReply > 6)
                        {
                            Console.WriteLine("Err 5");
                            exoskeleton.str_ErrorCode += "Err 5" + "\n";
                            cls_SerialCom.ServoMotor.Close();
                            Tried_Transfer = Tried_Transfer + 1;
                            NoReply = 0;
                        }
                    }
                    if (!cls_SerialCom.ServoMotor.IsOpen)
                    {
                        b_SerialReaded = false;

                        Console.WriteLine("Err 4");
                        exoskeleton.str_ErrorCode += "Err 4" + "\n";
                        break;

                    }

                }

                catch (Exception f)
                {
                    if (cls_SerialCom.ServoMotor.IsOpen)
                    {
                        cls_SerialCom.ServoMotor.Close();
                        b_SerialReaded = false;
                        exoskeleton.str_ErrorCode += "Err 6" + "\n";
                        Console.WriteLine("Err 6");
                        break;

                    }
                }



            }







        


        }
        public static void SerialRead(object sender, EventArgs e)
        {









            if (cls_SerialCom.ServoMotor.IsOpen && !b_SerialReaded)
            {
                try
                {
                    i_ReadedDataSize = cls_SerialCom.ServoMotor.BytesToRead;
                    byte[] byt_ReaddedData = new byte[i_ReadedDataSize];

                    string[] DatasData;
                    // byte[] byt_ReaddedData = new byte[i_ReadedDataSize];
                    if (i_ReadedDataSize > 0)
                    {
                        cls_SerialCom.ServoMotor.Read(byt_ReaddedData, 0, i_ReadedDataSize);
                        Console.WriteLine(System.Text.Encoding.ASCII.GetString(byt_ReaddedData));
                        Deneme_gelen_data = System.Text.Encoding.ASCII.GetString(byt_ReaddedData);
                        foreach (var a in byt_ReaddedData)
                        {
                            string r = a.ToString();


                        }

                        Console.WriteLine(Deneme_gelen_data);
                        cls_RejectData.noluyo += Deneme_gelen_data;
                        DatasData = Deneme_gelen_data.Split('\n');
                        i_Total_Packet_Size_rece = (DatasData.Length - 1) + i_Total_Packet_Size_rece;

                        if (i_Total_Packet_Size_rece == i_Total_Packet_Must_Be)
                        {

                            cls_RejectData.fncReject_Received_Data();
                            b_SerialReaded = true;
                        }
                        else if (i_Total_Packet_Size_rece > i_Total_Packet_Must_Be)
                        {
                            exoskeleton.str_ErrorCode += "Err 7" + "\n";
                            Console.WriteLine("Err 7");
                            //  ServoMotor.Close();
                        }
                        else
                        {
                            Console.WriteLine("Err 8");
                            exoskeleton.str_ErrorCode += "Err 8" + "\n\r";
                        }
                    }





                }
                catch (Exception f)
                {
                    Console.WriteLine("Err 9");
                    //   ServoMotor.Close();
                    exoskeleton.str_ErrorCode += "Err 9" + "\n";
                }

            }
            else
            {
                Console.WriteLine("Err 10");
                exoskeleton.str_ErrorCode += "Err 10" + "\n";
            }

        }
    }
}
