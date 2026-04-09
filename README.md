[Русская версия](README.ru.md)

# SingleLanguageBypass
**Tool for upgrading Windows 11 Single Language Edition to Windows 11 Home without losing applications, data, and drivers.** <br>
<br>
[Download SingleLanguageBypass.exe](https://github.com/AdePavel/SingleLanguageBypass/releases/download/v2.0/SingleLanguageBypass.exe)
<br>

## Table of Contents
- [What the program does](#-what-the-program-does)
- [Description of the problem](#description-of-the-problem)
- [Solution](#solution)
- [Who is this useful for](#who-is-this-useful-for)
- [How the program works](#how-the-program-works)
- [Step-by-step usage instructions](#-step-by-step-usage-instructions)
- [⚠️ Important tips and warnings](#️-important-tips-and-warnings)
- [License](#license)
---

## ✨ What the program does
The program allows you to upgrade Windows **Single Language Edition** to **Windows Home** with the ability to change the interface language, **while preserving**:
- all installed drivers and programs
- all user files and settings
- the active official Windows license
---

## Problem description

When purchasing a new laptop, the system often comes with **Windows 11 Single Language Edition** preinstalled. In this edition, changing the interface language **is not provided** by Microsoft.
The officially recommended way is a full Windows reinstallation, which leads to the loss of factory applications and the need to reinstall drivers manually.

---
Solution

SingleLanguageBypass automates the upgrade of the Windows 11 Single Language Edition edition to Windows 11 Home using standard Microsoft mechanisms, while preserving all drivers, applications, and data.
Everything happens quickly and with minimal user involvement.
---


## Who is it useful for

- **Regular users** who do not want to spend time and effort on a full Windows reinstallation followed by manual installation of all drivers.
- **Laptop stores and service centers** — for quick automated installation of the required interface language for their customers.
---

## How the program works

1. Changing the Windows key to the official Generic Home key
2. Installing the language pack through standard Windows settings
3. Mounting the ISO image and copying files to the desktop
4. Configuring system parameters
5. Rebooting and performing the system upgrade to Windows Home
---

## 📖 Step-by-step usage instructions

**The system must be connected to the internet!**

   **Prepare the ISO file**
   Download the official Windows 11 ISO from the Microsoft website **in the language** you want to install.
   [→ Download Windows 11 ISO](https://www.microsoft.com/en-us/software-download/windows11)

   **Step 1 — Change key**<br>
   Launch the program → click **"1. Change Key"**.<br>
   In the opened UAC window, move the slider to the lowest position (“Never notify”).<br>
   The key will change automatically. The computer **will restart**.<br>
   
   ![](screenshots/1.gif)

   **Step 2 — Install language pack**<br>
   After restarting, click **"2. Change Language"**.<br>
   Click “Add a language”, select the desired language (it **must match** the language of the ISO file).<br>
   Disable handwriting and speech recognition.<br>
   Check the box **"Set as my Windows display language"** and install the pack.<br>
   
   ![](screenshots/2.gif)

   **This step can be considered complete when the language pack appears in the list:**
   
   ![](screenshots/3.png)

   **Step 3 — Prepare ISO**.<br>
   Click **"3. Prepare ISO"**..<br>
   Select the downloaded ISO file and the corresponding language → click **"Start"**..<br>
   The program will copy the files to the desktop and configure the necessary system parameters. Agree to restart..<br>
   
   ![](screenshots/4.gif)

   **Step 4 — System upgrade**<br>
   After restarting, launch `Setup.exe` from the desktop (or via the **"4. Open Setup.exe"** button in the program).<br>
   Follow the installer instructions to upgrade to Windows Home.<br>
   
   ![](screenshots/5.gif)
<br>
---
<br>
## ⚠️ Important tips and warnings
- **Languages must match exactly**:
  ISO file language = Language pack language = Language selected in the program at step 3.
- After step 3, Windows may work **unstable** — this is normal. That is why the program lowers the UAC level in advance to avoid extra bugs.
- **After completion**, it is recommended to return UAC to its original position.
- At step 4, **disable Windows Update checking** — the process will go significantly faster.
- **The program is intended only for devices with a legitimate OEM license of Windows 11 Single Language Edition.**
- **Use at your own risk.**

---
## License
The project is distributed under the **MIT** license.
Details — in the [LICENSE](LICENSE) file.

---
**Author:** AdePavel
**GitHub:** [github.com/AdePavel](https://github.com/AdePavel)
