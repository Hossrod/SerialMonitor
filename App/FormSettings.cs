namespace SerialMonitor
{
    public partial class FormSettings : Form
    {
        /// <summary>
        /// Gets or sets the background color of the terminal.
        /// </summary>
        public Color TerminalBGColor { get; set; }

        /// <summary>
        /// Gets or sets the font color of the terminal.
        /// </summary>
        public Color TerminalFontColor { get; set; }

        /// <summary>
        /// Gets or sets the font of the terminal.
        /// </summary>
        public Font TerminalFont { get; set; }

        /// <summary>
        /// Initializes a new instance of the FormSettings class.
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
            Shown += FormSettings_Shown;
        }

        /// <summary>
        /// Handles the click event of the TerminalBGColorPreview control.
        /// </summary>
        private void TerminalBGColorPreview_Click(object sender, EventArgs e)
        {
            TerminalBGColor = GetColorFromDialog(TerminalBGColor);
            UpdatePreviews();
        }

        /// <summary>
        /// Handles the click event of the TerminalFontColorPreview control.
        /// </summary>
        private void TerminalFontColorPreview_Click(object sender, EventArgs e)
        {
            TerminalFontColor = GetColorFromDialog(TerminalFontColor);
            UpdatePreviews();
        }

        /// <summary>
        /// Handles the LinkClicked event of the TerminalFontLink control.
        /// </summary>
        private void TerminalFontLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using FontDialog fontDlg = new()
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

        /// <summary>
        /// Handles the Shown event of the FormSettings form.
        /// </summary>
        private void FormSettings_Shown(object? sender, EventArgs e)
        {
            UpdatePreviews();
        }

        /// <summary>
        /// Handles the click event of the SaveButton control.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the CancelButton control.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Opens a color dialog and returns the selected color.
        /// </summary>
        /// <param name="currentColor">The initial color selected in the dialog.</param>
        /// <returns>The color selected by the user, or the initial color if the user cancels the dialog.</returns>
        private Color GetColorFromDialog(Color currentColor)
        {
            using ColorDialog colorDlg = new()
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = currentColor
            };
            return colorDlg.ShowDialog() == DialogResult.OK ? colorDlg.Color : currentColor;
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
