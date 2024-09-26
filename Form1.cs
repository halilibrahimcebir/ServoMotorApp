using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ServoControlApp
{
    public partial class exoskeleton : Form
    {
        public exoskeleton()
        {
            InitializeComponent();


        }
        // public SerialPort SerialClass = new SerialPort();
        public List<double> ListYGraph = new List<double>();
        public int TimeForGrapg = 0;
        public int GraphXMinSize;
        public static bool b_FormClosing;
        public int i_AxisSetting;
        public int i_controlmodesetting;
        public int i_inputModesetting;
        public static string i_vel_limit;
        public static string i_current_lim;
        public static string i_ramp_rate;
        public static string i_torque_const;
        public static string str_Reply_free_prot;
        public static string str_AxisState_cmd;
        public static string str_ControlMode_cmd;
        public static string str_InputMode_cmd;
        public static string str_Driving_cmd;
        public static float Torque_Value;
        public static string str_pos_estimated;
        public static string str_CurrentValue;
        public static string str_Vel_Estimated;
        public static string str_AxisiMode;
        public static string str_ContolMode;
        public static string str_InputMode;
        public static double d_Automatic_Speed;
        public static double d_Automatic_Pos;
        public static bool DriveVelControl;
        public static bool b_Velocity_Control;
        public static bool b_Position_Control;
        public static bool b_DriveWithVel;
        public static bool b_DriveWithPos;
        public static bool b_MotorRun;
        public static bool b_MotorIdle;
        public static bool b_Vel_Ramp;
        public static bool b_Pos_filter;
        public static bool b_Trap_Traj;
        public static bool b_Volcity_Control;
        public static bool POsitionControl;
        public static bool b_Manual_Drive;
        public static bool b_Automatic;
        public static bool Timer_Set;
        public static string str_TrapTraj_Vel_lim;
        public static string str_TrapTraj_acc_lim;
        public static string str_TrapTraj_dec_lim;
        public static string str_TrapTraj_inertia;
        public static string str_TrapTraj_pos_input;
        public static string str_Pos_Value;
        public static string str_vc_vel_pos;
        public static string[] str_Error_Codes = new string[7];
        public static double dbl_position;
        public static bool Dene;
        public static int a = 0;
        public static bool received_value;
        public static string err_General;
        public static string err_Motor;
        public static string err_Encoder;
        public static string err_Controller;
        public static string Drv_Error;
        public static string[] MotorInfo = new string[20];
        public static string str_ErrorCode;
        public static double d_ErrorCode;
        public static bool DriveModeActive;
        public static int Max_Trq;
        public static int Min_Trq;
        public static int MasterMot;
        public static bool BreakIt;
        public static byte[] can_reply;
        public static string value_1 = "";
        public static string value_2 = "";
        public static byte[] will_send_data = new byte[9];
        public static bool TableCAnWrite;
        public static string CanReply_1;
        public static string CanReply_2;
        public static string[] rowvalue = new string[9];
        byte[] willsenddata = new byte[9];
        byte[] willsenddata_Ax1 = new byte[9];
        byte[] pidoutbyte = new byte[9];
        byte[] pidoutbyte_Ax1 = new byte[9];
        public bool Pid_can_work;
        public static float f_TotalTork;
       public static float first= 0;
       public static int second= 0;
        public static float f_Current_Ax0;
        public static float f_Current_Ax1;
        public static float f_Pos_Estimate_Ax0;
        public static float f_Pos_Estimate_Ax1;
        public static float f_Vel_Estimate_Ax0;
        public static float f_Vel_Estimate_Ax1;
        public static float kp;
        public static float kd;
        public static float ki;
        public static float pid_out;
        public static float pid_calc_out=0;
        public static bool Pid_1_Can_Run;
        public static bool Pid_2_Can_Run;

        Stopwatch stopwatch = new Stopwatch();

        private void exoskeleton_Load(object sender, EventArgs e)
        {
            Thread GamePad = new Thread(str_gamepad);
            GamePad.Start();
            Thread crs = new Thread(thrd_cursor);
            crs.Start();
            Thread PID = new Thread(thrd_PID_Control);
            PID.Start();
           Thread PID_Axis1 = new Thread(thrd_PID_Control_ax1);
            PID_Axis1.Start();
            ToolAdder();


        }

        public void str_gamepad()
        {
            //  cls_gamepad.Gamepad_Reader();
        }
        public void thrd_PID_Control_ax1()
        {
           
                float Old_pos = 0;
                float new_pos = 0;

                cls_PID_Control_Axis1 pidController = new cls_PID_Control_Axis1(0.5f, 0.05f, 0.01f, 0f);
                while (!b_FormClosing)
                {
                   
                    new_pos = f_Pos_Estimate_Ax1;
                    Thread.Sleep(100);
                    //  Console.WriteLine("pid new test");
                    Console.WriteLine(new_pos - Old_pos + "differanceAx1");
                    if (new_pos - Old_pos > 4 )
                    {
                    Pid_1_Can_Run = true;
                    if(Pid_2_Can_Run == true)
                    {
                        pidController.Calculate((Convert.ToSingle(f_Pos_Estimate_Ax1)));
                    }
                    //    Console.WriteLine(new_pos.ToString()+"new"+Old_pos.ToString()+"old");
              


                       

                    }
                    else if (new_pos - Old_pos > 1 && new_pos - Old_pos <= 4)
                    {
                    Pid_1_Can_Run = false;
                    Console.WriteLine("PID resetedAx1");

                        pidController.Reset();
                    }


                    Old_pos = new_pos;
          

                   

                }

            

        }
        public void thrd_PID_Control()
        {
            float Old_pos = 0;
            float new_pos = 0;

                        cls_PID_Control pidController = new cls_PID_Control(0.5f, 0.05f, 0.01f, 0f);
            while (!b_FormClosing)
            {
              
                new_pos = f_Pos_Estimate_Ax0 ;
                Thread.Sleep(100);
                //  Console.WriteLine("pid new test");
                Console.WriteLine(new_pos - Old_pos+"differanceAx0");
                if (new_pos - Old_pos > 4 && Pid_1_Can_Run)
                {
                    Pid_2_Can_Run = true;
                    if (Pid_1_Can_Run == true)
                    {
                        pidController.Calculate((Convert.ToSingle(f_Pos_Estimate_Ax0)));
                    }
                        
                    
                //    Console.WriteLine(new_pos.ToString()+"new"+Old_pos.ToString()+"old");
                  
           

                }
               else if(new_pos - Old_pos >1 && new_pos - Old_pos <= 4)
                {
                    Pid_2_Can_Run = false;

                   Console.WriteLine("PID resetedAx0");

                    pidController.Reset();
                }
                

                Old_pos = new_pos;
          
          
            
            

            }

        }
        
        public void thrd_cursor()
        {
            // cls_gamepad_cursor.cursor_pos();
        }
        public void ToolAdder()
        {

            for (int i = 0; i <= 6; i++)
            {



                ComboBox combo_Text = new ComboBox();
                switch (i)
                {
                    case 0:
                        combo_Text.Name = "combo_Text" + 1.ToString();
                        combo_Text.Font = new Font("Arial", 10);
                        // string[] ports = SerialPort.GetPortNames();
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        // Her bir portu yazdır
                        string[] ports = SerialPort.GetPortNames();
                        foreach (string port in ports)
                        {
                            Console.WriteLine(port);
                            combo_Text.Items.Add(port);
                        }
                        //   for (int y = 0; y <= 80; y++)
                        {

                            //    combo_Text.Items.Add("COM" + y.ToString());

                        }

                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 20);
                        // Console.WriteLine("combobox item" + combo_Text.Name.ToString());
                        // combo_Text.SelectedIndex = 3;
                        combo_Text.SelectedIndexChanged +=
            new System.EventHandler(port);


                        break;
                    case 1:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 2.ToString();
                        combo_Text.Items.Add("2400");
                        combo_Text.Items.Add("9600");
                        combo_Text.Items.Add("19200");
                        combo_Text.Items.Add("38400");
                        combo_Text.Items.Add("57600");
                        combo_Text.Items.Add("115200");
                        combo_Text.Items.Add("921600");
                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 60);
                        combo_Text.SelectedIndex = 5;
                        combo_Text.SelectedIndexChanged += new System.EventHandler(BoudRateValue);
                        cls_SerialCom.str_BoudRate = combo_Text.SelectedItem.ToString();
                        //   Console.WriteLine(combo_Text.SelectedItem.ToString());
                        //  Console.WriteLine(cls_SerialCom.str_BoudRate.ToString());
                        break;

                    case 2:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 3.ToString();
                        combo_Text.Items.Add("7");
                        combo_Text.Items.Add("8");

                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 100);
                        combo_Text.SelectedIndex = 1;
                        combo_Text.SelectedIndexChanged +=
           new System.EventHandler(DataBit);
                        cls_SerialCom.str_DataBit = combo_Text.SelectedItem.ToString();
                        break;
                    case 3:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 4.ToString();
                        combo_Text.Items.Add("none");
                        combo_Text.Items.Add("even");
                        combo_Text.Items.Add("odd");
                        combo_Text.Items.Add("mark");

                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 140);
                        combo_Text.SelectedIndex = 0;
                        combo_Text.SelectedIndexChanged +=
           new System.EventHandler(Parity);
                        cls_SerialCom.str_parity = combo_Text.SelectedItem.ToString();
                        break;
                    case 4:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 5.ToString();
                        combo_Text.Items.Add("stop bit 1");
                        combo_Text.Items.Add("stop bit 2");

                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 180);
                        combo_Text.SelectedIndex = 0;
                        combo_Text.SelectedIndexChanged +=
           new System.EventHandler(StopBit);
                        cls_SerialCom.str_StopBit = combo_Text.SelectedItem.ToString();
                        break;
                    case 5:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 6.ToString();
                        combo_Text.Items.Add("Motor 1");
                        combo_Text.Items.Add("Motor 2");


                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 220);
                        combo_Text.SelectedIndex = 0;
                        combo_Text.SelectedIndexChanged +=
           new System.EventHandler(MotorPoint);
                        cls_SerialCom.str_StopBit = combo_Text.SelectedItem.ToString();
                        break;


                    case 6:
                        combo_Text.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_Text.Name = "combo_Text" + 7.ToString();
                        combo_Text.Items.Add("Serial");
                        combo_Text.Items.Add("Can");
                        combo_Text.Items.Add("USB");


                        combo_Text.Height = 10;
                        combo_Text.Width = 100;
                        pnl_SerialCom.Controls.Add(combo_Text);
                        combo_Text.Location = new Point(20, 260);
                        combo_Text.SelectedIndex = 0;
                        combo_Text.SelectedIndexChanged +=
           new System.EventHandler(comtype);
                        cls_SerialCom.str_StopBit = combo_Text.SelectedItem.ToString();
                        break;



                }

                //    Console.WriteLine(combo_Text.Name);
            }
        }

        private void btn_OpenPOrt_Click(object sender, EventArgs e)
        {
            ComboBox combo_Text_1 = this.Controls.Find("combo_Text1", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_2 = this.Controls.Find("combo_Text2", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_3 = this.Controls.Find("combo_Text3", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_4 = this.Controls.Find("combo_Text4", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_5 = this.Controls.Find("combo_Text5", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_6 = this.Controls.Find("combo_Text6", true).FirstOrDefault() as ComboBox;

            ComboBox combo_Text_7 = this.Controls.Find("combo_Text7", true).FirstOrDefault() as ComboBox;



            if (combo_Text_1.Text.Length < 1 || combo_Text_2.Text.Length < 1 || combo_Text_4.Text.Length < 1 || combo_Text_3.Text.Length < 1 || combo_Text_5.Text.Length < 1 || combo_Text_6.Text.Length < 1 || combo_Text_7.Text.Length < 1)
            {
                MessageBox.Show("There are place that cant be empty");
            }

            else
            {
                Console.WriteLine(combo_Text_1.Text.Length);
                PortProcces();
            }



        }


        public void PortProcces()
        {
            Thread Port_Porcces = new Thread(PortProcces_Thread);

            Port_Porcces.Start();

            Thread Graphics_Porcces = new Thread(GraphicsProcces);

            Graphics_Porcces.Start();

            Thread thrd_StatusDisplay = new Thread(StatusDisplay);
            thrd_StatusDisplay.Start();


        }



        public void PortProcces_Thread()
        {
            Dene = true;
            ComboBox ComboBoudrate = this.Controls.Find("combo_Text7", true).FirstOrDefault() as ComboBox;


            while (!b_FormClosing)
            {
                Thread.Sleep(4000);
                if (cls_SerialCom.ServoMotor.IsOpen == false)
                {
                    Console.WriteLine("port acık");


                    cls_SerialCom.SerialOpen();
                }
                else
                {
                    if (btn_ClosePort.Visible == false)
                    {
                        btn_ClosePort.Invoke(new Action(() => btn_ClosePort.Visible = true));

                    }
                }

            }



        }
        public void comtype(object sender, EventArgs e)
        {
            ComboBox SelectedTool = (ComboBox)sender;
            if (SelectedTool.SelectedIndex == 0)
            {
                cls_SerialCom.Serial = true;
                cls_SerialCom.Can = false;
            }
            else if (SelectedTool.SelectedIndex == 1)
            {
                cls_SerialCom.Serial = false;
                cls_SerialCom.Can = true;
            }
            else
            {
                Firmware_Download.Main_fw();
                Console.WriteLine("download frimware");
            }






        }
        public void MotorPoint(object sender, EventArgs e)
        {

            ComboBox SelectedTool = (ComboBox)sender;
            cls_Serial_Read_Write.i_MotorNum = SelectedTool.SelectedIndex;
            Console.WriteLine(cls_Serial_Read_Write.i_MotorNum.ToString());
            string selectedcomboname = SelectedTool.Name;




        }
        public void BoudRateValue(object sender, EventArgs e)
        {

            Control SelectedTool = (Control)sender;
            string selectedcomboname = SelectedTool.Name;
            ComboBox ComboBoudrate = this.Controls.Find(selectedcomboname, true).FirstOrDefault() as ComboBox;
            cls_SerialCom.str_BoudRate = ComboBoudrate.SelectedItem.ToString();


        }
        public void Parity(object sender, EventArgs e)
        {

            Control SelectedTool = (Control)sender;
            string selectedcomboname = SelectedTool.Name;
            ComboBox ComboParity = this.Controls.Find(selectedcomboname, true).FirstOrDefault() as ComboBox;

            cls_SerialCom.str_parity = ComboParity.SelectedItem.ToString();
        }
        public void port(object sender, EventArgs e)
        {

            Control SelectedTool = (Control)sender;
            string selectedcomboname = SelectedTool.Name;
            ComboBox ComboPort = this.Controls.Find(selectedcomboname, true).FirstOrDefault() as ComboBox;

            cls_SerialCom.str_Com_Port = ComboPort.SelectedItem.ToString();
        }
        public void StopBit(object sender, EventArgs e)
        {

            Control SelectedTool = (Control)sender;
            string selectedcomboname = SelectedTool.Name;
            ComboBox StopBit = this.Controls.Find(selectedcomboname, true).FirstOrDefault() as ComboBox;

            cls_SerialCom.str_StopBit = StopBit.SelectedItem.ToString();
        }
        public void DataBit(object sender, EventArgs e)
        {

            Control SelectedTool = (Control)sender;
            string selectedcomboname = SelectedTool.Name;
            ComboBox DataBit = this.Controls.Find(selectedcomboname, true).FirstOrDefault() as ComboBox;

            cls_SerialCom.str_DataBit = DataBit.SelectedItem.ToString();
        }

        public void GraphicsProcces()
        {
            int i = 0;

            try
            {
                while (!b_FormClosing)
                {

                    Thread.Sleep(100);

                    if (b_FormClosing)
                    {
                        break;
                    }
                    if (CanReply_1 != null)
                    {
                        txt_FirstData.Invoke(new Action(() => txt_FirstData.Text = CanReply_1));
                    }
                    if (CanReply_2 != null)
                    {
                        txt_Second_Data.Invoke(new Action(() => txt_Second_Data.Text = CanReply_2));
                    }
                    if (TableCAnWrite)
                    {
                        TableCAnWrite = false;
                        CanTable.Invoke(new Action(() => CanTable.Rows.Add(rowvalue[0], rowvalue[1], rowvalue[2], rowvalue[3], rowvalue[4], CanReply_1 + "-" + CanReply_2)));

                    }
                    if ((cls_SerialCom.ServoMotor.IsOpen && received_value)|| cls_SerialCom.Can==true)
                    {

                        if (TimeForGrapg > 50)
                        {

                            GraphXMinSize = GraphXMinSize + 1;
                        }
                        TimeForGrapg = TimeForGrapg + 1;

                        ListYGraph.Add(TimeForGrapg);


                        //Console.WriteLine("graph");



                        if (str_CurrentValue != null)
                        {
                            grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                            grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));


                            grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Minimum = -20));

                            grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Maximum = 20));


                            grph_time_torque.Invoke(new Action(() => grph_time_torque.Series["Torque"].Points.AddY(Convert.ToDouble(str_CurrentValue) * 5.34)));

                            lbl_torque.Invoke(new Action(() => lbl_torque.Text = (Convert.ToDouble(str_CurrentValue) * 5.34).ToString()));
                            Torque_Value = Convert.ToSingle(str_CurrentValue) * 5.34f;


                            /*
                            if (Convert.ToDouble(str_CurrentValue) > 0)
                            {
                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));


                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Minimum = -0.2));

                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Maximum = 20));


                                grph_time_torque.Invoke(new Action(() => grph_time_torque.Series["Torque"].Points.AddY(Convert.ToDouble(str_CurrentValue) * 5.34)));
                             
                                lbl_torque.Invoke(new Action(() => lbl_torque.Text = (Convert.ToDouble(str_CurrentValue) * 5.34).ToString()));
                                Torque_Value= Convert.ToDouble(str_CurrentValue) * 5.34;


                            }
                            else
                            {
                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Minimum = -20));

                                grph_time_torque.Invoke(new Action(() => grph_time_torque.ChartAreas["ChartArea1"].AxisY.Maximum = 0.2));

                                grph_time_torque.Invoke(new Action(() => grph_time_torque.Series["Torque"].Points.AddY(Convert.ToDouble(str_CurrentValue) * 5.34)));

                                lbl_torque.Invoke(new Action(() => lbl_torque.Text = (Convert.ToDouble(str_CurrentValue) * 5.34).ToString()));
                                Torque_Value = Convert.ToDouble(str_CurrentValue) * 5.34;
                            }
*/
                            //  Console.WriteLine("current"+(Convert.ToDouble(cls_SerialCom.strA_Received_Data_str[i])) / 100000);
                        }

                    
                            clct_PID_out.Invoke(new Action (()=>clct_PID_out.Text = pid_calc_out.ToString()));
                            grph_PID.Invoke(new Action(() => grph_PID.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                            grph_PID.Invoke(new Action(() => grph_PID.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));


                            grph_PID.Invoke(new Action(() => grph_PID.ChartAreas["ChartArea1"].AxisY.Minimum = -360));

                            grph_PID.Invoke(new Action(() => grph_PID.ChartAreas["ChartArea1"].AxisY.Maximum = 360));


                            grph_PID.Invoke(new Action(() => grph_PID.Series["Kp"].Points.AddY(Convert.ToDouble(kp) )));
                            grph_PID.Invoke(new Action(() => grph_PID.Series["Kd"].Points.AddY(Convert.ToDouble(kd) )));
                            grph_PID.Invoke(new Action(() => grph_PID.Series["Ki"].Points.AddY(Convert.ToDouble(ki) )));
                            grph_PID.Invoke(new Action(() => grph_PID.Series["Out"].Points.AddY(Convert.ToDouble(pid_out) )));

                        

                        

                            if (str_pos_estimated != null && !DriveVelControl)
                        {
                            grp_time_pos.Invoke(new Action(() => grp_time_pos.Update()));
                            i = i + 1;
                            grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                            grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg+300));

                            grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Minimum = -360));

                            grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Maximum = 360));

                            grp_time_pos.Invoke(new Action(() => grp_time_pos.Series["Position"].Points.AddY(Convert.ToDouble(str_pos_estimated) * 5.625)));
                         //   Console.WriteLine(str_pos_estimated.ToString() + "Forgrapg");
                            // Console.WriteLine("pos" + (Convert.ToDouble(cls_SerialCom.strA_Received_Data_str[i])) / 100000);
                            //   Console.WriteLine(Convert.ToDouble(cls_SerialCom.strA_Received_Data_str[i]) / 1000000+"graph value");


                            /* if (Convert.ToDouble(str_pos_estimated) > 0)
                             {
                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Minimum = -0.2));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Maximum = 360));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.Series["Position"].Points.AddY(Convert.ToDouble(str_pos_estimated)* 5.625)));
                                 // Console.WriteLine("pos" + (Convert.ToDouble(cls_SerialCom.strA_Received_Data_str[i])) / 100000);
                                 //   Console.WriteLine(Convert.ToDouble(cls_SerialCom.strA_Received_Data_str[i]) / 1000000+"graph value");

                                 d_Automatic_Pos = (Convert.ToDouble(str_pos_estimated) * 5.625);

                             }
                             else
                             {



                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Minimum = -360));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.ChartAreas["ChartArea1"].AxisY.Maximum = 0.2));

                                 grp_time_pos.Invoke(new Action(() => grp_time_pos.Series["Position"].Points.AddY(Convert.ToDouble(str_pos_estimated)  * 5.625)));
                                 d_Automatic_Pos = (Convert.ToDouble(str_pos_estimated) * 5.625);
                             }
                                 */
                        }
                        if (str_Vel_Estimated != null)
                        {
                            grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                            grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                            grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Minimum = -48));

                            grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Maximum = 48));

                            grph_time_vel.Invoke(new Action(() => grph_time_vel.Series["Velocity"].Points.AddY(Convert.ToDouble(str_Vel_Estimated))));

                            /*   if (Convert.ToDouble(str_Vel_Estimated) > 0)
                              {
                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Minimum = -0.2));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Maximum = 48));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.Series["Velocity"].Points.AddY(Convert.ToDouble(str_Vel_Estimated) )));
                              }
                              else
                              {
                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Minimum = ListYGraph[GraphXMinSize]));
                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisX.Maximum = TimeForGrapg));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Minimum = -48));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.ChartAreas["ChartArea1"].AxisY.Maximum = 0.2));

                                  grph_time_vel.Invoke(new Action(() => grph_time_vel.Series["Velocity"].Points.AddY(Convert.ToDouble(str_Vel_Estimated) )));

                              }
                         */
                        }
                        received_value = false;



                    }
                }
            }


            catch (Exception f)
            {
                str_ErrorCode += "Err 1" + "\n";
                Console.WriteLine("Err 1");
                GraphXMinSize = 0;
                TimeForGrapg = 0;


            }

        }



        public void StatusDisplay()
        {





            while (!b_FormClosing)
            {


                if (str_ErrorCode != null)
                {
                    lst_SoftErr.Invoke(new Action(() => lst_SoftErr.Items.Insert(0, str_ErrorCode)));
                    str_ErrorCode = null;
                }
                Thread.Sleep(500);

                try
                {
                    //  ComboBox foundControls = this.Controls.Find("combo_Text1", true).FirstOrDefault() as ComboBox;

                    // Her bir portu yazdır



                    /*if (!b_Automatic)
                    {

                        if (btn_TepkiModu.Visible == false)
                        {
                            btn_TepkiModu.Invoke(new Action(() => btn_TepkiModu.Visible = true));
                        }

                    }
                    else
                    {

                        if (btn_TepkiModu.Visible == true)
                        {
                            btn_TepkiModu.Invoke(new Action(() => btn_TepkiModu.Visible = false));
                        }
                    }*/

                    if (err_Controller != null)
                    {
                        d_ErrorCode = Convert.ToDouble(err_Controller);
                        if (d_ErrorCode > 0)
                        {
                            lst_DriverError.Invoke(new Action(() => lst_DriverError.Items.Insert(0, "Controller Error " + err_Controller)));
                        }
                    }
                    if (err_Encoder != null)
                    {
                        d_ErrorCode = Convert.ToDouble(err_Encoder);
                        if (d_ErrorCode > 0)
                        {
                            lst_DriverError.Invoke(new Action(() => lst_DriverError.Items.Insert(0, "Encoder Error " + err_Encoder)));
                        }
                    }
                    if (err_General != null)
                    {
                        d_ErrorCode = Convert.ToDouble(err_General);
                        if (d_ErrorCode > 0)
                        {
                            lst_DriverError.Invoke(new Action(() => lst_DriverError.Items.Insert(0, "General Error " + err_General)));
                        }
                    }
                    if (err_Motor != null)
                    {
                        d_ErrorCode = Convert.ToDouble(err_Motor);
                        if (d_ErrorCode > 0)
                        {
                            lst_DriverError.Invoke(new Action(() => lst_DriverError.Items.Insert(0, "Motor Error " + err_Motor)));
                        }
                    }

                    if (!cls_SerialCom.ServoMotor.IsOpen)
                    {
                        cls_Serial_Read_Write.port_Status = false;
                        cls_Serial_Read_Write.i_Total_Packet_Must_Be = 0;
                    }

                    if (cls_SerialCom.ServoMotor.IsOpen)
                    {
                        if (btn_OpenPOrt.Visible)
                        {
                            btn_OpenPOrt.Invoke(new Action(() => btn_OpenPOrt.Visible = false));
                        }

                    }
                    if (!cls_SerialCom.ServoMotor.IsOpen)
                    {
                        if (btn_OpenPOrt.Visible == false)
                        {
                            btn_OpenPOrt.Invoke(new Action(() => btn_OpenPOrt.Visible = true));
                        }
                        cls_Serial_Read_Write.b_SerialReaded = false;
                    }

                    if (cls_SerialCom.ServoMotor.IsOpen)
                    {
                        lbl_PortStatus.Invoke(new Action(() => lbl_PortStatus.Text = "OPEN"));
                        lbl_PortStatus.Invoke(new Action(() => lbl_PortStatus.BackColor = Color.Green));
                        /*  cmd_AxisState.Visible = true;
                          cmd_ControlMode.Visible = true;
                          cmd_inputMode.Visible = true;
                          btn_Adjust.Visible = true;
                          btn_Save.Visible = true;
                          btn_inputmodeset.Visible = true;
                          btn_controlmodeset.Visible = true;
                          btn_axisset.Visible = true;
                        */


                    }
                    else
                    {
                        lbl_PortStatus.Invoke(new Action(() => lbl_PortStatus.Text = "CLOSE"));
                        lbl_PortStatus.Invoke(new Action(() => lbl_PortStatus.BackColor = Color.Red));
                        /*   cmd_AxisState.Visible = false;
                           cmd_ControlMode.Visible = false;
                           cmd_inputMode.Visible = false;
                           btn_Adjust.Visible = false;
                           btn_Save.Visible = false;
                           btn_inputmodeset.Visible = false;
                           btn_controlmodeset.Visible = false;
                           btn_axisset.Visible = false;*/
                    }


                    if (cls_SerialCom.ServoMotor.IsOpen)
                    {
                        if (i_current_lim != null)
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!");

                            txt_cur_lim.Invoke(new Action(() => txt_cur_lim.Text = i_current_lim));
                            i_current_lim = null;
                        }
                        if (b_MotorIdle)
                        {

                            if (btn_Save.Visible == false)
                            {
                                btn_Save.Invoke(new Action(() => btn_Save.Visible = true));


                            }
                        }
                        else
                        {

                            if (btn_Save.Visible == true)
                            {
                                btn_Save.Invoke(new Action(() => btn_Save.Visible = false));

                            }

                        }

                        //  Console.WriteLine("graph");
                        if (i_vel_limit != null)
                        {
                            txt_vel_lim.Invoke(new Action(() => txt_vel_lim.Text = i_vel_limit));
                            i_vel_limit = null;
                        }
                        if (i_ramp_rate != null)
                        {
                            txt_vel_ramp_lim.Invoke(new Action(() => txt_vel_ramp_lim.Text = i_ramp_rate));
                            i_ramp_rate = null;
                        }
                        if (i_torque_const != null)
                        {
                            txt_torq_cons.Invoke(new Action(() => txt_torq_cons.Text = i_torque_const));
                            i_torque_const = null;
                        }

                        //  Console.WriteLine("graph");
                        if (str_TrapTraj_Vel_lim != null)
                        {
                            txt_tt_vel_lim.Invoke(new Action(() => txt_tt_vel_lim.Text = str_TrapTraj_Vel_lim));
                            str_TrapTraj_Vel_lim = null;
                        }
                        if (str_TrapTraj_acc_lim != null)
                        {
                            txt_tt_acc_lim.Invoke(new Action(() => txt_tt_acc_lim.Text = str_TrapTraj_acc_lim));
                            str_TrapTraj_acc_lim = null;
                        }
                        if (str_TrapTraj_dec_lim != null)
                        {
                            txt_tt_dcc_lim.Invoke(new Action(() => txt_tt_dcc_lim.Text = str_TrapTraj_dec_lim));
                            str_TrapTraj_dec_lim = null;
                        }
                        if (str_TrapTraj_inertia != null)
                        {
                            txt_tt_inertia.Invoke(new Action(() => txt_tt_inertia.Text = str_TrapTraj_inertia));
                            str_TrapTraj_inertia = null;
                        }


                        if (str_Reply_free_prot != null)
                        {
                            lst_replyof_freeprot.Invoke(new Action(() => lst_replyof_freeprot.Items.Insert(0, str_Reply_free_prot)));
                            str_Reply_free_prot = null;
                        }



                        //   Console.WriteLine(i_ramp_rate+ i_vel_limit+ i_torque_const+ i_current_lim+"labeles");




                        if (str_ContolMode != null)
                        {
                            switch (Convert.ToInt32(str_ContolMode))
                            {
                                case 0:
                                    lbl_ControlMode.Invoke(new Action(() => lbl_ControlMode.Text = "VOLTAGE CONTROL"));
                                    b_Velocity_Control = false;
                                    b_Position_Control = false;
                                    break;
                                case 1:
                                    lbl_ControlMode.Invoke(new Action(() => lbl_ControlMode.Text = "TORQUE CONTROL"));
                                    b_Velocity_Control = false;
                                    b_Position_Control = false;
                                    break;
                                case 2:
                                    lbl_ControlMode.Invoke(new Action(() => lbl_ControlMode.Text = "VELOCITY CONTROL"));
                                    b_Velocity_Control = true;
                                    b_Position_Control = false;
                                    break;
                                case 3:
                                    lbl_ControlMode.Invoke(new Action(() => lbl_ControlMode.Text = "POSITION CONTROL"));
                                    b_Position_Control = true;
                                    b_Velocity_Control = false;

                                    break;


                            }
                        }


                        if (str_InputMode != null)
                        {
                            switch (Convert.ToInt32(str_InputMode))
                            {
                                case 0:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "INACTIVE"));
                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 1:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "PASSTHROUGH"));
                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 2:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "VEL RAMP"));
                                    b_Vel_Ramp = true;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 3:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "POS FILTER"));
                                    b_Pos_filter = true;
                                    b_Trap_Traj = false;
                                    b_Vel_Ramp = false;

                                    break;
                                case 4:

                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "MIX CHANNELS"));
                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 5:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "TRAP TRAJ"));
                                    b_Trap_Traj = true;
                                    b_Vel_Ramp = false;
                                    b_Pos_filter = false;
                                    break;
                                case 6:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "TORQUE RAMP"));
                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 7:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "MIRRORL"));

                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;
                                case 8:
                                    lbl_Input_mode.Invoke(new Action(() => lbl_Input_mode.Text = "TUNING"));

                                    b_Vel_Ramp = false;
                                    b_Trap_Traj = false;
                                    b_Pos_filter = false;
                                    break;


                            }
                        }

                        if (str_AxisiMode != null)
                        {
                            switch (Convert.ToInt32(str_AxisiMode))
                            {
                                case 0:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "UNDEFINED"));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 1:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "IDLE"));
                                    b_MotorRun = false;
                                    b_MotorIdle = true;
                                    break;
                                case 2:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "STARTUP SEQUENCE"));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 3:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "FULL CALIBRATION SEQUENCE"));

                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 4:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "ENCODER INDEX SEARCH"));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 5:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = ""));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 6:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "ENCODER OFFSET CALIBRATION "));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 7:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "NCODER OFFSET CALIBRATION"));
                                    b_MotorIdle = false;
                                    b_MotorRun = false;
                                    break;
                                case 8:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "CLOSED LOOP CONTROL"));
                                    b_MotorRun = true;
                                    b_MotorIdle = false;
                                    break;

                                case 9:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "LOCKIN SPIN"));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;
                                    break;
                                case 10:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "ENCODER DIR FIND"));
                                    b_MotorRun = false;
                                    b_MotorIdle = false;

                                    break;
                                case 11:
                                    lbl_RequestedState.Invoke(new Action(() => lbl_RequestedState.Text = "HOMING"));
                                    b_MotorIdle = false;
                                    b_MotorRun = false;
                                    break;


                            }
                        }
                    }
                }

                catch (Exception f)
                {

                    str_ErrorCode += "Err 2" + "\n";
                    Console.WriteLine("err 2");

                }
            }


        }
        private void exoskeleton_FormClosed(object sender, FormClosedEventArgs e)
        {



        }

        private void exoskeleton_FormClosing(object sender, FormClosingEventArgs e)
        {
            b_FormClosing = true;
            Console.WriteLine(b_FormClosing.ToString());
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {

            cls_Serial_Read_Write.str_FreeCode = txt_SenderBox.Text;
            cls_Serial_Read_Write.b_Free_Code = true;



        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmd_AxisState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmd_AxisState.SelectedItem != null)
            {
                i_AxisSetting = cmd_AxisState.SelectedIndex;
                str_AxisState_cmd = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".requested_state " + i_AxisSetting.ToString() + "\n";
                Console.WriteLine(str_AxisState_cmd);
                btn_axisset.Visible = true;
            }
            else
            {
                btn_axisset.Visible = false;
            }
            letsProcces();

        }

        private void cmd_ControlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmd_ControlMode.SelectedItem != null)
            {
                i_controlmodesetting = cmd_ControlMode.SelectedIndex;
                if (cls_Serial_Read_Write.i_MotorNum == 0)
                {
                    str_ControlMode_cmd = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".requested_state 3" + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.control_mode " + i_controlmodesetting.ToString() + "\n" + "w axis1.requested_state 3" + "\n" + "w axis1.controller.config.control_mode 2" + "\n";

                }
                else if (cls_Serial_Read_Write.i_MotorNum == 1)
                {
                    str_ControlMode_cmd = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".requested_state 3" + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.control_mode " + i_controlmodesetting.ToString() + "\n" + "w axis0.requested_state 3" + "\n" + "w axis0.controller.config.control_mode 3" + "\n";

                }
                Console.WriteLine(str_ControlMode_cmd);
                btn_controlmodeset.Visible = true;
            }
            else
            {
                btn_controlmodeset.Visible = false;
            }
            letsProcces();
        }

        private void cmd_inputMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmd_inputMode.SelectedItem != null)
            {
                i_inputModesetting = cmd_inputMode.SelectedIndex;
                if (cls_Serial_Read_Write.i_MotorNum == 0)
                {
                    str_InputMode_cmd = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.input_mode " + i_inputModesetting.ToString() + "\n" + "w axis1.controller.config.input_mode 7" + "\n";

                }
                else if (cls_Serial_Read_Write.i_MotorNum == 1)
                {
                    str_InputMode_cmd = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.input_mode " + i_inputModesetting.ToString() + "\n" + "w axis0.controller.config.input_mode 7" + "\n";

                }
                Console.WriteLine(str_InputMode_cmd);
                btn_inputmodeset.Visible = true;
            }
            else
            {
                btn_inputmodeset.Visible = false;
            }
            letsProcces();
        }
        public void letsProcces()
        {
            lbl_AxisWarning.Text = "";
            lbl_controlModeWarning.Text = "";
            lbl_inputmodewarn.Text = "";

            if (cmd_AxisState.SelectedItem != null)
            {

                lbl_AxisWarning.Text = "";
            }
            else
            {
                Console.WriteLine("axis state secmelisin");
                lbl_AxisWarning.Text = "!!!!";
            }
            if (cmd_ControlMode.SelectedItem != null)
            {

                lbl_controlModeWarning.Text = "";
            }
            else
            {
                Console.WriteLine("control mode secmelisin");
                lbl_controlModeWarning.Text = "!!!!";
            }
            if (cmd_inputMode.SelectedItem != null)
            {

                lbl_inputmodewarn.Text = "";
            }
            else
            {
                Console.WriteLine("control mode secmelisin");
                lbl_inputmodewarn.Text = "!!!!";
            }




        }
        private void btn_Adjust_Click(object sender, EventArgs e)
        {




        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            btn_Save.Visible = false;
            cls_Serial_Read_Write.str_updateconfig = "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".motor.config.current_lim " + txt_cur_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.vel_limit " + txt_vel_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.vel_ramp_rate " + txt_vel_ramp_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".motor.config.torque_constant " + txt_torq_cons.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".trap_traj.config.vel_limit " + txt_tt_vel_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".trap_traj.config.accel_limit " + txt_tt_acc_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".trap_traj.config.decel_limit " + txt_tt_dcc_lim.Text + "\n" + "w axis" + cls_Serial_Read_Write.i_MotorNum.ToString() + ".controller.config.inertia " + txt_tt_inertia.Text;
            cls_Serial_Read_Write.b_For_Config = true;
        }


        private void tp_Configration_Setting_Enter(object sender, EventArgs e)
        {
            if (!b_MotorRun && cls_SerialCom.ServoMotor.IsOpen)
            {
                asktoconfig();
            }


        }
        public void asktoconfig()
        {



            cls_Serial_Read_Write.b_For_Config = true;


        }

        private void btn_axisset_Click(object sender, EventArgs e)
        {
            cls_Serial_Read_Write.str_AxisModeSet = str_AxisState_cmd;
            cls_Serial_Read_Write.b_AxisModeSet = true;

        }

        private void btn_controlmodeset_Click(object sender, EventArgs e)
        {

            cls_Serial_Read_Write.str_ControlModeSet = str_ControlMode_cmd;
            cls_Serial_Read_Write.b_ControlModeSet = true;

        }

        private void btn_inputmodeset_Click(object sender, EventArgs e)
        {
            cls_Serial_Read_Write.str_InputModeSet = str_InputMode_cmd;
            cls_Serial_Read_Write.b_InputModeSet = true;



        }



        private void txt_tt_vel_lim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_tt_acc_lim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_tt_dcc_lim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_tt_inertia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_tt_pos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btn_Drive_Click(object sender, EventArgs e)
        {

        }




        public static void tmr_Read_Timeour_Tick(object sender, EventArgs e)
        {

        }

        private void tmr_Read_Timeour_Tick_1(object sender, EventArgs e)
        {
            int b = 0;
            if (cls_SerialCom.ServoMotor.IsOpen)
            {

                if (a == 0 && !cls_Serial_Read_Write.b_SerialReaded)
                {
                    a = a + 1;
                }
                else if (a == 1 && !cls_Serial_Read_Write.b_SerialReaded)
                {

                }
            }
        }

        private void btn_ClosePort_Click(object sender, EventArgs e)
        {
            btn_ClosePort.Visible = false;
            cls_SerialCom.ServoMotor.Close();
        }





        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }


        private void tec_velocity_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (b_Velocity_Control && b_Vel_Ramp && b_MotorRun)
            {
                if (cls_Serial_Read_Write.i_MotorNum == 0)
                {
                    MasterMot = 1;
                    cls_Serial_Read_Write.str_FreeCode = "w axis0.controller.input_vel " + tec_velocity.Value.ToString();

                    cls_Serial_Read_Write.b_Free_Code = true;
                }
                else if (cls_Serial_Read_Write.i_MotorNum == 1)
                {
                    MasterMot = 2;
                    cls_Serial_Read_Write.str_FreeCode = "w axis1.controller.input_vel " + tec_velocity.Value.ToString() + "w axis0.controller.input_pos " + str_pos_estimated;

                    cls_Serial_Read_Write.b_Free_Code = true;
                }
            }
            prc_Vel.Value = tec_velocity.Value;
        }





        private void tec_pos_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (b_Position_Control && b_Trap_Traj && b_MotorRun)
            {
                if (cls_Serial_Read_Write.i_MotorNum == 0)
                {
                    cls_Serial_Read_Write.str_FreeCode = "w axis0.controller.input_pos " + (Convert.ToDouble(tec_pos.Value) / 5.625);

                }
                else if (cls_Serial_Read_Write.i_MotorNum == 1)
                {
                    cls_Serial_Read_Write.str_FreeCode = "w axis0.controller.input_pos " + (Convert.ToDouble(tec_pos.Value) / 5.625);

                }

            }
            cls_Serial_Read_Write.b_Free_Code = true;


            prc_pos.Value = tec_pos.Value;

        }

        private void btn_Clear_Err_Click(object sender, EventArgs e)
        {
            cls_Serial_Read_Write.str_FreeCode = "w odrv0.clear_errors()";
            cls_Serial_Read_Write.b_Free_Code = true;
        }

        private void tP_ErrorPage_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("entered");
            cls_Serial_Read_Write.b_ScanErr = true;
            BreakIt = false;
            /* while (!BreakIt)
             {
                 Thread.Sleep(100);
                 if (cls_SerialCom.b_ScanErr == false)
                 {
                     cls_SerialCom.b_ScanErr = true;
                     Console.WriteLine("scan error");
                 }
             }*/
        }

        private void tP_ErrorPage_Leave(object sender, EventArgs e)
        {
            BreakIt = true;
            Console.WriteLine("leave");

        }

        private void btn_Reflash_Click(object sender, EventArgs e)
        {
            ComboBox combo_Text = this.Controls.Find("combo_Text1", true).FirstOrDefault() as ComboBox;
            combo_Text.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                Console.WriteLine(port);
                combo_Text.Items.Add(port);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedDisplay(comboBox1.SelectedIndex);


        }
        static byte[] CombineArrays(byte[] array1, byte[] array2)
        {
            byte[] result = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, result, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, result, array1.Length, array2.Length);
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {


            // cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Motr_Err);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void AddReplyinCantable(byte[] value)
        {


            byte[] bytes_1 = new byte[] { value[0] };
            byte[] bytes_2 = new byte[] { value[1] }; ;
            byte[] bytes_3 = new byte[] { value[3], value[2] }; ;
            byte[] bytes_4 = new byte[] { value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11] }; ;
            byte[] bytes_41 = new byte[] { value[4], value[5], value[6], value[7] };
            byte[] bytes_42 = new byte[] { value[8], value[9], value[10], value[11] };
            byte[] bytes_5 = new byte[] { value[12] }; 

         
            string hexString_1 = BitConverter.ToString(bytes_1).Replace("-", "");
            string hexString_2 = BitConverter.ToString(bytes_2).Replace("-", "");
            string hexString_3 = BitConverter.ToString(bytes_3).Replace("-", "");
            string hexString_4 = BitConverter.ToString(bytes_4).Replace("-", "");
            string hexString_5 = BitConverter.ToString(bytes_5).Replace("-", "");
            rowvalue[0] = hexString_1;
            rowvalue[1] = hexString_2;
            rowvalue[2] = hexString_3;
            rowvalue[3] = hexString_4;
            rowvalue[4] = hexString_5;

            CanReplyReject(hexString_3, bytes_4, bytes_41, bytes_42);


            TableCAnWrite = true;
            //  ConvertUINT64First(bytes_4);

            //txt_FirstData.Invoke(new Action(() => txt_FirstData.Text = value_1));

            // ConvertUINT32First(bytes_4);





        }
        public void CanReplyReject(string value,byte[] value_1,byte[] value_2,byte[] value_3)
        {
         
            switch(value)
            {
                
                case "0203":
                case "0303":
                    txt_Firstdataname.Text = "Motor Error";
                    txt_Seconddataname.Text = "NULL";
                    ConvertUINT64First(value_1);
                    
                    Console.WriteLine(value);
                    break;
                case "0204":
                case "0304":
                    txt_Firstdataname.Text = "Encoder Error";
                    txt_Seconddataname.Text = "NULL";
                    ConvertUINT32First(value_2);
                    ConvertUINT32Second(value_3);

                    break;
                case "0205":
                case "0305":
                    txt_Firstdataname.Text = "Sensorless Error";
                    txt_Seconddataname.Text = "NULL";
                    ConvertUINT32First(value_2);
                    ConvertUINT32Second(value_3);
                    break;
                case "0209":
                case "0309":
                    txt_Firstdataname.Text = "Pos Estimated";
                    txt_Seconddataname.Text = "Vel Estimated";
                    if (cls_Serial_Read_Write.i_MotorNum == 0 && value == "0209")
                    {
                        ConvertUINT32First(value_2);
                        ConvertUINT32Second(value_3);
                        str_pos_estimated = CanReply_1;
                        str_Vel_Estimated = CanReply_2;

                     
                    }
                     if(value == "0209")
                    {
                        ConvertUINT32First(value_2);
                        ConvertUINT32Second(value_3);
                        f_Pos_Estimate_Ax0 = Convert.ToSingle(CanReply_1) * 5.625f;
                        f_Vel_Estimate_Ax0 = Convert.ToSingle(CanReply_2);
                    }

                    
                    if (cls_Serial_Read_Write.i_MotorNum == 1 && value == "0309")
                    {
                        ConvertUINT32First(value_2);
                        ConvertUINT32Second(value_3);
                        str_pos_estimated = CanReply_1;
                        str_Vel_Estimated = CanReply_2;

                       
                    }
                     if(value == "0309")
                    {
                        ConvertUINT32First(value_2);
                        ConvertUINT32Second(value_3);
                        f_Pos_Estimate_Ax1 = Convert.ToSingle(CanReply_1) * 5.625f;
                        f_Vel_Estimate_Ax1 = Convert.ToSingle(CanReply_2);
                    }

                    


                    break;
                case "020a":
                case "030a":
                    txt_Firstdataname.Text = "Shadow Count";
                    txt_Seconddataname.Text = "CPR Count";
                    ConvertUINT32First(value_2);
                   
                    ConvertUINT32Second(value_3);
                    break;
                case "0214":
                case "0314":
                    if (cls_Serial_Read_Write.i_MotorNum == 0&&value == "0214")
                    {
                        float setvalue = BitConverter.ToSingle(value_3, 0);
                       // Console.WriteLine(setvalue + "revei");
                        // TotalTork(setvalue);
                        str_CurrentValue = setvalue.ToString();
                        f_Current_Ax0 = setvalue;

                    }
                    if (cls_Serial_Read_Write.i_MotorNum == 1 && value == "0314")
                    {
                        float setvalue = BitConverter.ToSingle(value_3, 0);
                       // Console.WriteLine(setvalue + "revei");
                        //TotalTork(setvalue);
                        str_CurrentValue = setvalue.ToString();
                        f_Current_Ax1 = setvalue;

                    }
                    break;
                case "0215":
                case "0315":
                    txt_Firstdataname.Text = "Senseless Pos ";
                    txt_Seconddataname.Text = "Senseless Vel";
                    ConvertUINT32First(value_2);
                    ConvertUINT32Second(value_3);
                    break;
                case "0217":
                case "0317":
                    txt_Firstdataname.Text = "VbusVoltage ";
                    txt_Seconddataname.Text = "NULL";
                    ConvertUINT32First(value_2);
                    ConvertUINT32Second(value_3);
                    break;
            }
        }
        public void TotalTork(float a)
        {

            if (second < 2)
            {
                first = a + first;
               
                second = second + 1;
                Console.WriteLine(a.ToString() + "current value" + second.ToString()) ;
            }
            else
            {
               
                str_CurrentValue = first.ToString();

                first = 0;
                second = 0;
            }



        }
        public void ConvertUINT64First(byte[] Value)
        {

            UInt64 setvalue = BitConverter.ToUInt64(Value, 0);
       //     Console.WriteLine(setvalue + "revei");
            CanReply_1 = setvalue.ToString();

           
            //  Array.Reverse(byteArray);



        }
        public void ConvertUINT32First(byte[] Value)
        {
            float setvalue = BitConverter.ToSingle(Value, 0);
         //   Console.WriteLine(setvalue + "revei");

            CanReply_1 = setvalue.ToString();



            // byte[] byteArray = BitConverter.GetBytes(setvalue);
            //   string hexString = BitConverter.ToString(byteArray).Replace("-", "");
            //  Array.Reverse(byteArray);



        }
        public void ConvertUINT32Second(byte[] Value)
        {
            float setvalue = BitConverter.ToSingle(Value, 0);
          //  Console.WriteLine(setvalue + "revei");
            CanReply_2 = setvalue.ToString();
        }
        public void ConvertSignedFirst(int Value)
        {

            byte[] byteArray = BitConverter.GetBytes(Value);

            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
            Array.Reverse(byteArray);
            //  textBox10.Text = hexString;
            SetValue_1(byteArray);
        }
        public void ConvertSignedSecond(int Value)
        {


            byte[] byteArray = BitConverter.GetBytes(Value);

            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
            Array.Reverse(byteArray);
            //  textBox10.Text = hexString;
            SetValue_2(byteArray);
        }
        public void ConvertFloatFirst(float Value)
        {


            byte[] byteArray = BitConverter.GetBytes(Value);
            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
          
            for(int i=0;i<byteArray.Length;i++)
            {
                Console.WriteLine(byteArray[i].ToString());
                pidoutbyte[i] = byteArray[i];

            }
            pidoutbyte[4] = 0;
            pidoutbyte[5] = 0;
            pidoutbyte[6] = 0;
            pidoutbyte[7] = 0;
            pidoutbyte[8] = 85;
            Can_Communication(10);
            //  textBox10.Text = hexString;

        }
        public void ConvertFloatFirst_Ax1(float Value)
        {
            Console.WriteLine("burada");

            byte[] byteArray = BitConverter.GetBytes(Value);
            string hexString = BitConverter.ToString(byteArray).Replace("-", "");

            for (int i = 0; i < byteArray.Length; i++)
            {
                Console.WriteLine(byteArray[i].ToString());
                pidoutbyte_Ax1[i] = byteArray[i];

            }
            pidoutbyte_Ax1[4] = 0;
            pidoutbyte_Ax1[5] = 0;
            pidoutbyte_Ax1[6] = 0;
            pidoutbyte_Ax1[7] = 0;
            pidoutbyte_Ax1[8] = 85;
            Can_Communication(23);
            //  textBox10.Text = hexString;

        }
        public void ConvertFloatSecond(float Value)
        {


            byte[] byteArray = BitConverter.GetBytes(Value);
            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
            Array.Reverse(byteArray);
            //// textBox10.Text = hexString;
            SetValue_2(byteArray);
        }

        public void SetValue_1(byte[] value)
        {
            textBox4.Text = value[0].ToString();
            willsenddata[3] = value[0];

            textBox3.Text = value[1].ToString();
            willsenddata[2] = value[1];
            textBox2.Text = value[2].ToString();
            willsenddata[1] = value[2];
            textBox1.Text = value[3].ToString();
            willsenddata[0] = value[3];
        }
        public void SetValue_2(byte[] value)
        {
            textBox5.Text = value[0].ToString();
            willsenddata[7] = value[0];

            textBox6.Text = value[1].ToString();
            willsenddata[6] = value[1];
            textBox7.Text = value[2].ToString();
            willsenddata[5] = value[2];
            textBox8.Text = value[3].ToString();
            willsenddata[4] = value[3];
        }
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            CanReply_1 = null;
            CanReply_2 = null;
            Can_Communication(comboBox1.SelectedIndex);
        }


        public void Can_Communication(int compoint)
        {
            string data = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + textBox8.Text;


           // Console.WriteLine("can write girdi");

            //Thread.Sleep(1000);



            switch (compoint)
            {



                case 0:
                    try
                    {
                        if (cls_Serial_Read_Write.i_MotorNum == 0)
                        {
                         
                            cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Motr_Err_1);
                        }
                        else if (cls_Serial_Read_Write.i_MotorNum == 1)
                        {
                            cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Motr_Err_2);
                        }



                    }
                    catch (Exception f)
                    {

                    }




                    break;

                case 1:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                      
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Encoder_Err_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Encoder_Err_2);


                    }

                    break;
                case 2:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                       
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Sensorless_Err_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.str_Sensorless_Err_2);
                    }
                    break;
                case 3:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        txt_Firstdataname.Text = "NodeId";
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        txt_Firstdataname.Text = "NodeId";
                    }
                    break;
                case 4:
                   
                   
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Axis_RequestState_1, willsenddata));
                       
                    
                    
                    break;
                case 5:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {

                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Encoder_Estimated_1);
                      
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Encoder_Estimated_2);
                    }
                    break;
                case 6:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Encoder_Count_1);
                      
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Encoder_Count_2);
                    }
                    break;
                case 7:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                      
                      
                     
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Controller_Mode_1, willsenddata));
                      
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                 
                        ConvertSignedFirst(Convert.ToInt32(a));
                        ConvertSignedSecond(Convert.ToInt32(b));
                       
                      
                    
                    }

                    break;
                case 8:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_ınput_Pos_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }

                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_ınput_Pos_2);
                    }
                    break;
                case 9:
                     cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_ınput_Vel_1, pidoutbyte));
                  
                    
                   
                    break;

                case 10:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_ınput_Torque_1,pidoutbyte));
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_ınput_Torque_2);
                    }
                    break;
                case 11:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Vel_Current_lim_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Vel_Current_lim_2);
                    }
                    break;
                case 12:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Trap_Traj_Vel_lim_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Trap_Traj_Vel_lim_2);
                    }
                    break;
                case 13:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Trap_Traj_Accel_Dec_lim_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_Trap_Traj_Accel_Dec_lim_2);
                    }

                    break;
                case 14:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_inertia_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                       {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_inertia_2);
                    }
                    break;
                case 15:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {

                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Sensorless_Estimate_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Sensorless_Estimate_2);
                    }
                    break;

                case 16:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Reboot_1, willsenddata));
                     
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Reboot_2, willsenddata));
                       
                    }
                    break;
                case 17:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                    
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Vbus_Voltage_1);
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                      
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Get_Vbus_Voltage_2);
                    }
                    break;
                case 18:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Clear_Error_1, willsenddata));
                    }

                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Clear_Error_2, willsenddata));

                    }
                    break;
                case 19:
                    if (cls_Serial_Read_Write.i_MotorNum == 0)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Vel_Gain_1, willsenddata));
                 
                    }
                    else if (cls_Serial_Read_Write.i_MotorNum == 1)
                    {
                        int a = 0;
                        int b = 0;
                        if (txt_FirstData.Text.Length > 0)
                        {
                            a = Convert.ToInt32(txt_FirstData.Text);
                        }
                        if (txt_Second_Data.Text.Length > 0)
                        {
                            b = Convert.ToInt32(txt_Second_Data.Text);
                        }
                        cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Vel_Gain_2, willsenddata));
                      
                    }
                    break;
                case 20:
                     
                        cls_Can_Read_Write.CanWrite(cls_Can_Read_Write.Set_ınput_Vel_2);
                    
                    break;
                case 21:
                    cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Axis_RequestState_2, willsenddata));
                    break;
                case 22:
                    cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_Controller_Mode_2, willsenddata));
                    break;
                case 23:
                    cls_Can_Read_Write.CanWrite(CombineArrays(cls_Can_Read_Write.Set_ınput_Torque_2, pidoutbyte_Ax1));
                    break;

            }

        }
        public void selectedDisplay(int a)
        {
            switch (a)
            {



                case 0:

                    txt_Firstdataname.Text = "MOTOR ERROR";
                    txt_FirstData.Text = "0";
                    txt_Seconddataname.Text = "null";
                    txt_Second_Data.Text = "0";


                    break;

                case 1:

                    txt_Firstdataname.Text = "ENCODER Err";
                    txt_FirstData.Text = "0";
                    txt_Seconddataname.Text = "null";
                    txt_Second_Data.Text = "0";


                    break;
                case 2:

                    txt_Firstdataname.Text = "Sensorless Err";
                    txt_FirstData.Text = "0";
                    txt_Seconddataname.Text = "null";
                    txt_Second_Data.Text = "0";

                    break;
                case 3:

                    txt_Firstdataname.Text = "NodeId";

                    txt_FirstData.Text = "0";
                    txt_Seconddataname.Text = "null";
                    txt_Second_Data.Text = "0";
                    break;

                case 4:

                    txt_Firstdataname.Text = "Requested State";

                    txt_FirstData.Text = "0";
                    txt_Seconddataname.Text = "null";
                    txt_Second_Data.Text = "0";

                    break;
                case 5:

                  
                    txt_Firstdataname.Text = "Pos Estimated";
                    txt_Seconddataname.Text = "Vel Estimated";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 6:

                    txt_Firstdataname.Text = "Shadow Count";
                    txt_Seconddataname.Text = "CPR Count";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";

                    break;
                case 7:


                    txt_Firstdataname.Text = "Control Mode";
                    txt_Seconddataname.Text = "Input Mode";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";


                    break;
                case 8:
                    txt_Firstdataname.Text = "Input POS";
                    txt_Seconddataname.Text = "VEL FF";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 9:
                    txt_Firstdataname.Text = "Input Vel";
                    txt_Seconddataname.Text = "VEL FF";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";

                    break;

                case 10:
                    txt_Firstdataname.Text = "SET Torq";
                    txt_Seconddataname.Text = "Null";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 11:
                    txt_Firstdataname.Text = "Vel Limit";
                    txt_Seconddataname.Text = "Cuurent Lim";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 12:
                    txt_Firstdataname.Text = "Vel Lim TT ";
                    txt_Seconddataname.Text = "Null";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 13:
                    txt_Firstdataname.Text = "ACC  TT ";
                    txt_Seconddataname.Text = "DEC";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";

                    break;
                case 14:
                    txt_Firstdataname.Text = "Inertia ";
                    txt_Seconddataname.Text = "NULL";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 15:
                    txt_Firstdataname.Text = "Senseless Pos ";
                    txt_Seconddataname.Text = "Senseless Vel";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;

                case 16:
                    txt_Firstdataname.Text = "Reboot ";
                    txt_Seconddataname.Text = "NULL";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 17:
                    txt_Firstdataname.Text = "VbusVoltage ";
                    txt_Seconddataname.Text = "NULL";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 18:
                    txt_Firstdataname.Text = "ClearError ";
                    txt_Seconddataname.Text = "NULL";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;
                case 19:
                    txt_Firstdataname.Text = "Set Vel Gain ";
                    txt_Seconddataname.Text = "NULL";
                    txt_FirstData.Text = "0";
                    txt_Second_Data.Text = "0";
                    break;

            }
        }

        private void Drive_test_With_Can_Click(object sender, EventArgs e)
        {
            Logiccanstart();
        }
        public void Logiccanstart()
        {
            willsenddata[0] = 8;
            willsenddata[1] = 0;
            willsenddata[2] = 0;
            willsenddata[3] = 0;
            willsenddata[4] = 0;
            willsenddata[5] = 0;
            willsenddata[6] = 0;
            willsenddata[7] = 0;
            willsenddata[8] = 85;
            Can_Communication(4);
            willsenddata[0] = 1;
            willsenddata[1] = 0;
            willsenddata[2] = 0;
            willsenddata[3] = 0;
            willsenddata[4] = 1;
            willsenddata[5] = 0;
            willsenddata[6] = 0;
            willsenddata[7] = 0;
            willsenddata[8] = 85;
            Can_Communication(7);
            willsenddata[0] = 8;
            willsenddata[1] = 0;
            willsenddata[2] = 0;
            willsenddata[3] = 0;
            willsenddata[4] = 0;
            willsenddata[5] = 0;
            willsenddata[6] = 0;
            willsenddata[7] = 0;
            willsenddata[8] = 85;
            Can_Communication(21);
            willsenddata[0] = 1;
            willsenddata[1] = 0;
            willsenddata[2] = 0;
            willsenddata[3] = 0;
            willsenddata[4] = 1;
            willsenddata[5] = 0;
            willsenddata[6] = 0;
            willsenddata[7] = 0;
            willsenddata[8] = 85;
            Can_Communication(22);

            if (cls_SerialCom.Can)
            {
                cls_PID_Control.pid_canwork = true;
                cls_PID_Control_Axis1.pid_canwork = true;
            }
            else
            {
                cls_PID_Control.pid_canwork = false;
                cls_PID_Control_Axis1.pid_canwork = false;
            }
        }
        public void Logiccanstop()
        {
            willsenddata[0] = 1;
            willsenddata[1] = 0;
            willsenddata[2] = 0;
            willsenddata[3] = 0;
            willsenddata[4] = 0;
            willsenddata[5] = 0;
            willsenddata[6] = 0;
            willsenddata[7] = 0;
            willsenddata[8] = 85;
            Can_Communication(4);
        }

        private void grp_time_pos_Click(object sender, EventArgs e)
        {

        }
    }
}
