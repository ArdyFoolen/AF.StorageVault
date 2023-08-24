using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AF.StorageVault
{
    public partial class PwdTextboxControl : UserControl
    {
        public PwdTextboxControl()
        {
            InitializeComponent();
        }

        public new event EventHandler? Click;
        public new event MouseEventHandler? MouseDown;
        public new event EventHandler? Enter;

        /// <summary>
        /// location is relative location within the parent control
        /// </summary>
        /// <param name="location"></param>
        public void PerformClick(Point location)
        {
            if (this.GetChildAtPoint(location.Minus(this.Location)) is Button && Click != null)
                Click(this.btnPasswordEye, new EventArgs());
        }

        private void btnPasswordEye_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(sender, e);
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(sender, e);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (Enter != null)
                Enter(sender, e);
        }

        public new string? Text { get => txtPassword.Text; set => txtPassword.Text = value; }

        public bool UseSystemPasswordChar
        { get => txtPassword.UseSystemPasswordChar; set => txtPassword.UseSystemPasswordChar = value; }

        public new bool Enabled
        {
            get
            {
                return txtPassword.Enabled;
            }
            set
            {
                base.Enabled = value;
                txtPassword.Enabled = value;
                SetBackgroundColor();
            }
        }

        public override ContextMenuStrip ContextMenuStrip { get => txtPassword.ContextMenuStrip; set => txtPassword.ContextMenuStrip = value; }

        private void SetBackgroundColor()
        {
            if (Enabled)
            {
                btnPasswordEye.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
                this.BackColor = Color.White;
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                btnPasswordEye.BackColor = SystemColors.Control;
                txtPassword.BackColor = SystemColors.Control;
                this.BackColor = SystemColors.Control;
                this.BorderStyle = BorderStyle.Fixed3D;
            }
        }
    }
}
