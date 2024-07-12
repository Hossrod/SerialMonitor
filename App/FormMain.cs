using SerialMonitor.Properties;
using System.IO.Ports;
using System.Xml.Serialization;

namespace SerialMonitor
{
    public partial class FormMain : Form
    {
        private SerialPort serialPort;
        private AppSettings appSettings;

        /// <summary>
        /// Initializes a new instance of the FormMain class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            comPortSelection.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comPortSelection.Items.AddRange(ports);

            comPortSelection.SelectedIndex = 0;
            baudSelection.SelectedIndex = 6;

            // Default settings
            appSettings = new()
            {
                LastUsedCOMPort = "",
                LastUsedBaudRate = "",
                MonitorBackColor = Color.White,
                MonitorFontColor = Color.Black,
                MonitorFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular)
            };

            LoadSettings();

            UpdateMonitorAppearance();
        }

        /// <summary>
        /// Handles the DataReceived event of the SerialPort object.
        /// </summary>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                //string receivedData = serialPort.ReadExisting(); // Read data from the serial port
                string receivedData = serialPort.ReadLine(); // Read data from the serial port
                
                // Update the UI (e.g., append receivedData to a RichTextBox)
                AppendLineToMonitor(receivedData);
            }
        }

        /// <summary>
        /// Processes/formats the provided line of text to append to the end of the monitor.
        /// </summary>
        /// <param name="lineOfText">The line of text to append.</param>
        private void AppendLineToMonitor(string lineOfText)
        {
            if (InvokeRequired)
            {
                // Invoke on the UI thread
                Invoke(new Action<string>(AppendLineToMonitor), lineOfText);
            }
            else
            {
                string formattedText = DateTime.Now.ToString("M/d/yy h:mm:ss tt > ") + lineOfText.Trim();

                List<FormatRule> rules = new()
                {
                    new FormatRule("error", Color.Red),
                    new FormatRule("Temperature = ", Color.Cyan),
                    new FormatRule(" > ", Color.Yellow),
                    new FormatRule("ChipChop =>", Color.DarkGray),
                    new FormatRule("ChipChop => Keep Alive =>", Color.Red)
                };

                AppendFormattedText(monitorOutput, formattedText, rules);

                monitorOutput.AppendText(Environment.NewLine);
                monitorOutput.SelectionStart = monitorOutput.TextLength;
                monitorOutput.ScrollToCaret();

                bytesStatusLabel.Text = Helpers.ConvertBytesToHumanReadable(monitorOutput.TextLength) + " received.";
            }
        }

        /// <summary>
        /// Appends formated text (based on the provided rules) to the specified RTB.
        /// </summary>
        /// <param name="rtb">The RichTextBox to append the text to.</param>
        /// <param name="text">The text to append.</param>
        /// <param name="rules">A list of rules to process formatting.</param>
        static void AppendFormattedText(RichTextBox rtb, string text, List<FormatRule> rules)
        {
            // Save the current selection start and length
            int selectionStart = rtb.TextLength;
            int selectionLength = 0;

            // Append the line of text to the RichTextBox
            rtb.AppendText(text);

            // Set the selection start and length to the end of the text
            rtb.Select(selectionStart, selectionLength);

            // Loop through each search term-color pair
            foreach (var rule in rules)
            {
                string searchTerm = rule.SearchTerm;
                Color termColor = rule.TermColor;

                // Find the start index of the current search term
                int startIndex = text.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);

                while (startIndex != -1)
                {
                    // Set the selection start and length for the current search term
                    rtb.Select(selectionStart + startIndex, searchTerm.Length);
                    rtb.SelectionColor = termColor;

                    // Move the starting index to the character after the current search term
                    startIndex = text.IndexOf(searchTerm, startIndex + 1, StringComparison.OrdinalIgnoreCase);
                }
            }

            // Reset the selection color to the default
            rtb.Select(selectionStart + text.Length, 0);
            rtb.SelectionColor = rtb.ForeColor;
        }

        /// <summary>
        /// Loads the application settings from a file.
        /// </summary>
        private void LoadSettings()
        {
            // Load settings from a file (e.g., XML)
            try
            {
                var serializer = new XmlSerializer(typeof(AppSettings));
                using (var reader = new StreamReader("settings.xml"))
                {
                    try
                    {
                        var settings = (AppSettings)serializer.Deserialize(reader);
                        appSettings.MonitorBackColor = settings.MonitorBackColor;
                        appSettings.MonitorFontColor = settings.MonitorFontColor;
                        appSettings.MonitorFont = settings.MonitorFont;
                        appSettings.LastUsedCOMPort = settings.LastUsedCOMPort;
                        appSettings.LastUsedBaudRate = settings.LastUsedBaudRate;
                    }
                    catch
                    {
                        // Do nothing
                    }

                    UpdateMonitorAppearance();
                }
            }
            catch (FileNotFoundException)
            {
                // Do nothing, defaults will be used.
            }
        }

        /// <summary>
        /// Saves the application settings to a file.
        /// </summary>
        private void SaveSettings()
        {
            var serializer = new XmlSerializer(typeof(AppSettings));
            using (var writer = new StreamWriter("settings.xml"))
            {
                serializer.Serialize(writer, appSettings);
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up: close the serial port when the form is closing
            serialPort.Close();
        }

        /// <summary>
        /// Represents the application settings for the SerialMonitor application.
        /// This class is serializable, allowing the settings to be easily saved and loaded.
        /// </summary>
        [Serializable]
        public class AppSettings
        {
            public string MonitorBackColorHTML { get; set; }
            public string MonitorFontColorHTML { get; set; }
            public string LastUsedCOMPort { get; set; }
            public string LastUsedBaudRate { get; set; }
            public float MonitorFontSize { get; set; }
            public string MonitorFontName { get; set; }
            public FontStyle MonitorFontStyle { get; set; }

            [XmlIgnore]
            public Color MonitorBackColor
            {
                get => HtmlToColor(MonitorBackColorHTML);
                set => MonitorBackColorHTML = ColorToHtml(value);
            }

            [XmlIgnore]
            public Color MonitorFontColor
            {
                get => HtmlToColor(MonitorFontColorHTML);
                set => MonitorFontColorHTML = ColorToHtml(value);
            }

            [XmlIgnore]
            public Font MonitorFont
            {
                get
                {
                    return new Font(MonitorFontName, MonitorFontSize, MonitorFontStyle);
                }
                set
                {
                    MonitorFontName = value.Name;
                    MonitorFontSize = value.Size;
                    MonitorFontStyle = value.Style;
                }
            }

            /// <summary>
            /// Converts an HTML color string to a Color object.
            /// </summary>
            private static Color HtmlToColor(string htmlColor)
            {
                return ColorTranslator.FromHtml(htmlColor);
            }

            /// <summary>
            /// Converts a Color object to an HTML color string.
            /// </summary>
            private static string ColorToHtml(Color color)
            {
                return ColorTranslator.ToHtml(color);
            }
        }

        /// <summary>
        /// Handles the Click event of the settingsButton object.
        /// </summary>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            FormSettings settingsForm = new()
            {
                TerminalBGColor = appSettings.MonitorBackColor,
                TerminalFontColor = appSettings.MonitorFontColor,
                TerminalFont = appSettings.MonitorFont
            };
            var result = settingsForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                appSettings.MonitorBackColor = settingsForm.TerminalBGColor;
                appSettings.MonitorFontColor = settingsForm.TerminalFontColor;
                appSettings.MonitorFont = settingsForm.TerminalFont;
                UpdateMonitorAppearance();
                SaveSettings();
                settingsForm.Close();
            }
        }

        /// <summary>
        /// Updates the monitor's appearance using current property values.
        /// </summary>
        private void UpdateMonitorAppearance()
        {
            monitorOutput.BackColor = appSettings.MonitorBackColor;
            monitorOutput.ForeColor = appSettings.MonitorFontColor;
            monitorOutput.Font = appSettings.MonitorFont;
        }

        /// <summary>
        /// Handles the Connect/Disconnect button being clicked.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                DiconnectSerialPort();

            }
            else
            {
                ConnectSerialPort();

            }
        }

        /// <summary>
        /// Connects the serial port and updates any applicable UI.
        /// </summary>
        private void ConnectSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived; // Register event handler
            serialPort.BaudRate = int.Parse(baudSelection.Text); // Set your desired baud rate
            serialPort.PortName = comPortSelection.Text; // Set the correct COM port name
            try
            {
                serialPort.Open(); // Open the serial port
                baudSelection.Enabled = false;
                comPortSelection.Enabled = false;
                connectionStatusLabel.Text = "Connected to " + serialPort.PortName + " (" + serialPort.BaudRate + " baud) @ " + DateTime.Now.ToString();
                connectButton.Image = Resources.connect;
                connectButton.ToolTipText = "Click to disconnect...";
                connectButton.BackColor = Color.MediumSeaGreen;
                bytesStatusLabel.Text = "0/0";
                bytesStatusLabel.Visible = true;
            }
            catch (Exception ex)
            {
                connectionStatusLabel.Text = "Could not connect... " + ex.Message;
            }
        }

        /// <summary>
        /// Disconnects the serial port and updates any applicable UI.
        /// </summary>
        private void DiconnectSerialPort()
        {
            serialPort.Close();
            connectionStatusLabel.Text = "Disconnected @ " + DateTime.Now.ToString();
            baudSelection.Enabled = true;
            comPortSelection.Enabled = true;
            connectButton.Image = Resources.disconnect;
            connectButton.ToolTipText = "Click to connect...";
            connectButton.BackColor = SystemColors.Control;
            bytesStatusLabel.Visible = false;
        }

        /// <summary>
        /// Handles any tasks needed when the main form is closing.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DiconnectSerialPort();
        }

        /// <summary>
        /// Handles any tasks needed when the COM port drop down is clicked.
        /// </summary>
        /// <param name="sender">Object that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void comPortSelection_DropDown(object sender, EventArgs e)
        {
            comPortSelection.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comPortSelection.Items.AddRange(ports);
            comPortSelection.SelectedIndex = 0;
        }

        private void clearMonitorButton_Click(object sender, EventArgs e)
        {
            monitorOutput.Clear();
        }
    }

    /// <summary>
    /// A rule for formatting text based on a search term. 
    /// </summary>
    class FormatRule
    {
        public string SearchTerm { get; }
        public Color TermColor { get; }
        public bool CaseSensitive { get; }

        public FormatRule(string searchTerm, Color termColor, bool caseSensitive) : this(searchTerm, termColor)
        {
            CaseSensitive = caseSensitive;
        }

        public FormatRule(string searchTerm, Color termColor)
        {
            SearchTerm = searchTerm;
            TermColor = termColor;
        }
    }
}