using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
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
            TopMost = true;
            
            string userName = Environment.UserName;
            UserNameLabel.Text = userName;
            UserNameLabel.BackColor = Color.Transparent;
            
            int usernameloch = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usericonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 29;
            int buttonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usernameh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 50;
            int locked = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 57;
           
            PasswordTextBox.Top = usernameloch;
            PasswordTextBox.UseSystemPasswordChar = true;
            ProfileIcon.Top = usericonh;
            SubmitPasswordButton.Top = buttonh;
            UserNameLabel.Top = usernameh;
            LockedLabel.Top = locked;
            
            foreach (var screen in Screen.AllScreens)
            {
                Thread thread = new Thread(() => WorkThreadFunction(screen));
                thread.Start();
            }
        }

        public void WorkThreadFunction(Screen screen)
        {
            try
            {
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
            catch (Exception ex)
            {
                // log errors
            }
        }

        public string getSpotlightImage()
        { 
            //Get Windows Spotlight Images Location Path.      C:\Users\[Username]\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\
            string spotlight_dir_path = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\");
            
            /* Save the name of the larger image from spotlight dir.
             * Normally the larger image present in this directory is the current lock screen image. */
            string img_name = "";
            
            //Save image path plus extension
            string new_jpg_path = "";
            
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

            new_jpg_path = Path.Combine(spotlight_dir_path, img_name + ".jpg");

            if(!File.Exists(new_jpg_path)) //prevent copy error after multiples app runs
                File.Copy(Path.Combine(spotlight_dir_path, img_name), new_jpg_path);

            return new_jpg_path;
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
            Taskbar.Show();
            base.OnClosing(e);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(PasswordTextBox);
        }

        private void SubmitPasswordButton_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            Application.Exit();
        }
    }
}
