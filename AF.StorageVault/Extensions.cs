using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AF.StorageVault
{
    public static class Extensions
    {
        public static T? As<T>(this object value)
            where T: class
        {
            if (value == null) return null;
            var result = value as T;
            if (result != null) return result;
            return default(T);
        }

        public static Point Minus(this Point left, Point right)
            => new Point(left.X - right.X, left.Y - right.Y);
    }
}
