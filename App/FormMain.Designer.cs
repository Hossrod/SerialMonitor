namespace SerialMonitor
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            monitorOutput = new RichTextBox();
            statusStrip1 = new StatusStrip();
            connectionStatusLabel = new ToolStripStatusLabel();
            bytesStatusLabel = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            comPortSelection = new ToolStripComboBox();
            baudSelection = new ToolStripComboBox();
            connectButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            saveMonitorToFileButton = new ToolStripButton();
            clearMonitorButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            settingsButton = new ToolStripButton();
            helpButton = new ToolStripButton();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // monitorOutput
            // 
            monitorOutput.BackColor = Color.White;
            monitorOutput.Dock = DockStyle.Fill;
            monitorOutput.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            monitorOutput.Location = new Point(0, 25);
            monitorOutput.Name = "monitorOutput";
            monitorOutput.ReadOnly = true;
            monitorOutput.Size = new Size(1104, 796);
            monitorOutput.TabIndex = 0;
            monitorOutput.Text = "";
            monitorOutput.WordWrap = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { connectionStatusLabel, toolStripStatusLabel1, bytesStatusLabel });
            statusStrip1.Location = new Point(0, 821);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1104, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new Size(455, 17);
            connectionStatusLabel.Text = "Not connected. Select COM port and baud rate and click Connect button to connect.";
            // 
            // bytesStatusLabel
            // 
            bytesStatusLabel.Name = "bytesStatusLabel";
            bytesStatusLabel.Size = new Size(94, 17);
            bytesStatusLabel.Text = "0 bytes received.";
            bytesStatusLabel.ToolTipText = "Total bytes received since connection.";
            bytesStatusLabel.Visible = false;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { comPortSelection, baudSelection, connectButton, toolStripSeparator1, saveMonitorToFileButton, clearMonitorButton, toolStripSeparator2, settingsButton, helpButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1104, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // comPortSelection
            // 
            comPortSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comPortSelection.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20" });
            comPortSelection.MaxDropDownItems = 10;
            comPortSelection.Name = "comPortSelection";
            comPortSelection.Size = new Size(100, 25);
            comPortSelection.ToolTipText = "COM Port";
            comPortSelection.DropDown += comPortSelection_DropDown;
            // 
            // baudSelection
            // 
            baudSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            baudSelection.Items.AddRange(new object[] { "1200", "2400", "4800", "9600", "19200", "57600", "115200" });
            baudSelection.Name = "baudSelection";
            baudSelection.Size = new Size(100, 25);
            baudSelection.ToolTipText = "Baud Rate";
            // 
            // connectButton
            // 
            connectButton.BackColor = SystemColors.Control;
            connectButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            connectButton.Image = Properties.Resources.disconnect;
            connectButton.ImageTransparentColor = Color.Magenta;
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(23, 22);
            connectButton.Text = "toolStripButton1";
            connectButton.ToolTipText = "Click to connect...";
            connectButton.Click += connectButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // saveMonitorToFileButton
            // 
            saveMonitorToFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveMonitorToFileButton.Image = Properties.Resources.disk;
            saveMonitorToFileButton.ImageTransparentColor = Color.Magenta;
            saveMonitorToFileButton.Name = "saveMonitorToFileButton";
            saveMonitorToFileButton.Size = new Size(23, 22);
            saveMonitorToFileButton.ToolTipText = "Save monitor contents to file.";
            // 
            // clearMonitorButton
            // 
            clearMonitorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            clearMonitorButton.Image = Properties.Resources.table_delete;
            clearMonitorButton.ImageTransparentColor = Color.Magenta;
            clearMonitorButton.Name = "clearMonitorButton";
            clearMonitorButton.Size = new Size(23, 22);
            clearMonitorButton.ToolTipText = "Clear monitor contents.";
            clearMonitorButton.Click += clearMonitorButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // settingsButton
            // 
            settingsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            settingsButton.Image = Properties.Resources.cog;
            settingsButton.ImageTransparentColor = Color.Magenta;
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(23, 22);
            settingsButton.Text = "toolStripButton2";
            settingsButton.ToolTipText = "Settings";
            settingsButton.Click += settingsButton_Click;
            // 
            // helpButton
            // 
            helpButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpButton.Image = Properties.Resources.help;
            helpButton.ImageTransparentColor = Color.Magenta;
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(23, 22);
            helpButton.Text = "toolStripButton3";
            helpButton.ToolTipText = "Help/About";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(10, 17);
            toolStripStatusLabel1.Text = "|";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 843);
            Controls.Add(monitorOutput);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "HossMon";
            FormClosing += FormMain_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox monitorOutput;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel connectionStatusLabel;
        private ToolStrip toolStrip1;
        private ToolStripComboBox comPortSelection;
        private ToolStripComboBox baudSelection;
        private ToolStripButton connectButton;
        private ToolStripButton settingsButton;
        private ToolStripButton helpButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton clearMonitorButton;
        private ToolStripButton saveMonitorToFileButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripStatusLabel bytesStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}