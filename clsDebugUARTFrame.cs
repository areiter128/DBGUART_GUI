using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpsDebugUART
{
    class smpsDebugUARTFrame
    {
        /* *********************************************************************************
         * Digital Power Debugging UART Communication Frame
         * ================================================
         * 
         * 1) Data Frame Format:
         * 
         * 
         *     SOF   IDH   IDL   DLH   DLL   DAT0  DAT1  ?  DATn  CRCH  CRCL  EOF
         *    [0x55][0xnn][0xmm][0xkk][0xkk][0xkk][0xkk][?][0xkk][0xkk][0xkk][0x0D]
         * 
         *    SOF = START_OF_FRAME (always 0x55)
         *    IDH = IDENTIFIER_HIGH_BYTE
         *    IDL = IDENTIFIER_LOW_BYTE
         *    DLH = DATA_LENGTH_HIGH_BYTE
         *    DLL = DATA_LENGTH_LOW_BYTE
         *    DAT0?DATn = DATA_BYTES
         *    CRCH = CRC16_HIGH_BYTE (IBM CRC16 format)
         *    CRCL = CRC16_LOW_BYTE  (IBM CRC16 format)
         *    EOF = END_OF_FRAME (always 0x0D)
         *
         * *********************************************************************************/

        // Frame constants
        public const byte START_OF_FRAME = (byte)0x55;
        public const byte END_OF_FRAME = (byte)0x0D;

        // frame offset definition
        public const int FRAME_OFFSET_SOF = 0;
        public const int FRAME_OFFSET_ID = 2;
        public const int FRAME_OFFSET_DLEN = 4;
        public const int FRAME_OFFSET_DATA = 5;
        public const int FRAME_OFFSET_CRC = 6;
        public const int FRAME_OFFSET_EOF = 7;

        public const int FRAME_HEADER_OVERHEAD = 5;
        public const int FRAME_TAIL_OVERHEAD = 3;
        public const int FRAME_OVERHEAD = (FRAME_HEADER_OVERHEAD + FRAME_TAIL_OVERHEAD);

        public const int FRAME_CRC_BYPASS_CID = 0x000F;

        /*
            * Communication Frame
            * 
            * |-SOF-|-----CID-----|--- DATA_LEN---|---------DATA-----------|-----CRC16-------|-EOF-|
            * [0x55] [CIDH] [CIDL] [DLENH] [DLENL] [DAT0] [DAT1] ... [DATn] [CRC16H] [CRC16L] [EOF]
            */

        private byte _SOF = 0;
        public byte SOF                        //  8-bit wide START_OF_FRAME byte = 0x55 
        {
            get { return _SOF; }
            set { _SOF = value; return; }
        }

        private UInt16 _CID = 0;
        public UInt16 CID                        // 16-bit wide Message ID 
        {
            get { return _CID; }
            set { _CID = value; UpdateByteStream(); return; }
        }

        private UInt16 _DLEN = 0;
        public UInt16 DLEN                      // 16-bit wide data length 
        {
            get { return _DLEN; }
            set { _DLEN = value; UpdateByteStream(); return; }
        }

        private byte[] _DATA = new byte[0];
        public byte[] DATA                      // dynamic byte array holding data
        {
            get { return _DATA; }
            set { _DATA = value; UpdateByteStream(); return; }
        }

        private UInt16 _CRC16 = 0;
        public UInt16 CRC16                     // 16-bit checksum 
        {
            get { return _CRC16; }
            set { _CRC16 = value; UpdateByteStream(); return; }
        }

        private byte _EOF = 0;
        public byte EOF                        // 8-bit wide END_OF_FRAME byte = 0x0D
        {
            get { return _EOF; }
            set { _EOF = value; return; }
        }

        private bool _IsComplete = false;
        public bool IsComplete                       // Flag indicating that building this frame has completed
        {
            get { return _IsComplete; }
            set { _IsComplete = value; return; }
        }

        private bool _IsKnown = false;
        public bool IsKnown                     // Flag indicating if this frame has been received previously
        {
            get { return _IsKnown; }
            set { _IsKnown = value; return; }
        }

        private long _receive_time_stamp = 0;
        public long ReceiveTimeStamp
        {
            get { return (_receive_time_stamp);  }
            set { _receive_time_stamp = value; return;  }
        }

        private byte[] _byte_stream;
        public byte[] ByteStream               // 8-bit data array covering the entire data frame
        {
            get { return _byte_stream; }
            set {

                if (value.Length < 7) return;  // Check if array is long enough

                try
                {
                    // Update values
                    if ((value[0] == START_OF_FRAME) && (value[value.Length - 1] == END_OF_FRAME))
                    {
                        ushort _cid = 0, crc_len = 0, crc = 0, crc_in = 0;

                        crc_len = (ushort)((((int)value[3] << 8) | (int)value[4]) + FRAME_OFFSET_DATA);

                        // only check CRC in frames with IDs > #15
                        _cid = (ushort)(((int)value[1] << 8) | ((int)value[2]));

                        // Check CRC only in frames with IDs >0x000F
                        if (_cid > FRAME_CRC_BYPASS_CID)
                        { crc = GetCRC16(value, 0, (int)crc_len); }
                        
                        crc_in = ((ushort)(((int)value[value.Length - 3] << 8) | (int)value[value.Length - 2]));
                        if (crc == crc_in) 
                        {
                            _byte_stream = value;          // Copy array 

                            _SOF = _byte_stream[0];
                            _CID = (ushort)(((int)_byte_stream[1] << 8) | (int)_byte_stream[2]);
                            _DLEN = (ushort)(((int)_byte_stream[3] << 8) | (int)_byte_stream[4]);
                            _CRC16 = crc_in;
                            _EOF = _byte_stream[_byte_stream.Length - 1];

                            Array.Resize<byte>(ref _DATA, _DLEN);
                            Array.Copy(_byte_stream, FRAME_OFFSET_DATA, _DATA, 0, _DLEN);

                            _IsComplete = true;  // Set flag that this frame is new/updated
                        }

                    }
                }
                catch 
                {
                    _IsComplete = false;
                }

                return; 
            }
        }

        private bool UpdateByteStream()
        {
            int i = 0, crc_mark = 0;

            if (_byte_stream == null) _byte_stream = new byte[0];
            Array.Resize<byte>(ref _byte_stream, _DLEN + FRAME_OVERHEAD);

            _byte_stream[0] = START_OF_FRAME;
            _byte_stream[1] = (byte)((_CID & 0xFF00) >> 8);
            _byte_stream[2] = (byte) (_CID & 0x00FF);
            _byte_stream[3] = (byte)((_DLEN & 0xFF00) >> 8);
            _byte_stream[4] = (byte) (_DLEN & 0x00FF);

            if ((_DLEN > 0) && (_DATA != null))
            {
                if (_DATA.Length >= _DLEN)
                { 
                    for (i = 0; i < _DLEN; i++)
                    {
                        _byte_stream[FRAME_OFFSET_DATA + i] = _DATA[i];
                    }
                }
            }

            crc_mark = (FRAME_OFFSET_DATA + i);
            _byte_stream[crc_mark++] = (byte)((_CRC16 & 0xFF00) >> 8);
            _byte_stream[crc_mark++] = (byte) (_CRC16 & 0x00FF);
            _byte_stream[crc_mark] = END_OF_FRAME;

            return (true);
        }

        public bool ValidateFrame(byte[] data)
        {
            ushort _dlen = 0;
            ushort _cid = 0;

            try
            {
                // Validation succeeds when first byte is START_OF_FRAME, last byte is END_OF_FRAME and CRC16 matches.
                if ((data[0] == START_OF_FRAME) && (data[data.GetUpperBound(0)] == END_OF_FRAME))
                {
                    ushort crc_len = 0, crc = 0, crc_in = 0;

                    crc_len = (ushort)((((int)data[3] << 8) | (int)data[4]) + FRAME_OFFSET_DATA);
                    _cid = (ushort)((((int)data[1] << 8) | (int)data[2]));

                    // Check CRC only in frames with IDs >0x000F
                    if (_cid > FRAME_CRC_BYPASS_CID) { 
                        crc = GetCRC16(data, 0, (int)crc_len);
                    }

                    crc_in = ((ushort)(((int)data[data.Length - 3] << 8) | (int)data[data.Length - 2]));

                    if (crc == crc_in) {
                        _dlen = (ushort)(((int)data[3] << 8) | (int)data[4]);
                    }
                    else
                    { return (false); }
                }
                else
                { return (false); }
            }
            catch { return (false); }

            return (true);

        }

        public UInt16 GetCRC16(byte[] data, int start, int data_len)
        {
            int _i, _j;
            int crc_result = 0;

            for (_i = start; _i < data_len; _i++)
            {
                crc_result ^= (Int16)data[_i];
                for (_j = 0; _j < 8; ++_j)
                {
                    if ((crc_result & 1) == 1)
                        crc_result = (crc_result >> 1) ^ 0xA001;
                    else
                        crc_result = (crc_result >> 1);
                }
            }

            return ((UInt16)crc_result);

        }

    }

    // ********************************************************************************************

    class smpsDebugUARTParser 
    {

        private int _FrameBufferSize = 32;
        public int FrameBufferSize               // size of data frame buffer
        {
            get { return _FrameBufferSize; }
            set { _FrameBufferSize = value; }
        }

        private long _crc_error_count = 0;
        public long CRCErrorCount                  // number of data frame errors received
        {
            get { return _crc_error_count; }
            set { _crc_error_count = value; return; }
        }

        private long _frame_count = 0;
        public long FrameCount                  // number of data frames received
        {
            get { return _frame_count; }
            set { _frame_count = value; return; }
        }

        private long _frames_used = 0;
        public long FramesUsed
        {
            get { return _frames_used; }
        }

        private smpsDebugUARTFrame[] _frames;
        public smpsDebugUARTFrame[] Frames
        {
            get { return _frames; }
            set { _frames = value; return; }
        }

        public bool AddRxFrameToBuffer(byte[] _frame_data)
        {

            if (_frames == null)
            { // No Frame has been defined yet...
                Array.Resize<smpsDebugUARTFrame>(ref _frames, 1);
            }
            else if (_frames.Length < _FrameBufferSize)
            { // Frame buffer is filled up to maximum
                Array.Resize<smpsDebugUARTFrame>(ref _frames, (_frames.Length + 1));
            }
            else
            { // All n frames have been created => destroy oldest one and move 
              // all frames one index down
                Array.Copy(_frames, 1, _frames, 0, (int)(_frames.Length - 1));
            }

            // Write data to newly added frame
            _frames[_frames.GetUpperBound(0)] = new smpsDebugUARTFrame();
            _frames[_frames.GetUpperBound(0)].ByteStream = _frame_data;
            if (_frames[_frames.GetUpperBound(0)].IsComplete)
            {
                _frame_count++;
                _frames[_frames.GetUpperBound(0)].ReceiveTimeStamp = DateTime.Now.Ticks;
            }
            else
            {
                _crc_error_count++;
                if (_frames.Length == 1)
                { _frames = null; }
                else
                { Array.Resize<smpsDebugUARTFrame>(ref _frames, (_frames.Length - 1)); }
            }

            if (_frames != null)
                _frames_used = _frames.Length;
            else
                _frames_used = 0;

            return(_frames[_frames.GetUpperBound(0)].IsComplete);

        }

        public smpsDebugUARTFrame BuildFrame(ushort CID, byte[] data)
        {

            smpsDebugUARTFrame _frame = new smpsDebugUARTFrame();

            _frame.SOF = smpsDebugUARTFrame.START_OF_FRAME;     // Set SOF = 0x55
            _frame.CID = CID;                  // Set CID
            _frame.DLEN = (ushort)data.Length; // Set data length
            _frame.DATA = data;              // Load data array
            if (CID > smpsDebugUARTFrame.FRAME_CRC_BYPASS_CID)
            { // Message frames with IDs greater than #15 need to have a checksum calculated across SOF to end of DATA
                _frame.CRC16 = _frame.GetCRC16(_frame.ByteStream, 0, (_frame.DLEN + smpsDebugUARTFrame.FRAME_OFFSET_DATA)); // Set calculated CRC 
            }
            else
            { // With message frames with IDs less or euqual #15 ignore the CRC
                _frame.CRC16 = 0x0000;
            }
            _frame.EOF = smpsDebugUARTFrame.END_OF_FRAME;       // Set EOF = 0x0D

            return (_frame);
        }

        public bool ResetRxFrameBuffer()
        {
            _frames = null;
            _crc_error_count = 0;
            _frame_count = 0;
            _frames_used = 0;
            return (true);
        }

    }

    // ********************************************************************************************

    class smpsDebugUARTBuffer
    {
        private const int DEFAULT_BUFFER_SIZE = 256;

        private byte[] _rx_fifo_capture_buffer; // = new byte[0];
        public byte[] RxFIFOCaptureBuffer
        {
            get { return _rx_fifo_capture_buffer; }
            set { _rx_fifo_capture_buffer = value; return; }
        }

        private int _buffer_size = DEFAULT_BUFFER_SIZE;
        public int BufferSize
        {
            get { return _buffer_size; }
            set { 
                _buffer_size = value;
                Array.Resize<byte>(ref _buffer, _buffer_size);
                return; 
            }
        }

        private bool _suspend_receive = false;
        public bool SuspendReceive
        {
            get { return (_suspend_receive); }
            set { _suspend_receive = value; return; }
        }

        private byte[] _buffer = new byte[DEFAULT_BUFFER_SIZE];
        public byte[] Buffer
        {
            get { return _buffer; }
            set { _buffer = value; return; }
        }

        private bool _frame_sync = false;
        public bool FrameSync
        {
            get { return _frame_sync; }
            set { _frame_sync = value; return; }
        }

        private int _frame_dlen = 0;
        public int FrameDLEN
        {
            get { return _frame_dlen; }
            set { _frame_dlen = value; return; }
        }

        private long _frame_sync_error_count = 0;
        public long FrameSyncErrorCount
        {
            get { return _frame_sync_error_count; }
            set { _frame_sync_error_count = value; return; }
        }

        private int _buffer_pointer = 0;
        public int BufferPointer
        {
            get { return _buffer_pointer; }
            set { _buffer_pointer = value; return; }
        }

    }

    // ********************************************************************************************

    class smpsDebugUARTStatistics
    {
        private long _last_package_count = 0;
        private long _recent_package_count = 0;
        private long _data_package_count = 0;
        public long DataPackageCount
        {
            get { return _data_package_count; }
            set {
                _last_package_count = _recent_package_count;
                _recent_package_count = value;
                _data_package_count = value; 
                return; 
            }
        }

        private long _data_package_length = 0;
        public long DataPackageLength
        {
            get { return _data_package_length; }
            set {
                if (value < _data_package_length_min)
                    _data_package_length_min = value;
                if (value > _data_package_length_max) 
                    _data_package_length_max = value;
                _data_package_length = value; 
                return; }
        }

//        private byte _avg_counter = 0;
//        private long _interval_average = 0;
        private long _last_time_stamp = 0;
        private long _recent_time_stamp = 0;
        private long _receive_interval = 0;
        public long ReceiveInterval
        {
            get { return _receive_interval; }
            set {
                
                _last_time_stamp = _recent_time_stamp;
                _recent_time_stamp = value;

                if ((_last_time_stamp > 0) && (_last_time_stamp != _recent_time_stamp) && (_data_package_count > 0))
                { 
                    _receive_interval = (_recent_time_stamp - _last_time_stamp);
                }


                return; 
            }
        }

        private long _data_package_length_min = long.MaxValue;
        public long DataPackageLenMinimum
        {
            get { return _data_package_length_min; }
//            set { _data_package_length_min = value; return; }
        }

        private long _data_package_length_max = 0;
        public long DataPackageLenMaximum
        {
            get { return _data_package_length_max; }
//            set { _data_package_length_max = value; return; }
        }

        private long _data_stream_errors = 0;
        public long DataStreamErrors
        {
            get { return _data_stream_errors; }
            set { _data_stream_errors = value; return; }
        }

        public void ResetDataStatistics()
        {
            _data_package_count = 0;
            _data_package_length = 0;
            _data_package_length_min = long.MaxValue;
            _data_package_length_max = 0;
            _data_stream_errors = 0;

            return;
        }

    }
}
