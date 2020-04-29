using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Ports;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using smpsDebugUART;

using Diagnostics = System.Diagnostics;

namespace smpsDebugUartTestWindow
{
    
    public partial class frmMain : Form
    {

        /* **************************************************************************************************
         * PRIVATE DECLARATIONS FOR TERMINAL WINDOW
         * *************************************************************************************************/
        private const int WM_USER = 0x400;
        private const int SB_VERT = 1;
        private const int EM_SETSCROLLPOS = WM_USER + 222;
        private const int EM_GETSCROLLPOS = WM_USER + 221;
        private bool TerminalScrolledToBottom = false;
        StringBuilder TerminalBuffer = new StringBuilder();

        [DllImport("user32.dll")]
        private static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);

        /* **************************************************************************************************
         * PRIVATE DECLARATIONS
         * *************************************************************************************************/
        smpsDebugUARTParser dbgUart = new smpsDebugUARTParser();
        smpsDebugUARTBuffer dbgUBuf = new smpsDebugUARTBuffer();
        smpsDebugUARTFrame dbgUTxFrame = new smpsDebugUARTFrame();
        smpsDebugUARTStatistics dbgUStats = new smpsDebugUARTStatistics();

        clsINIFileHandler ProjectFile = new clsINIFileHandler();
        clsINIFileHandler UserDataFile = new clsINIFileHandler();

        private const string PROJECT_DEFAULT_FILENAME = "DebugUARTConfig.ini";

        bool _user_file_loaded = false;
        bool _timer_plot_active = false;
        bool _open_file_in_progress = false;

        string[] ListOfPorts = new string[100];

        int serBufferSizeDefault = 4095;
        int dbgUartFrameBufferSizeDefault = 32;

        //private ListView lvDataMonitorExt;

        /* **************************************************************************************************
         * MAIN FORM ROUTINES
         * *************************************************************************************************/

        /* ************************************************************************************************ */
        public frmMain()
        {
            InitializeComponent();
        }

        /* ************************************************************************************************ */
        private void frmMain_Load(object sender, EventArgs e)
        {

            int i = 0, j = 0, file_count = 0;
            string sdum = "";

            this.Text = Application.ProductName + " v." + Application.ProductVersion;
            tmrMain.Enabled = false;

            lblUserConfigName.Text = "New Configuration";
            lblUserConfigDescription.Text = "(add a description)";

            ProjectFile.SetFilename (ProjectFile.DefaultDirectory + PROJECT_DEFAULT_FILENAME);
            if (!ProjectFile.FileExists(ProjectFile.FileName))
            {
                // Mark creating date
                ProjectFile.WriteKey("global", "created", DateTime.Now.ToShortDateString());

                // Load default values
                txtReadTimerInterval.Text = tmrMain.Interval.ToString();
                cmbBaudrate.SelectedIndex = 16;
                HexTextBoxPrint(txtID, false);
                dbgUart.FrameBufferSize = dbgUartFrameBufferSizeDefault;
            }
            else 
            {
                // Load settings from file
                txtReadTimerInterval.Text = ProjectFile.ReadKey("settings", "ReadInterval", tmrMain.Interval.ToString());
                cmbCommPort.Text = ProjectFile.ReadKey("settings", "Port", "");
                cmbBaudrate.Text = ProjectFile.ReadKey("settings", "Baudrate", cmbBaudrate.Items[16].ToString());
                dbgUart.FrameBufferSize = Convert.ToInt32(ProjectFile.ReadKey("settings", "FrameBufferSize", dbgUartFrameBufferSizeDefault.ToString()));

                // Check User File History
                file_count = 10;
                for (i = 0; i <8; i++)
                {
                    sdum = ProjectFile.ReadKey("UserDataFiles", "file" + i.ToString(), "");

                    // Delete non-existing files
                    if (!System.IO.File.Exists(sdum))
                        ProjectFile.DeleteKey("UserDataFiles", "file" + j.ToString());

                    // Delete duplicates
                    for (j = i+1; j < 8; j++)
                    {
                        if (sdum.ToLower() == ProjectFile.ReadKey("UserDataFiles", "file" + j.ToString(), "").ToLower())
                            ProjectFile.DeleteKey("UserDataFiles", "file" + j.ToString());
                    }

                    if (ProjectFile.ReadKey("UserDataFiles", "file" + i.ToString(), "").Length > 0)
                    {
                        ProjectFile.WriteKey("UserDataFiles", "file" + (file_count++).ToString(), sdum);
                        ProjectFile.DeleteKey("UserDataFiles", "file" + i.ToString());
                    }

                }

                // Build new index and load filenames into history combo box
                cmbUserFileName.Items.Clear();
                file_count = 0;
                for (i = 10; i <18; i++)
                {
                    sdum = ProjectFile.ReadKey("UserDataFiles", "file" + i.ToString(), "");
                    if (sdum.Length > 0)
                    {
                        cmbUserFileName.Items.Add(sdum);
                        ProjectFile.WriteKey("UserDataFiles", "file" + (file_count++).ToString(), sdum);
                        ProjectFile.DeleteKey("UserDataFiles", "file" + i.ToString());
                    }
                }
                ProjectFile.WriteKey("UserDataFiles", "count", file_count.ToString());

                // Load last user file 
                sdum = ProjectFile.ReadKey("UserDataFiles", "LastFile", "");
                if (System.IO.File.Exists(sdum))
                { OpenFile(sdum); }
                else
                { ProjectFile.WriteKey("UserDataFiles", "LastFile", ""); }

            }

            lvRxFrames.Items.Clear();
            lvRxFrames.SmallImageList = imlFrameClasses;
            lvRxFrames.View = View.Details;
            lvRxFrames.Columns[0].Width = 120;
            lvRxFrames.Columns[2].Width = 120;
            lvRxFrames.Columns[3].Width = 160;
            lvRxFrames.Columns[1].Width = (lvRxFrames.Width - (lvRxFrames.Columns[0].Width + lvRxFrames.Columns[2].Width + lvRxFrames.Columns[3].Width + 6));
            lvRxFrames.AllowColumnReorder = false;
            lvRxFrames.AllowDrop = false;
            lvRxFrames.AutoArrange = true;
            lvRxFrames.FullRowSelect = true;

            tmrPortScan.Enabled = true;
            HexTextBoxPrint(txtID, false);

            lblBytePos.Text = "0";
            lblBytePos.TextAlign = ContentAlignment.MiddleRight;
            lblBytePos.AutoSize = false;
            lblBytePos.Width = 25;
            lblBytePos.Left = (txtDATA.Left + txtDATA.Width) - lblBytePos.Width;
            lblBytePosLabel.Left = lblBytePos.Left - lblBytePosLabel.Width;
            lblBytePosLabel.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            lblBytePos.Anchor = (AnchorStyles.Right | AnchorStyles.Top);

            txtOutputTerminal.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            txtFrameBuffer.Text = ProjectFile.ReadKey("settings", "FrameBufferSize", dbgUartFrameBufferSizeDefault.ToString());

            chkBufferView.Checked = Convert.ToBoolean(Convert.ToInt32(ProjectFile.ReadKey("settings", "DataMonitorUpdate", "0")));
            splitFrames.SplitterDistance = (splitFrames.Height / 2);
            tabMain.SelectTab(Convert.ToInt32(ProjectFile.ReadKey("settings", "last_tab", "0")));

            // Ebalble Double Buffering where ever possible

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


        }

        /* ************************************************************************************************ */
        private void lvRxFrames_Resize(object sender, EventArgs e)
        {
            lvRxFrames.Columns[0].Width = 120;
            lvRxFrames.Columns[2].Width = 120;
            lvRxFrames.Columns[3].Width = 160;
            lvRxFrames.Columns[1].Width = (lvRxFrames.Width - (lvRxFrames.Columns[0].Width + lvRxFrames.Columns[2].Width + lvRxFrames.Columns[3].Width + 6));
        }

        /* ************************************************************************************************ */
        private void lvTxFrames_Resize(object sender, EventArgs e)
        {
            lvTxFrames.Columns[0].Width = 220;
            lvTxFrames.Columns[1].Width = (lvTxFrames.Width - (lvTxFrames.Columns[0].Width + 6));
        }

