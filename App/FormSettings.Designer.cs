namespace SerialMonitor
{
    partial class FormSettings
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
            groupBox1 = new GroupBox();
            TerminalPreviewGroup = new GroupBox();
            TerminalPreview = new RichTextBox();
            TerminalFontLink = new LinkLabel();
            label3 = new Label();
            TerminalFontColorPreview = new Label();
            TerminalBGColorPreview = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            groupBox1.SuspendLayout();
            TerminalPreviewGroup.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TerminalPreviewGroup);
            groupBox1.Controls.Add(TerminalFontLink);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TerminalFontColorPreview);
            groupBox1.Controls.Add(TerminalBGColorPreview);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 177);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Terminal Display";
            // 
            // TerminalPreviewGroup
            // 
            TerminalPreviewGroup.Controls.Add(TerminalPreview);
            TerminalPreviewGroup.Location = new Point(219, 22);
            TerminalPreviewGroup.Name = "TerminalPreviewGroup";
            TerminalPreviewGroup.Size = new Size(200, 149);
            TerminalPreviewGroup.TabIndex = 8;
            TerminalPreviewGroup.TabStop = false;
            TerminalPreviewGroup.Text = "Preview";
            // 
            // TerminalPreview
            // 
            TerminalPreview.BorderStyle = BorderStyle.FixedSingle;
            TerminalPreview.Dock = DockStyle.Fill;
            TerminalPreview.Location = new Point(3, 19);
            TerminalPreview.Name = "TerminalPreview";
            TerminalPreview.Size = new Size(194, 127);
            TerminalPreview.TabIndex = 0;
            TerminalPreview.Text = "> Log text \n> Some more text\n> SOME CAPS TEXT\n> 0123456789\n> ~`!@#$%^&*()_+-\n> =?,./:\"<>;'{}[]|\\";
            // 
            // TerminalFontLink
            // 
            TerminalFontLink.AutoSize = true;
            TerminalFontLink.Location = new Point(123, 68);
            TerminalFontLink.Name = "TerminalFontLink";
            TerminalFontLink.Size = new Size(25, 15);
            TerminalFontLink.TabIndex = 7;
            TerminalFontLink.TabStop = true;
            TerminalFontLink.Text = "n/a";
            TerminalFontLink.LinkClicked += TerminalFontLink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 68);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 6;
            label3.Text = "Font:";
            // 
            // TerminalFontColorPreview
            // 
            TerminalFontColorPreview.BackColor = Color.Red;
            TerminalFontColorPreview.Location = new Point(123, 47);
            TerminalFontColorPreview.Name = "TerminalFontColorPreview";
            TerminalFontColorPreview.Size = new Size(50, 15);
            TerminalFontColorPreview.TabIndex = 5;
            TerminalFontColorPreview.Click += TerminalFontColorPreview_Click;
            // 
            // TerminalBGColorPreview
            // 
            TerminalBGColorPreview.BackColor = Color.Red;
            TerminalBGColorPreview.Location = new Point(123, 26);
            TerminalBGColorPreview.Name = "TerminalBGColorPreview";
            TerminalBGColorPreview.Size = new Size(50, 15);
            TerminalBGColorPreview.TabIndex = 3;
            TerminalBGColorPreview.Click += TerminalBGColorPreview_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 47);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Font Color:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 26);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Background Color:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(281, 195);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 1;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(362, 195);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 226);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormSettings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            TerminalPreviewGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label TerminalBGColorPreview;
        private Label TerminalFontColorPreview;
        private Button SaveButton;
        private Button CancelButton;
        private LinkLabel TerminalFontLink;
        private Label label3;
        private GroupBox TerminalPreviewGroup;
        private RichTextBox TerminalPreview;
    }
}