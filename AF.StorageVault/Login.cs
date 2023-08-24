namespace AF.StorageVault
{
    public partial class Login : Form
    {
        private PasswordHandler passwordHandler;

        public Login(PasswordHandler passwordHandler)
        {
            InitializeComponent();
            this.passwordHandler = passwordHandler;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var password = passwordHandler.Decrypt();
                if (SecurePasswordHasher.Verify(txtPassword.Text, password))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Error: Password not correct";
                    lblError.Visible = true;
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error: Password not correct";
                lblError.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            using (var register = new Register(passwordHandler))
            {
                register.ShowDialog();
            }

            this.Visible = true;
        }
    }
}