        /* ************************************************************************************************ */
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            int i = 0;
            string sdum = "";

            // Turn Off communication
            tmrMain.Enabled = false;
            if (serialPort.IsOpen)
                serialPort.Close();

            ProjectFile.WriteKey("settings", "last_tab", tabMain.SelectedIndex.ToString()); //  .SelectedTab TabIndex

            // Save user format of User Data Table
            if (_user_file_loaded)
            { 
                for (i = 0; i < lvDataMonitor.Columns.Count; i++)
                { UserDataFile.WriteKey("UserDataView", "col_width" + i.ToString(), lvDataMonitor.Columns[i].Width.ToString()); }

                for (i = 0; i < lvDataMonitor.Items.Count; i++)
                {
                    sdum = lvDataMonitor.Items[i].SubItems[0].Text.Trim();
                    sdum = sdum.Substring(1, (sdum.Length-1));
                    sdum = "Data" + Convert.ToInt32(sdum).ToString();
                    UserDataFile.WriteKey(sdum, "log", Convert.ToInt32(lvDataMonitor.Items[i].Checked).ToString());
                }
            }

        }

        /* **************************************************************************************************
         * COMM PORT ROUTINES
         * *************************************************************************************************/

        /* ************************************************************************************************ */
        void ListCommPorts()
        {
            RegistryKey reg;
            object reg_key_value;
            string[] Values = new string[0];
            string[] ComPorts = new string[0];
            bool _change_detected = false;
            string sercom_filter = "", reg_key = "";
            int _i=0, _f=0, port_count=0, filter_count=0;

            string[] str_arr;
            string[] dum_sep = new string[1];
            string sel_item = "";
            int sel_index = 0;


            dum_sep[0] = ("\\");
            reg_key = ProjectFile.ReadKey("serialcomm", "key", "");
            reg = Registry.LocalMachine.OpenSubKey(reg_key, false);
            
            if (reg != null)
            {
                Values = reg.GetValueNames();
                filter_count = Convert.ToInt32(ProjectFile.ReadKey("serialcomm", "filters", "0"));

                for (_f = 0; _f < filter_count; _f++)
                {
                    sercom_filter = ProjectFile.ReadKey("serialcomm", "filter" + _f.ToString(), "");

                    for (_i = 0; _i < Values.Length; _i++)
                    {
                        reg_key_value = reg.GetValue(Values[_i]);
                        str_arr = Values[_i].Split(dum_sep, StringSplitOptions.RemoveEmptyEntries);

                        if (str_arr[0].ToLower() == sercom_filter.ToLower())
                        {
                            Array.Resize(ref ComPorts, (ComPorts.Length + 1));
                            ComPorts[port_count++] = reg_key_value.ToString();
                        }
                    }
                }
            }

            if (ComPorts.Length != ListOfPorts.Length)
            { // If length of list of ports is different than previous list, trigger refresh
                _change_detected = true;
            }
            else
            { // If length of list of ports is the same, check if contents have changed
                for (_i = 0; _i < ComPorts.Length; _i++)
                {
                    _change_detected = (bool)(ListOfPorts[_i] != ComPorts[_i]); 
                }

            }
                
            if(_change_detected)
            {
                Array.Clear(ListOfPorts, 0, ListOfPorts.Length);
                Array.Resize(ref ListOfPorts, (ComPorts.Length));
                Array.Copy(ComPorts, ListOfPorts, ComPorts.Length);

                sel_item = cmbCommPort.Text;
                cmbCommPort.Items.Clear();
                for (_i = 0; _i < ListOfPorts.Length; _i++)
                { 
                    cmbCommPort.Items.Add(ListOfPorts[_i]);
                    if ((sel_item.Trim().ToLower() == ListOfPorts[_i].Trim().ToLower()) && (sel_item.Trim().Length > 0))
                    { sel_index = _i; }
                }
                cmbCommPort.Sorted = true;

                if ((sel_item.Trim().Length > 0))
                {
                    cmbCommPort.Text = sel_item;
                    //cmbCommPort.SelectedIndex = sel_index;
                    cmdOpenPort.Enabled = true;
                }
                else if ((cmbCommPort.Text.Trim().Length == 0) && (ListOfPorts.Length > 0))
                {
                    cmbCommPort.Text = ListOfPorts[0];
                    cmdOpenPort.Enabled = true;
                }
                else
                {
                    cmbCommPort.Text = "";
                    cmdOpenPort.Enabled = false;
                }

            }


        }

        /* ************************************************************************************************ */
        private void cmbCommPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();
        }

        /* ************************************************************************************************ */
        private void cmdOpenPort_Click(object sender, EventArgs e)
        {

            if (serialPort.IsOpen) serialPort.Close();            

            if (cmdOpenPort.Text == "Open Port")
            {
                tmrPortScan.Enabled = false;
                serialPort.PortName = cmbCommPort.Text;

                if (cmbBaudrate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please selected a valid baudrate first.\t", "Comm-Port Interface Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                else { 
                    serialPort.BaudRate = Convert.ToInt32(cmbBaudrate.Text);
                }

                serialPort.Parity = (Parity)(0);
                serialPort.StopBits = (StopBits)(1);
                serialPort.DataBits = 8;
                serialPort.Handshake = (Handshake)(0);
                serialPort.ReadBufferSize = Convert.ToInt32(ProjectFile.ReadKey("settings", "SerialPortBufferSize", serBufferSizeDefault.ToString()));

                serialPort.NewLine = Convert.ToChar((byte)0x0D).ToString();

                try
                {
                    serialPort.Open();

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();

                    txtFrameBuffer.Enabled = false;
                    txtReadTimerInterval.Select();
                    cmbCommPort.Enabled = false;
                    cmbBaudrate.Enabled = false;
                    cmdOpenPort.Text = "Close Port";
                    tmrMain.Enabled = true;
                    cmdResetFrameBuffer.Enabled = false;
                    TerminalScrolledToBottom = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(cmbCommPort.Text + " could not be opened. \r\n" + 
                        "Error (0x" + ex.HResult.ToString("X") + "):" + ex.Message + "\r\n\r\n" + 
                        "Please verify that the port exists, is not used by any other applicaiton and try again.", 
                        "Communication Port Control", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation, 
                        MessageBoxDefaultButton.Button1
                        );

                    tmrPortScan.Enabled = true;
                    
                }


            }
            else {
                cmdOpenPort.Text = "Open Port";
                tmrMain.Enabled = false;
                txtFrameBuffer.Enabled = true;
                cmbCommPort.Enabled = true;
                cmbBaudrate.Enabled = true;
                cmdResetFrameBuffer.Enabled = true;
                pgbBuffer.Value = 0;
                tmrPortScan.Enabled = true;
                TerminalScrolledToBottom = false;

            }
        }

        /* ************************************************************************************************ */
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int rx_val = 0, fifo_bufLen = 0;
            byte[] _rx_buf = new byte[0];
            byte[] _frame_data = new byte[0];

            SerialPort _serial = (SerialPort)sender;
            if (!_serial.IsOpen) return;

            dbgUStats.DataPackageCount++;
//            dbgUStats.ReceiveInterval = DateTime.Now.Ticks;

            fifo_bufLen = _serial.BytesToRead; // check how many bytes are in the FIFO
            if (fifo_bufLen > 0)
                dbgUStats.DataPackageLength = fifo_bufLen; // Monitor received buffer size

            while ((_serial.BytesToRead > 0) && (!dbgUBuf.SuspendReceive))
            {

                // Safety switch in case port got closed while receiving frame
                if (!_serial.IsOpen) return;

                // Read byte from RS232 FIFO into Receive Buffer
                rx_val = _serial.ReadByte();
                dbgUBuf.Buffer[dbgUBuf.BufferPointer++] = (byte)rx_val;

                if (!dbgUBuf.FrameSync)
                {
                    if (rx_val == (int)smpsDebugUARTFrame.START_OF_FRAME)
                    { 
                        dbgUBuf.FrameSync = true;
                        dbgUStats.ReceiveInterval = DateTime.Now.Ticks;
                    }
                    else { dbgUBuf.BufferPointer = 0; }
                }
                else
                {
                    if (dbgUBuf.BufferPointer == smpsDebugUARTFrame.FRAME_OFFSET_DATA)
                    {
                        dbgUBuf.FrameDLEN = (((int)dbgUBuf.Buffer[dbgUBuf.BufferPointer - 2] << 8) | ((int)dbgUBuf.Buffer[dbgUBuf.BufferPointer - 1]));
                        if (dbgUBuf.FrameDLEN > (dbgUBuf.BufferSize - (int)smpsDebugUARTFrame.FRAME_OFFSET_EOF))
                        { // Frame synchronization error => Reset pointer to next starting cell and reset Sync Flag
                            dbgUBuf.BufferPointer = 0;
                            dbgUBuf.FrameSync = false;

                            // Frame sync error
                            dbgUBuf.FrameSyncErrorCount++;

                        }
                    }
                    else if (dbgUBuf.BufferPointer == (dbgUBuf.FrameDLEN + smpsDebugUARTFrame.FRAME_OFFSET_DATA + smpsDebugUARTFrame.FRAME_TAIL_OVERHEAD))
                    {
                        if ((int)dbgUBuf.Buffer[dbgUBuf.BufferPointer - 1] == (int)smpsDebugUARTFrame.END_OF_FRAME)
                        {
                            // For Frame Parsing, extract comlete frame data into new array
                            Array.Resize<byte>(ref _frame_data, dbgUBuf.BufferPointer);
                            Array.Copy(dbgUBuf.Buffer, 0, _frame_data, 0, dbgUBuf.BufferPointer);
                            dbgUart.AddRxFrameToBuffer(_frame_data);
                        }
                        else
                        {
                            // Frame sync error
                            dbgUBuf.FrameSyncErrorCount++;
                        }

                        Array.Clear(dbgUBuf.Buffer, 0, dbgUBuf.Buffer.GetUpperBound(0));
                        dbgUBuf.BufferPointer = 0;
                        dbgUBuf.FrameDLEN = 0;
                        dbgUBuf.FrameSync = false;
                    }
                    else if (dbgUBuf.BufferPointer > (dbgUBuf.FrameDLEN + smpsDebugUARTFrame.FRAME_OFFSET_DATA + smpsDebugUARTFrame.FRAME_TAIL_OVERHEAD))
                    {
                        dbgUBuf.BufferPointer = 0;
                        dbgUBuf.FrameSync = false;
                    }
                }
            }

            // Fire timer calling data display task
            tmrMain.Enabled = true;

        }

        /* ************************************************************************************************ */
        private void cmbBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectFile.WriteKey("settings", "Baudrate", cmbBaudrate.Text);
        }

        /* ************************************************************************************************ */
        private void txtReadTimerInterval_TextChanged(object sender, EventArgs e)
        {
            if (txtReadTimerInterval.Text.Trim().Length > 0)
            {
                if (Convert.ToInt32(txtReadTimerInterval.Text) > 10)
                { tmrMain.Interval = Convert.ToInt32(txtReadTimerInterval.Text); }
                else
                { tmrMain.Interval = 10; }

                // Save setting
                ProjectFile.WriteKey("settings", "ReadInterval", tmrMain.Interval.ToString());

            }
        }

        /* ************************************************************************************************ */
        private void txtFrameBuffer_TextChanged(object sender, EventArgs e)
        {
            int _buf_size = 0;

            if (serialPort.IsOpen) return;

            try
            {
                // Clear the data content and buffer window and re-initialize receive buffers
                _buf_size = Convert.ToInt32(txtFrameBuffer.Text);
                if (_buf_size == 0) _buf_size = dbgUartFrameBufferSizeDefault;


                txtBufferView.Clear();
                dbgUart.FrameBufferSize = _buf_size;
                txtFrameBuffer.BackColor = SystemColors.Window;
            }
            catch {
                txtFrameBuffer.BackColor = Color.LightCoral;
            }
            return;
        }


        /* ************************************************************************************************ */
        int notice_flash_counter = 0;
        private void timOpenPortNotice_Tick(object sender, EventArgs e)
        {
            try
            {
                cmdOpenPort.Select();

                if (cmdOpenPort.BackColor == SystemColors.Control)
                    cmdOpenPort.BackColor = Color.LightCoral;
                else
                    cmdOpenPort.BackColor = SystemColors.Control;

                if (notice_flash_counter++ > 4)
                { tmrOpenPortNotice.Enabled = false; }
            }
            catch { }
        }

        /* ************************************************************************************************ */
        private void cmbCommPort_TextChanged(object sender, EventArgs e)
        {
            int _i = 0;

            for (_i = 0; _i < cmbCommPort.Items.Count; _i++)
            {
                if (cmbCommPort.Text.ToLower() == cmbCommPort.Items[_i].ToString().ToLower())
                    break;
            }

            if (_i == cmbCommPort.Items.Count)
            { 
                cmbCommPort.BackColor = Color.LightCoral;
                cmdOpenPort.Enabled = false;
            }
            else
            { 
                cmbCommPort.BackColor = SystemColors.Window;
                cmdOpenPort.Enabled = true;
            }
        }

        private void chkDataOutput_CheckedChanged(object sender, EventArgs e)
        {
            ProjectFile.WriteKey("settings", "DataMonitorUpdate", Convert.ToInt32(chkBufferView.Checked).ToString());
        }

        /* **************************************************************************************************
         * DATA AND STATISTICS DISPLAY ROUTINES
         * *************************************************************************************************/

        /* ************************************************************************************************ */
        private void tmrMain_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int _i = 0, _n = 0;
            string[] sdum = new string[0];
            ListViewItem lv = new ListViewItem();
            StringBuilder OutputWindowText = new StringBuilder();

            // Variable for value parsing
            
            string _user_cid = "", _data_format = "", _unit = ""; 
            int _k = 0, _m = 0, _dat_points = 0, _datlen = 0, _datptr = 0;
            bool _is_hidden = false;
            long ldum = 0;
            double _data_val = 0.0, _offset = 0.0, _scale = 0.0;
            double ProcessTicks = 0.0;

            ProcessTicks = DateTime.Now.Ticks;
