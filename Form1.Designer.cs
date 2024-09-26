namespace ServoControlApp
{
    partial class exoskeleton
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnl_SerialCom = new System.Windows.Forms.Panel();
            this.btn_Reflash = new System.Windows.Forms.Button();
            this.lbl_PortStatus = new System.Windows.Forms.Label();
            this.btn_ClosePort = new System.Windows.Forms.Button();
            this.btn_OpenPOrt = new System.Windows.Forms.Button();
            this.ControlTab = new System.Windows.Forms.TabControl();
            this.Graph_pos = new System.Windows.Forms.TabPage();
            this.grp_time_pos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Graph_vel = new System.Windows.Forms.TabPage();
            this.grph_time_vel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Graph_Torque = new System.Windows.Forms.TabPage();
            this.lbl_torque = new System.Windows.Forms.Label();
            this.grph_time_torque = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tp_Configration_Setting = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_tt_inertia = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_tt_dcc_lim = new System.Windows.Forms.TextBox();
            this.txt_tt_acc_lim = new System.Windows.Forms.TextBox();
            this.txt_tt_vel_lim = new System.Windows.Forms.TextBox();
            this.lbl_ControleMode = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_torq_cons = new System.Windows.Forms.TextBox();
            this.txt_vel_ramp_lim = new System.Windows.Forms.TextBox();
            this.txt_cur_lim = new System.Windows.Forms.TextBox();
            this.txt_vel_lim = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tP_ErrorPage = new System.Windows.Forms.TabPage();
            this.lst_DriverError = new System.Windows.Forms.ListBox();
            this.lst_SoftErr = new System.Windows.Forms.ListBox();
            this.btn_Clear_Err = new System.Windows.Forms.Button();
            this.Tb_CanTester = new System.Windows.Forms.TabPage();
            this.Drive_test_With_Can = new System.Windows.Forms.Button();
            this.txt_Seconddataname = new System.Windows.Forms.TextBox();
            this.txt_Firstdataname = new System.Windows.Forms.TextBox();
            this.txt_Second_Data = new System.Windows.Forms.TextBox();
            this.txt_FirstData = new System.Windows.Forms.TextBox();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CanTable = new System.Windows.Forms.DataGridView();
            this.HeaderFirstByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndByte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tp_Graph_PID = new System.Windows.Forms.TabPage();
            this.clct_PID_out = new System.Windows.Forms.Label();
            this.grph_PID = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txt_SenderBox = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.btn_inputmodeset = new System.Windows.Forms.Button();
            this.btn_controlmodeset = new System.Windows.Forms.Button();
            this.btn_axisset = new System.Windows.Forms.Button();
            this.lbl_inputmodewarn = new System.Windows.Forms.Label();
            this.lbl_controlModeWarning = new System.Windows.Forms.Label();
            this.lbl_AxisWarning = new System.Windows.Forms.Label();
            this.cmd_inputMode = new System.Windows.Forms.ComboBox();
            this.cmd_ControlMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmd_AxisState = new System.Windows.Forms.ComboBox();
            this.lbl_Input_mode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_ControlMode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_RequestedState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_replyof_freeprot = new System.Windows.Forms.ListBox();
            this.pnl_Driving = new System.Windows.Forms.Panel();
            this.tec_pos = new System.Windows.Forms.TrackBar();
            this.tec_velocity = new System.Windows.Forms.TrackBar();
            this.prc_pos = new CodeArtEng.Gauge.CircularGauge2();
            this.prc_Vel = new CodeArtEng.Gauge.CircularGauge();
            this.tmr_Read_Timeour = new System.Windows.Forms.Timer(this.components);
            this.pnl_SerialCom.SuspendLayout();
            this.ControlTab.SuspendLayout();
            this.Graph_pos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grp_time_pos)).BeginInit();
            this.Graph_vel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grph_time_vel)).BeginInit();
            this.Graph_Torque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grph_time_torque)).BeginInit();
            this.tp_Configration_Setting.SuspendLayout();
            this.tP_ErrorPage.SuspendLayout();
            this.Tb_CanTester.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanTable)).BeginInit();
            this.tp_Graph_PID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grph_PID)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl_Driving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tec_pos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tec_velocity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_SerialCom
            // 
            this.pnl_SerialCom.Controls.Add(this.btn_Reflash);
            this.pnl_SerialCom.Controls.Add(this.lbl_PortStatus);
            this.pnl_SerialCom.Controls.Add(this.btn_ClosePort);
            this.pnl_SerialCom.Controls.Add(this.btn_OpenPOrt);
            this.pnl_SerialCom.Location = new System.Drawing.Point(12, 26);
            this.pnl_SerialCom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_SerialCom.Name = "pnl_SerialCom";
            this.pnl_SerialCom.Size = new System.Drawing.Size(353, 485);
            this.pnl_SerialCom.TabIndex = 0;
            // 
            // btn_Reflash
            // 
            this.btn_Reflash.Location = new System.Drawing.Point(274, 3);
            this.btn_Reflash.Name = "btn_Reflash";
            this.btn_Reflash.Size = new System.Drawing.Size(76, 49);
            this.btn_Reflash.TabIndex = 3;
            this.btn_Reflash.Text = "Com Reflash";
            this.btn_Reflash.UseVisualStyleBackColor = true;
            this.btn_Reflash.Click += new System.EventHandler(this.btn_Reflash_Click);
            // 
            // lbl_PortStatus
            // 
            this.lbl_PortStatus.AutoSize = true;
            this.lbl_PortStatus.BackColor = System.Drawing.Color.Red;
            this.lbl_PortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_PortStatus.Location = new System.Drawing.Point(19, 354);
            this.lbl_PortStatus.Name = "lbl_PortStatus";
            this.lbl_PortStatus.Size = new System.Drawing.Size(133, 39);
            this.lbl_PortStatus.TabIndex = 2;
            this.lbl_PortStatus.Text = "CLOSE";
            // 
            // btn_ClosePort
            // 
            this.btn_ClosePort.Location = new System.Drawing.Point(179, 402);
            this.btn_ClosePort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ClosePort.Name = "btn_ClosePort";
            this.btn_ClosePort.Size = new System.Drawing.Size(141, 79);
            this.btn_ClosePort.TabIndex = 1;
            this.btn_ClosePort.Text = "CLOSE";
            this.btn_ClosePort.UseVisualStyleBackColor = true;
            this.btn_ClosePort.Visible = false;
            this.btn_ClosePort.Click += new System.EventHandler(this.btn_ClosePort_Click);
            // 
            // btn_OpenPOrt
            // 
            this.btn_OpenPOrt.Location = new System.Drawing.Point(11, 402);
            this.btn_OpenPOrt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OpenPOrt.Name = "btn_OpenPOrt";
            this.btn_OpenPOrt.Size = new System.Drawing.Size(141, 79);
            this.btn_OpenPOrt.TabIndex = 0;
            this.btn_OpenPOrt.Text = "OPEN";
            this.btn_OpenPOrt.UseVisualStyleBackColor = true;
            this.btn_OpenPOrt.Click += new System.EventHandler(this.btn_OpenPOrt_Click);
            // 
            // ControlTab
            // 
            this.ControlTab.Controls.Add(this.Graph_pos);
            this.ControlTab.Controls.Add(this.Graph_vel);
            this.ControlTab.Controls.Add(this.Graph_Torque);
            this.ControlTab.Controls.Add(this.tp_Configration_Setting);
            this.ControlTab.Controls.Add(this.tP_ErrorPage);
            this.ControlTab.Controls.Add(this.Tb_CanTester);
            this.ControlTab.Controls.Add(this.tp_Graph_PID);
            this.ControlTab.Location = new System.Drawing.Point(399, 26);
            this.ControlTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ControlTab.Name = "ControlTab";
            this.ControlTab.SelectedIndex = 0;
            this.ControlTab.Size = new System.Drawing.Size(829, 711);
            this.ControlTab.TabIndex = 1;
            // 
            // Graph_pos
            // 
            this.Graph_pos.Controls.Add(this.grp_time_pos);
            this.Graph_pos.Location = new System.Drawing.Point(4, 25);
            this.Graph_pos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_pos.Name = "Graph_pos";
            this.Graph_pos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_pos.Size = new System.Drawing.Size(821, 682);
            this.Graph_pos.TabIndex = 0;
            this.Graph_pos.Text = "Position";
            this.Graph_pos.UseVisualStyleBackColor = true;
            // 
            // grp_time_pos
            // 
            chartArea1.Name = "ChartArea1";
            this.grp_time_pos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grp_time_pos.Legends.Add(legend1);
            this.grp_time_pos.Location = new System.Drawing.Point(0, -1);
            this.grp_time_pos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_time_pos.Name = "grp_time_pos";
            this.grp_time_pos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Position";
            this.grp_time_pos.Series.Add(series1);
            this.grp_time_pos.Size = new System.Drawing.Size(812, 662);
            this.grp_time_pos.TabIndex = 0;
            this.grp_time_pos.Text = "chart1";
            this.grp_time_pos.Click += new System.EventHandler(this.grp_time_pos_Click);
            // 
            // Graph_vel
            // 
            this.Graph_vel.Controls.Add(this.grph_time_vel);
            this.Graph_vel.Location = new System.Drawing.Point(4, 25);
            this.Graph_vel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_vel.Name = "Graph_vel";
            this.Graph_vel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_vel.Size = new System.Drawing.Size(821, 682);
            this.Graph_vel.TabIndex = 1;
            this.Graph_vel.Text = "Velocitiy";
            this.Graph_vel.UseVisualStyleBackColor = true;
            // 
            // grph_time_vel
            // 
            chartArea2.Name = "ChartArea1";
            this.grph_time_vel.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.grph_time_vel.Legends.Add(legend2);
            this.grph_time_vel.Location = new System.Drawing.Point(4, 5);
            this.grph_time_vel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grph_time_vel.Name = "grph_time_vel";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Velocity";
            this.grph_time_vel.Series.Add(series2);
            this.grph_time_vel.Size = new System.Drawing.Size(812, 617);
            this.grph_time_vel.TabIndex = 1;
            this.grph_time_vel.Text = "chart2";
            // 
            // Graph_Torque
            // 
            this.Graph_Torque.Controls.Add(this.lbl_torque);
            this.Graph_Torque.Controls.Add(this.grph_time_torque);
            this.Graph_Torque.Location = new System.Drawing.Point(4, 25);
            this.Graph_Torque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_Torque.Name = "Graph_Torque";
            this.Graph_Torque.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Graph_Torque.Size = new System.Drawing.Size(821, 682);
            this.Graph_Torque.TabIndex = 2;
            this.Graph_Torque.Text = "Torque";
            this.Graph_Torque.UseVisualStyleBackColor = true;
            // 
            // lbl_torque
            // 
            this.lbl_torque.AutoSize = true;
            this.lbl_torque.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_torque.Location = new System.Drawing.Point(667, 108);
            this.lbl_torque.Name = "lbl_torque";
            this.lbl_torque.Size = new System.Drawing.Size(0, 31);
            this.lbl_torque.TabIndex = 2;
            // 
            // grph_time_torque
            // 
            chartArea3.Name = "ChartArea1";
            this.grph_time_torque.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grph_time_torque.Legends.Add(legend3);
            this.grph_time_torque.Location = new System.Drawing.Point(4, 5);
            this.grph_time_torque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grph_time_torque.Name = "grph_time_torque";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Torque";
            this.grph_time_torque.Series.Add(series3);
            this.grph_time_torque.Size = new System.Drawing.Size(812, 617);
            this.grph_time_torque.TabIndex = 1;
            this.grph_time_torque.Text = "chart3";
            // 
            // tp_Configration_Setting
            // 
            this.tp_Configration_Setting.Controls.Add(this.label21);
            this.tp_Configration_Setting.Controls.Add(this.txt_tt_inertia);
            this.tp_Configration_Setting.Controls.Add(this.label20);
            this.tp_Configration_Setting.Controls.Add(this.label19);
            this.tp_Configration_Setting.Controls.Add(this.label18);
            this.tp_Configration_Setting.Controls.Add(this.txt_tt_dcc_lim);
            this.tp_Configration_Setting.Controls.Add(this.txt_tt_acc_lim);
            this.tp_Configration_Setting.Controls.Add(this.txt_tt_vel_lim);
            this.tp_Configration_Setting.Controls.Add(this.lbl_ControleMode);
            this.tp_Configration_Setting.Controls.Add(this.btn_Save);
            this.tp_Configration_Setting.Controls.Add(this.txt_torq_cons);
            this.tp_Configration_Setting.Controls.Add(this.txt_vel_ramp_lim);
            this.tp_Configration_Setting.Controls.Add(this.txt_cur_lim);
            this.tp_Configration_Setting.Controls.Add(this.txt_vel_lim);
            this.tp_Configration_Setting.Controls.Add(this.label13);
            this.tp_Configration_Setting.Controls.Add(this.label12);
            this.tp_Configration_Setting.Controls.Add(this.label11);
            this.tp_Configration_Setting.Controls.Add(this.label10);
            this.tp_Configration_Setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tp_Configration_Setting.Location = new System.Drawing.Point(4, 25);
            this.tp_Configration_Setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tp_Configration_Setting.Name = "tp_Configration_Setting";
            this.tp_Configration_Setting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tp_Configration_Setting.Size = new System.Drawing.Size(821, 682);
            this.tp_Configration_Setting.TabIndex = 3;
            this.tp_Configration_Setting.Text = "ConfigData";
            this.tp_Configration_Setting.UseVisualStyleBackColor = true;
            this.tp_Configration_Setting.Enter += new System.EventHandler(this.tp_Configration_Setting_Enter);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(293, 295);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 29);
            this.label21.TabIndex = 25;
            this.label21.Text = "Inertia";
            // 
            // txt_tt_inertia
            // 
            this.txt_tt_inertia.Location = new System.Drawing.Point(293, 345);
            this.txt_tt_inertia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tt_inertia.MaxLength = 5;
            this.txt_tt_inertia.Name = "txt_tt_inertia";
            this.txt_tt_inertia.Size = new System.Drawing.Size(100, 26);
            this.txt_tt_inertia.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(293, 208);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 29);
            this.label20.TabIndex = 23;
            this.label20.Text = "Decel Limit";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(293, 121);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 29);
            this.label19.TabIndex = 22;
            this.label19.Text = "Acc Limit";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(293, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 29);
            this.label18.TabIndex = 21;
            this.label18.Text = "Vel limit";
            // 
            // txt_tt_dcc_lim
            // 
            this.txt_tt_dcc_lim.Location = new System.Drawing.Point(293, 258);
            this.txt_tt_dcc_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tt_dcc_lim.MaxLength = 5;
            this.txt_tt_dcc_lim.Name = "txt_tt_dcc_lim";
            this.txt_tt_dcc_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_tt_dcc_lim.TabIndex = 20;
            // 
            // txt_tt_acc_lim
            // 
            this.txt_tt_acc_lim.Location = new System.Drawing.Point(293, 170);
            this.txt_tt_acc_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tt_acc_lim.MaxLength = 5;
            this.txt_tt_acc_lim.Name = "txt_tt_acc_lim";
            this.txt_tt_acc_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_tt_acc_lim.TabIndex = 19;
            // 
            // txt_tt_vel_lim
            // 
            this.txt_tt_vel_lim.Location = new System.Drawing.Point(293, 81);
            this.txt_tt_vel_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tt_vel_lim.MaxLength = 5;
            this.txt_tt_vel_lim.Name = "txt_tt_vel_lim";
            this.txt_tt_vel_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_tt_vel_lim.TabIndex = 18;
            // 
            // lbl_ControleMode
            // 
            this.lbl_ControleMode.AutoSize = true;
            this.lbl_ControleMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ControleMode.Location = new System.Drawing.Point(293, 100);
            this.lbl_ControleMode.Name = "lbl_ControleMode";
            this.lbl_ControleMode.Size = new System.Drawing.Size(0, 25);
            this.lbl_ControleMode.TabIndex = 17;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Save.Location = new System.Drawing.Point(51, 420);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(135, 62);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_torq_cons
            // 
            this.txt_torq_cons.Location = new System.Drawing.Point(51, 345);
            this.txt_torq_cons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_torq_cons.MaxLength = 5;
            this.txt_torq_cons.Name = "txt_torq_cons";
            this.txt_torq_cons.Size = new System.Drawing.Size(100, 26);
            this.txt_torq_cons.TabIndex = 7;
            this.txt_torq_cons.Text = "0";
            this.txt_torq_cons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // txt_vel_ramp_lim
            // 
            this.txt_vel_ramp_lim.Location = new System.Drawing.Point(51, 258);
            this.txt_vel_ramp_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_vel_ramp_lim.MaxLength = 5;
            this.txt_vel_ramp_lim.Name = "txt_vel_ramp_lim";
            this.txt_vel_ramp_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_vel_ramp_lim.TabIndex = 6;
            this.txt_vel_ramp_lim.Text = "0";
            this.txt_vel_ramp_lim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // txt_cur_lim
            // 
            this.txt_cur_lim.Location = new System.Drawing.Point(51, 170);
            this.txt_cur_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_cur_lim.MaxLength = 5;
            this.txt_cur_lim.Name = "txt_cur_lim";
            this.txt_cur_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_cur_lim.TabIndex = 5;
            this.txt_cur_lim.Text = "0";
            this.txt_cur_lim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // txt_vel_lim
            // 
            this.txt_vel_lim.Location = new System.Drawing.Point(51, 81);
            this.txt_vel_lim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_vel_lim.MaxLength = 5;
            this.txt_vel_lim.Name = "txt_vel_lim";
            this.txt_vel_lim.Size = new System.Drawing.Size(100, 26);
            this.txt_vel_lim.TabIndex = 4;
            this.txt_vel_lim.Text = "0";
            this.txt_vel_lim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(45, 295);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 29);
            this.label13.TabIndex = 2;
            this.label13.Text = "Torque Constant";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(45, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 29);
            this.label12.TabIndex = 1;
            this.label12.Text = "Vel Ramp Rate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(45, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Current Limit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(45, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 29);
            this.label10.TabIndex = 0;
            this.label10.Text = "Vel Limiti";
            // 
            // tP_ErrorPage
            // 
            this.tP_ErrorPage.Controls.Add(this.lst_DriverError);
            this.tP_ErrorPage.Controls.Add(this.lst_SoftErr);
            this.tP_ErrorPage.Controls.Add(this.btn_Clear_Err);
            this.tP_ErrorPage.Location = new System.Drawing.Point(4, 25);
            this.tP_ErrorPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tP_ErrorPage.Name = "tP_ErrorPage";
            this.tP_ErrorPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tP_ErrorPage.Size = new System.Drawing.Size(821, 682);
            this.tP_ErrorPage.TabIndex = 4;
            this.tP_ErrorPage.Text = "ErrorPage";
            this.tP_ErrorPage.UseVisualStyleBackColor = true;
            this.tP_ErrorPage.Enter += new System.EventHandler(this.tP_ErrorPage_Enter);
            this.tP_ErrorPage.Leave += new System.EventHandler(this.tP_ErrorPage_Leave);
            // 
            // lst_DriverError
            // 
            this.lst_DriverError.FormattingEnabled = true;
            this.lst_DriverError.ItemHeight = 16;
            this.lst_DriverError.Location = new System.Drawing.Point(48, 39);
            this.lst_DriverError.Margin = new System.Windows.Forms.Padding(4);
            this.lst_DriverError.Name = "lst_DriverError";
            this.lst_DriverError.Size = new System.Drawing.Size(328, 324);
            this.lst_DriverError.TabIndex = 3;
            // 
            // lst_SoftErr
            // 
            this.lst_SoftErr.FormattingEnabled = true;
            this.lst_SoftErr.ItemHeight = 16;
            this.lst_SoftErr.Location = new System.Drawing.Point(415, 39);
            this.lst_SoftErr.Margin = new System.Windows.Forms.Padding(4);
            this.lst_SoftErr.Name = "lst_SoftErr";
            this.lst_SoftErr.Size = new System.Drawing.Size(336, 324);
            this.lst_SoftErr.TabIndex = 2;
            // 
            // btn_Clear_Err
            // 
            this.btn_Clear_Err.Location = new System.Drawing.Point(48, 402);
            this.btn_Clear_Err.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Clear_Err.Name = "btn_Clear_Err";
            this.btn_Clear_Err.Size = new System.Drawing.Size(128, 57);
            this.btn_Clear_Err.TabIndex = 1;
            this.btn_Clear_Err.Text = "Clear";
            this.btn_Clear_Err.UseVisualStyleBackColor = true;
            this.btn_Clear_Err.Click += new System.EventHandler(this.btn_Clear_Err_Click);
            // 
            // Tb_CanTester
            // 
            this.Tb_CanTester.Controls.Add(this.Drive_test_With_Can);
            this.Tb_CanTester.Controls.Add(this.txt_Seconddataname);
            this.Tb_CanTester.Controls.Add(this.txt_Firstdataname);
            this.Tb_CanTester.Controls.Add(this.txt_Second_Data);
            this.Tb_CanTester.Controls.Add(this.txt_FirstData);
            this.Tb_CanTester.Controls.Add(this.btn_Scan);
            this.Tb_CanTester.Controls.Add(this.textBox5);
            this.Tb_CanTester.Controls.Add(this.textBox6);
            this.Tb_CanTester.Controls.Add(this.textBox7);
            this.Tb_CanTester.Controls.Add(this.textBox8);
            this.Tb_CanTester.Controls.Add(this.textBox4);
            this.Tb_CanTester.Controls.Add(this.textBox3);
            this.Tb_CanTester.Controls.Add(this.textBox2);
            this.Tb_CanTester.Controls.Add(this.textBox1);
            this.Tb_CanTester.Controls.Add(this.CanTable);
            this.Tb_CanTester.Controls.Add(this.comboBox1);
            this.Tb_CanTester.Location = new System.Drawing.Point(4, 25);
            this.Tb_CanTester.Name = "Tb_CanTester";
            this.Tb_CanTester.Padding = new System.Windows.Forms.Padding(3);
            this.Tb_CanTester.Size = new System.Drawing.Size(821, 682);
            this.Tb_CanTester.TabIndex = 5;
            this.Tb_CanTester.Text = "CAN_Tester";
            this.Tb_CanTester.UseVisualStyleBackColor = true;
            // 
            // Drive_test_With_Can
            // 
            this.Drive_test_With_Can.Location = new System.Drawing.Point(679, 140);
            this.Drive_test_With_Can.Name = "Drive_test_With_Can";
            this.Drive_test_With_Can.Size = new System.Drawing.Size(124, 49);
            this.Drive_test_With_Can.TabIndex = 20;
            this.Drive_test_With_Can.Text = "Drive";
            this.Drive_test_With_Can.UseVisualStyleBackColor = true;
            this.Drive_test_With_Can.Click += new System.EventHandler(this.Drive_test_With_Can_Click);
            // 
            // txt_Seconddataname
            // 
            this.txt_Seconddataname.Location = new System.Drawing.Point(688, 34);
            this.txt_Seconddataname.Name = "txt_Seconddataname";
            this.txt_Seconddataname.Size = new System.Drawing.Size(100, 22);
            this.txt_Seconddataname.TabIndex = 19;
            // 
            // txt_Firstdataname
            // 
            this.txt_Firstdataname.Location = new System.Drawing.Point(513, 34);
            this.txt_Firstdataname.Name = "txt_Firstdataname";
            this.txt_Firstdataname.Size = new System.Drawing.Size(100, 22);
            this.txt_Firstdataname.TabIndex = 18;
            // 
            // txt_Second_Data
            // 
            this.txt_Second_Data.Location = new System.Drawing.Point(688, 99);
            this.txt_Second_Data.Name = "txt_Second_Data";
            this.txt_Second_Data.Size = new System.Drawing.Size(100, 22);
            this.txt_Second_Data.TabIndex = 17;
            // 
            // txt_FirstData
            // 
            this.txt_FirstData.Location = new System.Drawing.Point(513, 99);
            this.txt_FirstData.Name = "txt_FirstData";
            this.txt_FirstData.Size = new System.Drawing.Size(100, 22);
            this.txt_FirstData.TabIndex = 16;
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(42, 156);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(104, 50);
            this.btn_Scan.TabIndex = 13;
            this.btn_Scan.Text = "Send";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox5.Location = new System.Drawing.Point(441, 99);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(35, 22);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "00";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox6.Location = new System.Drawing.Point(384, 99);
            this.textBox6.MaxLength = 2;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(35, 22);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "00";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox7.Location = new System.Drawing.Point(327, 99);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(35, 22);
            this.textBox7.TabIndex = 9;
            this.textBox7.Text = "00";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox8.Location = new System.Drawing.Point(270, 99);
            this.textBox8.MaxLength = 2;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(35, 22);
            this.textBox8.TabIndex = 8;
            this.textBox8.Text = "00";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox4.Location = new System.Drawing.Point(213, 99);
            this.textBox4.MaxLength = 2;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(35, 22);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "00";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox3.Location = new System.Drawing.Point(156, 99);
            this.textBox3.MaxLength = 2;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "00";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.Location = new System.Drawing.Point(99, 99);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "00";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Location = new System.Drawing.Point(42, 99);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CanTable
            // 
            this.CanTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CanTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HeaderFirstByte,
            this.PacketType,
            this.ID,
            this.Data,
            this.EndByte,
            this.ValueDec});
            this.CanTable.Location = new System.Drawing.Point(15, 250);
            this.CanTable.Name = "CanTable";
            this.CanTable.RowHeadersWidth = 51;
            this.CanTable.RowTemplate.Height = 24;
            this.CanTable.Size = new System.Drawing.Size(773, 380);
            this.CanTable.TabIndex = 3;
            // 
            // HeaderFirstByte
            // 
            this.HeaderFirstByte.HeaderText = "HeaderFirstByte";
            this.HeaderFirstByte.MinimumWidth = 6;
            this.HeaderFirstByte.Name = "HeaderFirstByte";
            this.HeaderFirstByte.Width = 125;
            // 
            // PacketType
            // 
            this.PacketType.HeaderText = "PacketType";
            this.PacketType.MinimumWidth = 6;
            this.PacketType.Name = "PacketType";
            this.PacketType.Width = 125;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            this.Data.Width = 125;
            // 
            // EndByte
            // 
            this.EndByte.HeaderText = "EndByte";
            this.EndByte.MinimumWidth = 6;
            this.EndByte.Name = "EndByte";
            this.EndByte.Width = 125;
            // 
            // ValueDec
            // 
            this.ValueDec.HeaderText = "ValueDec";
            this.ValueDec.MinimumWidth = 6;
            this.ValueDec.Name = "ValueDec";
            this.ValueDec.Width = 125;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "str_Motr_Err",
            "str_Encoder_Err",
            "str_Sensorless_Err",
            "Set_Axis_Node_Id",
            "Set_Axis_RequestState",
            "Get_Encoder_Estimated",
            "Get_Encoder_Count ",
            "Set_Controller_Mode",
            "Set_ınput_Pos",
            "Set_ınput_Vel ",
            "Set_ınput_Torque",
            "Set_Vel_Current_lim",
            "Set_Trap_Traj_Vel_lim",
            "Set_Trap_Traj_Accel_Dec_lim ",
            "Set_inertia",
            "Get_Sensorless_Estimate ",
            "Reboot ",
            "Get_Vbus_Voltage",
            "Clear_Error",
            "Set_Vel_Gain",
            "Set_Pos_Gain "});
            this.comboBox1.Location = new System.Drawing.Point(42, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(434, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tp_Graph_PID
            // 
            this.tp_Graph_PID.Controls.Add(this.clct_PID_out);
            this.tp_Graph_PID.Controls.Add(this.grph_PID);
            this.tp_Graph_PID.Location = new System.Drawing.Point(4, 25);
            this.tp_Graph_PID.Name = "tp_Graph_PID";
            this.tp_Graph_PID.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Graph_PID.Size = new System.Drawing.Size(821, 682);
            this.tp_Graph_PID.TabIndex = 6;
            this.tp_Graph_PID.Text = "PID";
            this.tp_Graph_PID.UseVisualStyleBackColor = true;
            // 
            // clct_PID_out
            // 
            this.clct_PID_out.AutoSize = true;
            this.clct_PID_out.Location = new System.Drawing.Point(711, 196);
            this.clct_PID_out.Name = "clct_PID_out";
            this.clct_PID_out.Size = new System.Drawing.Size(51, 16);
            this.clct_PID_out.TabIndex = 3;
            this.clct_PID_out.Text = "label14";
            // 
            // grph_PID
            // 
            chartArea4.Name = "ChartArea1";
            this.grph_PID.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.grph_PID.Legends.Add(legend4);
            this.grph_PID.Location = new System.Drawing.Point(4, 33);
            this.grph_PID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grph_PID.Name = "grph_PID";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Kp";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Kd";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Ki";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Out";
            this.grph_PID.Series.Add(series4);
            this.grph_PID.Series.Add(series5);
            this.grph_PID.Series.Add(series6);
            this.grph_PID.Series.Add(series7);
            this.grph_PID.Size = new System.Drawing.Size(812, 617);
            this.grph_PID.TabIndex = 2;
            this.grph_PID.Text = "chart3";
            // 
            // txt_SenderBox
            // 
            this.txt_SenderBox.Location = new System.Drawing.Point(12, 694);
            this.txt_SenderBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SenderBox.Name = "txt_SenderBox";
            this.txt_SenderBox.Size = new System.Drawing.Size(359, 22);
            this.txt_SenderBox.TabIndex = 2;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(12, 722);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 28);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "SEND";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Status);
            this.panel1.Controls.Add(this.btn_inputmodeset);
            this.panel1.Controls.Add(this.btn_controlmodeset);
            this.panel1.Controls.Add(this.btn_axisset);
            this.panel1.Controls.Add(this.lbl_inputmodewarn);
            this.panel1.Controls.Add(this.lbl_controlModeWarning);
            this.panel1.Controls.Add(this.lbl_AxisWarning);
            this.panel1.Controls.Add(this.cmd_inputMode);
            this.panel1.Controls.Add(this.cmd_ControlMode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmd_AxisState);
            this.panel1.Controls.Add(this.lbl_Input_mode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbl_ControlMode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl_RequestedState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1245, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 425);
            this.panel1.TabIndex = 4;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Status.Location = new System.Drawing.Point(197, 420);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(0, 25);
            this.lbl_Status.TabIndex = 24;
            // 
            // btn_inputmodeset
            // 
            this.btn_inputmodeset.Location = new System.Drawing.Point(364, 346);
            this.btn_inputmodeset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_inputmodeset.Name = "btn_inputmodeset";
            this.btn_inputmodeset.Size = new System.Drawing.Size(75, 39);
            this.btn_inputmodeset.TabIndex = 22;
            this.btn_inputmodeset.Text = "set";
            this.btn_inputmodeset.UseVisualStyleBackColor = true;
            this.btn_inputmodeset.Visible = false;
            this.btn_inputmodeset.Click += new System.EventHandler(this.btn_inputmodeset_Click);
            // 
            // btn_controlmodeset
            // 
            this.btn_controlmodeset.Location = new System.Drawing.Point(364, 226);
            this.btn_controlmodeset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_controlmodeset.Name = "btn_controlmodeset";
            this.btn_controlmodeset.Size = new System.Drawing.Size(75, 39);
            this.btn_controlmodeset.TabIndex = 21;
            this.btn_controlmodeset.Text = "set";
            this.btn_controlmodeset.UseVisualStyleBackColor = true;
            this.btn_controlmodeset.Visible = false;
            this.btn_controlmodeset.Click += new System.EventHandler(this.btn_controlmodeset_Click);
            // 
            // btn_axisset
            // 
            this.btn_axisset.Location = new System.Drawing.Point(364, 100);
            this.btn_axisset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_axisset.Name = "btn_axisset";
            this.btn_axisset.Size = new System.Drawing.Size(75, 39);
            this.btn_axisset.TabIndex = 20;
            this.btn_axisset.Text = "set";
            this.btn_axisset.UseVisualStyleBackColor = true;
            this.btn_axisset.Visible = false;
            this.btn_axisset.Click += new System.EventHandler(this.btn_axisset_Click);
            // 
            // lbl_inputmodewarn
            // 
            this.lbl_inputmodewarn.AutoSize = true;
            this.lbl_inputmodewarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_inputmodewarn.ForeColor = System.Drawing.Color.Red;
            this.lbl_inputmodewarn.Location = new System.Drawing.Point(259, 347);
            this.lbl_inputmodewarn.Name = "lbl_inputmodewarn";
            this.lbl_inputmodewarn.Size = new System.Drawing.Size(0, 20);
            this.lbl_inputmodewarn.TabIndex = 19;
            // 
            // lbl_controlModeWarning
            // 
            this.lbl_controlModeWarning.AutoSize = true;
            this.lbl_controlModeWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_controlModeWarning.ForeColor = System.Drawing.Color.Red;
            this.lbl_controlModeWarning.Location = new System.Drawing.Point(269, 187);
            this.lbl_controlModeWarning.Name = "lbl_controlModeWarning";
            this.lbl_controlModeWarning.Size = new System.Drawing.Size(0, 20);
            this.lbl_controlModeWarning.TabIndex = 18;
            // 
            // lbl_AxisWarning
            // 
            this.lbl_AxisWarning.AutoSize = true;
            this.lbl_AxisWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_AxisWarning.ForeColor = System.Drawing.Color.Red;
            this.lbl_AxisWarning.Location = new System.Drawing.Point(269, 70);
            this.lbl_AxisWarning.Name = "lbl_AxisWarning";
            this.lbl_AxisWarning.Size = new System.Drawing.Size(0, 20);
            this.lbl_AxisWarning.TabIndex = 17;
            // 
            // cmd_inputMode
            // 
            this.cmd_inputMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_inputMode.FormattingEnabled = true;
            this.cmd_inputMode.Items.AddRange(new object[] {
            "INACTIVE",
            "PASSTHROUGH",
            "VEL RAMP ",
            "FILTER",
            "CHANNELS",
            "TRAP TRAJ",
            "TORQUE RAMP",
            "MIRROR",
            "TUNING"});
            this.cmd_inputMode.Location = new System.Drawing.Point(292, 318);
            this.cmd_inputMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmd_inputMode.Name = "cmd_inputMode";
            this.cmd_inputMode.Size = new System.Drawing.Size(143, 24);
            this.cmd_inputMode.TabIndex = 15;
            this.cmd_inputMode.SelectedIndexChanged += new System.EventHandler(this.cmd_inputMode_SelectedIndexChanged);
            // 
            // cmd_ControlMode
            // 
            this.cmd_ControlMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_ControlMode.FormattingEnabled = true;
            this.cmd_ControlMode.Items.AddRange(new object[] {
            "VOLTAGE CONTROL",
            "TORQUE CONTROL",
            "VELOCITY CONTROL",
            "POSITION CONTROL   "});
            this.cmd_ControlMode.Location = new System.Drawing.Point(292, 197);
            this.cmd_ControlMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmd_ControlMode.Name = "cmd_ControlMode";
            this.cmd_ControlMode.Size = new System.Drawing.Size(143, 24);
            this.cmd_ControlMode.TabIndex = 14;
            this.cmd_ControlMode.SelectedIndexChanged += new System.EventHandler(this.cmd_ControlMode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Selected";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Current";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Selected";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Current";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Current";
            // 
            // cmd_AxisState
            // 
            this.cmd_AxisState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmd_AxisState.FormattingEnabled = true;
            this.cmd_AxisState.Items.AddRange(new object[] {
            "UNDEFINED",
            "IDLE",
            "STARTUP SEQUENCE",
            "CALIBRATION SEQUENCE",
            "HIC",
            "MOTOR_CALIBRATION",
            "ENCODER_INDEX SEARCH",
            "OFFSET CALIBRATION",
            "CLOSED LOOP CONTROL",
            "LOCKIN SPIN",
            "ENCODER DIR FIND",
            "HOMING"});
            this.cmd_AxisState.Location = new System.Drawing.Point(292, 70);
            this.cmd_AxisState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmd_AxisState.Name = "cmd_AxisState";
            this.cmd_AxisState.Size = new System.Drawing.Size(143, 24);
            this.cmd_AxisState.TabIndex = 6;
            this.cmd_AxisState.SelectedIndexChanged += new System.EventHandler(this.cmd_AxisState_SelectedIndexChanged);
            // 
            // lbl_Input_mode
            // 
            this.lbl_Input_mode.AutoSize = true;
            this.lbl_Input_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Input_mode.Location = new System.Drawing.Point(11, 324);
            this.lbl_Input_mode.Name = "lbl_Input_mode";
            this.lbl_Input_mode.Size = new System.Drawing.Size(0, 17);
            this.lbl_Input_mode.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(105, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 31);
            this.label6.TabIndex = 4;
            this.label6.Text = "INPUTMODE";
            // 
            // lbl_ControlMode
            // 
            this.lbl_ControlMode.AutoSize = true;
            this.lbl_ControlMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_ControlMode.Location = new System.Drawing.Point(11, 198);
            this.lbl_ControlMode.Name = "lbl_ControlMode";
            this.lbl_ControlMode.Size = new System.Drawing.Size(0, 17);
            this.lbl_ControlMode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(77, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "CONTROLMODE";
            // 
            // lbl_RequestedState
            // 
            this.lbl_RequestedState.AutoSize = true;
            this.lbl_RequestedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_RequestedState.Location = new System.Drawing.Point(11, 69);
            this.lbl_RequestedState.Name = "lbl_RequestedState";
            this.lbl_RequestedState.Size = new System.Drawing.Size(0, 17);
            this.lbl_RequestedState.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(105, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "AXİSSTATE";
            // 
            // lst_replyof_freeprot
            // 
            this.lst_replyof_freeprot.FormattingEnabled = true;
            this.lst_replyof_freeprot.ItemHeight = 16;
            this.lst_replyof_freeprot.Location = new System.Drawing.Point(12, 517);
            this.lst_replyof_freeprot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lst_replyof_freeprot.Name = "lst_replyof_freeprot";
            this.lst_replyof_freeprot.ScrollAlwaysVisible = true;
            this.lst_replyof_freeprot.Size = new System.Drawing.Size(359, 164);
            this.lst_replyof_freeprot.TabIndex = 5;
            // 
            // pnl_Driving
            // 
            this.pnl_Driving.Controls.Add(this.tec_pos);
            this.pnl_Driving.Controls.Add(this.tec_velocity);
            this.pnl_Driving.Controls.Add(this.prc_pos);
            this.pnl_Driving.Controls.Add(this.prc_Vel);
            this.pnl_Driving.Location = new System.Drawing.Point(1245, 482);
            this.pnl_Driving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_Driving.Name = "pnl_Driving";
            this.pnl_Driving.Size = new System.Drawing.Size(451, 270);
            this.pnl_Driving.TabIndex = 6;
            // 
            // tec_pos
            // 
            this.tec_pos.Location = new System.Drawing.Point(231, 212);
            this.tec_pos.Maximum = 360;
            this.tec_pos.Minimum = -360;
            this.tec_pos.Name = "tec_pos";
            this.tec_pos.Size = new System.Drawing.Size(219, 56);
            this.tec_pos.TabIndex = 5;
            this.tec_pos.MouseCaptureChanged += new System.EventHandler(this.tec_pos_MouseCaptureChanged);
            // 
            // tec_velocity
            // 
            this.tec_velocity.Location = new System.Drawing.Point(14, 44);
            this.tec_velocity.Maximum = 40;
            this.tec_velocity.Minimum = -40;
            this.tec_velocity.Name = "tec_velocity";
            this.tec_velocity.Size = new System.Drawing.Size(213, 56);
            this.tec_velocity.TabIndex = 4;
            this.tec_velocity.MouseCaptureChanged += new System.EventHandler(this.tec_velocity_MouseCaptureChanged);
            // 
            // prc_pos
            // 
            this.prc_pos.AnimationEnabled = false;
            this.prc_pos.Location = new System.Drawing.Point(280, 35);
            this.prc_pos.Maximum = 360D;
            this.prc_pos.Name = "prc_pos";
            this.prc_pos.ScaleFactor = 1D;
            this.prc_pos.Size = new System.Drawing.Size(159, 173);
            this.prc_pos.TabIndex = 1;
            this.prc_pos.Title = "";
            this.prc_pos.Unit = "ratio";
            this.prc_pos.Value = 0D;
            // 
            // prc_Vel
            // 
            this.prc_Vel.AnimationEnabled = false;
            this.prc_Vel.Location = new System.Drawing.Point(25, 106);
            this.prc_Vel.Maximum = 40D;
            this.prc_Vel.Minimum = -40D;
            this.prc_Vel.Name = "prc_Vel";
            this.prc_Vel.ScaleFactor = 1D;
            this.prc_Vel.Size = new System.Drawing.Size(188, 164);
            this.prc_Vel.TabIndex = 0;
            this.prc_Vel.Title = "";
            this.prc_Vel.Unit = "d/dk";
            this.prc_Vel.Value = 0D;
            // 
            // tmr_Read_Timeour
            // 
            this.tmr_Read_Timeour.Tick += new System.EventHandler(this.tmr_Read_Timeour_Tick_1);
            // 
            // exoskeleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1707, 763);
            this.Controls.Add(this.pnl_Driving);
            this.Controls.Add(this.lst_replyof_freeprot);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_SenderBox);
            this.Controls.Add(this.ControlTab);
            this.Controls.Add(this.pnl_SerialCom);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "exoskeleton";
            this.Text = "Hic_Speacial_Servo_App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.exoskeleton_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.exoskeleton_FormClosed);
            this.Load += new System.EventHandler(this.exoskeleton_Load);
            this.pnl_SerialCom.ResumeLayout(false);
            this.pnl_SerialCom.PerformLayout();
            this.ControlTab.ResumeLayout(false);
            this.Graph_pos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grp_time_pos)).EndInit();
            this.Graph_vel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grph_time_vel)).EndInit();
            this.Graph_Torque.ResumeLayout(false);
            this.Graph_Torque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grph_time_torque)).EndInit();
            this.tp_Configration_Setting.ResumeLayout(false);
            this.tp_Configration_Setting.PerformLayout();
            this.tP_ErrorPage.ResumeLayout(false);
            this.Tb_CanTester.ResumeLayout(false);
            this.Tb_CanTester.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanTable)).EndInit();
            this.tp_Graph_PID.ResumeLayout(false);
            this.tp_Graph_PID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grph_PID)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Driving.ResumeLayout(false);
            this.pnl_Driving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tec_pos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tec_velocity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_SerialCom;
        private System.Windows.Forms.Button btn_ClosePort;
        private System.Windows.Forms.Button btn_OpenPOrt;
        public System.Windows.Forms.Label lbl_PortStatus;
        private System.Windows.Forms.TabControl ControlTab;
        private System.Windows.Forms.TabPage Graph_pos;
        private System.Windows.Forms.TabPage Graph_vel;
        private System.Windows.Forms.DataVisualization.Charting.Chart grph_time_vel;
        private System.Windows.Forms.TabPage Graph_Torque;
        private System.Windows.Forms.DataVisualization.Charting.Chart grph_time_torque;
        public System.Windows.Forms.DataVisualization.Charting.Chart grp_time_pos;
        private System.Windows.Forms.TextBox txt_SenderBox;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Input_mode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_ControlMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_RequestedState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmd_inputMode;
        private System.Windows.Forms.ComboBox cmd_ControlMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmd_AxisState;
        private System.Windows.Forms.TabPage tp_Configration_Setting;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_torq_cons;
        private System.Windows.Forms.TextBox txt_vel_ramp_lim;
        private System.Windows.Forms.TextBox txt_cur_lim;
        private System.Windows.Forms.TextBox txt_vel_lim;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lst_replyof_freeprot;
        private System.Windows.Forms.Label lbl_inputmodewarn;
        private System.Windows.Forms.Label lbl_controlModeWarning;
        private System.Windows.Forms.Label lbl_AxisWarning;
        private System.Windows.Forms.Button btn_inputmodeset;
        private System.Windows.Forms.Button btn_controlmodeset;
        private System.Windows.Forms.Button btn_axisset;
        private System.Windows.Forms.Panel pnl_Driving;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_tt_inertia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_tt_dcc_lim;
        private System.Windows.Forms.TextBox txt_tt_acc_lim;
        private System.Windows.Forms.TextBox txt_tt_vel_lim;
        private System.Windows.Forms.Label lbl_ControleMode;
        private System.Windows.Forms.Label lbl_torque;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Timer tmr_Read_Timeour;
        private System.Windows.Forms.TabPage tP_ErrorPage;
        private System.Windows.Forms.Button btn_Clear_Err;
        private System.Windows.Forms.ListBox lst_SoftErr;
        private System.Windows.Forms.ListBox lst_DriverError;
        private CodeArtEng.Gauge.CircularGauge2 prc_pos;
        private CodeArtEng.Gauge.CircularGauge prc_Vel;
        private System.Windows.Forms.TrackBar tec_pos;
        private System.Windows.Forms.TrackBar tec_velocity;
        private System.Windows.Forms.Button btn_Reflash;
        private System.Windows.Forms.TabPage Tb_CanTester;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView CanTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderFirstByte;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndByte;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueDec;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.TextBox txt_Second_Data;
        private System.Windows.Forms.TextBox txt_FirstData;
        private System.Windows.Forms.TextBox txt_Seconddataname;
        private System.Windows.Forms.TextBox txt_Firstdataname;
        private System.Windows.Forms.Button Drive_test_With_Can;
        private System.Windows.Forms.TabPage tp_Graph_PID;
        private System.Windows.Forms.DataVisualization.Charting.Chart grph_PID;
        private System.Windows.Forms.Label clct_PID_out;
    }
}

