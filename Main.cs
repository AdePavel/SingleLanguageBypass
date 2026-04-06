using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SingleLanguageBypass
{
	/// <summary>
	/// Главная форма приложения, обеспечивает последовательное исполнение главных шагов алгоритма с удобным пользовательским интерфейсом.
	/// /
	/// Main application form that guides the user through the entire process with a clean and intuitive step-by-step interface.
	/// </summary>
	public partial class Main : MaterialForm
	{
		private Language currentLanguage = Language.EN;

		public Main()
		{
			InitializeComponent();

			ApplyMaterialSkinTheme();
			ConfigureFormAppearance();

			UpdateLanguage();
		}
		private void Main_Load(object sender, EventArgs e)
		{
			CheckSetupFileOnDesktop();
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
			Size = new Size(474, 321);
			MinimumSize = new Size(474, 321);
			MaximumSize = new Size(474, 321);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = true;
			StartPosition = FormStartPosition.CenterScreen;
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
		}

		// ====================== ЛОКАЛИЗАЦИЯ / LOCALIZATION ======================
		private enum Language { EN, RU }

		private void UpdateLanguage()
		{
			this.Text = "SingleLanguageBypass - by AdePavel";

			if (currentLanguage == Language.RU)
			{
				LanguageSwitch.Text = "RU";
				AboutMe.Text = "О программе";
				ChangeKey.Text = "1. Сменить ключ";
				ChangeLanguage.Text = "2. Изменить язык";
				PrepareIso.Text = "3. Подготовить ISO";
				OpenSetup.Text = "4. Открыть Setup.exe";
			}
			else
			{
				LanguageSwitch.Text = "EN";
				AboutMe.Text = "About me";
				ChangeKey.Text = "1. Change Key";
				ChangeLanguage.Text = "2. Change Language";
				PrepareIso.Text = "3. Prepare ISO";
				OpenSetup.Text = "4. Open Setup.exe";
			}

			this.Refresh();
		}

		private string GetLocalized(string key)
		{
			return currentLanguage == Language.RU ? key switch
			{
				"UAC_Title" => "Важно",
				"UAC_Message" => "В следующем окне необходимо перевести ползунок в самый нижний режим — «Никогда не уведомлять»",
				"Error" => "Ошибка",
				"KeyChangeError" => "Ошибка при установке ключа",
				"SetupSuccess" => "Файл setup.exe успешно запущен с рабочего стола.",
				"SetupNotFound" => "Файл setup.exe не найден на рабочем столе!\n\nПуть: ",
				"LaunchError" => "Не удалось запустить setup.exe",
				"LanguageConfirmTitle" => "Подтверждение установки языкового пакета",
				"LanguageConfirmText" => "Пожалуйста, подтвердите:\n\nВы скачали языковой пакет и выбрали его основным языком?\n\n",
				"SelectISO" => "Выберите ISO-файл",
				_ => key
			} : key switch
			{
				"UAC_Title" => "Important",
				"UAC_Message" => "In the following window, move the slider all the way down to 'Never notify'",
				"Error" => "Error",
				"KeyChangeError" => "Error while changing product key",
				"SetupSuccess" => "Setup.exe has been successfully launched from the desktop.",
				"SetupNotFound" => "Setup.exe file not found on the desktop!\n\nPath: ",
				"LaunchError" => "Failed to launch setup.exe",
				"LanguageConfirmTitle" => "Language Pack Installation Confirmation",
				"LanguageConfirmText" => "Please confirm:\n\nHave you downloaded the necessary language pack and selected it as your main language?\n\n",
				"SelectISO" => "Select ISO file",
				_ => key
			};
		}

		// ====================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ / HELPER METHODS ======================
		private bool IsUACSettingsOpen() =>
			Process.GetProcessesByName("UserAccountControlSettings").Length > 0;

		private static string GetChangeKeyBatContent() =>
			@"@echo off
chcp 65001 >nul
echo ========================================
echo Changing Windows product key...
echo ========================================
echo.
echo Removing current key...
cscript //nologo ""%windir%\system32\slmgr.vbs"" /upk >nul 2>&1
echo Clearing key from registry...
cscript //nologo ""%windir%\system32\slmgr.vbs"" /cpky >nul 2>&1
echo.
echo Applying Generic key...
changepk.exe /ProductKey YTMG3-N6DKC-DKB77-7M9GH-8HVX7
echo.
echo ========================================
echo Key successfully applied!
echo ========================================
echo You can now install the language pack.
del ""%~f0""";

		// ====================== ОСНОВНАЯ ЛОГИКА / MAIN LOGIC ======================
		private async Task ChangeWindowsProductKey()
		{
			while (IsUACSettingsOpen())
				await Task.Delay(500);

			string batPath = Path.Combine(Path.GetTempPath(), "ChangeWindowsKey.bat");

			try
			{
				File.WriteAllText(batPath, GetChangeKeyBatContent(), System.Text.Encoding.UTF8);

				var psi = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = $"/c \"{batPath}\"",
					Verb = "runas",
					UseShellExecute = true,
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden
				};

				using var process = Process.Start(psi);
				if (process != null)
					await Task.Run(() => process.WaitForExit());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, GetLocalized("KeyChangeError"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (File.Exists(batPath))
					File.Delete(batPath);
			}
		}

		private void ChangeUAC()
		{
			MessageBox.Show(GetLocalized("UAC_Message"), GetLocalized("UAC_Title"),
				MessageBoxButtons.OK, MessageBoxIcon.Information);

			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "useraccountcontrolsettings.exe",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, GetLocalized("Error"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void OpenLanguageSettings()
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "ms-settings:regionlanguage",
					UseShellExecute = true
				});
			}
			catch { }
		}

		private void CheckSetupFileOnDesktop()
		{
			try
			{
				var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				var setupPath = Path.Combine(desktopPath, "setup.exe");
				OpenSetup.Enabled = File.Exists(setupPath);
			}
			catch
			{
				OpenSetup.Enabled = false;
			}
		}

		// ====================== ОБРАБОТЧИКИ КНОПОК / BUTTON EVENT HANDLERS ======================
		private void AboutMe_Click(object sender, EventArgs e)
		{
			using var about = new AboutForm(currentLanguage.ToString());
			about.ShowDialog();
		}

		private async void ChangeKey_Click(object sender, EventArgs e)
		{
			ChangeUAC();
			await ChangeWindowsProductKey();
		}

		private void PrepareIso_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(
				GetLocalized("LanguageConfirmText"),
				GetLocalized("LanguageConfirmTitle"),
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1);

			if (result == DialogResult.Yes)
			{
				using var isoForm = new IsoUpload(currentLanguage.ToString());
				isoForm.ShowDialog();
			}
			else if (result == DialogResult.No)
			{
				OpenLanguageSettings();
			}
		}

		private void OpenSetup_Click(object sender, EventArgs e)
		{
			try
			{
				var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
				var setupPath = Path.Combine(desktopPath, "setup.exe");

				if (File.Exists(setupPath))
				{
					Process.Start(new ProcessStartInfo { FileName = setupPath, UseShellExecute = true });
					MessageBox.Show(GetLocalized("SetupSuccess"), "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(GetLocalized("SetupNotFound") + setupPath,
						GetLocalized("Error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(GetLocalized("LaunchError") + "\n\n" + ex.Message,
					GetLocalized("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ChangeLanguage_Click(object sender, EventArgs e)
		{
			OpenLanguageSettings();
		}

		private void LanguageSwitch_Click(object sender, EventArgs e)
		{
			currentLanguage = currentLanguage == Language.RU ? Language.EN : Language.RU;
			UpdateLanguage();
		}
	}
}