//            try
            {
                // output statistics
                tmrMain.Enabled = false;
                if (_timer_plot_active) return;
                _timer_plot_active = true;

                dbgUBuf.SuspendReceive = true;
                Application.DoEvents();

                lblDPackCount.Text = dbgUStats.DataPackageCount.ToString();
                lblReceivePeriod.Text = String.Format("{0:0}", dbgUStats.ReceiveInterval / 10000); 

                lblRecLength.Text = dbgUStats.DataPackageLength.ToString();
                lblMinLength.Text = dbgUStats.DataPackageLenMinimum.ToString();
                lblMaxLength.Text = dbgUStats.DataPackageLenMaximum.ToString();
                try { pgbBuffer.Value = Convert.ToInt32(100 * (Convert.ToDouble(dbgUStats.DataPackageLength) / Convert.ToDouble(serialPort.ReadBufferSize))); }
                catch { }

                if (dbgUart.FrameCount > 0)
                    lblFrameBuffer.Text = dbgUart.Frames.Length.ToString();
                lblFrameCount.Text = dbgUart.FrameCount.ToString();
                lblFrameErrors.Text = dbgUBuf.FrameSyncErrorCount.ToString();
                lblCRCErrors.Text = dbgUart.CRCErrorCount.ToString();

                Array.Resize<string>(ref sdum, dbgUart.FrameBufferSize);

                if (dbgUart.FrameCount > 0)
                {
                    for (_i = dbgUart.Frames.GetLowerBound(0); _i < dbgUart.Frames.Length; _i++)
                    {
                        // == FEEDING TERMINAL DATA INTO OUTPUT TERMINAL ===============================
                        if (dbgUart.Frames[_i].IsKnown)
                        {
                            _m = 0;
                        }

                        if ((dbgUart.Frames[_i].CID < 0x0008) && (dbgUart.Frames[_i].IsComplete))
                        {

                            TerminalBuffer.Append(Encoding.UTF8.GetString(dbgUart.Frames[_i].DATA, 0, dbgUart.Frames[_i].DLEN));

                            if (TerminalScrolledToBottom)
                            {
                                txtOutputTerminal.AppendText(TerminalBuffer.ToString());
                                TerminalBuffer.Clear();
                                txtOutputTerminal.ScrollToCaret();
                            }

                            dbgUart.Frames[_i].IsComplete = false;

                        }
                        else { 
                        // == FEEDING TERMINAL DATA INTO OUTPUT TERMINAL END ===========================

                        // == PARSING USER DATA INTO MONITOR TABLE ===============================
                        if ((_user_file_loaded) && (dbgUart.Frames[_i].IsComplete))
                        {
                            _user_cid = UserDataFile.ReadKey("Data" + _k.ToString(), "CID", "0");

                            if (dbgUart.Frames[_i].CID.ToString("X04").ToUpper() == _user_cid.ToUpper())
                            {
                                _dat_points = Convert.ToInt32(UserDataFile.ReadKey("Data", "count", "0"));

                                for (_k = 0; _k < _dat_points; _k++)
                                {
                                    _is_hidden = Convert.ToBoolean(Convert.ToInt32(UserDataFile.ReadKey("Data" + _k.ToString(), "hide", "0")));
                                    _datlen = Convert.ToInt32(UserDataFile.ReadKey("Data" + _k.ToString(), "length", "0"));
                                    _offset = Convert.ToDouble(UserDataFile.ReadKey("Data" + _k.ToString(), "offset", "0"));
                                    _scale = Convert.ToDouble(UserDataFile.ReadKey("Data" + _k.ToString(), "scale", "1"));
                                    _data_format = UserDataFile.ReadKey("Data" + _k.ToString(), "format", "{0:0.0}");
                                    _unit = UserDataFile.ReadKey("Data" + _k.ToString(), "unit", "").Replace("%NONE%", "-");

                                    _datptr = Convert.ToInt32(UserDataFile.ReadKey("Data" + _k.ToString(), "start", "0"));
                                    ldum = 0;

                                    for (_m = 0; _m < _datlen; _m++)
                                    {
                                        _datptr += _m;
                                        ldum |= dbgUart.Frames[_i].DATA[_datptr];
                                        if (_m < (_datlen - 1)) ldum <<= 8;
                                    }
                                    _data_val = Convert.ToDouble(ldum);
                                    _data_val -= _offset;
                                    _data_val *= _scale;

                                    lv = lvDataMonitor.Items[_k.ToString("0000")];

                                    if ((lv != null) && (!_is_hidden))
                                    {

                                        lv.SubItems[2].Text = String.Format(_data_format, _data_val);
                                        lv.SubItems[4].Text = ldum.ToString();
                                        lv.SubItems[5].Text = ldum.ToString("X04");
                                        lv.SubItems[6].Text = Convert.ToString(ldum, 2).PadLeft((_datlen * 8), '0'); ;
                                        lv.SubItems[7].Text = dbgUart.Frames[_i].ReceiveTimeStamp.ToString();
                                    }
                                }
                            }
                        }
                        // == END OF PARSING USER DATA INTO MONITOR TABLE ========================
                        }
                        
                        // == FRAME PROCESSING ==============================================

                        OutputWindowText.Append(">" + _i.ToString("D04") + ": (" + Convert.ToUInt32(dbgUart.Frames[_i].IsComplete).ToString("D1") + ") ");

                        for (_n = 0; _n < (int)dbgUart.Frames[_i].ByteStream.Length; _n++)
                        {
                            OutputWindowText.Append("[" + dbgUart.Frames[_i].ByteStream[_n].ToString("X02") + "]");
                            sdum[_i] = sdum[_i] + " " + dbgUart.Frames[_i].ByteStream[_n].ToString("X02");
                        }
                        OutputWindowText.Append("\r\n");
                        sdum[_i] = sdum[_i].Trim();


                        if (dbgUart.Frames[_i].IsComplete)
                        { 
                            lv = new ListViewItem();

                            for (_n = 0; _n < lvRxFrames.Items.Count; _n++)
                            {
                                if (dbgUart.Frames[_i].CID.ToString("X04") == lvRxFrames.Items[_n].Name)
                                { lv = lvRxFrames.Items[_n]; break; }
                            }

                            if (lv.ListView == null)
                            { // New Message ID has been detected => Add to list 
                                lv = lvRxFrames.Items.Add(dbgUart.Frames[_i].CID.ToString("X04"));
                                lv.Name = dbgUart.Frames[_i].CID.ToString("X04"); // Frame name
                                lv.SubItems.Add(sdum[_i].Trim());               // Frame data
                                lv.SubItems.Add("1");                           // Frame Counter
                                lv.SubItems.Add(dbgUart.Frames[_i].ReceiveTimeStamp.ToString()); // Time Stamp of last received message
                                lv.ImageIndex = 1;
                            }
                            else
                            { // ID is already known and listed => Update data
                                lv.SubItems[1].Text = sdum[_i].Trim();
                                lv.SubItems[2].Text = (Convert.ToUInt64(lv.SubItems[2].Text) + 1).ToString();
                                lv.SubItems[3].Text = dbgUart.Frames[_i].ReceiveTimeStamp.ToString(); 
                            }
                        }

                        dbgUart.Frames[_i].IsComplete = false;

                        // == FRAME PROCESSING END ==========================================


                        // == TEST FRAME FOR ANALYSING DATA STREAM CONSISTENCY ==============
                        if ((chkEnableCID_22Check.Checked) && (_i > 0))
                        {
                            if ((dbgUart.Frames[_i - 1].CID == 0x0022) && (dbgUart.Frames[_i].CID == 0x0022))
                            { 
                                if (dbgUart.Frames[_i - 1].DATA[0] != (dbgUart.Frames[_i].DATA[0] - 1))
                                {
                                    if (dbgUart.Frames[_i].DATA[0] != 0x30) 
                                        dbgUStats.DataStreamErrors++;
                                }
                            }
                        }
                        // == TEST FRAME FOR ANALYSING DATA STREAM CONSISTENCY END ==========



                    }

                    // == TEXT OUTPUT UPDATE ==============================================
                    if (!chkBufferView.Checked)
                    { txtBufferView.Text = OutputWindowText.ToString(); }
                    // == TEXT OUTPUT UPDATE END ==========================================

                }

                lblStreamErrorCounter.Text = dbgUStats.DataStreamErrors.ToString();
            }
