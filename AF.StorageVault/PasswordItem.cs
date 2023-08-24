using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public class PasswordItem : StorageItem
    {
        public string? Link { get; set; }
        public string? User { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public override void Accept(StorageFactory visitor)
            => visitor.Visit(this);
    }
}
