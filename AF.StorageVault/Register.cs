using System.Security.Principal;

namespace AF.StorageVault
{
    public partial class Register : Form
    {
        private PasswordHandler passwordHandler;

        public Register(PasswordHandler passwordHandler)
        {
            InitializeComponent();
            this.passwordHandler = passwordHandler;
            this.AcceptButton = btnRegister;
            if (!passwordHandler.FileExists() || !IsElevated)
                btnDelete.Visible = false;
        }

        private bool IsElevated
        {
            get => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                passwordHandler.Encrypt(txtPassword.Text);
                if (IsElevated)
                    btnDelete.Visible = true;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            if (passwordHandler.FileExists())
                result = MessageBox.Show("Are you sure?\nWhen deleting the registration, stored data becomes inaccesible", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                passwordHandler.Delete();

                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
    }
}
