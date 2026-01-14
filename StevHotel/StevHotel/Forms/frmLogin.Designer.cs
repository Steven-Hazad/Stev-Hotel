namespace StevHotel.Forms
{
    partial class frmLogin
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
            pnlMain = new Panel();
            pnlLoginCard = new Panel();
            lblError = new Label();
            pnlDivider = new Panel();
            btnLogin = new Button();
            pnlPasswordWrapper = new Panel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            pnlUsernameWrapper = new Panel();
            txtUsername = new TextBox();
            lblUsername = new Label();
            pnlBranding = new Panel();
            picLogo = new PictureBox();
            pnlMain.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlPasswordWrapper.SuspendLayout();
            pnlUsernameWrapper.SuspendLayout();
            pnlBranding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlLoginCard);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(40);
            pnlMain.Size = new Size(500, 650);
            pnlMain.TabIndex = 0;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.BackColor = Color.White;
            pnlLoginCard.Controls.Add(lblError);
            pnlLoginCard.Controls.Add(pnlDivider);
            pnlLoginCard.Controls.Add(btnLogin);
            pnlLoginCard.Controls.Add(pnlPasswordWrapper);
            pnlLoginCard.Controls.Add(pnlUsernameWrapper);
            pnlLoginCard.Controls.Add(pnlBranding);
            pnlLoginCard.Dock = DockStyle.Fill;
            pnlLoginCard.Location = new Point(40, 40);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(420, 570);
            pnlLoginCard.TabIndex = 0;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Black;
            lblError.Location = new Point(60, 520);
            lblError.Name = "lblError";
            lblError.Size = new Size(300, 40);
            lblError.TabIndex = 5;
            lblError.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.Black;
            pnlDivider.Location = new Point(60, 250);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(300, 2);
            pnlDivider.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(60, 455);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 50);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "SIGN IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // pnlPasswordWrapper
            // 
            pnlPasswordWrapper.BackColor = Color.White;
            pnlPasswordWrapper.Controls.Add(txtPassword);
            pnlPasswordWrapper.Controls.Add(lblPassword);
            pnlPasswordWrapper.Location = new Point(60, 370);
            pnlPasswordWrapper.Name = "pnlPasswordWrapper";
            pnlPasswordWrapper.Size = new Size(300, 70);
            pnlPasswordWrapper.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(0, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.Size = new Size(300, 22);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Admin@2025";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(0, 5);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 19);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            // 
            // pnlUsernameWrapper
            // 
            pnlUsernameWrapper.BackColor = Color.White;
            pnlUsernameWrapper.Controls.Add(txtUsername);
            pnlUsernameWrapper.Controls.Add(lblUsername);
            pnlUsernameWrapper.Location = new Point(60, 285);
            pnlUsernameWrapper.Name = "pnlUsernameWrapper";
            pnlUsernameWrapper.Size = new Size(300, 70);
            pnlUsernameWrapper.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(0, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Enter username";
            txtUsername.Size = new Size(300, 22);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "Admin1";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(0, 5);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(76, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // pnlBranding
            // 
            pnlBranding.Controls.Add(picLogo);
            pnlBranding.Dock = DockStyle.Top;
            pnlBranding.Location = new Point(0, 0);
            pnlBranding.Name = "pnlBranding";
            pnlBranding.Padding = new Padding(60, 40, 60, 20);
            pnlBranding.Size = new Size(420, 240);
            pnlBranding.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.White;
            picLogo.Image = Properties.Resources.unnamed__1_1;
            picLogo.Location = new Point(0, 40);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(417, 183);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 650);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stev-Hotel - Login";
            pnlMain.ResumeLayout(false);
            pnlLoginCard.ResumeLayout(false);
            pnlPasswordWrapper.ResumeLayout(false);
            pnlPasswordWrapper.PerformLayout();
            pnlUsernameWrapper.ResumeLayout(false);
            pnlUsernameWrapper.PerformLayout();
            pnlBranding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlLoginCard;
        private Panel pnlBranding;
        private PictureBox picLogo;
        private Panel pnlUsernameWrapper;
        private Label lblUsername;
        private TextBox txtUsername;
        private Panel pnlPasswordWrapper;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private Panel pnlDivider;
        private Label lblError;
    }
}