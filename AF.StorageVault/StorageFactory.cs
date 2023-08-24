using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public class StorageFactory
    {
        public PasswordItemControl? ItemControl { get; set; }

        private StorageItemController storageItemController { get; set; }

        public StorageFactory(StorageItemController storageItemController)
        {
            this.storageItemController = storageItemController;
        }

        public void Visit(StorageItem item)
        {
        }

        public void Visit(PasswordItem item)
        {
            storageItemController.Add(item);

            ItemControl = new PasswordItemControl(storageItemController, item.StorageId);
            ItemControl.Visible = false;
            ItemControl.Location = new Point(0, 50);
        }
    }
}
