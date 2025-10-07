using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GAMMA
{
    public partial class Form1 : Form
    {
        // Global hotkey interop
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID_PERIOD = 1;
        private const uint MOD_ALT = 0x0001;
        private const uint MOD_CONTROL = 0x0002;
        private const uint MOD_SHIFT = 0x0004;

        private bool isRunning = false;
        private DateTime serverTimeBase;
        private int dayDurationMinutes = 45; // 45 real minutes = day
        private int nightDurationMinutes = 15; // 15 real minutes = night
        private int totalCycleMinutes = 60; // 45 + 15 = 60 minutes per cycle
        private GammaController gammaController = new GammaController();
        private string currentPhase = ""; // Track current phase for automatic switching
        private double speedMultiplier = 1.0; // Speed multiplier for time acceleration
        private Keys currentHotkeyKey = Keys.OemPeriod; // Current key used with Ctrl+Alt

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            // Enable form-level key handling
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;

            // Set custom icon from PNG path
            TrySetFormIconFromPng("C\\Users\\robin\\Documents\\prof\\GammaTool.png");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Restore original gamma when closing
            gammaController.RestoreOriginalGamma();
            // Unregister global hotkeys
            try { UnregisterHotKey(this.Handle, HOTKEY_ID_PERIOD); } catch { }
        }

        private void InitializeUI()
        {
            // Set initial values
            lblDayValue.Text = trackDayGamma.Value.ToString();
            lblNightValue.Text = trackNightGamma.Value.ToString();
            
            // Initialize server time to show 00:00:00 when app starts
            // Set serverTimeBase to current time so game time shows 00:00:00
            serverTimeBase = DateTime.Now;
            
            // Show 00:00 initially
            lblCurrentServerTime.Text = "Game Time: 00:00";
            
            // Initialize speed button
            btnSpeedToggle.Text = "1x SPEED";
            btnSpeedToggle.BackColor = Color.FromArgb(108, 117, 125); // Gray color
            
            // Initialize cycle status
            UpdateCycleStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Register global hotkey for '.' (period) with Ctrl+Alt modifiers only
            try
            {
                // Use Ctrl+Alt+. to work better in fullscreen apps and avoid conflicts
                RegisterHotKey(this.Handle, HOTKEY_ID_PERIOD, MOD_CONTROL | MOD_ALT, (uint)currentHotkeyKey);
            }
            catch { }

            // Ensure the form uses the application's icon
            try { this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); } catch { }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                StartCycle();
            }
            else
            {
                StopCycle();
            }
        }

        private void StartCycle()
        {
            isRunning = true;
            btnToggle.Text = "STOP";
            btnToggle.BackColor = Color.FromArgb(220, 53, 69); // Red color
            lblStatus.Text = "Running";
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69); // Green color
            
            // Disable manual gamma control while running
            trackDayGamma.Enabled = false;
            trackNightGamma.Enabled = false;
            btnResetDay.Enabled = false;
            btnResetNight.Enabled = false;
            
            // Reset phase tracking
            currentPhase = "";
            
            timer1.Start();
        }

        private void StopCycle()
        {
            isRunning = false;
            btnToggle.Text = "START";
            btnToggle.BackColor = Color.FromArgb(40, 167, 69); // Green color
            lblStatus.Text = "Stopped";
            lblStatus.ForeColor = Color.FromArgb(108, 117, 125); // Gray color
            
            // Re-enable manual gamma control when stopped
            trackDayGamma.Enabled = true;
            trackNightGamma.Enabled = true;
            btnResetDay.Enabled = true;
            btnResetNight.Enabled = true;
            
            timer1.Stop();
            UpdateCycleStatus();
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            try
            {
                int hour = int.Parse(txtHour.Text);
                int minute = int.Parse(txtMinute.Text);
                
                if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
                {
                    MessageBox.Show("Please enter valid time values:\nHour: 0-23\nMinute: 0-59", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Simply set the game time to what you entered
                // 24 game hours = 60 real minutes
                // 1 game hour = 2.5 real minutes (60 ÷ 24 = 2.5)
                serverTimeBase = DateTime.Now;
                
                UpdateServerTimeDisplay();
                // Removed popup message - just set the time silently
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting time: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackDayGamma_ValueChanged(object sender, EventArgs e)
        {
            lblDayValue.Text = trackDayGamma.Value.ToString();
            // Only apply gamma manually when NOT running
            if (!isRunning)
            {
                ApplyDayGamma();
            }
        }

        private void trackNightGamma_ValueChanged(object sender, EventArgs e)
        {
            lblNightValue.Text = trackNightGamma.Value.ToString();
            // Only apply gamma manually when NOT running
            if (!isRunning)
            {
                ApplyNightGamma();
            }
        }

        private void ApplyDayGamma()
        {
            // Convert trackbar value (1-255) to gamma value (0.1-3.0)
            double gamma = ConvertTrackbarToGamma(trackDayGamma.Value);
            gammaController.SetGamma(gamma);
        }

        private void ApplyNightGamma()
        {
            // Convert trackbar value (1-255) to gamma value (0.1-3.0)
            double gamma = ConvertTrackbarToGamma(trackNightGamma.Value);
            gammaController.SetGamma(gamma);
        }

        private double ConvertTrackbarToGamma(int trackbarValue)
        {
            // Convert 1-255 to 0.1-3.0
            // 1 = 0.1, 128 = 1.0, 255 = 3.0
            if (trackbarValue <= 1) return 0.1;
            if (trackbarValue >= 255) return 3.0;
            
            // Linear conversion with more precision around 1.0
            if (trackbarValue < 128)
            {
                // 1-127 maps to 0.1-1.0
                return 0.1 + (trackbarValue - 1) * (0.9 / 126.0);
            }
            else
            {
                // 128-255 maps to 1.0-3.0
                return 1.0 + (trackbarValue - 128) * (2.0 / 127.0);
            }
        }

        private void btnResetGamma_Click(object sender, EventArgs e)
        {
            gammaController.RestoreOriginalGamma();
        }

        private void btnResetDay_Click(object sender, EventArgs e)
        {
            trackDayGamma.Value = 128; // Default gamma position
        }

        private void btnResetNight_Click(object sender, EventArgs e)
        {
            trackNightGamma.Value = 128; // Default gamma position
        }

        private void btnSpeedToggle_Click(object sender, EventArgs e)
        {
            if (speedMultiplier == 1.0)
            {
                // Switch to 10x speed
                speedMultiplier = 10.0;
                btnSpeedToggle.Text = "10x SPEED";
                btnSpeedToggle.BackColor = Color.FromArgb(0, 123, 255); // Blue color
            }
            else if (speedMultiplier == 10.0)
            {
                // Switch to 60x speed
                speedMultiplier = 60.0;
                btnSpeedToggle.Text = "60x SPEED";
                btnSpeedToggle.BackColor = Color.FromArgb(255, 193, 7); // Yellow/orange color
            }
            else
            {
                // Switch back to normal speed
                speedMultiplier = 1.0;
                btnSpeedToggle.Text = "1x SPEED";
                btnSpeedToggle.BackColor = Color.FromArgb(108, 117, 125); // Gray color
            }
            
            // Reset the time base to current time to avoid time jumps
            serverTimeBase = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // When running, show the actual game time ticking
                UpdateRunningGameTime();
            }
            else
            {
                // When stopped, show the set time from input fields
                UpdateServerTimeDisplay();
            }
            
            UpdateCycleStatus();
        }

        private void UpdateServerTimeDisplay()
        {
            // Show the time that was set, not calculated from real time
            try
            {
                int hour = int.Parse(txtHour.Text);
                int minute = int.Parse(txtMinute.Text);
                lblCurrentServerTime.Text = $"Game Time: {hour:D2}:{minute:D2}";
            }
            catch
            {
                lblCurrentServerTime.Text = "Game Time: 00:00";
            }
        }

        private void UpdateRunningGameTime()
        {
            // Show the actual running game time when the timer is active
            var currentGameTime = GetCurrentGameTime();
            lblCurrentServerTime.Text = $"Game Time: {currentGameTime:HH:mm}";
        }

        private DateTime GetCurrentGameTime()
        {
            // Get the set time from input fields
            try
            {
                int hour = int.Parse(txtHour.Text);
                int minute = int.Parse(txtMinute.Text);
                
                // Calculate how much real time has passed since serverTimeBase
                var realTimeElapsed = DateTime.Now - serverTimeBase;
                
                // Apply speed multiplier to the elapsed time
                var acceleratedTimeElapsed = TimeSpan.FromMilliseconds(realTimeElapsed.TotalMilliseconds * speedMultiplier);
                
                // Convert real time to game time (60 real minutes = 24 game hours)
                // 1 in-game hour = 2.5 real minutes (60 ÷ 24 = 2.5)
                var gameTimeElapsed = TimeSpan.FromHours(acceleratedTimeElapsed.TotalMinutes / 2.5);
                
                // Start from the time that was set, not from serverTimeBase
                var setTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
                return setTime.Add(gameTimeElapsed);
            }
            catch
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            }
        }

        private void UpdateCycleStatus()
        {
            if (!isRunning)
            {
                lblCyclePhase.Text = "Cycle Phase: Stopped";
                lblTimeRemaining.Text = "Time Remaining: --:--";
                return;
            }

            // No override; allow automatic switching

            // Get the current game time to determine day/night phase
            var currentGameTime = GetCurrentGameTime();
            var gameHour = currentGameTime.Hour;
            var gameMinute = currentGameTime.Minute;
            var gameSecond = currentGameTime.Second;
            
            string phase;
            int remainingMinutes;
            int remainingSeconds;
            
            // New cycle times:
            // Night: 19:00 – 09:00 
            // Sunrise transition: 09:00 – 09:30 (transition with gamma change)
            // Day: 09:30 – 18:30 
            // Sunset transition: 18:30 – 19:00 (transition with gamma change)
            
            if ((gameHour == 9 && gameMinute < 30))
            {
                // Sunrise transition phase (9:00 AM to 9:30 AM)
                phase = "Sunrise";
                
                // Calculate real-time seconds until day (09:30)
                var gameSecondsUntilDay = (9 * 60 * 60 + 30 * 60) - (gameHour * 60 * 60 + gameMinute * 60 + gameSecond);
                var realSecondsUntilDay = (int)(gameSecondsUntilDay / 24);
                remainingMinutes = realSecondsUntilDay / 60;
                remainingSeconds = realSecondsUntilDay % 60;
            }
            else if ((gameHour > 9 || (gameHour == 9 && gameMinute >= 30)) && (gameHour < 18 || (gameHour == 18 && gameMinute < 30)))
            {
                // Day phase (9:30 AM to 6:30 PM)
                phase = "Day";
                
                // Calculate real-time seconds until sunset (18:30)
                var gameSecondsUntilSunset = (18 * 60 * 60 + 30 * 60) - (gameHour * 60 * 60 + gameMinute * 60 + gameSecond);
                var realSecondsUntilSunset = (int)(gameSecondsUntilSunset / 24);
                remainingMinutes = realSecondsUntilSunset / 60;
                remainingSeconds = realSecondsUntilSunset % 60;
            }
            else if (gameHour == 18 && gameMinute >= 30)
            {
                // Sunset transition phase (6:30 PM to 7:00 PM)
                phase = "Sunset";
                
                // Calculate real-time seconds until night (19:00)
                var gameSecondsUntilNight = (19 * 60 * 60) - (gameHour * 60 * 60 + gameMinute * 60 + gameSecond);
                var realSecondsUntilNight = (int)(gameSecondsUntilNight / 24);
                remainingMinutes = realSecondsUntilNight / 60;
                remainingSeconds = realSecondsUntilNight % 60;
            }
            else
            {
                // Night phase (7:00 PM to 9:00 AM)
                phase = "Night";
                
                // Calculate real-time seconds until sunrise (09:00 next day)
                if (gameHour >= 19)
                {
                    // It's evening/night, calculate until 9:00 AM next day
                    var gameSecondsUntilMidnight = (24 * 60 * 60) - (gameHour * 60 * 60 + gameMinute * 60 + gameSecond);
                    var gameSecondsFromMidnightTo9AM = 9 * 60 * 60;
                    var totalGameSeconds = gameSecondsUntilMidnight + gameSecondsFromMidnightTo9AM;
                    var realSecondsUntilSunrise = (int)(totalGameSeconds / 24);
                    remainingMinutes = realSecondsUntilSunrise / 60;
                    remainingSeconds = realSecondsUntilSunrise % 60;
                }
                else
                {
                    // It's early morning (0-8:59 AM), calculate until 9:00 AM
                    var gameSecondsUntil9AM = (9 * 60 * 60) - (gameHour * 60 * 60 + gameMinute * 60 + gameSecond);
                    var realSecondsUntil9AM = (int)(gameSecondsUntil9AM / 24);
                    remainingMinutes = realSecondsUntil9AM / 60;
                    remainingSeconds = realSecondsUntil9AM % 60;
                }
            }
            
            lblCyclePhase.Text = $"Cycle Phase: {phase}";
            lblTimeRemaining.Text = $"Time Remaining: {remainingMinutes:D2}:{remainingSeconds:D2}";
            
            // Check if phase changed and apply automatic gamma switching
            if (currentPhase != phase)
            {
                currentPhase = phase;
                ApplyAutomaticGamma(phase, gameHour, gameMinute);
            }
            else if (phase == "Sunset" || phase == "Sunrise")
            {
                // Continue applying gradual gamma changes during transitions
                ApplyAutomaticGamma(phase, gameHour, gameMinute);
            }
        }

        private void ApplyAutomaticGamma(string phase, int gameHour, int gameMinute)
        {
            if (phase == "Day")
            {
                ApplyDayGamma();
            }
            else if (phase == "Night")
            {
                ApplyNightGamma();
            }
            else if (phase == "Sunset")
            {
                // Gradual transition from day gamma to night gamma during 18:30-19:00
                ApplyTransitionGamma(gameMinute, true); // true = sunset (day to night)
            }
            else if (phase == "Sunrise")
            {
                // Gradual transition from night gamma to day gamma during 09:00-09:30
                ApplyTransitionGamma(gameMinute, false); // false = sunrise (night to day)
            }
        }

        private void ApplyTransitionGamma(int gameMinute, bool isSunset)
        {
            double progress;
            
            if (isSunset)
            {
                // Sunset: 18:30-19:00 (30 minutes)
                // gameMinute will be 30-59, so we need to map 30-59 to 0.0-1.0
                progress = (gameMinute - 30) / 30.0;
            }
            else
            {
                // Sunrise: 09:00-09:30 (30 minutes)
                // gameMinute will be 0-29, so we map 0-29 to 0.0-1.0
                progress = gameMinute / 30.0;
            }
            
            // Ensure progress stays within bounds
            progress = Math.Max(0.0, Math.Min(1.0, progress));
            
            // Get day and night gamma values from trackbars
            double dayGamma = ConvertTrackbarToGamma(trackDayGamma.Value);
            double nightGamma = ConvertTrackbarToGamma(trackNightGamma.Value);
            
            double targetGamma;
            
            if (isSunset)
            {
                // Sunset: transition from day to night
                targetGamma = dayGamma + (nightGamma - dayGamma) * progress;
            }
            else
            {
                // Sunrise: transition from night to day
                targetGamma = nightGamma + (dayGamma - nightGamma) * progress;
            }
            
            // Apply the calculated gamma value
            gammaController.SetGamma(targetGamma);
        }

        private bool isDayMode = true;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Use global hotkey only (Ctrl+Alt+.); ignore plain '.'
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                if (id == HOTKEY_ID_PERIOD)
                {
                    ToggleDayNight();
                }
            }
            base.WndProc(ref m);
        }

        private void ToggleDayNight()
        {
            // Toggle between day and night by setting representative times and gamma
            isDayMode = !isDayMode;

            if (isDayMode)
            {
                // Day
                txtHour.Text = "12";
                txtMinute.Text = "00";
                serverTimeBase = DateTime.Now;
                ApplyDayGamma();
            }
            else
            {
                // Night
                txtHour.Text = "00";
                txtMinute.Text = "00";
                serverTimeBase = DateTime.Now;
                ApplyNightGamma();
            }

            if (isRunning)
            {
                UpdateRunningGameTime();
            }
            else
            {
                UpdateServerTimeDisplay();
            }
        }

        // Removed gamma override; using ToggleDayNight

        private void txtHotkeyKey_KeyDown(object sender, KeyEventArgs e)
        {
            // Capture key and modifiers for custom hotkey
            e.SuppressKeyPress = true;
            try
            {
                // Update modifier checkboxes if present
                if (chkCtrl != null) chkCtrl.Checked = true; // Always Ctrl+Alt
                if (chkAlt != null) chkAlt.Checked = true;
                if (chkShift != null) chkShift.Checked = false;

                // Store the key pressed (avoid modifier-only keys)
                Keys key = e.KeyCode;
                if (key == Keys.ControlKey || key == Keys.ShiftKey || key == Keys.Menu)
                {
                    // Wait for a non-modifier key
                    return;
                }
                if (txtHotkeyKey != null)
                {
                    txtHotkeyKey.Text = key.ToString();
                }
            }
            catch { }
        }

        private void btnApplyHotkey_Click(object sender, EventArgs e)
        {
            try
            {
                // Build modifiers flag
                uint modifiers = MOD_CONTROL | MOD_ALT; // Always Ctrl+Alt

                // Parse key
                if (txtHotkeyKey == null || string.IsNullOrWhiteSpace(txtHotkeyKey.Text))
                {
                    MessageBox.Show("Choose a hotkey key by clicking the box and pressing a key.");
                    return;
                }

                Keys key;
                if (!Enum.TryParse(txtHotkeyKey.Text, out key))
                {
                    MessageBox.Show("Unrecognized key.");
                    return;
                }

                // Unregister existing
                try { UnregisterHotKey(this.Handle, HOTKEY_ID_PERIOD); } catch { }

                // Register new
                if (!RegisterHotKey(this.Handle, HOTKEY_ID_PERIOD, modifiers, (uint)key))
                {
                    MessageBox.Show("Failed to register hotkey. It might be in use by another app.");
                    return;
                }

                // Update hint label
                currentHotkeyKey = key;
                string hint = BuildHotkeyHint(modifiers, currentHotkeyKey);
                if (lblKeybindHint != null)
                {
                    lblKeybindHint.Text = hint;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying hotkey: {ex.Message}");
            }
        }

        private string BuildHotkeyHint(uint modifiers, Keys key)
        {
            var parts = new List<string>();
            if ((modifiers & MOD_CONTROL) != 0) parts.Add("Ctrl");
            if ((modifiers & MOD_ALT) != 0) parts.Add("Alt");
            if ((modifiers & MOD_SHIFT) != 0) parts.Add("Shift");
            parts.Add(KeyToDisplay(key));
            return "Press " + string.Join("+", parts) + " to toggle";
        }

        private string KeyToDisplay(Keys key)
        {
            if (key == Keys.OemPeriod) return ".";
            return key.ToString();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private void TrySetFormIconFromPng(string pngPath)
        {
            try
            {
                if (System.IO.File.Exists(pngPath))
                {
                    using (var bitmap = new Bitmap(pngPath))
                    {
                        IntPtr hIcon = bitmap.GetHicon();
                        using (var icon = Icon.FromHandle(hIcon))
                        {
                            // Clone to detach from HICON before destroying it
                            this.Icon = (Icon)icon.Clone();
                        }
                        DestroyIcon(hIcon);
                    }
                }
            }
            catch
            {
                // Ignore icon errors; keep default icon
            }
        }

        private void grpTimeSettings_Enter(object sender, EventArgs e)
        {

        }
    }
}
