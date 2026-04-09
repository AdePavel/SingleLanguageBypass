using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SingleLanguageBypass
{
	/// <summary>
	/// Форма с информацией о приложении и ссылкой на GitHub.
	/// /
	/// Form displaying information about the application and a link to GitHub.
	/// </summary>
	public partial class AboutForm : MaterialForm
	{
		private readonly string _language;

		
		public AboutForm(string language)
		{
			_language = language ?? "EN";

			InitializeComponent();

			ApplyMaterialSkinTheme();
			ConfigureFormAppearance();

			InitializeUI();
		}

		// ====================== ТЕМА И НАСТРОЙКИ ФОРМЫ / THEME AND FORM SETTINGS ======================
		private void ApplyMaterialSkinTheme()
		{
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
			materialSkinManager.ColorScheme = new ColorScheme(
				Primary.BlueGrey800,
				Primary.BlueGrey900,
				Primary.BlueGrey500,
				Accent.LightBlue200,
				TextShade.WHITE);
		}

		private void ConfigureFormAppearance()
		{
			AutoScaleMode = AutoScaleMode.None;
			Size = new Size(562, 320);
			MinimumSize = new Size(562, 320);
			MaximumSize = new Size(562, 320);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = true;
			StartPosition = FormStartPosition.CenterScreen;
			Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
		}

		// ====================== ИНИЦИАЛИЗАЦИЯ UI И ЛОКАЛИЗАЦИЯ / UI Initialization and Localization ======================
		private void InitializeUI()
		{

			Controls.Clear();
			Text = _language == "RU" ? "О программе" : "About me";

			var lblText = new MaterialLabel
			{
				Location = new Point(30, 75),
				Size = new Size(500, 190),
				Font = new Font("Segoe UI", 11F, FontStyle.Regular),
				AutoSize = false,
				Text = _language == "RU"
					? "Данная программа предназначена для обхода ограничения ручной смены языка интерфейса " +
					  "для изданий Windows с одним зафиксированным языком.\r\n\r\n" +
					  "Программа позволит беспрепятственно восстановить систему до Windows Home с возможностью выбора языка " +
					  "интерфейса с сохранением всех установленных программ, драйверов, файлов и всех пользовательских настроек.\r\n\r\n" +
					  "Внимательно изучите Readme перед использованием программы!"
					: "This application is intended to bypass the limitation of manual interface language switching " +
					  "in single-language versions of Windows.\r\n\r\n" +
					  "The program enables a smooth upgrade to Windows Home edition with full interface " +
					  "language selection support, while keeping all installed applications, drivers, files, and " +
					  "user settings intact.\r\n\r\n" +
					  "Carefully review the Readme file before using the program!"
			};
			Controls.Add(lblText);

			// === Ссылка на GitHub ===
			var linkGitHub = new LinkLabel
			{
				Text = "GitHub @AdePavel",
				Location = new Point(26, 285),
				Size = new Size(220, 25),
				Font = new Font("Segoe UI", 11F, FontStyle.Underline),
				LinkColor = Color.LightBlue,
				ActiveLinkColor = Color.Cyan,
				VisitedLinkColor = Color.LightBlue,
				LinkBehavior = LinkBehavior.AlwaysUnderline
			};

			linkGitHub.LinkClicked += (_, _) =>
			{
				try
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://github.com/AdePavel",
						UseShellExecute = true
					});
				}
				catch {}
			};

			Controls.Add(linkGitHub);
		}

		
		private void InitializeComponent() // Оставлено для совместимости с дизайнером Visual Studio / Left for Visual Studio Designer compatibility
		{
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			SuspendLayout();

			ClientSize = new Size(562, 270);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "AboutForm";

			ResumeLayout(false);
		}
	}
}