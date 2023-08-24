using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AF.StorageVault
{
    public static class DynamicJsonConverter
    {
        public static string Serialize<T>(T obj)
            => JsonConvert.SerializeObject(obj);

        public static StorageItem Deserialize(string jsonString)
        {
            var jsonDom = JsonConvert.DeserializeObject<JObject>(jsonString)!;
            return Deserialize(jsonDom);
        }

        public static StorageItem Deserialize(JObject jsonDom)
        {
            MethodInfo? method = typeof(DynamicJsonConverter).GetCastMethod();
            StorageItem item = method?.CreateStorageItem(jsonDom) ?? new StorageItem();
            if (method != null)
                item.SetProperties(method, jsonDom);

            return item;
        }

        public static IEnumerable<StorageItem> DeserializeArray(string jsonString)
        {
            List<StorageItem> items = new List<StorageItem>();
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                var jsonDom = JsonConvert.DeserializeObject<JArray>(jsonString)!;
                foreach (JObject item in jsonDom)
                    items.Add(Deserialize(item));
            }

            return items;
        }

        private static T? Cast<T>(JObject? jsonDom, string property)
        {
            T? result = default;
            if (jsonDom?.ContainsKey(property) ?? false)
                result = (T)Convert.ChangeType(jsonDom[property]!, typeof(T));
            return result;
        }

        private static MethodInfo? GetCastMethod(this Type type)
            => type.GetMethod(nameof(Cast), BindingFlags.NonPublic | BindingFlags.Static);
        private static Type GetPropertyType(this Type type, string typeName)
            => type!.GetProperty(typeName)!.PropertyType;

        private static StorageItem CreateStorageItem(this MethodInfo method, JObject? jsonDom)
        {
            MethodInfo? generic = method.MakeGenericMethod(typeof(StorageItem).GetPropertyType("TypeName"));

            if (jsonDom != null)
            {
                string typeName = (string?)generic.Invoke(null, new object[] { jsonDom, "TypeName" }) ?? string.Empty;
                Type? storageType = Type.GetType(typeName);
                if (storageType != null)
                    return (StorageItem)(Activator.CreateInstance(storageType) ?? new StorageItem());
                else
                    return new StorageItem();
            }

            return new StorageItem();
        }

        private static void SetProperties(this StorageItem item, MethodInfo method, JObject? jsonDom)
        {
            if (jsonDom != null)
            {
                var props = typeof(PasswordItem).GetProperties();
                foreach (var prop in props)
                {
                    MethodInfo generic = method.MakeGenericMethod(prop.PropertyType);
                    var result = generic.Invoke(null, new object[] { jsonDom, prop.Name });
                    if (result != null)
                        prop.GetSetMethod()?.Invoke(item, new object[] { result });
                }
            }
        }
    }
}
