using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Timer = System.Windows.Forms.Timer;

namespace AF.StorageVault
{
    public interface IStorageVault
    {
        PasswordItemControl? SelectedControl { get; set; }
    }
    public partial class StorageVaultForm : Form, IStorageVault
    {
        #region Fields & Properties

        private PasswordHandler passwordHandler;
        private StorageItemController storageItemController;
        private Timer timer;

        private new const char Enter = (char)13;
        private const char Escape = (char)27;

        private TextBox editBox = new TextBox();
        private int delta = 3;

        private PasswordItemControl? selectedControl;
        public PasswordItemControl? SelectedControl
        {
            get
            {
                return selectedControl;
            }
            set
            {
                selectedControl = value;
                if (selectedControl != null)
                {
                    SelectedIndex = lstStorage.Items.Add(selectedControl);
                    splitContainer1.Panel2.Controls.Add(selectedControl);
                }
            }
        }
        private int SelectedIndex { get; set; }

        #endregion

        #region ctors

        public StorageVaultForm(PasswordHandler passwordHandler, StorageItemController storageItemController)
        {
            InitializeComponent();

            storageTypeControl1.StorageVault = this;
            this.storageItemController = storageItemController;
            storageTypeControl1.Initialize(storageItemController);
            this.passwordHandler = passwordHandler;

            lstStorage.DisplayMember = "ItemName";
            lstStorage.ValueMember = "ItemId";

            CreateEditBox();

            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
        }

        #endregion

        #region StorageVaultForm

        private void StorageVault_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            using (var login = new Login(passwordHandler))
            {
                if (login.ShowDialog() != DialogResult.OK)
                    this.Close();
                else
                {
                    this.Visible = true;

                    var items = storageItemController.Load();
                    StorageFactory factory = new StorageFactory(storageItemController);
                    foreach (var item in items)
                    {
                        item.Accept(factory);
                        SelectedControl = factory.ItemControl;
                    }

                    timer.Enabled = true;
                    timer.Start();
                }
            }
        }

        public void ResetTimer()
        {
            timer.Stop();
            timer.Start();
        }

        private void StorageVaultForm_KeyDown(object sender, KeyEventArgs e)
        {
            ResetTimer();
        }

        private void StorageVaultForm_MouseMove(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            this.Visible = false;
            using (var login = new Login(passwordHandler))
            {
                if (login.ShowDialog() != DialogResult.OK)
                    this.Close();
                else
                {
                    this.Visible = true;
                    timer.Start();
                }
            }
        }

        private void StorageVaultForm_FormClosed(object sender, FormClosedEventArgs e)
            => storageItemController.Store();

        #endregion

        #region lstStorage

        private void lstStorage_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var item in lstStorage.Items)
            {
                ((PasswordItemControl)item).Hide();
            }

            SelectedIndex = this.lstStorage.IndexFromPoint(e.Location);
            if (SelectedIndex != ListBox.NoMatches)
            {
                lstStorage.SetSelected(SelectedIndex, true);
                selectedControl = (PasswordItemControl)lstStorage.Items[SelectedIndex];
                selectedControl.Show();
                if (e.Button == MouseButtons.Right)
                    mnuLstStorage.Show(lstStorage, new Point(e.X, e.Y));
            }
        }

        private void removeLstStorageItem_Click(object sender, EventArgs e)
        {
            if (SelectedControl != null)
            {
                storageItemController.Remove(SelectedControl.ItemId);
                lstStorage.Items.Remove(SelectedControl);
                splitContainer1.Panel2.Controls.Remove(SelectedControl);
                SelectedControl = null;
            }
            SelectedIndex = -1;
        }

        private void renameLstStorageItem_Click(object sender, EventArgs e)
            => ShowEditBox();

        #endregion

        #region EditBox

        private void CreateEditBox()
        {
            editBox = new TextBox();
            editBox.Location = new Point(0, 0);
            editBox.Size = new Size(0, 0);
            editBox.Hide();
            editBox.Text = "";
            editBox.BackColor = Color.Beige;
            editBox.Font = new Font("Varanda", 15, FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Pixel);
            editBox.ForeColor = Color.Blue;
            editBox.BorderStyle = BorderStyle.FixedSingle;
            editBox.KeyPress += EditBox_KeyPress;
            editBox.Leave += EditBox_Leave;
            lstStorage.Controls.AddRange(new Control[] { this.editBox });
        }

        private void ShowEditBox()
        {
            Rectangle r = lstStorage.GetItemRectangle(SelectedIndex);
            editBox.Location = new Point(r.X + delta, r.Y + delta);
            editBox.Size = new Size(r.Width - 10, r.Height - delta);
            editBox.Show();
            editBox.Text = SelectedControl?.ItemName ?? string.Empty;
            editBox.Focus();
            editBox.SelectAll();
        }

        private void EditBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case Enter:
                    if (SelectedControl != null)
                    {
                        SelectedControl.ItemName = editBox.Text;
                        lstStorage.Items[SelectedIndex] = SelectedControl;
                    }
                    editBox.Hide();
                    break;
                case Escape:
                    editBox.Hide();
                    break;
            }
        }

        private void EditBox_Leave(object? sender, EventArgs e)
            => editBox.Hide();

        #endregion

        private void lstStorage_MouseMove(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }

        private void splitContainer1_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }
    }
}