//            catch { }

            ProcessTicks = ((DateTime.Now.Ticks - ProcessTicks)/10000.0);
            toolStripStatusProcessTicks.Text = String.Format("{0:0.0}", ProcessTicks) + " ms";
            _timer_plot_active = false;
            dbgUBuf.SuspendReceive = false;

        }

        /* ************************************************************************************************ */
        private void cmdResetStatistics_Click(object sender, EventArgs e)
        {
            dbgUStats.ResetDataStatistics();
            lblDPackCount.Text = "0";
            lblMinLength.Text = "0";
            lblMaxLength.Text = "0";
            lblRecLength.Text = "0";

            return;
        }

        /* ************************************************************************************************ */
        private void cmdResetFrameBuffer_Click(object sender, EventArgs e)
        {
            dbgUart.ResetRxFrameBuffer();
            lvRxFrames.Items.Clear();
            lblFrameBuffer.Text = "0";
            lblFrameCount.Text = "0";
            lblFrameErrors.Text = "0";
            lblStreamErrorCounter.Text = "0";
            txtBufferView.Clear();
            return;
        }

        /* **************************************************************************************************
         * TEXTBOX VALUE VALIDATION ROUTINES
         * *************************************************************************************************/

        /* ************************************************************************************************ */
        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (
                ((48 <= e.KeyValue) && (e.KeyValue <= 57)) ||    // Numbers from 0-9 on keyboard
                ((96 <= e.KeyValue) && (e.KeyValue <= 105)) ||   // Number from 0-9 on NumPad
                (e.KeyValue == 8) || (e.KeyValue == 46) || ((37 <= e.KeyValue) && (e.KeyValue <= 40)) ||  // DEL, Backspace, Left-Right-Up-Down Arrows
                (e.KeyValue == 35) || (e.KeyValue == 36) || (e.KeyValue == 45)    // POS1, END, INS
                )
            {
                // u=85
                return;
            }
            else
            {
                e.SuppressKeyPress = true;
                return;
            }

        }

        /* ************************************************************************************************ */
        bool forced_update = false;
        bool hex_text_box_changed = false;
        int cursor_pos = 0;
        internal void HexTextBoxEdit(object sender, KeyEventArgs e)
        {

            if (!forced_update)
            {
                // First check who's calling
                TextBox txt;

                txt = (TextBox)sender;

                if (txt.Name == txtDATA.Name)
                { txt = txtDATA; }
                else if (txt.Name == txtID.Name)
                { txt = txtID; }
                else { return; }

                string _datX = "";
                bool cur_at_end = false;

                forced_update = true;

                cursor_pos = txt.SelectionStart; 
                cur_at_end = (bool)(txt.SelectionStart == txt.Text.Length);

                if (hex_text_box_changed)
                    _datX = HexTextBoxPrint(txt, false);

                if (cursor_pos < 0) cursor_pos = 0;

                if (cur_at_end)
                    txt.SelectionStart = txt.Text.Length; // Set cursor
                else
                    txt.SelectionStart = cursor_pos; // Set cursor

                GenerateTxFrame(sender, e);

                forced_update = false;
                hex_text_box_changed = false;
            }

        }

        /* ************************************************************************************************ */
        private string HexTextBoxPrint(TextBox txt, bool move_cursor)
        {
            string _data = "", _datX = "", datE = "";
            int i = 0, k = 0, cursor_offset = 0;

            _data = txt.Text;

            // Walk through string...
            for (i = 0; i < _data.Length; i++)
            {
                // capture next HEX-Nibble
                datE = _data.Substring(i, 1);
                k = ((++k) & 0x03);

                if ((datE == " ") && (k != 3))
                {
                    datE = "";
                    k--;
                    if(i<cursor_pos) cursor_offset--;
                }

                if (k == 3)
                {
                    k = 0;
                    if (datE != " ")
                    {
                        datE = " " + datE;
                        k++;
                        if (i < cursor_pos) cursor_offset++;
                    }
                }


                // Add HEX-Nibble
                _datX = _datX + datE;
            
            }

            // Check end of string for spaces
            if (_datX.Length > 0) { 
                if (_datX.Substring(_datX.Length - 1, 1) == " ")
                    _datX.TrimEnd();
            }

            cursor_pos += cursor_offset;
            txt.Text = _datX;
            return (_datX);

        }

        /* ************************************************************************************************ */
        private void TxFrameField_TextChanged(object sender, EventArgs e)
        {
            hex_text_box_changed = true;
        }

        /* ************************************************************************************************ */
        private void TxFrameField_GetCursor(object sender, EventArgs e)
        {
            int byte_offset = 0;
            TextBox txt;

            txt = (TextBox)sender;

            if (txt.Name == txtDATA.Name)
            { txt = txtDATA; }
            else if (txt.Name == txtID.Name)
            { txt = txtID; }
            else { return; }

            cursor_pos = txt.SelectionStart;

            if (txt.Name == txtDATA.Name)
            {
                byte_offset = Convert.ToInt32(Math.Floor((double)txt.SelectionStart / 3.0));
                lblBytePos.Text = byte_offset.ToString();
            }
            else { lblBytePos.Text = "0"; }
        }

        /* ************************************************************************************************ */
        private void TxFrameField_KeyDown(object sender, KeyEventArgs e)
        {

            TextBox txt;

            txt = (TextBox)sender;

            if (txt.Name == txtDATA.Name)
            { txt = txtDATA; }
            else if (txt.Name == txtID.Name)
            { txt = txtID; }
            else { return; }

            TxFrameField_GetCursor(sender, (EventArgs)e);

            // If ENTER is hit, trigger entry update
            if (e.KeyCode == Keys.Enter)
            {
                if (cmdAddTxFrame.Enabled)
                { cmdAddTxFrame_Click(cmdAddTxFrame, e); }
                e.SuppressKeyPress = true;
            }

            // Special considerations with DEL and BACK
            if ((txt.SelectionStart < txt.Text.Length) && (txt.Text.Length > 0))
            {
                if ((e.KeyCode == Keys.Delete) && (txt.Text.Substring(txt.SelectionStart, 1) == " "))
                { txt.SelectionStart++; }
            }

            if ((txt.SelectionStart > 0) && (txt.Text.Length > 0))
            {
                if ((e.KeyCode == Keys.Back) && (txt.Text.Substring((txt.SelectionStart - 1), 1) == " "))
                { txt.SelectionStart--; }
            }

            // Exclude everything besides HEX numbers and navigation keys
            if (
                ((48 <= e.KeyValue) && (e.KeyValue <= 57)) ||    // Numbers from 0-9 on keyboard
                ((96 <= e.KeyValue) && (e.KeyValue <= 105)) ||   // Number from 0-9 on NumPad
                ((65 <= e.KeyValue) && (e.KeyValue <= 70)) ||    // Number from A-F on keyboard
                ((97 <= e.KeyValue) && (e.KeyValue <= 102)) ||    // Number from a-f on keyboard
                (e.KeyValue == 8) || (e.KeyValue == 46) || ((37 <= e.KeyValue) && (e.KeyValue <= 40)) ||  // DEL, Backspace, Left-Right-Up-Down Arrows
                (e.KeyValue == 35) || (e.KeyValue == 36) || (e.KeyValue == 45)    // POS1, END, INS
                )
            {
                // u=85
                return;
            }
            else
            {
                e.SuppressKeyPress = true;
                return;
            }

        }

        /* ************************************************************************************************ */
        private void TxFrameField_MouseClick(object sender, MouseEventArgs e)
        {
            TxFrameField_GetCursor(sender, EventArgs.Empty);
        }

        /* **************************************************************************************************
         * TX FRAME VALUE EDIT VALIDATION ROUTINES
         * *************************************************************************************************/

        /* ************************************************************************************************ */
        private void GenerateTxFrame(object sender, EventArgs e)
        {
            int i = 0;
            string _dlen = "", _data = "", _crc = "";
            int cid = 0, dlen = 0, crc = 0, _data_array_len = 0;

            string[] _data_array;
            byte[] _frm_data = new byte[0];
            smpsDebugUARTParser frmP = new smpsDebugUARTParser();
            smpsDebugUARTFrame frmm = new smpsDebugUARTFrame();

            try
            {

                _data = txtDATA.Text.Trim();
                _data_array = _data.Split(new Char[] { ' ' });
                _data_array_len = _data_array.Length;

                if (_data.Length > 0)
                {
                    if (_data_array[0].Trim() != "")
                    { dlen = (int)(_data_array_len); }
                    else { return; }
                }
                else
                {
                    _data_array_len = 0;
                    dlen = 0;
                }
                _dlen = ((dlen & 0xFF00) >> 8).ToString("X02") + " " + (dlen & 0x00FF).ToString("X02");
                txtDLEN.Text = _dlen;

                _data = txtID.Text.Trim();
                _data = _data.Replace(" ", "");
                cid = (int)Convert.ToInt64(_data, 16);

                Array.Resize<byte>(ref _frm_data, (int)dlen); // + smpsDebugUART.smpsDebugUARTFrame.FRAME_OFFSET_DATA));

                if (_data_array_len > 0)
                {
                    for (i = 0; i < (_data_array.Length); i++)
                    {
                        _frm_data[i] = Convert.ToByte(Convert.ToInt64(_data_array[i], 16));
                    }
                }

                frmm = frmP.BuildFrame((ushort)cid, _frm_data);

                dbgUTxFrame = frmm;

                crc = frmm.CRC16;
                _crc = ((crc & 0xFF00) >> 8).ToString("X02") + " " + (crc & 0x00FF).ToString("X02");
                txtCRC.Text = _crc;

                txtID.BackColor = SystemColors.Window;
                txtDATA.BackColor = SystemColors.Window;
                cmdAddTxFrame.Enabled = true;

            }
            catch
            {
                txtID.BackColor = Color.LightCoral;
                txtDATA.BackColor = Color.LightCoral;
                cmdAddTxFrame.Enabled = false;

            }

            return;

        }

        /* ************************************************************************************************ */
        private void AddTxFrameToList(object sender, EventArgs e)
        {
            int _i = 0;
            string sdum = "";
            ListViewItem lv;

            if (!_user_file_loaded) return;

            if (lvTxFrames.SelectedItems.Count == 0)
            { // If no list item is selected, the user is creating a new entry

                lv = lvTxFrames.Items.Add("");
                lv.SubItems.Add("");

                // Capture the next available index
                do
                { sdum = (_i++).ToString(); }
                while (UserDataFile.KeyExists("TxFrames", sdum));

                lv.Name = sdum; 

            }
            else
            { // If a list item is selected, the user is editing an existing entry
                lv = lvTxFrames.SelectedItems[0];
            }

            lv.SubItems[0].Text = txtUserLabel.Text.Trim();
            lv.SubItems[1].Text = (
                    smpsDebugUART.smpsDebugUARTFrame.START_OF_FRAME.ToString("X02").Trim() + " " +
                    txtID.Text.Trim() + " " +
                    txtDLEN.Text.Trim() + " " +
                    txtDATA.Text.Trim() + " " +
                    txtCRC.Text.Trim() + " " +
                    smpsDebugUART.smpsDebugUARTFrame.END_OF_FRAME.ToString("X02").Trim()
                );
            lv.ImageIndex = 0;

            UserDataFile.WriteKey("TxFrames", lv.Name, (lv.SubItems[0].Text.Trim() + "\t" + lv.SubItems[1].Text.Trim()));

            // Update Tx command list index
            UpdateTxListIndex();

            return;
        }

        /* ************************************************************************************************ */
        private void SendTxFrame(object sender, EventArgs e)
        {
            // If no command is selected, exit here
            if (lvTxFrames.SelectedItems.Count == 0)
                return;

            // If Tx Frame is empty, exit here
            if (dbgUTxFrame == null)
                return;

            // If port is not opened, throw notice
            if (!serialPort.IsOpen) 
            {
                notice_flash_counter = 0;
                tmrOpenPortNotice.Enabled = true;
                return;
            }

            // Send data
            if ((dbgUTxFrame.ValidateFrame(dbgUTxFrame.ByteStream) && (serialPort.IsOpen)))
                serialPort.Write(dbgUTxFrame.ByteStream, 0, dbgUTxFrame.ByteStream.Length);

            return;
        }

        /* ************************************************************************************************ */
        private void UpdateTxListIndex()
        {
            int i = 0;
            string sdum = "";

            if (!_user_file_loaded) return;

            // Build new index list
            for (i = 0; i < lvTxFrames.Items.Count; i++)
            {
                sdum = sdum + lvTxFrames.Items[i].Name.ToString();
                if (i < (lvTxFrames.Items.Count - 1))
                    sdum = sdum + ",";
            }
            UserDataFile.WriteKey("TxFrames", "List", sdum);

            return;
        
        }

        /* ************************************************************************************************ */
        private void cmdAddTxFrame_Click(object sender, EventArgs e)
        {
            AddTxFrameToList(sender, e);
            try { txtUserLabel.Select(); }
            catch { }
            return;
        }

        /* ************************************************************************************************ */
        private void cmdNewTxFrame_Click(object sender, EventArgs e)
        {
            lvTxFrames.SelectedItems.Clear();
            txtUserLabel.Text = "New Tx Frame";
            txtID.Text = "00 00";
            txtDATA.Text = "00";
            try { txtUserLabel.Select(); }
            catch { }
            return;
        }

        /* ************************************************************************************************ */
        private void cmdDeleteTxFrame_Click(object sender, EventArgs e)
        {
            int i = 0, sel_items = 0;
            ListViewItem lv;

            if (!_user_file_loaded) return;

            // Check if list conains selected entries
            if (lvTxFrames.SelectedItems.Count == 0)
            {
                cmdDeleteTxFrame.Enabled = false;
                return;
            }

            // Delete all selected items
            sel_items = lvTxFrames.SelectedItems.Count;

            for (i = 0; i < sel_items; i++)
            {
                lv = lvTxFrames.SelectedItems[0];
                UserDataFile.DeleteKey("TxFrames", lv.Name);
                lv.Remove();
            }

            // Unselect all items
            lvTxFrames.SelectedItems.Clear();

            // Update Tx command list index
            UpdateTxListIndex();

            return;

        }


        /* ************************************************************************************************ */
        private void txtUserLabel_KeyDown(object sender, KeyEventArgs e)
        {
            // If ENTER is hit, trigger entry update
            if (e.KeyCode == Keys.Enter)
            {
                if (cmdAddTxFrame.Enabled)
                { cmdAddTxFrame_Click(cmdAddTxFrame, e); }
            }

        }

        /* ************************************************************************************************ */
        private void lvTxFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            string sdum = "";
            string[] _split_cmd;
            ListViewItem lv;


            if (lvTxFrames.SelectedItems.Count == 0)
            {
                cmdAddTxFrame.Text = "&Add";
                cmdDeleteTxFrame.Enabled = false;
                return;
            }
            else
            {
                cmdAddTxFrame.Text = "&Update";
                cmdDeleteTxFrame.Enabled = true;
                lv = lvTxFrames.SelectedItems[0];

                // Replace User Label
                txtUserLabel.Text = lv.SubItems[0].Text; 

                // Parse Frame Items
                sdum = lv.SubItems[1].Text.Trim();
                _split_cmd = sdum.Split(new Char[] { ' ' });

                // Add ID
                sdum = _split_cmd[1] + " " + _split_cmd[2];
                txtID.Text = sdum;

                // Add DATA bytes
                sdum = "";
                for (i = smpsDebugUART.smpsDebugUARTFrame.FRAME_OFFSET_DATA; i < _split_cmd.Length - 3; i++)
                {
                    sdum = sdum + _split_cmd[i] + " ";
                }

                txtDATA.Text = sdum.Trim();
                GenerateTxFrame(sender, e);


            }

            return;

        }

        /* ************************************************************************************************ */
        private void lvTxFrames_KeyDown(object sender, KeyEventArgs e)
        {
            // If ENTER is hit, send selected command
            if (e.KeyCode == Keys.Enter)
            { SendTxFrame(sender, e); }

            // If DELETE is hit, delete selected entries
            else if (e.KeyCode == Keys.Delete)
            {
                if (cmdDeleteTxFrame.Enabled)
                    cmdDeleteTxFrame_Click(sender, (EventArgs)e);
            }
        }

        /* ************************************************************************************************ */
        private void AddRxFrameToList(smpsDebugUARTFrame RxFrame)
        {
            int i = 0;
            string sdum = "";
            ListViewItem lv;

            lv = lvRxFrames.Items.Add(RxFrame.CID.ToString("X04"));
            lv.SubItems[0].Text = RxFrame.CID.ToString("X04");
            lv.Name = RxFrame.CID.ToString("X04");

            lv.SubItems.Add("");

            for (i = 0; i < (RxFrame.ByteStream.Length - smpsDebugUARTFrame.FRAME_TAIL_OVERHEAD); i++)
            {
                sdum = sdum + " " + RxFrame.ByteStream[i].ToString("X02");
            }

            lv.SubItems[1].Text = sdum.Trim();
            lv.ImageIndex = 1;

            return;
        }

        private void tmrPortScan_Tick(object sender, EventArgs e)
        {
            ListCommPorts();
        }

        private bool OpenFile(string FileToOpen)
        {

            string sdum = "", udum = "";
            int i = 0, file_list_count = 0; // for reading Rx Frames
            string[] _split_cmd, _split_list; // for reading Tx Frames
            ListViewItem lv;

            // If File doesn't exists, exit here
            if (!System.IO.File.Exists(FileToOpen))
            {
                cmbUserFileName.Text = "";
                _user_file_loaded = false;
                return (false);
            }

            // Set Global Flag
            if (_open_file_in_progress) return(false);
            _open_file_in_progress = true;

            // Set FileToOpen as new User Data File
            if (UserDataFile.SetFilename(FileToOpen))
            {
                // === LOAD RX FRAME DEFINITIONS =============================================
                lvDataMonitor.Items.Clear();

                lblUserConfigName.Text = UserDataFile.ReadKey("common", "Title", "User Data Table");
                lblUserConfigDescription.Text = UserDataFile.ReadKey("common", "Description", "");

                sdum = UserDataFile.ReadKey("Data", "count", "0");
                for (i = 0; i < Convert.ToInt32(sdum); i++)
                {

                    if (!Convert.ToBoolean(Convert.ToInt32(UserDataFile.ReadKey("Data" + i.ToString(), "hide", "0"))))
                    {
                        lvDataMonitor.VirtualMode = false;
                        lv = lvDataMonitor.Items.Add(i.ToString("0000"), "D" + i.ToString("0000"), "");

                        lv.Checked = Convert.ToBoolean(Convert.ToInt32(UserDataFile.ReadKey("Data" + i.ToString(), "log", "0")));
                        lv.SubItems.Add(UserDataFile.ReadKey("Data" + i.ToString(), "Name", "n/a")); // Name field
                        lv.SubItems.Add("0"); // Value field
                        udum = UserDataFile.ReadKey("Data" + i.ToString(), "Unit", "n/a").Replace("%NONE%", "-");
                        udum = udum.Replace("%DEGREE%", "°");
                        lv.SubItems.Add(udum); // Physical unit
                        lv.SubItems.Add("0"); // Decimal value
                        lv.SubItems.Add("0x0000"); // Hexadecimal value
                        lv.SubItems.Add("00000000 00000000"); // Binary value
                        lv.SubItems.Add("0"); // Timestamp of last received message
                    }
                }

                lvDataMonitor.View = View.Details;
                lvDataMonitor.GridLines = true;

                for (i = 0; i < lvDataMonitor.Columns.Count; i++)
                { lvDataMonitor.Columns[i].Width = Convert.ToInt32(UserDataFile.ReadKey("UserDataView", "col_width" + i.ToString(), "120")); }

                lvDataMonitor.Columns[0].TextAlign = HorizontalAlignment.Center;
                lvDataMonitor.Columns[1].TextAlign = HorizontalAlignment.Left;
                lvDataMonitor.Columns[2].TextAlign = HorizontalAlignment.Right;
                lvDataMonitor.Columns[3].TextAlign = HorizontalAlignment.Left;
                lvDataMonitor.Columns[4].TextAlign = HorizontalAlignment.Right;
                lvDataMonitor.Columns[5].TextAlign = HorizontalAlignment.Right;
                lvDataMonitor.Columns[6].TextAlign = HorizontalAlignment.Right;
                lvDataMonitor.Columns[7].TextAlign = HorizontalAlignment.Left;

            }


            // === LOAD TX FRAME DEFINITIONS =============================================

            lvTxFrames.Items.Clear();
            lvTxFrames.SmallImageList = imlFrameClasses;
            lvTxFrames.View = View.Details;
            lvTxFrames.Columns[0].Width = 220;
            lvTxFrames.Columns[1].Width = (lvTxFrames.Width - (lvTxFrames.Columns[0].Width + 6));
            lvTxFrames.AllowColumnReorder = false;
            lvTxFrames.AllowDrop = false;
            lvTxFrames.AutoArrange = true;
            lvTxFrames.FullRowSelect = true;

            sdum = UserDataFile.ReadKey("TxFrames", "List", "");
            if (sdum.Trim().Length > 0)
            {

                _split_list = sdum.Split(new Char[] { ',' });

                for (i = 0; i < _split_list.Length; i++)
                {
                    sdum = UserDataFile.ReadKey("TxFrames", _split_list[i].Trim(), "");
                    if (sdum.Trim().Length > 0)
                    {
                        _split_cmd = sdum.Split(new Char[] { '\t' });

                        lv = lvTxFrames.Items.Add(_split_cmd[0].Trim());
                        lv.Name = _split_list[i].Trim();
                        lv.ImageIndex = 0;
                        lv.SubItems.Add(_split_cmd[1].Trim());
                    }

                }
            }

            // === ADD USER DATA FILE TO HISTORY ==============================================

            // Check if this file is known
            for (i = 0; i < cmbUserFileName.Items.Count; i++)
            {
                if (cmbUserFileName.Items[i].ToString().ToLower() == FileToOpen.ToLower())
                {
                    cmbUserFileName.SelectedIndex = i;
                    break;
                }
            }

            // If this is a new, unknown file...
            if (i >= cmbUserFileName.Items.Count)
            {
                // Update file history
                file_list_count = Convert.ToInt32(ProjectFile.ReadKey("UserDataFiles", "count", "0"));
                file_list_count++;

                if (file_list_count > 8) // When file list gets too long, reorder list
                { file_list_count = 8; }

                for (i = (file_list_count-1); i > 0; i--)
                {
                    if (System.IO.File.Exists(ProjectFile.ReadKey("UserDataFiles", "file" + (i - 1).ToString(), "")))
                    { ProjectFile.WriteKey("UserDataFiles", "file" + i.ToString(), ProjectFile.ReadKey("UserDataFiles", "file" + (i - 1).ToString(), "")); }
                }

                ProjectFile.WriteKey("UserDataFiles", "file0", FileToOpen); // Add new file

                cmbUserFileName.Items.Clear();
                for (i = 0; i < file_list_count; i++)
                { cmbUserFileName.Items.Add(ProjectFile.ReadKey("UserDataFiles", "file" + i.ToString(), "")); }

            }

            // Set flag and save last file
            ProjectFile.WriteKey("UserDataFiles", "LastFile", FileToOpen);
            _user_file_loaded = true;
            cmdAddTxFrame.Enabled = true;
            cmdNewTxFrame.Enabled = true;

            this.Text = Application.ProductName + " v" + Application.ProductVersion + " - [" + UserDataFile.FileTitle + "]";

            // Select corrent filename in filen list drop down menu
            for (i = 0; i < cmbUserFileName.Items.Count; i++)
            {
                if (cmbUserFileName.Items[i].ToString().ToLower() == UserDataFile.FileName.ToLower())
                {
                    cmbUserFileName.SelectedIndex = i;
                    break;
                }
            }

            // Clear OpenFile flag            
            _open_file_in_progress = false;

            return (true);

        }

        private bool SaveFile(string FileToSave)
        {

            return (true);
        }

        private void cmbUserFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode== Keys.E) && (e.Control))
            {
                try
                {
                    e.SuppressKeyPress = true;
                    openUserDataConfigurationToolStripMenuItem_Click(sender, EventArgs.Empty);
                }
                catch { }
            
            }
            else if ((e.KeyCode == Keys.O) && (e.Control))
            {
                e.SuppressKeyPress = true;
                openToolStripMenuItem_Click(sender, (EventArgs)e);
            }

        }

        private void openUserDataConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(cmbUserFileName.Text.Trim());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();

            ofdlg.Filter = "Debugging UART Data Definition Files (*.ini)|*.ini|All files (*.*)|*.*";
            ofdlg.FilterIndex = 1;

            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofdlg.CheckPathExists)
                    {
                        // Open File Here
                        OpenFile(ofdlg.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error (0x" + ex.HResult.ToString("X") + "): Could not read file from disk.\r\n" +
                        "Original error: " + ex.Message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            ofdlg.Dispose();

        }

        private void cmbUserFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_open_file_in_progress)
                OpenFile(cmbUserFileName.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* *********************************************************************************************** */
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsINIFileHandler new_cfg_file = new clsINIFileHandler();
            SaveFileDialog sfdlg = new SaveFileDialog();

            // Get New Filename 
            // Show "Save As..." Dialog
            sfdlg.FileName = "New User Data Configuration";
            sfdlg.Filter = "Debugging UART Data Definition Files (*.ini)|*.ini";
            sfdlg.FilterIndex = 1;

            if (_user_file_loaded)
                sfdlg.InitialDirectory = UserDataFile.Directory;
            else
                sfdlg.InitialDirectory = Application.StartupPath;

            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfdlg.CheckPathExists)
                    {
                        // Save File Template
                        new_cfg_file.Create(sfdlg.FileName, "common", "Date", DateTime.Now.ToString("MM/dd/yyyy"));

                        // Write Initial Sections and Values
                        new_cfg_file.WriteKey("common", "Title", "New Configuration");
                        new_cfg_file.WriteKey("common", "Description", "(add a description)");
                        new_cfg_file.WriteKey("common", "User", Environment.UserName);
                        new_cfg_file.WriteKey("common", "Version", "1.0");

                        new_cfg_file.WriteKey("UserDataView", "col_width0", "70");
                        new_cfg_file.WriteKey("UserDataView", "col_width1", "200");
                        new_cfg_file.WriteKey("UserDataView", "col_width2", "120");
                        new_cfg_file.WriteKey("UserDataView", "col_width3", "60");
                        new_cfg_file.WriteKey("UserDataView", "col_width4", "60");
                        new_cfg_file.WriteKey("UserDataView", "col_width5", "90");
                        new_cfg_file.WriteKey("UserDataView", "col_width6", "200");
                        new_cfg_file.WriteKey("UserDataView", "col_width7", "160");

                        new_cfg_file.WriteKey("TxFrames", "List", "");

                        new_cfg_file.WriteKey("Data", "count", "0");

                        OpenFile(new_cfg_file.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error (0x" + ex.HResult.ToString("X") + "):" + ex.Message + "\r\n" +
                                    "File path could not be identified."
                                    , "Save File",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1
                                    );
                    // Restore output window
                    sfdlg.Dispose();

                    return;

                }
            }
            else
            {
                // Restore output window
                sfdlg.Dispose();
                return;
            }

            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsINIFileHandler new_cfg_file = new clsINIFileHandler();
            SaveFileDialog sfdlg = new SaveFileDialog();

            int i = 0;
            string str_dum = "";
            string[] str_arr;
            string[] dum_sep = new string[1];

            // Get New Filename 
            // Show "Save As..." Dialog

            if (_user_file_loaded) {
                sfdlg.FileName = UserDataFile.FileTitle;
                sfdlg.InitialDirectory = UserDataFile.Directory;
            }
            else {
            // If no user configuration can be copied, switch to "Create New File" procedure
                newToolStripMenuItem_Click(sender, e);
                return;
            }

            sfdlg.Filter = "Debugging UART Data Definition Files (*.ini)|*.ini";
            sfdlg.FilterIndex = 1;

            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfdlg.CheckPathExists)
                    {
                        // Save File Template
                        new_cfg_file.Create(sfdlg.FileName, "common", "Date", DateTime.Now.ToString("MM/dd/yyyy"));

                        // Write Initial Sections and Values
                        new_cfg_file.WriteKey("common", "Title", UserDataFile.ReadKey("common", "Title", ""));
                        new_cfg_file.WriteKey("common", "User", Environment.UserName);
                        new_cfg_file.WriteKey("common", "Version", UserDataFile.ReadKey("common", "Version", "1.0"));

                        new_cfg_file.WriteKey("UserDataView", "col_width0", "70");
                        new_cfg_file.WriteKey("UserDataView", "col_width1", "200");
                        new_cfg_file.WriteKey("UserDataView", "col_width2", "120");
                        new_cfg_file.WriteKey("UserDataView", "col_width3", "60");
                        new_cfg_file.WriteKey("UserDataView", "col_width4", "60");
                        new_cfg_file.WriteKey("UserDataView", "col_width5", "90");
                        new_cfg_file.WriteKey("UserDataView", "col_width6", "200");
                        new_cfg_file.WriteKey("UserDataView", "col_width7", "160");

                        new_cfg_file.WriteKey("TxFrames", "List", UserDataFile.ReadKey("TxFrames", "List", ""));

                        str_dum = UserDataFile.ReadKey("TxFrames", "List", "");
                        dum_sep[0] = ",";
                        str_arr = str_dum.Split(dum_sep, StringSplitOptions.RemoveEmptyEntries);
                        for (i=0; i<str_arr.Length; i++)
                        {
                            new_cfg_file.WriteKey("TxFrames", i.ToString(), UserDataFile.ReadKey("TxFrames", i.ToString(), ""));
                        }

                        new_cfg_file.WriteKey("Data", "count", UserDataFile.ReadKey("Data", "count", "0"));
                        str_dum = UserDataFile.ReadKey("Data", "count", "0");
                        for (i=0; i<str_arr.Length; i++)
                        {
                            new_cfg_file.WriteKey("Data" + i.ToString(), "cid", UserDataFile.ReadKey("Data" + i.ToString(), "cid", "0000"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "start", UserDataFile.ReadKey("Data" + i.ToString(), "start", "0"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "length", UserDataFile.ReadKey("Data" + i.ToString(), "length", "1"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "name", UserDataFile.ReadKey("Data" + i.ToString(), "neame", "n/a"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "unit", UserDataFile.ReadKey("Data" + i.ToString(), "unit", "n/a"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "offset", UserDataFile.ReadKey("Data" + i.ToString(), "offset", "0"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "scale", UserDataFile.ReadKey("Data" + i.ToString(), "scale", "1"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "log", UserDataFile.ReadKey("Data" + i.ToString(), "log", "0"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "hide", UserDataFile.ReadKey("Data" + i.ToString(), "hide", "0"));
                            new_cfg_file.WriteKey("Data" + i.ToString(), "format", UserDataFile.ReadKey("Data" + i.ToString(), "format", "{0:0.0}"));
                        }

                        // Open File
                        OpenFile(new_cfg_file.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error (0x" + ex.HResult.ToString("X") + "):" + ex.Message + "\r\n" +
                                    "File path could not be identified."
                                    , "Save File",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1
                                    );
                    // Restore output window
                    sfdlg.Dispose();

                    return;

                }
            }
            else
            {
                // Restore output window
                sfdlg.Dispose();
                return;
            }

        }

        private void lblUserConfigName_Click(object sender, EventArgs e)
        {
        }

        private void lblUserConfigName_DoubleClick(object sender, EventArgs e)
        {
            string label = "";
            DialogResult result = new DialogResult();

            label = this.lblUserConfigName.Text;

            result = ShowInputDialog(this, this.Font, ref label,
                    "New Title:", "Please enter a new user-defined title:");

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lblUserConfigName.Text = label;
                UserDataFile.WriteKey("common", "Title", label);
            }

        }

        private void lblUserConfigDescription_DoubleClick(object sender, EventArgs e)
        {
            string label = "";
            DialogResult result = new DialogResult();

            label = this.lblUserConfigName.Text;

            result = ShowInputDialog(this, this.Font, ref label,
                    "New Description:", "Please enter a new user-defined description:");

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lblUserConfigDescription.Text = label;
                UserDataFile.WriteKey("common", "Description", label);
            }

        }

        private static DialogResult ShowInputDialog(IWin32Window owner, Font font, ref string input, string caption, string descr)
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 90);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Font = font;
            inputBox.Text = caption;

            System.Windows.Forms.Label labelLabel = new Label();
            labelLabel.TextAlign = ContentAlignment.TopLeft;
            labelLabel.Size = new System.Drawing.Size(size.Width - 10, 23);
            labelLabel.Location = new System.Drawing.Point(5, 5);
            labelLabel.Font = font;
            labelLabel.Text = descr;
            inputBox.Controls.Add(labelLabel);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(labelLabel.Left, labelLabel.Top + labelLabel.Height + 5);
            textBox.Font = font;
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 100, textBox.Top + textBox.Height + 9);
            inputBox.Controls.Add(cancelButton);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(cancelButton.Left - okButton.Width - 2, cancelButton.Top);
            inputBox.Controls.Add(okButton);

            inputBox.Height = okButton.Top + okButton.Height + 49;

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;
            inputBox.StartPosition = FormStartPosition.CenterParent;

            DialogResult result = inputBox.ShowDialog(owner);
            input = textBox.Text;
            return result;
        }

        private void txtOutputTerminal_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.C) && (e.Alt))
            {
                TerminalBuffer.Clear();
                txtOutputTerminal.Clear();
                e.SuppressKeyPress = true;
            }
        }

        private void txtOutputTerminal_VScroll(object sender, EventArgs e)
        {
            int minScroll;
            int maxScroll;
            long snapMargin;

            GetScrollRange(txtOutputTerminal.Handle, SB_VERT, out minScroll, out maxScroll);
            Point rtfPoint = Point.Empty;
            SendMessage(txtOutputTerminal.Handle, EM_GETSCROLLPOS, 0, ref rtfPoint);

            snapMargin = Convert.ToUInt32(rtfPoint.Y * 0.05);
            TerminalScrolledToBottom = rtfPoint.Y + txtOutputTerminal.ClientSize.Height >= (maxScroll-snapMargin);
            //label16.Text = rtfPoint.Y.ToString();

        }

    }
}

