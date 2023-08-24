namespace AF.StorageVault
{
    partial class PasswordItemControl
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtLink = new TextBox();
            mnuTextbox = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            txtUser = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnUpdate = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            pwdTextControl = new PwdTextboxControl();
            mnuTextbox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "Link";
            // 
            // txtLink
            // 
            txtLink.ContextMenuStrip = mnuTextbox;
            txtLink.Enabled = false;
            txtLink.Location = new Point(143, 17);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(375, 27);
            txtLink.TabIndex = 0;
            txtLink.Enter += txtLink_Enter;
            txtLink.MouseDown += txtLink_MouseDown;
            // 
            // mnuTextbox
            // 
            mnuTextbox.ImageScalingSize = new Size(20, 20);
            mnuTextbox.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem });
            mnuTextbox.Name = "mnuTextbox";
            mnuTextbox.Size = new Size(113, 52);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(112, 24);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(112, 24);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // txtUser
            // 
            txtUser.ContextMenuStrip = mnuTextbox;
            txtUser.Enabled = false;
            txtUser.Location = new Point(143, 51);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(375, 27);
            txtUser.TabIndex = 1;
            txtUser.Enter += txtUser_Enter;
            txtUser.MouseDown += txtUser_MouseDown;
            // 
            // txtEmail
            // 
            txtEmail.ContextMenuStrip = mnuTextbox;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(143, 83);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(375, 27);
            txtEmail.TabIndex = 2;
            txtEmail.Enter += txtEmail_Enter;
            txtEmail.MouseDown += txtEmail_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 53);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 5;
            label2.Text = "User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 85);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 119);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(3, 197);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 197);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.TabStop = false;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(103, 197);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // pwdTextControl
            // 
            pwdTextControl.BackColor = Color.White;
            pwdTextControl.BorderStyle = BorderStyle.FixedSingle;
            pwdTextControl.ContextMenuStrip = mnuTextbox;
            pwdTextControl.Location = new Point(142, 116);
            pwdTextControl.Name = "pwdTextControl";
            pwdTextControl.Size = new Size(376, 30);
            pwdTextControl.TabIndex = 3;
            pwdTextControl.UseSystemPasswordChar = false;
            pwdTextControl.MouseDown += pwdTextControl_MouseDown;
            pwdTextControl.Enter += pwdTextControl_Enter;
            // 
            // PasswordItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pwdTextControl);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(txtUser);
            Controls.Add(txtLink);
            Controls.Add(label1);
            Name = "PasswordItemControl";
            Size = new Size(599, 229);
            Leave += PasswordItemControl_Leave;
            MouseDown += PasswordItemControl_MouseDown;
            MouseMove += PasswordItemControl_MouseMove;
            mnuTextbox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLink;
        private TextBox txtUser;
        private TextBox txtEmail;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnUpdate;
        private Button btnSave;
        private Button btnCancel;
        private PwdTextboxControl pwdTextControl;
        private ContextMenuStrip mnuTextbox;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
    }
}
