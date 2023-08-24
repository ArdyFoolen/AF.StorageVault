using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public enum StorageItemEnum
    {
        Password
    }

    public class StorageItem
    {
        private readonly object storageItemLock = new object();
        private static int maxId = 0;
        public StorageItem()
        {
            lock (storageItemLock)
            {
                maxId += 1;
                StorageId = maxId;
            }
        }

        public string TypeName { get => GetType()?.FullName ?? string.Empty; }
        public int StorageId { get; private set; }
        public string? Name { get; set; }

        public virtual void Accept(StorageFactory visitor)
            => visitor.Visit(this);
    }
}
