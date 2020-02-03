namespace WindowsFormsApp9
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LockedLabel = new System.Windows.Forms.Label();
            this.ProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.LoginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 33F);
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(246, 217);
            this.NameLabel.MinimumSize = new System.Drawing.Size(403, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(403, 60);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "label2";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.PasswordTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.PasswordTextBox.Location = new System.Drawing.Point(244, 324);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(364, 38);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // LockedLabel
            // 
            this.LockedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LockedLabel.AutoSize = true;
            this.LockedLabel.BackColor = System.Drawing.Color.Transparent;
            this.LockedLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockedLabel.ForeColor = System.Drawing.Color.White;
            this.LockedLabel.Location = new System.Drawing.Point(412, 277);
            this.LockedLabel.Name = "LockedLabel";
            this.LockedLabel.Size = new System.Drawing.Size(71, 25);
            this.LockedLabel.TabIndex = 8;
            this.LockedLabel.Text = "Locked";
            // 
            // ProfilePictureBox
            // 
            this.ProfilePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProfilePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ProfilePictureBox.Image = global::WindowsFormsApp9.Properties.Resources.thumb_14400082930User;
            this.ProfilePictureBox.Location = new System.Drawing.Point(345, 31);
            this.ProfilePictureBox.Name = "ProfilePictureBox";
            this.ProfilePictureBox.Size = new System.Drawing.Size(199, 199);
            this.ProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePictureBox.TabIndex = 1;
            this.ProfilePictureBox.TabStop = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginButton.AutoSize = true;
            this.LoginButton.BackColor = System.Drawing.Color.Transparent;
            this.LoginButton.BackgroundImage = global::WindowsFormsApp9.Properties.Resources.arrow;
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginButton.Location = new System.Drawing.Point(597, 324);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(45, 38);
            this.LoginButton.TabIndex = 9;
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // LockScreenForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.LockedLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ProfilePictureBox);
            this.Name = "LockScreenForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ProfilePictureBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label LockedLabel;
        private System.Windows.Forms.Button LoginButton;
    }
}

