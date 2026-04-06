using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleLanguageBypass
{
	/// <summary>
	/// Форма для выбора ISO-файла и указания языка данного ISO файла. Также в данной форме происходит событие изменения реестра после нажатия кнопки "Начать".
	/// /
	/// Form for selecting an ISO file and specifying its language. Also performs registry modifications after clicking the "Start" button.
	/// </summary>
	public partial class IsoUpload : MaterialForm
	{
		private readonly string _currentLanguage; //

		public string SelectedLanguage { get; private set; } = string.Empty;
		public string SelectedCulture { get; private set; } = "ru-RU";
		public string SelectedLCID { get; private set; } = "0419";

		private string _selectedIsoPath = string.Empty;

		public IsoUpload(string languageFromMain)
		{
			_currentLanguage = languageFromMain ?? "EN";

			InitializeComponent();

			ApplyMaterialSkinTheme();
			ConfigureFormAppearance();

			UpdateFormLanguage();
			FillLanguageComboBox();

			IsoStart.Enabled = false;
		}
		private void IsoUpload_Load(object sender, EventArgs e)
		{
			UpdateStartButtonState();
		}
		// ====================== ТЕМА И НАСТРОЙКИ ФОРМЫ / THEME AND FORM SETTINGS======================
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
			Size = new Size(580, 286);
			MinimumSize = Size;
			MaximumSize = Size;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = true;
			StartPosition = FormStartPosition.CenterScreen;
		}

		// ====================== ЛОКАЛИЗАЦИЯ / LOCALIZATION ======================
		private void UpdateFormLanguage()
		{
			Text = _currentLanguage == "RU" ? "Подготовить ISO" : "Prepare ISO";
			ChooseIso.Text = _currentLanguage == "RU" ? "Выбрать ISO-файл" : "Choose ISO-file";
			ChooseIsoLanguage.Hint = _currentLanguage == "RU" ? "Язык ISO-файла" : "ISO-file language";
			IsoStart.Text = _currentLanguage == "RU" ? "Начать" : "Start";
			lblSelectedISO.Text = _currentLanguage == "RU" ? "Не выбрано" : "Not chosen";
		}

		// ====================== СПИСОК ЯЗЫКОВ / LANGUAGE LIST ======================
		private void FillLanguageComboBox()
		{
			ChooseIsoLanguage.Items.Clear();

			var items = _currentLanguage == "RU"
				? new[]
				{
					new LanguageItem("Русский", "ru-RU", "0419"),
					new LanguageItem("Английский (США)", "en-US", "0409"),
					new LanguageItem("Немецкий", "de-DE", "0407"),
					new LanguageItem("Французский", "fr-FR", "040c"),
					new LanguageItem("Испанский (Испания)", "es-ES", "040a"),
					new LanguageItem("Итальянский", "it-IT", "0410"),
					new LanguageItem("Португальский (Бразилия)", "pt-BR", "0416"),
					new LanguageItem("Португальский (Португалия)", "pt-PT", "0816"),
					new LanguageItem("Польский", "pl-PL", "0415"),
					new LanguageItem("Турецкий", "tr-TR", "041f"),
					new LanguageItem("Украинский", "uk-UA", "0422"),
					new LanguageItem("Нидерландский", "nl-NL", "0413"),
					new LanguageItem("Шведский", "sv-SE", "041d"),
					new LanguageItem("Чешский", "cs-CZ", "0405"),
					new LanguageItem("Венгерский", "hu-HU", "040e"),
					new LanguageItem("Греческий", "el-GR", "0408"),
					new LanguageItem("Датский", "da-DK", "0406"),
					new LanguageItem("Финский", "fi-FI", "040b")
				}
				: new[]
				{
					new LanguageItem("Russian", "ru-RU", "0419"),
					new LanguageItem("English (United States)", "en-US", "0409"),
					new LanguageItem("German", "de-DE", "0407"),
					new LanguageItem("French", "fr-FR", "040c"),
					new LanguageItem("Spanish (Spain)", "es-ES", "040a"),
					new LanguageItem("Italian", "it-IT", "0410"),
					new LanguageItem("Portuguese (Brazil)", "pt-BR", "0416"),
					new LanguageItem("Portuguese (Portugal)", "pt-PT", "0816"),
					new LanguageItem("Polish", "pl-PL", "0415"),
					new LanguageItem("Turkish", "tr-TR", "041f"),
					new LanguageItem("Ukrainian", "uk-UA", "0422"),
					new LanguageItem("Dutch", "nl-NL", "0413"),
					new LanguageItem("Swedish", "sv-SE", "041d"),
					new LanguageItem("Czech", "cs-CZ", "0405"),
					new LanguageItem("Hungarian", "hu-HU", "040e"),
					new LanguageItem("Greek", "el-GR", "0408"),
					new LanguageItem("Danish", "da-DK", "0406"),
					new LanguageItem("Finnish", "fi-FI", "040b")
				};

			ChooseIsoLanguage.Items.AddRange(items);
			ChooseIsoLanguage.SelectedIndex = 0;
		}

		private class LanguageItem
		{
			public string DisplayName { get; }
			public string CultureName { get; }
			public string LCID { get; }

			public LanguageItem(string displayName, string cultureName, string lcid)
			{
				DisplayName = displayName;
				CultureName = cultureName;
				LCID = lcid;
			}

			public override string ToString() => DisplayName;
		}

		// ====================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ / HELPER METHODS ======================
		private void UpdateStartButtonState()
		{
			IsoStart.Enabled = ChooseIsoLanguage.SelectedItem != null &&
							   !string.IsNullOrEmpty(_selectedIsoPath);
		}

		private static string GetExtractIsoPowerShellScript(string isoPath)
		{
			return $@"
$isoPath = '{isoPath}'
$desktop = [Environment]::GetFolderPath('Desktop')

Write-Host 'Mounting ISO...' -ForegroundColor Cyan
$iso = Mount-DiskImage -ImagePath $isoPath -PassThru -ErrorAction Stop
$driveLetter = ($iso | Get-Volume).DriveLetter

if ($driveLetter) {{
    $source = ""$($driveLetter):\*""
    Write-Host 'Copying files to desktop...' -ForegroundColor Cyan
    Copy-Item -Path $source -Destination $desktop -Recurse -Force -ErrorAction Stop
    Write-Host '✅ Success!' -ForegroundColor Green
}} else {{
    Write-Host '❌ Error mounting ISO' -ForegroundColor Red
}}

Dismount-DiskImage -ImagePath $isoPath -ErrorAction SilentlyContinue
Write-Host 'Operation completed.' -ForegroundColor Gray
Start-Sleep -Seconds 2";
		}

		private string GetSetLanguageBatContent()
		{
			string muiValue = $"{SelectedLCID}:{SelectedLCID.PadLeft(8, '0')}";

			return "@echo off\r\n" +
				   "chcp 65001 >nul\r\n" +
				   $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Nls\\Language\" /v Default /t REG_SZ /d {SelectedLCID} /f\r\n" +
				   $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Nls\\Language\" /v InstallLanguage /t REG_SZ /d {SelectedLCID} /f\r\n" +
				   $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\MUI\\UILanguages\\{SelectedCulture}\" /ve /t REG_SZ /d {muiValue} /f\r\n" +
				   "del \"%~f0\"";
		}

		// ====================== ОСНОВНАЯ ЛОГИКА / MAIN LOGIC ======================
		private async void StartProcess()
		{
			if (string.IsNullOrEmpty(_selectedIsoPath) || ChooseIsoLanguage.SelectedItem == null)
			{
				MessageBox.Show(
					_currentLanguage == "RU" ? "Выберите язык и ISO-файл!" : "Please select language and ISO file!",
					_currentLanguage == "RU" ? "Ошибка" : "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			string tempScriptPath = Path.Combine(Path.GetTempPath(), $"ExtractISO_{Guid.NewGuid()}.ps1");
			string batPath = Path.Combine(Path.GetTempPath(), "SetLanguage.bat");

			try
			{
				// 1. PowerShell — монтирование и копирование ISO / ISO Mounting and File Copying
				File.WriteAllText(tempScriptPath, GetExtractIsoPowerShellScript(_selectedIsoPath), System.Text.Encoding.UTF8);

				var psi = new ProcessStartInfo
				{
					FileName = "powershell.exe",
					Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{tempScriptPath}\"",
					UseShellExecute = true,
					Verb = "runas",
					CreateNoWindow = false,
					WindowStyle = ProcessWindowStyle.Normal
				};

				using (var ps = Process.Start(psi))
				{
					if (ps != null)
						await Task.Run(() => ps.WaitForExit());
				}

				// 2. Копирование текущего EXE на рабочий стол / Copying current EXE to Desktop
				try
				{
					string currentExe = Application.ExecutablePath;
					string exeName = Path.GetFileName(currentExe);
					string dest = Path.Combine(desktop, exeName);

					if (File.Exists(dest))
						File.Delete(dest);

					File.Copy(currentExe, dest, true);
				}
				catch {}

				// 3. BAT — изменение языка в реестре / BAT file — Language change via Registry
				File.WriteAllText(batPath, GetSetLanguageBatContent(), System.Text.Encoding.UTF8);

				var batInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = $"/c \"{batPath}\"",
					Verb = "runas",
					UseShellExecute = true,
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden
				};

				using (var bat = Process.Start(batInfo))
				{
					if (bat != null)
						await Task.Run(() => bat.WaitForExit());
				}

				// 4. Финальное сообщение + предложение перезагрузки / Final message with restart recommendation
				string msg = _currentLanguage == "RU"
					? $"Все операции успешно завершены!\n\n" +
					  "• Файлы из ISO скопированы на рабочий стол\n" +
					  "• Приложение скопировано на рабочий стол\n" +
					  $"• Системный язык изменён на: {SelectedLanguage}\n\n" +
					  "Для полного применения изменений необходимо перезагрузить компьютер.\n\n" +
					  "Перезагрузить сейчас?"
					: $"All operations completed successfully!\n\n" +
					  "• ISO files copied to desktop\n" +
					  "• Application copied to desktop\n" +
					  $"• System language changed to: {SelectedLanguage}\n\n" +
					  "A computer restart is required to apply changes.\n\n" +
					  "Restart now?";

				string title = _currentLanguage == "RU" ? "Завершение работы" : "Operation Completed";

				DialogResult result = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
					Process.Start("shutdown", "/r /t 0");

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка:\n" + ex.Message,
					_currentLanguage == "RU" ? "Ошибка" : "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				try { if (File.Exists(tempScriptPath)) File.Delete(tempScriptPath); } catch { }
				try { if (File.Exists(batPath)) File.Delete(batPath); } catch { }
			}
		}

		// ====================== ОБРАБОТЧИКИ КНОПОК / BUTTON EVENT HANDLERS ======================
		private void ChooseIso_Click(object sender, EventArgs e)
		{
			using var ofd = new OpenFileDialog
			{
				Filter = "ISO files (*.iso)|*.iso",
				Title = _currentLanguage == "RU" ? "Выберите ISO-файл" : "Select ISO file",
				CheckFileExists = true
			};

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				_selectedIsoPath = ofd.FileName;
				lblSelectedISO.Text = Path.GetFileName(_selectedIsoPath);
				lblSelectedISO.ForeColor = Color.LightGreen;

				UpdateStartButtonState();
			}
		}
		private void ChooseIsoLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ChooseIsoLanguage.SelectedItem is LanguageItem item)
			{
				SelectedLanguage = item.DisplayName;
				SelectedCulture = item.CultureName;
				SelectedLCID = item.LCID;
			}

			UpdateStartButtonState();
		}
		private async void IsoStart_Click(object sender, EventArgs e)
		{
			StartProcess();
		}
	}
}