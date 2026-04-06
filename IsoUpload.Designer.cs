namespace SingleLanguageBypass
{
	partial class IsoUpload
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
			ChooseIso = new MaterialSkin.Controls.MaterialButton();
			lblSelectedISO = new MaterialSkin.Controls.MaterialLabel();
			ChooseIsoLanguage = new MaterialSkin.Controls.MaterialComboBox();
			IsoStart = new MaterialSkin.Controls.MaterialButton();
			SuspendLayout();
			// 
			// ChooseIso
			// 
			ChooseIso.AutoSize = false;
			ChooseIso.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ChooseIso.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			ChooseIso.Depth = 0;
			ChooseIso.HighEmphasis = true;
			ChooseIso.Icon = null;
			ChooseIso.Location = new Point(22, 82);
			ChooseIso.Margin = new Padding(5, 8, 5, 8);
			ChooseIso.MouseState = MaterialSkin.MouseState.HOVER;
			ChooseIso.Name = "ChooseIso";
			ChooseIso.NoAccentTextColor = Color.Empty;
			ChooseIso.Size = new Size(250, 48);
			ChooseIso.TabIndex = 18;
			ChooseIso.Text = "Выбрать iso-файл";
			ChooseIso.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			ChooseIso.UseAccentColor = false;
			ChooseIso.UseVisualStyleBackColor = true;
			ChooseIso.Click += ChooseIso_Click;
			// 
			// lblSelectedISO
			// 
			lblSelectedISO.AutoSize = true;
			lblSelectedISO.Depth = 0;
			lblSelectedISO.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
			lblSelectedISO.Location = new Point(280, 95);
			lblSelectedISO.MouseState = MaterialSkin.MouseState.HOVER;
			lblSelectedISO.Name = "lblSelectedISO";
			lblSelectedISO.Size = new Size(90, 19);
			lblSelectedISO.TabIndex = 19;
			lblSelectedISO.Text = "Не выбрано";
			// 
			// ChooseIsoLanguage
			// 
			ChooseIsoLanguage.AutoResize = false;
			ChooseIsoLanguage.BackColor = Color.FromArgb(255, 255, 255);
			ChooseIsoLanguage.Depth = 0;
			ChooseIsoLanguage.DrawMode = DrawMode.OwnerDrawVariable;
			ChooseIsoLanguage.DropDownHeight = 174;
			ChooseIsoLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
			ChooseIsoLanguage.DropDownWidth = 121;
			ChooseIsoLanguage.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
			ChooseIsoLanguage.ForeColor = Color.FromArgb(222, 0, 0, 0);
			ChooseIsoLanguage.FormattingEnabled = true;
			ChooseIsoLanguage.Hint = "Язык файла iso";
			ChooseIsoLanguage.IntegralHeight = false;
			ChooseIsoLanguage.ItemHeight = 43;
			ChooseIsoLanguage.Location = new Point(22, 142);
			ChooseIsoLanguage.Margin = new Padding(3, 4, 3, 4);
			ChooseIsoLanguage.MaxDropDownItems = 4;
			ChooseIsoLanguage.MouseState = MaterialSkin.MouseState.OUT;
			ChooseIsoLanguage.Name = "ChooseIsoLanguage";
			ChooseIsoLanguage.Size = new Size(250, 49);
			ChooseIsoLanguage.StartIndex = 0;
			ChooseIsoLanguage.TabIndex = 20;
			ChooseIsoLanguage.SelectedIndexChanged += ChooseIsoLanguage_SelectedIndexChanged;
			// 
			// IsoStart
			// 
			IsoStart.AutoSize = false;
			IsoStart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			IsoStart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
			IsoStart.Depth = 0;
			IsoStart.Enabled = false;
			IsoStart.HighEmphasis = true;
			IsoStart.Icon = null;
			IsoStart.Location = new Point(22, 222);
			IsoStart.Margin = new Padding(5, 8, 5, 8);
			IsoStart.MouseState = MaterialSkin.MouseState.HOVER;
			IsoStart.Name = "IsoStart";
			IsoStart.NoAccentTextColor = Color.Empty;
			IsoStart.Size = new Size(250, 48);
			IsoStart.TabIndex = 21;
			IsoStart.Text = "Начать";
			IsoStart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
			IsoStart.UseAccentColor = false;
			IsoStart.UseVisualStyleBackColor = true;
			IsoStart.Click += IsoStart_Click;
			// 
			// IsoUpload
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(580, 286);
			Controls.Add(IsoStart);
			Controls.Add(ChooseIsoLanguage);
			Controls.Add(lblSelectedISO);
			Controls.Add(ChooseIso);
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "IsoUpload";
			Padding = new Padding(3, 85, 3, 4);
			Sizable = false;
			Text = "IsoUpload";
			Load += IsoUpload_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MaterialSkin.Controls.MaterialButton btnToSelectISO;
		private MaterialSkin.Controls.MaterialLabel lblSelectedISO;
		private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
		private MaterialSkin.Controls.MaterialButton ChooseIso;
		private MaterialSkin.Controls.MaterialButton IsoStart;
		private MaterialSkin.Controls.MaterialComboBox ChooseIsoLanguage;
	}
}