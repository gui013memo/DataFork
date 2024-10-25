using myLogger;
using System.IO.Ports;
using System.Text;

namespace DataFork
{
    public partial class SerialDataFork : Form
    {

        SerialPort receivingSerialPort;
        SerialPort sendingToTMSSerialPort;
        SerialPort sendingToSQSSerialPort;

        Logger logger;

        string WantedData = string.Empty;

        bool bSTX = false;
        bool bETX = false;
        StringBuilder sb = new StringBuilder();

        public SerialDataFork()
        {
            InitializeComponent();

            logger = new Logger();

            receivingSerialPort = new SerialPort
            {
                PortName = "COM3",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            sendingToTMSSerialPort = new SerialPort
            {
                PortName = "COM10", //OUTPUT = COM11
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            sendingToSQSSerialPort = new SerialPort
            {
                PortName = "COM12", //OUTPUT COM13
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None
            };

            ConnectSerialPorts();
        }

        private void ConnectSerialPorts()
        {
            string errorMessage = string.Empty;
            int connections = 0;

            try
            {
                if (!receivingSerialPort.IsOpen)
                {
                    receivingSerialPort.Open();
                    receivingSerialPort.DataReceived += ReceivingSerialPort_DataReceived; // Subscribe to DataReceived event
                    logger.Log("Serial port " + receivingSerialPort.PortName + " opened with buffer size: " + receivingSerialPort.ReadBufferSize);
                    connectionStateCOM3.BackColor = Color.ForestGreen;
                    connections++;
                }
                else
                {
                    errorMessage = "receivingSerialPort [" + receivingSerialPort.PortName + "] is already in use";
                    logger.Log(errorMessage);
                    MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connectionStateCOM3.BackColor = Color.Red;
                }

                if (!sendingToTMSSerialPort.IsOpen)
                {
                    sendingToTMSSerialPort.Open();
                    logger.Log("Serial port " + sendingToTMSSerialPort.PortName + " opened with buffer size: " + sendingToTMSSerialPort.WriteBufferSize);
                    connectionStateCOM10.BackColor = Color.ForestGreen;
                    connections++;
                }
                else
                {
                    errorMessage = "sendingToTMSSerialPort [" + sendingToTMSSerialPort.PortName + "] is already in use";
                    logger.Log(errorMessage);
                    MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connectionStateCOM3.BackColor = Color.Red;
                }

                if (!sendingToSQSSerialPort.IsOpen)
                {
                    sendingToSQSSerialPort.Open();
                    logger.Log("Serial port " + sendingToSQSSerialPort.PortName + " opened with buffer size: " + sendingToSQSSerialPort.WriteBufferSize);
                    connectionStateCOM12.BackColor = Color.ForestGreen;
                    connections++;
                }
                else
                {
                    errorMessage = "sendingToSQSSerialPort [" + sendingToSQSSerialPort.PortName + "] is already in use";
                    logger.Log(errorMessage);
                    MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connectionStateCOM12.BackColor = Color.Red;

                }
            }
            catch (Exception exc)
            {
                errorMessage = "Error on opening the COM ports - ERROR MESSAGE: \r\n" + exc.Message;
                logger.Log(errorMessage);
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (connections == 3)
            {
                connectButton.Enabled = false;
                connectButton.BackColor = Color.DarkOliveGreen;
            }
            else
            {
                connectButton.Enabled = true;
                connectButton.BackColor = Color.Gray;
            }
        }

        private void ReceivingSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            

            try
            {
                // Read the incoming data
                string rawDataFromScanner = receivingSerialPort.ReadExisting();

                logger.Log("RawData: " + rawDataFromScanner);

                foreach (char c in rawDataFromScanner)
                {
                    if (c == Convert.ToChar(0x02))
                    {
                        bSTX = true;
                    }
                    if (c == Convert.ToChar(0x03))
                    {
                        bETX = true;
                    }

                    if (bSTX || bETX)
                    {
                        sb.Append(c);
                    }
                    if (bSTX && bETX)
                    {
                        WantedData = sb.ToString();

                        sb.Clear();

                        this.Invoke((MethodInvoker)delegate
                        {
                            lastReadingsTextBox.Text += WantedData + "\r\n";
                        });

                        logger.Log("Data received from " + receivingSerialPort.PortName + ": " + WantedData);

                        ProcessBarcode(WantedData);
                        bSTX = false;
                        bETX = false;
                    }


                }


            }
            catch (Exception exc)
            {
                string errorMessage = "Error on receving/sending data - ERROR MESSAGE: \r\n" + exc.Message;
                logger.Log(errorMessage);
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessBarcode(string WantedData)
        {
            bool isTMSData = false;

            // Send the data to TMS 
            if (sendingToTMSSerialPort.IsOpen &&
                (WantedData.Contains("LEFTT") || WantedData.Contains("RIGHT") ||
                (WantedData.Length == 45 && WantedData.Contains("B1B2"))))
            {
                sendingToTMSSerialPort.Write(WantedData);
                logger.Log("Data sent to TMS on " + sendingToTMSSerialPort.PortName + ": " + WantedData);
                isTMSData = true;

                this.Invoke((MethodInvoker)delegate
                {
                    sentToTMSTextBox.Text += WantedData + "\r\n";
                });
            }

            // Send the data to SQS
            if (sendingToSQSSerialPort.IsOpen && !isTMSData)
            {
                sendingToSQSSerialPort.Write(WantedData);

                logger.Log("Data sent to SQS on " + sendingToSQSSerialPort.PortName + ": " + WantedData);
                this.Invoke((MethodInvoker)delegate
                {
                    sentToSQSTextBox.Text += WantedData + "\r\n";
                });
            }

            isTMSData = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lastReadingsTextBox.Text = string.Empty;
            sentToTMSTextBox.Text = string.Empty;
            sentToSQSTextBox.Text = string.Empty;

            logger.Log("DataFork opened");
        }
    }
}
