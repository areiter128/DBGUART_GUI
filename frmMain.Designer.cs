namespace smpsDebugUartTestWindow
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpPortConfig = new System.Windows.Forms.GroupBox();
            this.cmdOpenPort = new System.Windows.Forms.Button();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.lblCommPort = new System.Windows.Forms.Label();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.cmbCommPort = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFrameBuffer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReadTimerInterval = new System.Windows.Forms.TextBox();
            this.lblCRCErrors = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFrameErrors = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFrameCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStreamErrorCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecLength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaxLength = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMinLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBufferView = new System.Windows.Forms.CheckBox();
            this.lblFrameBuffer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDPackCount = new System.Windows.Forms.Label();
            this.lblPortDescrition = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tmrMain = new System.Timers.Timer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabAddTxFrames = new System.Windows.Forms.TabPage();
            this.splitFrames = new System.Windows.Forms.SplitContainer();
            this.grpTxFrameList = new System.Windows.Forms.GroupBox();
            this.lvTxFrames = new System.Windows.Forms.ListView();
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpRxFrameList = new System.Windows.Forms.GroupBox();
            this.lvRxFrames = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpTxFrameEdit = new System.Windows.Forms.GroupBox();
            this.lblBytePos = new System.Windows.Forms.Label();
            this.lblBytePosLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdNewTxFrame = new System.Windows.Forms.Button();
            this.cmdDeleteTxFrame = new System.Windows.Forms.Button();
            this.txtUserLabel = new System.Windows.Forms.TextBox();
            this.lblUserLabel = new System.Windows.Forms.Label();
            this.txtEOF = new System.Windows.Forms.TextBox();
            this.lblEOF = new System.Windows.Forms.Label();
            this.txtSOF = new System.Windows.Forms.TextBox();
            this.lblSOF = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCRC = new System.Windows.Forms.Label();
            this.cmdAddTxFrame = new System.Windows.Forms.Button();
            this.txtCRC = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblDATA = new System.Windows.Forms.Label();
            this.txtDLEN = new System.Windows.Forms.TextBox();
            this.txtDATA = new System.Windows.Forms.TextBox();
            this.lblDLEN = new System.Windows.Forms.Label();
            this.tabMonitorPanel = new System.Windows.Forms.TabPage();
            this.grpDataMonitor = new System.Windows.Forms.GroupBox();
            this.lvDataMonitor = new System.Windows.Forms.ListView();
            this.colCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDecimal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBinary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabTerminal = new System.Windows.Forms.TabPage();
            this.txtOutputTerminal = new System.Windows.Forms.RichTextBox();
            this.tabBufferView = new System.Windows.Forms.TabPage();
            this.txtBufferView = new System.Windows.Forms.RichTextBox();
            this.chkEnableCID_22Check = new System.Windows.Forms.CheckBox();
            this.imlFrameClasses = new System.Windows.Forms.ImageList(this.components);
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.lblReceivePeriod = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdResetFrameBuffer = new System.Windows.Forms.Button();
            this.cmdResetStatistics = new System.Windows.Forms.Button();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.grpReceiverSettings = new System.Windows.Forms.GroupBox();
            this.grpMonitorFile = new System.Windows.Forms.GroupBox();
            this.lblUserConfigDescription = new System.Windows.Forms.Label();
            this.lblUserConfigName = new System.Windows.Forms.Label();
            this.stbMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbBuffer = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusProcessTicks = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrOpenPortNotice = new System.Windows.Forms.Timer(this.components);
            this.tmrPortScan = new System.Windows.Forms.Timer(this.components);
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openUserDataConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbUserFileName = new System.Windows.Forms.ToolStripComboBox();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpPortConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmrMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabAddTxFrames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFrames)).BeginInit();
            this.splitFrames.Panel1.SuspendLayout();
            this.splitFrames.Panel2.SuspendLayout();
            this.splitFrames.SuspendLayout();
            this.grpTxFrameList.SuspendLayout();
            this.grpRxFrameList.SuspendLayout();
            this.grpTxFrameEdit.SuspendLayout();
            this.tabMonitorPanel.SuspendLayout();
            this.grpDataMonitor.SuspendLayout();
            this.tabTerminal.SuspendLayout();
            this.tabBufferView.SuspendLayout();
            this.grpStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.grpReceiverSettings.SuspendLayout();
            this.grpMonitorFile.SuspendLayout();
            this.stbMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPortConfig
            // 
            this.grpPortConfig.Controls.Add(this.cmdOpenPort);
            this.grpPortConfig.Controls.Add(this.lblBaudrate);
            this.grpPortConfig.Controls.Add(this.lblCommPort);
            this.grpPortConfig.Controls.Add(this.cmbBaudrate);
            this.grpPortConfig.Controls.Add(this.cmbCommPort);
            this.grpPortConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPortConfig.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPortConfig.Location = new System.Drawing.Point(0, 0);
            this.grpPortConfig.Name = "grpPortConfig";
            this.grpPortConfig.Size = new System.Drawing.Size(262, 136);
            this.grpPortConfig.TabIndex = 0;
            this.grpPortConfig.TabStop = false;
            this.grpPortConfig.Text = "Serial Port Configuration";
            // 
            // cmdOpenPort
            // 
            this.cmdOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpenPort.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpenPort.Location = new System.Drawing.Point(137, 97);
            this.cmdOpenPort.Name = "cmdOpenPort";
            this.cmdOpenPort.Size = new System.Drawing.Size(101, 27);
            this.cmdOpenPort.TabIndex = 4;
            this.cmdOpenPort.Text = "Open Port";
            this.cmdOpenPort.UseVisualStyleBackColor = true;
            this.cmdOpenPort.Click += new System.EventHandler(this.cmdOpenPort_Click);
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudrate.Location = new System.Drawing.Point(17, 62);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(60, 15);
            this.lblBaudrate.TabIndex = 3;
            this.lblBaudrate.Text = "Baudrate:";
            // 
            // lblCommPort
            // 
            this.lblCommPort.AutoSize = true;
            this.lblCommPort.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommPort.Location = new System.Drawing.Point(17, 37);
            this.lblCommPort.Name = "lblCommPort";
            this.lblCommPort.Size = new System.Drawing.Size(33, 15);
            this.lblCommPort.TabIndex = 2;
            this.lblCommPort.Text = "Port:";
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaudrate.AutoCompleteCustomSource.AddRange(new string[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cmbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudrate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cmbBaudrate.Location = new System.Drawing.Point(91, 59);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(147, 23);
            this.cmbBaudrate.TabIndex = 1;
            this.cmbBaudrate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudrate_SelectedIndexChanged);
            // 
            // cmbCommPort
            // 
            this.cmbCommPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommPort.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCommPort.FormattingEnabled = true;
            this.cmbCommPort.Location = new System.Drawing.Point(91, 33);
            this.cmbCommPort.Name = "cmbCommPort";
            this.cmbCommPort.Size = new System.Drawing.Size(147, 23);
            this.cmbCommPort.TabIndex = 0;
            this.cmbCommPort.SelectedIndexChanged += new System.EventHandler(this.cmbCommPort_SelectedIndexChanged);
            this.cmbCommPort.TextChanged += new System.EventHandler(this.cmbCommPort_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "No. of Frames buffered:";
            // 
            // txtFrameBuffer
            // 
            this.txtFrameBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrameBuffer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrameBuffer.Location = new System.Drawing.Point(180, 51);
            this.txtFrameBuffer.Name = "txtFrameBuffer";
            this.txtFrameBuffer.Size = new System.Drawing.Size(58, 23);
            this.txtFrameBuffer.TabIndex = 26;
            this.txtFrameBuffer.Text = "32";
            this.txtFrameBuffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFrameBuffer.TextChanged += new System.EventHandler(this.txtFrameBuffer_TextChanged);
            this.txtFrameBuffer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericTextBox_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Refresh Rate [ms]:";
            // 
            // txtReadTimerInterval
            // 
            this.txtReadTimerInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReadTimerInterval.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadTimerInterval.Location = new System.Drawing.Point(180, 22);
            this.txtReadTimerInterval.Name = "txtReadTimerInterval";
            this.txtReadTimerInterval.Size = new System.Drawing.Size(58, 23);
            this.txtReadTimerInterval.TabIndex = 2;
            this.txtReadTimerInterval.Text = "50";
            this.txtReadTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReadTimerInterval.TextChanged += new System.EventHandler(this.txtReadTimerInterval_TextChanged);
            this.txtReadTimerInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumericTextBox_KeyDown);
            // 
            // lblCRCErrors
            // 
            this.lblCRCErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCRCErrors.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCRCErrors.Location = new System.Drawing.Point(180, 174);
            this.lblCRCErrors.Name = "lblCRCErrors";
            this.lblCRCErrors.Size = new System.Drawing.Size(58, 15);
            this.lblCRCErrors.TabIndex = 25;
            this.lblCRCErrors.Text = "0";
            this.lblCRCErrors.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "CRC Errors:";
            // 
            // lblFrameErrors
            // 
            this.lblFrameErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrameErrors.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameErrors.Location = new System.Drawing.Point(180, 159);
            this.lblFrameErrors.Name = "lblFrameErrors";
            this.lblFrameErrors.Size = new System.Drawing.Size(58, 15);
            this.lblFrameErrors.TabIndex = 23;
            this.lblFrameErrors.Text = "0";
            this.lblFrameErrors.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Frame Errors:";
            // 
            // lblFrameCount
            // 
            this.lblFrameCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrameCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameCount.Location = new System.Drawing.Point(180, 144);
            this.lblFrameCount.Name = "lblFrameCount";
            this.lblFrameCount.Size = new System.Drawing.Size(58, 15);
            this.lblFrameCount.TabIndex = 21;
            this.lblFrameCount.Text = "0";
            this.lblFrameCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Frames Received:";
            // 
            // lblStreamErrorCounter
            // 
            this.lblStreamErrorCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStreamErrorCounter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamErrorCounter.Location = new System.Drawing.Point(180, 189);
            this.lblStreamErrorCounter.Name = "lblStreamErrorCounter";
            this.lblStreamErrorCounter.Size = new System.Drawing.Size(58, 15);
            this.lblStreamErrorCounter.TabIndex = 18;
            this.lblStreamErrorCounter.Text = "0";
            this.lblStreamErrorCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Stream Errors*:";
            // 
            // lblRecLength
            // 
            this.lblRecLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecLength.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecLength.Location = new System.Drawing.Point(180, 101);
            this.lblRecLength.Name = "lblRecLength";
            this.lblRecLength.Size = new System.Drawing.Size(58, 15);
            this.lblRecLength.TabIndex = 15;
            this.lblRecLength.Text = "0";
            this.lblRecLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Recent Length:";
            // 
            // lblMaxLength
            // 
            this.lblMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxLength.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLength.Location = new System.Drawing.Point(180, 86);
            this.lblMaxLength.Name = "lblMaxLength";
            this.lblMaxLength.Size = new System.Drawing.Size(58, 15);
            this.lblMaxLength.TabIndex = 13;
            this.lblMaxLength.Text = "0";
            this.lblMaxLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Maximum Length:";
            // 
            // lblMinLength
            // 
            this.lblMinLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinLength.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLength.Location = new System.Drawing.Point(180, 71);
            this.lblMinLength.Name = "lblMinLength";
            this.lblMinLength.Size = new System.Drawing.Size(58, 15);
            this.lblMinLength.TabIndex = 11;
            this.lblMinLength.Text = "0";
            this.lblMinLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Minimum Length:";
            // 
            // chkBufferView
            // 
            this.chkBufferView.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkBufferView.AutoSize = true;
            this.chkBufferView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBufferView.Location = new System.Drawing.Point(64, 86);
            this.chkBufferView.Name = "chkBufferView";
            this.chkBufferView.Size = new System.Drawing.Size(117, 19);
            this.chkBufferView.TabIndex = 9;
            this.chkBufferView.Text = "&Hold Buffer View";
            this.chkBufferView.UseVisualStyleBackColor = true;
            this.chkBufferView.CheckedChanged += new System.EventHandler(this.chkDataOutput_CheckedChanged);
            // 
            // lblFrameBuffer
            // 
            this.lblFrameBuffer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrameBuffer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrameBuffer.Location = new System.Drawing.Point(180, 129);
            this.lblFrameBuffer.Name = "lblFrameBuffer";
            this.lblFrameBuffer.Size = new System.Drawing.Size(58, 15);
            this.lblFrameBuffer.TabIndex = 8;
            this.lblFrameBuffer.Text = "0";
            this.lblFrameBuffer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Frames Buffered:";
            // 
            // lblDPackCount
            // 
            this.lblDPackCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDPackCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDPackCount.Location = new System.Drawing.Point(180, 29);
            this.lblDPackCount.Name = "lblDPackCount";
            this.lblDPackCount.Size = new System.Drawing.Size(58, 15);
            this.lblDPackCount.TabIndex = 6;
            this.lblDPackCount.Text = "0";
            this.lblDPackCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPortDescrition
            // 
            this.lblPortDescrition.AutoSize = true;
            this.lblPortDescrition.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortDescrition.Location = new System.Drawing.Point(17, 29);
            this.lblPortDescrition.Name = "lblPortDescrition";
            this.lblPortDescrition.Size = new System.Drawing.Size(141, 15);
            this.lblPortDescrition.TabIndex = 5;
            this.lblPortDescrition.Text = "Data Packages Received:";
            // 
            // serialPort
            // 
            this.serialPort.ReceivedBytesThreshold = 8;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // tmrMain
            // 
            this.tmrMain.SynchronizingObject = this;
            this.tmrMain.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrMain_Elapsed);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabAddTxFrames);
            this.tabMain.Controls.Add(this.tabMonitorPanel);
            this.tabMain.Controls.Add(this.tabTerminal);
            this.tabMain.Controls.Add(this.tabBufferView);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 75);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(999, 627);
            this.tabMain.TabIndex = 2;
            // 
            // tabAddTxFrames
            // 
            this.tabAddTxFrames.Controls.Add(this.splitFrames);
            this.tabAddTxFrames.Controls.Add(this.grpTxFrameEdit);
            this.tabAddTxFrames.Location = new System.Drawing.Point(4, 24);
            this.tabAddTxFrames.Name = "tabAddTxFrames";
            this.tabAddTxFrames.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddTxFrames.Size = new System.Drawing.Size(991, 599);
            this.tabAddTxFrames.TabIndex = 0;
            this.tabAddTxFrames.Text = "Message Frames";
            this.tabAddTxFrames.UseVisualStyleBackColor = true;
            // 
            // splitFrames
            // 
            this.splitFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFrames.Location = new System.Drawing.Point(3, 212);
            this.splitFrames.Name = "splitFrames";
            this.splitFrames.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFrames.Panel1
            // 
            this.splitFrames.Panel1.Controls.Add(this.grpTxFrameList);
            // 
            // splitFrames.Panel2
            // 
            this.splitFrames.Panel2.Controls.Add(this.grpRxFrameList);
            this.splitFrames.Size = new System.Drawing.Size(985, 384);
            this.splitFrames.SplitterDistance = 196;
            this.splitFrames.TabIndex = 10;
            // 
            // grpTxFrameList
            // 
            this.grpTxFrameList.Controls.Add(this.lvTxFrames);
            this.grpTxFrameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTxFrameList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTxFrameList.Location = new System.Drawing.Point(0, 0);
            this.grpTxFrameList.Name = "grpTxFrameList";
            this.grpTxFrameList.Size = new System.Drawing.Size(985, 196);
            this.grpTxFrameList.TabIndex = 10;
            this.grpTxFrameList.TabStop = false;
            this.grpTxFrameList.Text = "Tx Frame List";
            // 
            // lvTxFrames
            // 
            this.lvTxFrames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Label,
            this.Command});
            this.lvTxFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTxFrames.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTxFrames.FullRowSelect = true;
            this.lvTxFrames.GridLines = true;
            this.lvTxFrames.HideSelection = false;
            this.lvTxFrames.Location = new System.Drawing.Point(3, 19);
            this.lvTxFrames.Name = "lvTxFrames";
            this.lvTxFrames.Size = new System.Drawing.Size(979, 174);
            this.lvTxFrames.TabIndex = 1;
            this.lvTxFrames.UseCompatibleStateImageBehavior = false;
            this.lvTxFrames.View = System.Windows.Forms.View.Details;
            this.lvTxFrames.SelectedIndexChanged += new System.EventHandler(this.lvTxFrames_SelectedIndexChanged);
            this.lvTxFrames.DoubleClick += new System.EventHandler(this.SendTxFrame);
            this.lvTxFrames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvTxFrames_KeyDown);
            this.lvTxFrames.Resize += new System.EventHandler(this.lvTxFrames_Resize);
            // 
            // Label
            // 
            this.Label.Text = "User Label";
            this.Label.Width = 220;
            // 
            // Command
            // 
            this.Command.Text = "Message Frame";
            this.Command.Width = 747;
            // 
            // grpRxFrameList
            // 
            this.grpRxFrameList.Controls.Add(this.lvRxFrames);
            this.grpRxFrameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRxFrameList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRxFrameList.Location = new System.Drawing.Point(0, 0);
            this.grpRxFrameList.Name = "grpRxFrameList";
            this.grpRxFrameList.Size = new System.Drawing.Size(985, 184);
            this.grpRxFrameList.TabIndex = 11;
            this.grpRxFrameList.TabStop = false;
            this.grpRxFrameList.Text = "Rx Frame List";
            // 
            // lvRxFrames
            // 
            this.lvRxFrames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colCMD,
            this.colCount,
            this.colTimeStamp});
            this.lvRxFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRxFrames.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRxFrames.FullRowSelect = true;
            this.lvRxFrames.GridLines = true;
            this.lvRxFrames.HideSelection = false;
            this.lvRxFrames.Location = new System.Drawing.Point(3, 19);
            this.lvRxFrames.Name = "lvRxFrames";
            this.lvRxFrames.Size = new System.Drawing.Size(979, 162);
            this.lvRxFrames.TabIndex = 1;
            this.lvRxFrames.UseCompatibleStateImageBehavior = false;
            this.lvRxFrames.View = System.Windows.Forms.View.Details;
            this.lvRxFrames.Resize += new System.EventHandler(this.lvRxFrames_Resize);
            // 
            // colID
            // 
            this.colID.Text = "Message ID";
            this.colID.Width = 120;
            // 
            // colCMD
            // 
            this.colCMD.Text = "Message Frame";
            this.colCMD.Width = 674;
            // 
            // colCount
            // 
            this.colCount.Text = "Count";
            this.colCount.Width = 89;
            // 
            // colTimeStamp
            // 
            this.colTimeStamp.Text = "Time Stamp";
            this.colTimeStamp.Width = 89;
            // 
            // grpTxFrameEdit
            // 
            this.grpTxFrameEdit.Controls.Add(this.lblBytePos);
            this.grpTxFrameEdit.Controls.Add(this.lblBytePosLabel);
            this.grpTxFrameEdit.Controls.Add(this.label12);
            this.grpTxFrameEdit.Controls.Add(this.label1);
            this.grpTxFrameEdit.Controls.Add(this.cmdNewTxFrame);
            this.grpTxFrameEdit.Controls.Add(this.cmdDeleteTxFrame);
            this.grpTxFrameEdit.Controls.Add(this.txtUserLabel);
            this.grpTxFrameEdit.Controls.Add(this.lblUserLabel);
            this.grpTxFrameEdit.Controls.Add(this.txtEOF);
            this.grpTxFrameEdit.Controls.Add(this.lblEOF);
            this.grpTxFrameEdit.Controls.Add(this.txtSOF);
            this.grpTxFrameEdit.Controls.Add(this.lblSOF);
            this.grpTxFrameEdit.Controls.Add(this.txtID);
            this.grpTxFrameEdit.Controls.Add(this.lblCRC);
            this.grpTxFrameEdit.Controls.Add(this.cmdAddTxFrame);
            this.grpTxFrameEdit.Controls.Add(this.txtCRC);
            this.grpTxFrameEdit.Controls.Add(this.lblID);
            this.grpTxFrameEdit.Controls.Add(this.lblDATA);
            this.grpTxFrameEdit.Controls.Add(this.txtDLEN);
            this.grpTxFrameEdit.Controls.Add(this.txtDATA);
            this.grpTxFrameEdit.Controls.Add(this.lblDLEN);
            this.grpTxFrameEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTxFrameEdit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTxFrameEdit.Location = new System.Drawing.Point(3, 3);
            this.grpTxFrameEdit.Name = "grpTxFrameEdit";
            this.grpTxFrameEdit.Size = new System.Drawing.Size(985, 209);
            this.grpTxFrameEdit.TabIndex = 9;
            this.grpTxFrameEdit.TabStop = false;
            this.grpTxFrameEdit.Text = "Tx Frame Builder";
            // 
            // lblBytePos
            // 
            this.lblBytePos.AutoSize = true;
            this.lblBytePos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytePos.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblBytePos.Location = new System.Drawing.Point(685, 109);
            this.lblBytePos.Name = "lblBytePos";
            this.lblBytePos.Size = new System.Drawing.Size(43, 15);
            this.lblBytePos.TabIndex = 21;
            this.lblBytePos.Text = "BYTE-0";
            this.lblBytePos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBytePosLabel
            // 
            this.lblBytePosLabel.AutoSize = true;
            this.lblBytePosLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytePosLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblBytePosLabel.Location = new System.Drawing.Point(589, 109);
            this.lblBytePosLabel.Name = "lblBytePosLabel";
            this.lblBytePosLabel.Size = new System.Drawing.Size(81, 15);
            this.lblBytePosLabel.TabIndex = 20;
            this.lblBytePosLabel.Text = "Byte Position:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(180, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(549, 34);
            this.label12.TabIndex = 19;
            this.label12.Text = "Select an item from [Tx Frame List] below and hit ENTER or double-click a list it" +
    "em to send the selected, user defined message frame to the connected target devi" +
    "ce.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(177, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Please Note:";
            // 
            // cmdNewTxFrame
            // 
            this.cmdNewTxFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNewTxFrame.Enabled = false;
            this.cmdNewTxFrame.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewTxFrame.Location = new System.Drawing.Point(851, 125);
            this.cmdNewTxFrame.Name = "cmdNewTxFrame";
            this.cmdNewTxFrame.Size = new System.Drawing.Size(101, 27);
            this.cmdNewTxFrame.TabIndex = 16;
            this.cmdNewTxFrame.Text = "&New";
            this.cmdNewTxFrame.UseVisualStyleBackColor = true;
            this.cmdNewTxFrame.Click += new System.EventHandler(this.cmdNewTxFrame_Click);
            // 
            // cmdDeleteTxFrame
            // 
            this.cmdDeleteTxFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteTxFrame.Enabled = false;
            this.cmdDeleteTxFrame.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteTxFrame.Location = new System.Drawing.Point(851, 152);
            this.cmdDeleteTxFrame.Name = "cmdDeleteTxFrame";
            this.cmdDeleteTxFrame.Size = new System.Drawing.Size(101, 27);
            this.cmdDeleteTxFrame.TabIndex = 17;
            this.cmdDeleteTxFrame.Text = "&Delete";
            this.cmdDeleteTxFrame.UseVisualStyleBackColor = true;
            this.cmdDeleteTxFrame.Click += new System.EventHandler(this.cmdDeleteTxFrame_Click);
            // 
            // txtUserLabel
            // 
            this.txtUserLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLabel.Location = new System.Drawing.Point(177, 33);
            this.txtUserLabel.Name = "txtUserLabel";
            this.txtUserLabel.Size = new System.Drawing.Size(274, 23);
            this.txtUserLabel.TabIndex = 2;
            this.txtUserLabel.Text = "New Tx Frame";
            this.txtUserLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserLabel_KeyDown);
            // 
            // lblUserLabel
            // 
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLabel.Location = new System.Drawing.Point(101, 37);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new System.Drawing.Size(70, 15);
            this.lblUserLabel.TabIndex = 1;
            this.lblUserLabel.Text = "User Label: ";
            this.lblUserLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtEOF
            // 
            this.txtEOF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEOF.Enabled = false;
            this.txtEOF.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEOF.Location = new System.Drawing.Point(791, 86);
            this.txtEOF.Name = "txtEOF";
            this.txtEOF.Size = new System.Drawing.Size(33, 23);
            this.txtEOF.TabIndex = 14;
            this.txtEOF.Text = "0D";
            // 
            // lblEOF
            // 
            this.lblEOF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEOF.AutoSize = true;
            this.lblEOF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEOF.Location = new System.Drawing.Point(793, 68);
            this.lblEOF.Name = "lblEOF";
            this.lblEOF.Size = new System.Drawing.Size(28, 15);
            this.lblEOF.TabIndex = 13;
            this.lblEOF.Text = "EOF";
            // 
            // txtSOF
            // 
            this.txtSOF.Enabled = false;
            this.txtSOF.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSOF.Location = new System.Drawing.Point(27, 86);
            this.txtSOF.MaxLength = 2;
            this.txtSOF.Name = "txtSOF";
            this.txtSOF.Size = new System.Drawing.Size(33, 23);
            this.txtSOF.TabIndex = 4;
            this.txtSOF.Text = "55";
            // 
            // lblSOF
            // 
            this.lblSOF.AutoSize = true;
            this.lblSOF.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSOF.Location = new System.Drawing.Point(30, 68);
            this.lblSOF.Name = "lblSOF";
            this.lblSOF.Size = new System.Drawing.Size(28, 15);
            this.lblSOF.TabIndex = 3;
            this.lblSOF.Text = "SOF";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(68, 86);
            this.txtID.MaxLength = 5;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(47, 23);
            this.txtID.TabIndex = 6;
            this.txtID.Text = "00 30";
            this.txtID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxFrameField_MouseClick);
            this.txtID.TextChanged += new System.EventHandler(this.TxFrameField_TextChanged);
            this.txtID.Enter += new System.EventHandler(this.TxFrameField_GetCursor);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxFrameField_KeyDown);
            this.txtID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HexTextBoxEdit);
            // 
            // lblCRC
            // 
            this.lblCRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCRC.AutoSize = true;
            this.lblCRC.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCRC.Location = new System.Drawing.Point(738, 68);
            this.lblCRC.Name = "lblCRC";
            this.lblCRC.Size = new System.Drawing.Size(28, 15);
            this.lblCRC.TabIndex = 11;
            this.lblCRC.Text = "CRC";
            // 
            // cmdAddTxFrame
            // 
            this.cmdAddTxFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAddTxFrame.Enabled = false;
            this.cmdAddTxFrame.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddTxFrame.Location = new System.Drawing.Point(851, 83);
            this.cmdAddTxFrame.Name = "cmdAddTxFrame";
            this.cmdAddTxFrame.Size = new System.Drawing.Size(101, 27);
            this.cmdAddTxFrame.TabIndex = 15;
            this.cmdAddTxFrame.Text = "&Add";
            this.cmdAddTxFrame.UseVisualStyleBackColor = true;
            this.cmdAddTxFrame.Click += new System.EventHandler(this.cmdAddTxFrame_Click);
            // 
            // txtCRC
            // 
            this.txtCRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCRC.Enabled = false;
            this.txtCRC.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCRC.Location = new System.Drawing.Point(736, 86);
            this.txtCRC.Name = "txtCRC";
            this.txtCRC.Size = new System.Drawing.Size(47, 23);
            this.txtCRC.TabIndex = 12;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(71, 68);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 15);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "CID";
            // 
            // lblDATA
            // 
            this.lblDATA.AutoSize = true;
            this.lblDATA.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDATA.Location = new System.Drawing.Point(180, 68);
            this.lblDATA.Name = "lblDATA";
            this.lblDATA.Size = new System.Drawing.Size(33, 15);
            this.lblDATA.TabIndex = 9;
            this.lblDATA.Text = "DATA";
            // 
            // txtDLEN
            // 
            this.txtDLEN.Enabled = false;
            this.txtDLEN.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLEN.Location = new System.Drawing.Point(122, 86);
            this.txtDLEN.MaxLength = 5;
            this.txtDLEN.Name = "txtDLEN";
            this.txtDLEN.Size = new System.Drawing.Size(47, 23);
            this.txtDLEN.TabIndex = 8;
            this.txtDLEN.Text = "00 01";
            // 
            // txtDATA
            // 
            this.txtDATA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDATA.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDATA.Location = new System.Drawing.Point(177, 86);
            this.txtDATA.Name = "txtDATA";
            this.txtDATA.Size = new System.Drawing.Size(551, 23);
            this.txtDATA.TabIndex = 10;
            this.txtDATA.Text = "01";
            this.txtDATA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxFrameField_MouseClick);
            this.txtDATA.TextChanged += new System.EventHandler(this.TxFrameField_TextChanged);
            this.txtDATA.Enter += new System.EventHandler(this.TxFrameField_GetCursor);
            this.txtDATA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxFrameField_KeyDown);
            this.txtDATA.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HexTextBoxEdit);
            // 
            // lblDLEN
            // 
            this.lblDLEN.AutoSize = true;
            this.lblDLEN.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLEN.Location = new System.Drawing.Point(125, 68);
            this.lblDLEN.Name = "lblDLEN";
            this.lblDLEN.Size = new System.Drawing.Size(34, 15);
            this.lblDLEN.TabIndex = 7;
            this.lblDLEN.Text = "DLEN";
            // 
            // tabMonitorPanel
            // 
            this.tabMonitorPanel.Controls.Add(this.grpDataMonitor);
            this.tabMonitorPanel.Location = new System.Drawing.Point(4, 24);
            this.tabMonitorPanel.Name = "tabMonitorPanel";
            this.tabMonitorPanel.Size = new System.Drawing.Size(991, 599);
            this.tabMonitorPanel.TabIndex = 2;
            this.tabMonitorPanel.Text = "Monitor Panel";
            this.tabMonitorPanel.UseVisualStyleBackColor = true;
            // 
            // grpDataMonitor
            // 
            this.grpDataMonitor.Controls.Add(this.lvDataMonitor);
            this.grpDataMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDataMonitor.Location = new System.Drawing.Point(0, 0);
            this.grpDataMonitor.Name = "grpDataMonitor";
            this.grpDataMonitor.Size = new System.Drawing.Size(991, 599);
            this.grpDataMonitor.TabIndex = 2;
            this.grpDataMonitor.TabStop = false;
            this.grpDataMonitor.Text = "Data Monitor";
            // 
            // lvDataMonitor
            // 
            this.lvDataMonitor.CheckBoxes = true;
            this.lvDataMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCheck,
            this.colName,
            this.colValue,
            this.colUnit,
            this.colDecimal,
            this.colHex,
            this.colBinary,
            this.colTime});
            this.lvDataMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDataMonitor.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDataMonitor.FullRowSelect = true;
            this.lvDataMonitor.HideSelection = false;
            this.lvDataMonitor.Location = new System.Drawing.Point(3, 19);
            this.lvDataMonitor.MultiSelect = false;
            this.lvDataMonitor.Name = "lvDataMonitor";
            this.lvDataMonitor.Size = new System.Drawing.Size(985, 577);
            this.lvDataMonitor.TabIndex = 0;
            this.lvDataMonitor.UseCompatibleStateImageBehavior = false;
            this.lvDataMonitor.View = System.Windows.Forms.View.Details;
            this.lvDataMonitor.VirtualMode = true;
            // 
            // colCheck
            // 
            this.colCheck.Text = "Log";
            this.colCheck.Width = 37;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 156;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 116;
            // 
            // colUnit
            // 
            this.colUnit.Text = "Unit";
            this.colUnit.Width = 121;
            // 
            // colDecimal
            // 
            this.colDecimal.Text = "DEC";
            this.colDecimal.Width = 128;
            // 
            // colHex
            // 
            this.colHex.Text = "HEX";
            this.colHex.Width = 117;
            // 
            // colBinary
            // 
            this.colBinary.Text = "BIN";
            this.colBinary.Width = 118;
            // 
            // colTime
            // 
            this.colTime.Text = "Time Stamp";
            this.colTime.Width = 110;
            // 
            // tabTerminal
            // 
            this.tabTerminal.Controls.Add(this.txtOutputTerminal);
            this.tabTerminal.Location = new System.Drawing.Point(4, 24);
            this.tabTerminal.Name = "tabTerminal";
            this.tabTerminal.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerminal.Size = new System.Drawing.Size(991, 599);
            this.tabTerminal.TabIndex = 3;
            this.tabTerminal.Text = "Terminal Window";
            this.tabTerminal.UseVisualStyleBackColor = true;
            // 
            // txtOutputTerminal
            // 
            this.txtOutputTerminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOutputTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutputTerminal.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputTerminal.ForeColor = System.Drawing.Color.LightCyan;
            this.txtOutputTerminal.Location = new System.Drawing.Point(3, 3);
            this.txtOutputTerminal.Name = "txtOutputTerminal";
            this.txtOutputTerminal.ReadOnly = true;
            this.txtOutputTerminal.Size = new System.Drawing.Size(985, 593);
            this.txtOutputTerminal.TabIndex = 3;
            this.txtOutputTerminal.Text = "";
            this.txtOutputTerminal.WordWrap = false;
            this.txtOutputTerminal.VScroll += new System.EventHandler(this.txtOutputTerminal_VScroll);
            this.txtOutputTerminal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutputTerminal_KeyDown);
            // 
            // tabBufferView
            // 
            this.tabBufferView.Controls.Add(this.txtBufferView);
            this.tabBufferView.Location = new System.Drawing.Point(4, 24);
            this.tabBufferView.Name = "tabBufferView";
            this.tabBufferView.Padding = new System.Windows.Forms.Padding(3);
            this.tabBufferView.Size = new System.Drawing.Size(991, 599);
            this.tabBufferView.TabIndex = 1;
            this.tabBufferView.Text = "Buffer View";
            this.tabBufferView.UseVisualStyleBackColor = true;
            // 
            // txtBufferView
            // 
            this.txtBufferView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBufferView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBufferView.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBufferView.ForeColor = System.Drawing.Color.LightCyan;
            this.txtBufferView.Location = new System.Drawing.Point(3, 3);
            this.txtBufferView.Name = "txtBufferView";
            this.txtBufferView.Size = new System.Drawing.Size(985, 593);
            this.txtBufferView.TabIndex = 2;
            this.txtBufferView.Text = "";
            this.txtBufferView.WordWrap = false;
            // 
            // chkEnableCID_22Check
            // 
            this.chkEnableCID_22Check.AutoSize = true;
            this.chkEnableCID_22Check.Location = new System.Drawing.Point(34, 353);
            this.chkEnableCID_22Check.Name = "chkEnableCID_22Check";
            this.chkEnableCID_22Check.Size = new System.Drawing.Size(177, 19);
            this.chkEnableCID_22Check.TabIndex = 0;
            this.chkEnableCID_22Check.Text = "&Enable CID 0x22 Benchmark";
            this.chkEnableCID_22Check.UseVisualStyleBackColor = true;
            // 
            // imlFrameClasses
            // 
            this.imlFrameClasses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlFrameClasses.ImageStream")));
            this.imlFrameClasses.TransparentColor = System.Drawing.Color.Transparent;
            this.imlFrameClasses.Images.SetKeyName(0, "download.ico");
            this.imlFrameClasses.Images.SetKeyName(1, "incoming.ico");
            // 
            // grpStatistics
            // 
            this.grpStatistics.Controls.Add(this.chkEnableCID_22Check);
            this.grpStatistics.Controls.Add(this.lblReceivePeriod);
            this.grpStatistics.Controls.Add(this.label15);
            this.grpStatistics.Controls.Add(this.label14);
            this.grpStatistics.Controls.Add(this.label13);
            this.grpStatistics.Controls.Add(this.cmdResetFrameBuffer);
            this.grpStatistics.Controls.Add(this.cmdResetStatistics);
            this.grpStatistics.Controls.Add(this.lblPortDescrition);
            this.grpStatistics.Controls.Add(this.lblCRCErrors);
            this.grpStatistics.Controls.Add(this.lblDPackCount);
            this.grpStatistics.Controls.Add(this.label11);
            this.grpStatistics.Controls.Add(this.label2);
            this.grpStatistics.Controls.Add(this.lblFrameErrors);
            this.grpStatistics.Controls.Add(this.lblFrameBuffer);
            this.grpStatistics.Controls.Add(this.label10);
            this.grpStatistics.Controls.Add(this.label3);
            this.grpStatistics.Controls.Add(this.lblFrameCount);
            this.grpStatistics.Controls.Add(this.lblMinLength);
            this.grpStatistics.Controls.Add(this.label9);
            this.grpStatistics.Controls.Add(this.label5);
            this.grpStatistics.Controls.Add(this.lblMaxLength);
            this.grpStatistics.Controls.Add(this.label7);
            this.grpStatistics.Controls.Add(this.lblStreamErrorCounter);
            this.grpStatistics.Controls.Add(this.lblRecLength);
            this.grpStatistics.Controls.Add(this.label4);
            this.grpStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatistics.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatistics.Location = new System.Drawing.Point(0, 255);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.Size = new System.Drawing.Size(262, 447);
            this.grpStatistics.TabIndex = 3;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "Statistics";
            // 
            // lblReceivePeriod
            // 
            this.lblReceivePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivePeriod.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivePeriod.Location = new System.Drawing.Point(180, 44);
            this.lblReceivePeriod.Name = "lblReceivePeriod";
            this.lblReceivePeriod.Size = new System.Drawing.Size(58, 15);
            this.lblReceivePeriod.TabIndex = 31;
            this.lblReceivePeriod.Text = "0";
            this.lblReceivePeriod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(17, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 15);
            this.label15.TabIndex = 30;
            this.label15.Text = "Receive Period (ms)";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(20, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(218, 116);
            this.label14.TabIndex = 29;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(17, 219);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "Please Note:";
            // 
            // cmdResetFrameBuffer
            // 
            this.cmdResetFrameBuffer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdResetFrameBuffer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetFrameBuffer.Location = new System.Drawing.Point(20, 411);
            this.cmdResetFrameBuffer.Name = "cmdResetFrameBuffer";
            this.cmdResetFrameBuffer.Size = new System.Drawing.Size(218, 27);
            this.cmdResetFrameBuffer.TabIndex = 27;
            this.cmdResetFrameBuffer.Text = "Reset Frame Buffer";
            this.cmdResetFrameBuffer.UseVisualStyleBackColor = true;
            this.cmdResetFrameBuffer.Click += new System.EventHandler(this.cmdResetFrameBuffer_Click);
            // 
            // cmdResetStatistics
            // 
            this.cmdResetStatistics.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdResetStatistics.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetStatistics.Location = new System.Drawing.Point(20, 378);
            this.cmdResetStatistics.Name = "cmdResetStatistics";
            this.cmdResetStatistics.Size = new System.Drawing.Size(218, 27);
            this.cmdResetStatistics.TabIndex = 26;
            this.cmdResetStatistics.Text = "Reset Statistics";
            this.cmdResetStatistics.UseVisualStyleBackColor = true;
            this.cmdResetStatistics.Click += new System.EventHandler(this.cmdResetStatistics_Click);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 27);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grpStatistics);
            this.splitMain.Panel1.Controls.Add(this.grpReceiverSettings);
            this.splitMain.Panel1.Controls.Add(this.grpPortConfig);
            this.splitMain.Panel1MinSize = 262;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabMain);
            this.splitMain.Panel2.Controls.Add(this.grpMonitorFile);
            this.splitMain.Size = new System.Drawing.Size(1265, 702);
            this.splitMain.SplitterDistance = 262;
            this.splitMain.TabIndex = 3;
            // 
            // grpReceiverSettings
            // 
            this.grpReceiverSettings.Controls.Add(this.label8);
            this.grpReceiverSettings.Controls.Add(this.txtReadTimerInterval);
            this.grpReceiverSettings.Controls.Add(this.txtFrameBuffer);
            this.grpReceiverSettings.Controls.Add(this.label6);
            this.grpReceiverSettings.Controls.Add(this.chkBufferView);
            this.grpReceiverSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReceiverSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReceiverSettings.Location = new System.Drawing.Point(0, 136);
            this.grpReceiverSettings.Name = "grpReceiverSettings";
            this.grpReceiverSettings.Size = new System.Drawing.Size(262, 119);
            this.grpReceiverSettings.TabIndex = 2;
            this.grpReceiverSettings.TabStop = false;
            this.grpReceiverSettings.Text = "Receiver Settings";
            // 
            // grpMonitorFile
            // 
            this.grpMonitorFile.Controls.Add(this.lblUserConfigDescription);
            this.grpMonitorFile.Controls.Add(this.lblUserConfigName);
            this.grpMonitorFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMonitorFile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMonitorFile.Location = new System.Drawing.Point(0, 0);
            this.grpMonitorFile.Name = "grpMonitorFile";
            this.grpMonitorFile.Size = new System.Drawing.Size(999, 75);
            this.grpMonitorFile.TabIndex = 1;
            this.grpMonitorFile.TabStop = false;
            // 
            // lblUserConfigDescription
            // 
            this.lblUserConfigDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserConfigDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserConfigDescription.Location = new System.Drawing.Point(20, 45);
            this.lblUserConfigDescription.Name = "lblUserConfigDescription";
            this.lblUserConfigDescription.Size = new System.Drawing.Size(959, 15);
            this.lblUserConfigDescription.TabIndex = 6;
            this.lblUserConfigDescription.Text = "(Description)";
            this.lblUserConfigDescription.DoubleClick += new System.EventHandler(this.lblUserConfigDescription_DoubleClick);
            // 
            // lblUserConfigName
            // 
            this.lblUserConfigName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserConfigName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserConfigName.Location = new System.Drawing.Point(18, 19);
            this.lblUserConfigName.Name = "lblUserConfigName";
            this.lblUserConfigName.Size = new System.Drawing.Size(961, 26);
            this.lblUserConfigName.TabIndex = 0;
            this.lblUserConfigName.Text = "User Configuration Title";
            this.lblUserConfigName.Click += new System.EventHandler(this.lblUserConfigName_Click);
            this.lblUserConfigName.DoubleClick += new System.EventHandler(this.lblUserConfigName_DoubleClick);
            // 
            // stbMain
            // 
            this.stbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pgbBuffer,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.toolStripStatusProcessTicks});
            this.stbMain.Location = new System.Drawing.Point(0, 729);
            this.stbMain.Name = "stbMain";
            this.stbMain.Size = new System.Drawing.Size(1265, 22);
            this.stbMain.TabIndex = 4;
            this.stbMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel1.Text = "Rx Buffer Load:";
            // 
            // pgbBuffer
            // 
            this.pgbBuffer.Name = "pgbBuffer";
            this.pgbBuffer.Size = new System.Drawing.Size(170, 16);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(838, 17);
            this.toolStripSplitButton1.Spring = true;
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(140, 17);
            this.toolStripStatusLabel2.Text = "Frame Processing Period:";
            // 
            // toolStripStatusProcessTicks
            // 
            this.toolStripStatusProcessTicks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusProcessTicks.Name = "toolStripStatusProcessTicks";
            this.toolStripStatusProcessTicks.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusProcessTicks.Text = "0";
            // 
            // tmrOpenPortNotice
            // 
            this.tmrOpenPortNotice.Interval = 300;
            this.tmrOpenPortNotice.Tick += new System.EventHandler(this.timOpenPortNotice_Tick);
            // 
            // tmrPortScan
            // 
            this.tmrPortScan.Interval = 250;
            this.tmrPortScan.Tick += new System.EventHandler(this.tmrPortScan_Tick);
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cmbUserFileName,
            this.configurationToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1265, 27);
            this.mnuMain.TabIndex = 5;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::smpsDebugUART.Properties.Resources._new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::smpsDebugUART.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::smpsDebugUART.Properties.Resources.save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openUserDataConfigurationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // openUserDataConfigurationToolStripMenuItem
            // 
            this.openUserDataConfigurationToolStripMenuItem.Name = "openUserDataConfigurationToolStripMenuItem";
            this.openUserDataConfigurationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.openUserDataConfigurationToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.openUserDataConfigurationToolStripMenuItem.Text = "Open User Data Configuration...";
            this.openUserDataConfigurationToolStripMenuItem.Click += new System.EventHandler(this.openUserDataConfigurationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 23);
            this.toolStripMenuItem1.Text = "&?";
            // 
            // cmbUserFileName
            // 
            this.cmbUserFileName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbUserFileName.Name = "cmbUserFileName";
            this.cmbUserFileName.Size = new System.Drawing.Size(700, 23);
            this.cmbUserFileName.ToolTipText = "File History";
            this.cmbUserFileName.SelectedIndexChanged += new System.EventHandler(this.cmbUserFileName_SelectedIndexChanged);
            this.cmbUserFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUserFileName_KeyDown);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(96, 23);
            this.configurationToolStripMenuItem.Text = "Configuration:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 751);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.stbMain);
            this.Controls.Add(this.mnuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "SMPS Debug UART Protocol Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPortConfig.ResumeLayout(false);
            this.grpPortConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmrMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabAddTxFrames.ResumeLayout(false);
            this.splitFrames.Panel1.ResumeLayout(false);
            this.splitFrames.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitFrames)).EndInit();
            this.splitFrames.ResumeLayout(false);
            this.grpTxFrameList.ResumeLayout(false);
            this.grpRxFrameList.ResumeLayout(false);
            this.grpTxFrameEdit.ResumeLayout(false);
            this.grpTxFrameEdit.PerformLayout();
            this.tabMonitorPanel.ResumeLayout(false);
            this.grpDataMonitor.ResumeLayout(false);
            this.tabTerminal.ResumeLayout(false);
            this.tabBufferView.ResumeLayout(false);
            this.grpStatistics.ResumeLayout(false);
            this.grpStatistics.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.grpReceiverSettings.ResumeLayout(false);
            this.grpReceiverSettings.PerformLayout();
            this.grpMonitorFile.ResumeLayout(false);
            this.stbMain.ResumeLayout(false);
            this.stbMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPortConfig;
        private System.Windows.Forms.Button cmdOpenPort;
        private System.Windows.Forms.Label lblBaudrate;
        private System.Windows.Forms.Label lblCommPort;
        private System.Windows.Forms.ComboBox cmbBaudrate;
        private System.Windows.Forms.ComboBox cmbCommPort;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label lblPortDescrition;
        private System.Timers.Timer tmrMain;
        private System.Windows.Forms.Label lblDPackCount;
        private System.Windows.Forms.Label lblFrameBuffer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBufferView;
        private System.Windows.Forms.Label lblRecLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMaxLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMinLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStreamErrorCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReadTimerInterval;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabAddTxFrames;
        private System.Windows.Forms.Button cmdAddTxFrame;
        private System.Windows.Forms.TabPage tabBufferView;
        private System.Windows.Forms.Label lblCRC;
        private System.Windows.Forms.TextBox txtCRC;
        private System.Windows.Forms.Label lblDATA;
        private System.Windows.Forms.TextBox txtDATA;
        private System.Windows.Forms.Label lblDLEN;
        private System.Windows.Forms.TextBox txtDLEN;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox grpTxFrameEdit;
        private System.Windows.Forms.TextBox txtEOF;
        private System.Windows.Forms.Label lblEOF;
        private System.Windows.Forms.TextBox txtSOF;
        private System.Windows.Forms.Label lblSOF;
        private System.Windows.Forms.GroupBox grpTxFrameList;
        private System.Windows.Forms.TextBox txtUserLabel;
        private System.Windows.Forms.Label lblUserLabel;
        private System.Windows.Forms.Button cmdDeleteTxFrame;
        private System.Windows.Forms.Button cmdNewTxFrame;
        private System.Windows.Forms.Label lblFrameCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFrameErrors;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCRCErrors;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvTxFrames;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.ColumnHeader Command;
        private System.Windows.Forms.ImageList imlFrameClasses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFrameBuffer;
        private System.Windows.Forms.RichTextBox txtBufferView;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.StatusStrip stbMain;
        private System.Windows.Forms.Button cmdResetStatistics;
        private System.Windows.Forms.GroupBox grpRxFrameList;
        private System.Windows.Forms.ListView lvRxFrames;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colCMD;
        private System.Windows.Forms.Button cmdResetFrameBuffer;
        private System.Windows.Forms.SplitContainer splitFrames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpReceiverSettings;
        private System.Windows.Forms.Timer tmrOpenPortNotice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripProgressBar pgbBuffer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColumnHeader colTimeStamp;
        private System.Windows.Forms.Label lblReceivePeriod;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.Timer tmrPortScan;
        private System.Windows.Forms.TabPage tabMonitorPanel;
        private System.Windows.Forms.ListView lvDataMonitor;
        private System.Windows.Forms.ColumnHeader colCheck;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colUnit;
        private System.Windows.Forms.ColumnHeader colDecimal;
        private System.Windows.Forms.ColumnHeader colHex;
        private System.Windows.Forms.ColumnHeader colBinary;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.GroupBox grpDataMonitor;
        private System.Windows.Forms.CheckBox chkEnableCID_22Check;
        private System.Windows.Forms.Label lblBytePos;
        private System.Windows.Forms.Label lblBytePosLabel;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openUserDataConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpMonitorFile;
        private System.Windows.Forms.Label lblUserConfigName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusProcessTicks;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.Label lblUserConfigDescription;
        private System.Windows.Forms.ToolStripComboBox cmbUserFileName;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.TabPage tabTerminal;
        private System.Windows.Forms.RichTextBox txtOutputTerminal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

