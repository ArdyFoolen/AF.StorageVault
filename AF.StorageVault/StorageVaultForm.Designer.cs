namespace AF.StorageVault
{
    partial class StorageVaultForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageVaultForm));
            splitContainer1 = new SplitContainer();
            storageTypeControl1 = new StorageTypeControl();
            lstStorage = new ListBox();
            mnuLstStorage = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            mnuLstStorage.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(storageTypeControl1);
            splitContainer1.Panel1.Controls.Add(lstStorage);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.MouseMove += splitContainer1_Panel2_MouseMove;
            splitContainer1.Size = new Size(700, 338);
            splitContainer1.SplitterDistance = 231;
            splitContainer1.TabIndex = 0;
            // 
            // storageTypeControl1
            // 
            storageTypeControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            storageTypeControl1.AutoSize = true;
            storageTypeControl1.Location = new Point(10, 9);
            storageTypeControl1.Margin = new Padding(3, 2, 3, 2);
            storageTypeControl1.Name = "storageTypeControl1";
            storageTypeControl1.Size = new Size(218, 43);
            storageTypeControl1.StorageVault = null;
            storageTypeControl1.TabIndex = 1;
            // 
            // lstStorage
            // 
            lstStorage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstStorage.FormattingEnabled = true;
            lstStorage.ItemHeight = 15;
            lstStorage.Location = new Point(10, 56);
            lstStorage.Margin = new Padding(3, 2, 3, 2);
            lstStorage.Name = "lstStorage";
            lstStorage.Size = new Size(218, 274);
            lstStorage.TabIndex = 0;
            lstStorage.MouseDown += lstStorage_MouseDown;
            lstStorage.MouseMove += lstStorage_MouseMove;
            // 
            // mnuLstStorage
            // 
            mnuLstStorage.ImageScalingSize = new Size(20, 20);
            mnuLstStorage.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem, renameToolStripMenuItem });
            mnuLstStorage.Name = "contextMenuStrip1";
            mnuLstStorage.Size = new Size(118, 48);
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(117, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeLstStorageItem_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(117, 22);
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameLstStorageItem_Click;
            // 
            // StorageVaultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "StorageVaultForm";
            Text = "Storage Vault";
            WindowState = FormWindowState.Maximized;
            FormClosed += StorageVaultForm_FormClosed;
            Load += StorageVault_Load;
            KeyDown += StorageVaultForm_KeyDown;
            MouseMove += StorageVaultForm_MouseMove;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            mnuLstStorage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox lstStorage;
        private ContextMenuStrip mnuLstStorage;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private StorageTypeControl storageTypeControl1;
        //private StorageTypeControl storageTypeControl;
    }
}