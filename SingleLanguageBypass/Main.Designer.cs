namespace SingleLanguageBypass
{
    partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			LanguageSwitch = new MaterialSkin.Controls.MaterialButton();
			AboutMe = new MaterialSkin.Controls.MaterialButton();
			btnExtractISO = new MaterialSkin.Controls.MaterialButton();
			ChangeKey = new MaterialSkin.Controls.MaterialButton();
			Version = new MaterialSkin.Controls.MaterialLabel();
			PrepareIso = new MaterialSkin.Controls.MaterialButton();
			OpenSetup = new MaterialSkin.Controls.MaterialButton();
			ChangeLanguage = new MaterialSkin.Controls.MaterialButton();
			SuspendLayout();
			// 
			// LanguageSwitch
			// 
			LanguageSwitch.AutoSize = false;
			LanguageSwitch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			LanguageSwitch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			LanguageSwitch.Depth = 0;
			LanguageSwitch.HighEmphasis = true;
			LanguageSwitch.Icon = null;
			LanguageSwitch.Location = new Point(415, 204);
			LanguageSwitch.Margin = new Padding(4, 6, 4, 6);
			LanguageSwitch.MouseState = MaterialSkin.MouseState.HOVER;
			LanguageSwitch.Name = "LanguageSwitch";
			LanguageSwitch.NoAccentTextColor = Color.Empty;
			LanguageSwitch.Size = new Size(36, 36);
			LanguageSwitch.TabIndex = 15;
			LanguageSwitch.Text = "RU";
			LanguageSwitch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			LanguageSwitch.UseAccentColor = false;
			LanguageSwitch.UseVisualStyleBackColor = true;
			LanguageSwitch.Click += LanguageSwitch_Click;
			// 
			// AboutMe
			// 
			AboutMe.AutoSize = false;
			AboutMe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			AboutMe.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			AboutMe.Depth = 0;
			AboutMe.HighEmphasis = true;
			AboutMe.Icon = null;
			AboutMe.Location = new Point(332, 262);
			AboutMe.Margin = new Padding(4, 6, 4, 6);
			AboutMe.MouseState = MaterialSkin.MouseState.HOVER;
			AboutMe.Name = "AboutMe";
			AboutMe.NoAccentTextColor = Color.Empty;
			AboutMe.Size = new Size(119, 36);
			AboutMe.TabIndex = 16;
			AboutMe.Text = "About Me";
			AboutMe.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			AboutMe.UseAccentColor = false;
			AboutMe.UseVisualStyleBackColor = true;
			AboutMe.Click += AboutMe_Click;
			// 
			// btnExtractISO
			// 
			btnExtractISO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			btnExtractISO.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			btnExtractISO.Depth = 0;
			btnExtractISO.HighEmphasis = true;
			btnExtractISO.Icon = null;
			btnExtractISO.Location = new Point(0, 0);
			btnExtractISO.Margin = new Padding(4, 6, 4, 6);
			btnExtractISO.MouseState = MaterialSkin.MouseState.HOVER;
			btnExtractISO.Name = "btnExtractISO";
			btnExtractISO.NoAccentTextColor = Color.Empty;
			btnExtractISO.Size = new Size(64, 36);
			btnExtractISO.TabIndex = 26;
			btnExtractISO.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			btnExtractISO.UseAccentColor = false;
			// 
			// ChangeKey
			// 
			ChangeKey.AutoSize = false;
			ChangeKey.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ChangeKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			ChangeKey.Depth = 0;
			ChangeKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			ChangeKey.HighEmphasis = true;
			ChangeKey.Icon = null;
			ChangeKey.Location = new Point(18, 88);
			ChangeKey.Margin = new Padding(4, 6, 4, 6);
			ChangeKey.MouseState = MaterialSkin.MouseState.HOVER;
			ChangeKey.Name = "ChangeKey";
			ChangeKey.NoAccentTextColor = Color.Empty;
			ChangeKey.Size = new Size(219, 36);
			ChangeKey.TabIndex = 20;
			ChangeKey.Text = "1. Change Key";
			ChangeKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			ChangeKey.UseAccentColor = false;
			ChangeKey.UseVisualStyleBackColor = true;
			ChangeKey.Click += ChangeKey_Click;
			// 
			// Version
			// 
			Version.AutoSize = true;
			Version.Depth = 0;
			Version.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
			Version.Location = new Point(416, 88);
			Version.MouseState = MaterialSkin.MouseState.HOVER;
			Version.Name = "Version";
			Version.Size = new Size(35, 19);
			Version.TabIndex = 22;
			Version.Text = "v 2.0";
			// 
			// PrepareIso
			// 
			PrepareIso.AutoSize = false;
			PrepareIso.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			PrepareIso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			PrepareIso.Depth = 0;
			PrepareIso.HighEmphasis = true;
			PrepareIso.Icon = null;
			PrepareIso.Location = new Point(18, 204);
			PrepareIso.Margin = new Padding(4, 6, 4, 6);
			PrepareIso.MouseState = MaterialSkin.MouseState.HOVER;
			PrepareIso.Name = "PrepareIso";
			PrepareIso.NoAccentTextColor = Color.Empty;
			PrepareIso.Size = new Size(219, 36);
			PrepareIso.TabIndex = 23;
			PrepareIso.Text = "3. Prepare ISO";
			PrepareIso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			PrepareIso.UseAccentColor = false;
			PrepareIso.UseVisualStyleBackColor = true;
			PrepareIso.Click += PrepareIso_Click;
			// 
			// OpenSetup
			// 
			OpenSetup.AutoSize = false;
			OpenSetup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			OpenSetup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			OpenSetup.Depth = 0;
			OpenSetup.Enabled = false;
			OpenSetup.HighEmphasis = true;
			OpenSetup.Icon = null;
			OpenSetup.Location = new Point(18, 262);
			OpenSetup.Margin = new Padding(4, 6, 4, 6);
			OpenSetup.MouseState = MaterialSkin.MouseState.HOVER;
			OpenSetup.Name = "OpenSetup";
			OpenSetup.NoAccentTextColor = Color.Empty;
			OpenSetup.Size = new Size(219, 36);
			OpenSetup.TabIndex = 24;
			OpenSetup.Text = "4. Open Setup.exe";
			OpenSetup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			OpenSetup.UseAccentColor = false;
			OpenSetup.UseVisualStyleBackColor = true;
			OpenSetup.Click += OpenSetup_Click;
			// 
			// ChangeLanguage
			// 
			ChangeLanguage.AutoSize = false;
			ChangeLanguage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ChangeLanguage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			ChangeLanguage.Depth = 0;
			ChangeLanguage.HighEmphasis = true;
			ChangeLanguage.Icon = null;
			ChangeLanguage.Location = new Point(18, 146);
			ChangeLanguage.Margin = new Padding(4, 6, 4, 6);
			ChangeLanguage.MouseState = MaterialSkin.MouseState.HOVER;
			ChangeLanguage.Name = "ChangeLanguage";
			ChangeLanguage.NoAccentTextColor = Color.Empty;
			ChangeLanguage.Size = new Size(219, 36);
			ChangeLanguage.TabIndex = 27;
			ChangeLanguage.Text = "2. Change Language";
			ChangeLanguage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			ChangeLanguage.UseAccentColor = false;
			ChangeLanguage.UseVisualStyleBackColor = true;
			ChangeLanguage.Click += ChangeLanguage_Click;
			// 
			// Main
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(502, 327);
			Controls.Add(ChangeLanguage);
			Controls.Add(OpenSetup);
			Controls.Add(PrepareIso);
			Controls.Add(Version);
			Controls.Add(ChangeKey);
			Controls.Add(btnExtractISO);
			Controls.Add(AboutMe);
			Controls.Add(LanguageSwitch);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 2, 3, 2);
			Name = "Main";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "SingleLanguageBypass";
			Load += Main_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private MaterialSkin.Controls.MaterialButton LanguageSwitch;
        private MaterialSkin.Controls.MaterialButton AboutMe;
        private MaterialSkin.Controls.MaterialButton btnExtractISO;
        private MaterialSkin.Controls.MaterialButton ChangeKey;
        private MaterialSkin.Controls.MaterialLabel Version;
        private MaterialSkin.Controls.MaterialButton PrepareIso;
        private MaterialSkin.Controls.MaterialButton OpenSetup;
		private MaterialSkin.Controls.MaterialButton ChangeLanguage;
	}
}
