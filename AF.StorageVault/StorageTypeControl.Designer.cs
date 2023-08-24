namespace AF.StorageVault
{
    partial class StorageTypeControl
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
            cmbItemControl = new ComboBox();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // cmbItemControl
            // 
            cmbItemControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbItemControl.FormattingEnabled = true;
            cmbItemControl.Location = new Point(100, 12);
            cmbItemControl.Name = "cmbItemControl";
            cmbItemControl.Size = new Size(140, 28);
            cmbItemControl.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 11);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // StorageTypeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btnAdd);
            Controls.Add(cmbItemControl);
            Name = "StorageTypeControl";
            Size = new Size(251, 53);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbItemControl;
        private Button btnAdd;
    }
}
