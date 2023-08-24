using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public class PasswordItemControlFactory
    {
        private StorageItemController storageItemController;
        public string Description { get => "Password item"; }

        public PasswordItemControlFactory(StorageItemController storageItemController)
        {
            this.storageItemController = storageItemController;
        }

        public PasswordItemControl Create()
        {
            var item = new PasswordItem();
            item.Name = "New Item" + item.StorageId.ToString();
            return Create(item);
        }

        public PasswordItemControl Create(PasswordItem item)
        {
            storageItemController.Add(item);

            PasswordItemControl passwordItemControl = new PasswordItemControl(storageItemController, item.StorageId);
            passwordItemControl.Visible = false;
            passwordItemControl.Location = new Point(0, 50);

            return passwordItemControl;
        }
    }
}
