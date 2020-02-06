namespace SharpLocker
{
    partial class LockScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockScreenForm));
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LockedLabel = new System.Windows.Forms.Label();
            this.textboxBackground = new System.Windows.Forms.Button();
            this.SubmitPasswordButton = new System.Windows.Forms.Button();
            this.language = new System.Windows.Forms.Button();
            this.accessibility = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.power = new System.Windows.Forms.Button();
            this.ProfileIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.White;
            this.UserNameLabel.Location = new System.Drawing.Point(235, 266);
            this.UserNameLabel.MinimumSize = new System.Drawing.Size(403, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(403, 55);
            this.UserNameLabel.TabIndex = 4;
            this.UserNameLabel.Text = "label2";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserNameLabel.Click += new System.EventHandler(this.UserNameLabel_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.White;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft YaHei Light", 11F);
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PasswordTextBox.Location = new System.Drawing.Point(245, 330);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(325, 20);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // LockedLabel
            // 
            this.LockedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LockedLabel.AutoSize = true;
            this.LockedLabel.BackColor = System.Drawing.Color.Transparent;
            this.LockedLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockedLabel.ForeColor = System.Drawing.Color.White;
            this.LockedLabel.Location = new System.Drawing.Point(463, 308);
            this.LockedLabel.Name = "LockedLabel";
            this.LockedLabel.Size = new System.Drawing.Size(0, 25);
            this.LockedLabel.TabIndex = 8;
            this.LockedLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // textboxBackground
            // 
            this.textboxBackground.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textboxBackground.AutoSize = true;
            this.textboxBackground.BackColor = System.Drawing.Color.White;
            this.textboxBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.textboxBackground.Enabled = false;
            this.textboxBackground.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.textboxBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textboxBackground.Location = new System.Drawing.Point(245, 324);
            this.textboxBackground.Name = "textboxBackground";
            this.textboxBackground.Size = new System.Drawing.Size(361, 35);
            this.textboxBackground.TabIndex = 5;
            this.textboxBackground.UseVisualStyleBackColor = false;
            // 
            // SubmitPasswordButton
            // 
            this.SubmitPasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubmitPasswordButton.AutoSize = true;
            this.SubmitPasswordButton.BackColor = System.Drawing.Color.Transparent;
            this.SubmitPasswordButton.BackgroundImage = global::SharpLocker.Properties.Resources.arrow;
            this.SubmitPasswordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubmitPasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.SubmitPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitPasswordButton.Location = new System.Drawing.Point(569, 324);
            this.SubmitPasswordButton.Margin = new System.Windows.Forms.Padding(0);
            this.SubmitPasswordButton.Name = "SubmitPasswordButton";
            this.SubmitPasswordButton.Size = new System.Drawing.Size(35, 35);
            this.SubmitPasswordButton.TabIndex = 9;
            this.SubmitPasswordButton.UseVisualStyleBackColor = false;
            this.SubmitPasswordButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // language
            // 
            this.language.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.language.AutoSize = true;
            this.language.BackColor = System.Drawing.Color.Transparent;
            this.language.BackgroundImage = global::SharpLocker.Properties.Resources.language;
            this.language.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.language.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.language.FlatAppearance.BorderSize = 0;
            this.language.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.language.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.language.Location = new System.Drawing.Point(772, 466);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(35, 35);
            this.language.TabIndex = 13;
            this.language.UseVisualStyleBackColor = false;
            // 
            // accessibility
            // 
            this.accessibility.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accessibility.AutoSize = true;
            this.accessibility.BackColor = System.Drawing.Color.Transparent;
            this.accessibility.BackgroundImage = global::SharpLocker.Properties.Resources.accessibility;
            this.accessibility.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.accessibility.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.accessibility.FlatAppearance.BorderSize = 0;
            this.accessibility.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.accessibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accessibility.Location = new System.Drawing.Point(813, 466);
            this.accessibility.Name = "accessibility";
            this.accessibility.Size = new System.Drawing.Size(35, 35);
            this.accessibility.TabIndex = 12;
            this.accessibility.UseVisualStyleBackColor = false;
            // 
            // show
            // 
            this.show.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.show.AutoSize = true;
            this.show.BackColor = System.Drawing.Color.White;
            this.show.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("show.BackgroundImage")));
            this.show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.show.FlatAppearance.BorderSize = 0;
            this.show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show.Location = new System.Drawing.Point(535, 324);
            this.show.Margin = new System.Windows.Forms.Padding(0);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(35, 35);
            this.show.TabIndex = 11;
            this.show.TabStop = false;
            this.show.UseVisualStyleBackColor = false;
            // 
            // power
            // 
            this.power.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.power.AutoSize = true;
            this.power.BackColor = System.Drawing.Color.Transparent;
            this.power.BackgroundImage = global::SharpLocker.Properties.Resources.power;
            this.power.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.power.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.power.FlatAppearance.BorderSize = 0;
            this.power.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.power.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.power.Location = new System.Drawing.Point(854, 466);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(35, 35);
            this.power.TabIndex = 10;
            this.power.UseVisualStyleBackColor = false;
            // 
            // ProfileIcon
            // 
            this.ProfileIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProfileIcon.BackColor = System.Drawing.Color.Transparent;
            this.ProfileIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfileIcon.Image = global::SharpLocker.Properties.Resources.usericon;
            this.ProfileIcon.Location = new System.Drawing.Point(334, 51);
            this.ProfileIcon.Name = "ProfileIcon";
            this.ProfileIcon.Size = new System.Drawing.Size(199, 199);
            this.ProfileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfileIcon.TabIndex = 1;
            this.ProfileIcon.TabStop = false;
            this.ProfileIcon.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LockScreenForm
            // 
            this.AcceptButton = this.SubmitPasswordButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(903, 513);
            this.Controls.Add(this.language);
            this.Controls.Add(this.accessibility);
            this.Controls.Add(this.show);
            this.Controls.Add(this.power);
            this.Controls.Add(this.SubmitPasswordButton);
            this.Controls.Add(this.LockedLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.ProfileIcon);
            this.Controls.Add(this.textboxBackground);
            this.Name = "LockScreenForm";
            this.Text = "LockScreenForm";
            this.Load += new System.EventHandler(this.LockScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ProfileIcon;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label LockedLabel;
        private System.Windows.Forms.Button SubmitPasswordButton;
        private System.Windows.Forms.Button textboxBackground;
        private System.Windows.Forms.Button power;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.Button accessibility;
        private System.Windows.Forms.Button language;
    }
}

