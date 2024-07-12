using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SerialMonitor
{
    public partial class FormSettings : Form
    {
        public Color TerminalBGColor { get; set; }
        public Color TerminalFontColor { get; set; }
        public Font TerminalFont { get; set; }

        public FormSettings()
        {
            InitializeComponent();
            Shown += FormSettings_Shown;
        }

        private void TerminalBGColorPreview_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new()
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = TerminalBGColor
            };

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                TerminalBGColor = colorDlg.Color;
                UpdatePreviews();
            }
        }

        private void TerminalFontColorPreview_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new()
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = TerminalFontColor
            };

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                TerminalFontColor = colorDlg.Color;
                UpdatePreviews();
            }
        }

        private void TerminalFontLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontDialog fontDlg = new()
            {
                FontMustExist = true,
                FixedPitchOnly = true,
                ShowEffects = false,
                AllowScriptChange = false,
                Font = TerminalFont
            };

            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                TerminalFontLink.Text = fontDlg.Font.Name;
                TerminalFont = fontDlg.Font;
                UpdatePreviews();
            }
        }

        private void FormSettings_Shown(object? sender, EventArgs e)
        {
            UpdatePreviews();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Updates all preview objects with current property values.
        /// </summary>
        private void UpdatePreviews()
        {
            TerminalPreview.BackColor = TerminalBGColor;
            TerminalPreview.Font = TerminalFont;
            TerminalPreview.ForeColor = TerminalFontColor;
            TerminalBGColorPreview.BackColor = TerminalBGColor;
            TerminalFontColorPreview.BackColor = TerminalFontColor;
            TerminalFontLink.Text = TerminalFont.Name;
        }
    }
}
