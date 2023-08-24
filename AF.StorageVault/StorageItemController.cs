using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public class StorageItemController
    {
        private List<IStorageItemView> Views = new List<IStorageItemView>();
        private Dictionary<int, StorageItem> storageItems = new Dictionary<int, StorageItem>();
        private readonly PasswordHandler passwordHandler;

        public StorageItemController(PasswordHandler passwordHandler)
        {
            this.passwordHandler = passwordHandler;
        }

        public void Register(IStorageItemView item)
        {
            if (!Views.Contains(item))
                Views.Add(item);
        }

        public void Unregister(IStorageItemView item)
        {
            if (Views.Contains(item))
                Views.Remove(item);
        }

        private void NotifyViews()
        {
            foreach (IStorageItemView item in Views)
                item.UpdateView();
        }

        public void Add(StorageItem item)
        {
            if (!storageItems.ContainsKey(item.StorageId))
                storageItems.Add(item.StorageId, item);
        }

        public void Remove(int storageId)
        {
            if (storageItems.ContainsKey(storageId))
                storageItems.Remove(storageId);
        }

        public bool Exists(int storageId)
            => storageItems.ContainsKey(storageId);

        public StorageItem? Get(int storageId)
        {
            if (storageItems.ContainsKey(storageId))
                return storageItems[storageId];
            return null;
        }

        public IEnumerable<StorageItem> Load()
        {
            return passwordHandler.DecryptStorage();
        }

        public void Store()
        {
            passwordHandler.EncryptStorage(storageItems.Values);
        }
    }
}

