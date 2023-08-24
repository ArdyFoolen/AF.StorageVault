using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AF.StorageVault
{
    public partial class PasswordItemControl : UserControl
    {
        private StorageItemController storageItemController;
        public string ItemName
        {
            get
            {
                return item?.Name ?? string.Empty;
            }
            set
            {
                if (item != null)
                    item.Name = value;
            }
        }
        public int ItemId { get; set; }

        private PasswordItem? item
        {
            get
            {
                return (PasswordItem?)storageItemController.Get(ItemId);
            }
        }

        public PasswordItemControl(StorageItemController storageItemController, int itemId)
        {
            InitializeComponent();

            pwdTextControl.Enabled = false;
            pwdTextControl.UseSystemPasswordChar = true;
            pwdTextControl.Click += getBtnClickHandler();

            this.storageItemController = storageItemController;
            this.ItemId = itemId;

            if (storageItemController.Exists(itemId))
            {
                txtLink.Text = item?.Link ?? string.Empty;
                txtUser.Text = item?.User ?? string.Empty;
                txtEmail.Text = item?.Email ?? string.Empty;
                pwdTextControl.Text = item?.Password ?? string.Empty;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ToggleEnabled();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                item.Link = txtLink.Text;
                item.User = txtUser.Text;
                item.Email = txtEmail.Text;
                item.Password = pwdTextControl.Text;
            }

            ToggleEnabled();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ToggleEnabled();
        }

        private void ToggleEnabled()
        {
            btnUpdate.Visible = !btnUpdate.Visible;
            btnSave.Visible = !btnUpdate.Visible;
            btnCancel.Visible = !btnUpdate.Visible;

            txtLink.Enabled = !txtLink.Enabled;
            txtUser.Enabled = !txtUser.Enabled;
            txtEmail.Enabled = !txtEmail.Enabled;
            pwdTextControl.Enabled = !pwdTextControl.Enabled;
        }

        private void PasswordItemControl_Leave(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            txtLink.Enabled = false;
            txtUser.Enabled = false;
            txtEmail.Enabled = false;
            pwdTextControl.Enabled = false;

            this.Hide();
        }

        private EventHandler getBtnClickHandler()
            => (sender, e) => pwdTextControl.UseSystemPasswordChar = !pwdTextControl.UseSystemPasswordChar;

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox? textBox = sender.As<ToolStripItem>()?.Owner.As<ContextMenuStrip>()?.SourceControl.As<TextBox>();
            if (textBox != null)
                Clipboard.SetText(textBox.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox? textBox = sender.As<ToolStripItem>()?.Owner.As<ContextMenuStrip>()?.SourceControl.As<TextBox>();
            if (textBox != null)
                textBox.Text = Clipboard.GetText();
        }

        private void txtLink_MouseDown(object sender, MouseEventArgs e)
        {
            mnuTextboxShow(sender, e);
        }

        private void txtUser_MouseDown(object sender, MouseEventArgs e)
        {
            mnuTextboxShow(sender, e);
        }

        private void txtEmail_MouseDown(object sender, MouseEventArgs e)
        {
            mnuTextboxShow(sender, e);
        }

        private void pwdTextControl_MouseDown(object sender, MouseEventArgs e)
        {
            mnuTextboxShow(sender, e);
        }

        /// <summary>
        /// Gets called when children are enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTextboxShow(object sender, MouseEventArgs e)
        {
            ResetTimer();
            foreach (ToolStripMenuItem item in mnuTextbox.Items)
                item.Enabled = true;
            if (e.Button == MouseButtons.Right)
                mnuTextbox.Show((Control)sender, new Point(e.X, e.Y));
        }

        /// <summary>
        /// Gets called when children are disabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordItemControl_MouseDown(object sender, MouseEventArgs e)
        {
            ResetTimer();
            Control ctrl = this.GetChildAtPoint(e.Location);

            if (e.Button == MouseButtons.Left && ctrl is PwdTextboxControl)
            {
                ((PwdTextboxControl)ctrl).PerformClick(e.Location);
                return;
            }

            if (e.Button != MouseButtons.Right)
                return;

            if (ctrl != null)
            {
                ContextMenuStrip menu = ctrl.ContextMenuStrip;
                foreach (ToolStripMenuItem item in menu.Items)
                    if (item.AccessibilityObject.Name == "Paste")
                        item.Enabled = false;
                menu.Show(ctrl, e.Location.Minus(ctrl.Location));
            }
        }

        private void ResetTimer()
        {
            var form = this.Parent?.Parent?.Parent as StorageVaultForm;
            if (form != null)
                form.ResetTimer();
        }

        private void PasswordItemControl_MouseMove(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }

        private void txtLink_Enter(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void pwdTextControl_Enter(object sender, EventArgs e)
        {
            ResetTimer();
        }
    }
}
