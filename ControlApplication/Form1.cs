using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlApplication
{
    enum ConnectionState
    {
        CONNECTING,
        CONNECTED,
        DISCONNECTING,
        DISCONNECTED
    }

    enum ExecutionStatus
    {
        IDLE,
        EXECUTING,
        RESPONSE_RECEIVED
    }

    enum MotorStatus
    {
        HAS_NOT_MOVED,
        HAS_MOVED
    }

    struct SerialCommandResponse
    {
        public string command;
        public bool success;
        public string data;
    }
    public partial class Form1 : Form
    {
        private ConnectionState connectionState = ConnectionState.DISCONNECTED;

        static SerialPort _serialPort;

        bool _continue = false;
        ExecutionStatus executionStatus = ExecutionStatus.IDLE;
        SerialCommandResponse globalCommandResponse;

        private MotorStatus motorStatus = MotorStatus.HAS_NOT_MOVED;
        int motorPosition = 0; //micrometers

        string outputFilePath = @".\Output.csv";

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(outputFilePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(outputFilePath))
                {
                    sw.WriteLine("x,u");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Read available COM ports and populate the dropdown
            string[] ports = SerialPort.GetPortNames();
            List<string> portList = new List<string>();
            foreach (string port in ports)
            {
                portList.Add(port);
            }

            //If no ports are available, show it
            if (portList.Count == 0)
            {
                comPortDropdown.Enabled = false;
                connectButton.Enabled = false;
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "No COM ports available";
            }
            else
            {
                comPortDropdown.DataSource = new BindingSource(portList, null);
                comPortDropdown.SelectedIndex = 0;
            }

            //Populate the baud rate dropdown
            List<int> baudList = new List<int> { 9600, 19200, 38400, 57600, 115200 };
            baudDropdown.DataSource = new BindingSource(baudList, null);

            //Populate the voltage proble dropdown
            List<int> voltageProbeList = new List<int> {1, 2};
            voltageProbeDropdown.DataSource = new BindingSource(voltageProbeList, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if(connectionState == ConnectionState.DISCONNECTED)
            {
                //Display that connection is being established
                connectButton.Enabled = false;
                statusLabel.ForeColor = SystemColors.ControlText;
                statusLabel.Text = "Connecting...";
                connectionState = ConnectionState.CONNECTING;

                //Establish connection
                try
                {
                    _serialPort = new SerialPort();
                    _serialPort.PortName = comPortDropdown.SelectedValue.ToString();
                    _serialPort.BaudRate = Int32.Parse(baudDropdown.SelectedValue.ToString());
                    _serialPort.Open();

                    //Display that connection has been established
                    connectButton.Enabled = true;
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = "Connected";
                    connectionState = ConnectionState.CONNECTED;
                    connectButton.Text = "Disconnect";

                    //Set _continue to true, so that the serial port process can run
                    _continue = true;
                    ThreadPool.QueueUserWorkItem(o => mainSerial());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    statusLabel.Text = "Error: " + ex.Message;
                    connectionState = ConnectionState.DISCONNECTED;
                    connectButton.Enabled = true;
                    return;
                }

            } else if(connectionState == ConnectionState.CONNECTED)
            {
                //Set _continue to false, so that the serial port process can stop
                _continue = false;

                //Display that connection is being disconnected
                connectButton.Enabled = false;
                statusLabel.ForeColor = SystemColors.ControlText;
                statusLabel.Text = "Disconnecting...";
                connectionState = ConnectionState.DISCONNECTING;

                //Disconnect
                _serialPort.Close();

                //Display that connection has been disconnected
                connectButton.Enabled = true;
                statusLabel.Text = "Disconnected";
                connectionState = ConnectionState.DISCONNECTED;
                connectButton.Text = "Connect";   
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            motorStatus = MotorStatus.HAS_MOVED;
            motorStartPositionInput.Enabled = false;
            motorStepLengthInput.Enabled = false;
            stepButton.Enabled = false;

            //Execute command on a different thread to avoid blocking the UI
            string motorStepLength = motorStepLengthInput.Text;
            string voltageProbe = voltageProbeDropdown.SelectedValue.ToString();
            ThreadPool.QueueUserWorkItem(o => {
                serialOutput.Invoke((MethodInvoker)delegate
                {
                    serialOutput.Text += "Moving motor by " + motorStepLength + " mm\n";
                });

                //Convert motor step length to number of steps for a motor
                //TODO: Do proper conversion
                int motorSteps = (int)(Double.Parse(motorStepLength) * 1000);

                //Move motor
                SerialCommandResponse motorResponse = executeCommandOverSerial("motor move " + motorSteps);
                //MessageBox.Show("Command: " + motorResponse.command + "\nSuccess: " + motorResponse.success + "\nData: " + motorResponse.data);

                serialOutput.Invoke((MethodInvoker)delegate
                {
                    serialOutput.Text += "Reading voltage from probe " + voltageProbe + "\n";
                });
                //Measure voltage
                SerialCommandResponse voltageResponse = executeCommandOverSerial("voltage get " + voltageProbe);
                //MessageBox.Show("Command: " + voltageResponse.command + "\nSuccess: " + voltageResponse.success + "\nData: " + voltageResponse.data);

                //Set step button to Enabled again
                stepButton.Invoke((MethodInvoker)delegate
                {
                    stepButton.Enabled = true;
                    stepButton.Focus();
                });

                //Update motor position
                if (motorResponse.success)
                {
                    motorPosition = motorPosition + (int)(Double.Parse(motorStepLengthInput.Text) * 1000);
                    motorPositionLabel.Invoke((MethodInvoker)delegate
                    {
                        motorPositionLabel.Text = ((double)motorPosition / 1000) + " mm";
                    });

                    using (StreamWriter sw = File.AppendText(outputFilePath))
                    {
                        sw.WriteLine(motorPosition + "," + voltageResponse.data);
                    }
                } else
                {
                    MessageBox.Show("Error: Motor did not move");
                }
            });
        }

        private void motorStartPositionInput_ValueChanged(object sender, EventArgs e)
        {
            if(motorStatus == MotorStatus.HAS_NOT_MOVED)
            {
                motorPosition = (int)(motorStartPositionInput.Value * 1000);
                motorPositionLabel.Text = ((double)motorPosition/1000) + " mm";
            }
        }

        private SerialCommandResponse executeCommandOverSerial(string command)
        {
            int numberOfDots = 0;
            if(executionStatus != ExecutionStatus.IDLE)
            {
                stepStatusLabel.Invoke((MethodInvoker)delegate
                {
                    stepStatusLabel.Text = "Device is not idle. Waiting...";
                });
            }

            while(executionStatus != ExecutionStatus.IDLE)
            {
                stepStatusLabel.Invoke((MethodInvoker)delegate
                {
                    string dots = new string('.', numberOfDots);
                    stepStatusLabel.Text = "Device is not idle. Waiting" + dots;
                    numberOfDots = (numberOfDots + 1) % 4;
                });
                Thread.Sleep(100);
            }

            executionStatus = ExecutionStatus.EXECUTING;
            globalCommandResponse.command = command;
            _serialPort.WriteLine(command);

            while (executionStatus != ExecutionStatus.RESPONSE_RECEIVED)
            {
                stepStatusLabel.Invoke((MethodInvoker)delegate
                {
                    string dots = new string('.', numberOfDots);
                    stepStatusLabel.Text = "Waiting for response" + dots;
                    numberOfDots = (numberOfDots + 1) % 4;
                });

                Thread.Sleep(100);
            }

            executionStatus = ExecutionStatus.IDLE;

            stepStatusLabel.Invoke((MethodInvoker)delegate
            {
                stepStatusLabel.Text = "-";
            });

            return globalCommandResponse;
        }

        private void mainSerial()
        {
            int responseState = 0;
            while (_continue)
            {
                //System.Diagnostics.Debug.WriteLine("Reading line"); ;
                try
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        string message = _serialPort.ReadLine();
                        if (message != "")
                        {
                            System.Diagnostics.Debug.WriteLine(message);

                            //Update the serial output textbox
                            serialOutput.Invoke((MethodInvoker)delegate
                            {
                                serialOutput.Text += message + "\n";
                            });

                            if(executionStatus == ExecutionStatus.EXECUTING)
                            {
                                if(message.Contains("Success: "))
                                {
                                    responseState = 1;
                                    string success = message.Substring(9, 1);
                                    globalCommandResponse.success = success == "1";
                                } else if(message.Contains("Data: "))
                                {
                                    if(responseState == 1)
                                    {
                                        globalCommandResponse.data = message.Replace("Data: ", "").Trim();
                                        executionStatus = ExecutionStatus.RESPONSE_RECEIVED;
                                        responseState = 0;
                                    } else
                                    {
                                        MessageBox.Show("Error: Unexpected response, check output terminal for more details");
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(50);
                } catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    if(_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }
                    connectionState = ConnectionState.DISCONNECTED;
                    connectButton.Invoke((MethodInvoker)delegate
                    {
                        connectButton.Text = "Connect";
                        connectButton.Enabled = true;
                    });
                    statusLabel.Invoke((MethodInvoker)delegate
                    {
                        statusLabel.Text = "Disconnected";
                        statusLabel.ForeColor = Color.Red;
                    });
                    break;
                }
            }
        }
    }
}
