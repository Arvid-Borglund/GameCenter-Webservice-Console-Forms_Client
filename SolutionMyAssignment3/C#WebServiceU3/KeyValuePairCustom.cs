using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationGameCenter
{
    public class KeyValuePairCustom
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public KeyValuePairCustom(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public KeyValuePairCustom()
        {
            // Empty constructor required for serialization
        }

    }
}