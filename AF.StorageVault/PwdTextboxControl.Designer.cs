namespace AF.StorageVault
{
    partial class PwdTextboxControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPassword = new TextBox();
            btnPasswordEye = new Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(1, 2);
            txtPassword.MaxLength = 30;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 20);
            txtPassword.TabIndex = 0;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.MouseDown += txtPassword_MouseDown;
            // 
            // btnPasswordEye
            // 
            btnPasswordEye.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnPasswordEye.AutoSize = true;
            btnPasswordEye.BackColor = Color.White;
            btnPasswordEye.BackgroundImage = Properties.Resources.PasswordEyeImage;
            btnPasswordEye.BackgroundImageLayout = ImageLayout.Zoom;
            btnPasswordEye.FlatAppearance.BorderSize = 0;
            btnPasswordEye.FlatStyle = FlatStyle.Flat;
            btnPasswordEye.ForeColor = Color.Black;
            btnPasswordEye.Location = new Point(101, 1);
            btnPasswordEye.Name = "btnPasswordEye";
            btnPasswordEye.Size = new Size(21, 21);
            btnPasswordEye.TabIndex = 1;
            btnPasswordEye.UseVisualStyleBackColor = false;
            btnPasswordEye.Click += btnPasswordEye_Click;
            // 
            // PasswordTextboxControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(txtPassword);
            Controls.Add(btnPasswordEye);
            Name = "PasswordTextboxControl";
            Size = new Size(127, 24);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Button btnPasswordEye;
    }
}
