using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsApp9
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
            Image myimage = new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper"));
            //---


            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
            NameLabel.Text = userName;
            NameLabel.BackColor = System.Drawing.Color.Transparent;
            int usernameloch = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usericonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 29;
            int buttonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usernameh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 50;
            int locked = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 57;

            PasswordTextBox.Top = usernameloch;
            ProfilePictureBox.Top = usericonh;
            LoginButton.Top = buttonh;
            NameLabel.Top = usernameh;
            LockedLabel.Top = locked;
            PasswordTextBox.UseSystemPasswordChar = true;

            //Get the username. This returns Domain\Username
            string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //Set the text
            NameLabel.Text = userNameText.Split('\\')[1];

            //https://stackoverflow.com/questions/7731855/rounded-edges-in-picturebox-c-sharp
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, ProfilePictureBox.Width - 3, ProfilePictureBox.Height - 3);
            Region rg = new Region(gp);
            ProfilePictureBox.Region = rg;
            ProfilePictureBox.Image = Image.FromFile(GetUserTilePath(userNameText.Split('\\')[1]));

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
            catch (Exception ex)
            {
                // log errors
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(PasswordTextBox);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Taskbar.Show();
            Application.Exit();
        }
    }
    

}
