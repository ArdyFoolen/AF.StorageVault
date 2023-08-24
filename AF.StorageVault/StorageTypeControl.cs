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
    public partial class StorageTypeControl : UserControl
    {
        public IStorageVault? StorageVault { get; set; }

        public StorageTypeControl()
        {
            InitializeComponent();
        }

        public void Initialize(StorageItemController storageItemController)
        {
            cmbItemControl.Items.Add(new PasswordItemControlFactory(storageItemController));
            cmbItemControl.DisplayMember = "Description";
            cmbItemControl.ValueMember = "Description";
            cmbItemControl.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbItemControl.SelectedItem != null && StorageVault != null)
            {
                var factory = cmbItemControl.SelectedItem as PasswordItemControlFactory;
                StorageVault.SelectedControl = factory?.Create();
            }
        }
    }
}
