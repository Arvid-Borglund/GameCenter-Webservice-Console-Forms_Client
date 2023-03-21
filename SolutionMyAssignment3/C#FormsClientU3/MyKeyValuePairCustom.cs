using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsClient
{
    public class MyKeyValuePairCustom
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public MyKeyValuePairCustom() { }

        public MyKeyValuePairCustom(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public static implicit operator KeyValuePairCustom(MyKeyValuePairCustom myKvp)
        {
            return new KeyValuePairCustom() { Key = myKvp.Key, Value = myKvp.Value };
        }

        public static implicit operator MyKeyValuePairCustom(KeyValuePairCustom kvp)
        {
            return new MyKeyValuePairCustom() { Key = kvp.Key, Value = kvp.Value };
        }
    }
}
