using System;
using System.Linq;

namespace Plugins.FileBasedPrefs
{
    [Serializable]
    public class FileBasedPrefsSaveFileModel
    {
        public StringItem[] stringData = Array.Empty<StringItem>();
        public IntItem[] intData = Array.Empty<IntItem>();
        public FloatItem[] floatData = Array.Empty<FloatItem>();
        public BoolItem[] boolData = Array.Empty<BoolItem>();

        public object GetValueFromKey(string key, object defaultValue)
        {
            switch (defaultValue)
            {
                case string:
                {
                    foreach (var item in stringData)
                        if (item.key.Equals(key))
                            return item.value;

                    break;
                }
                case int:
                {
                    foreach (var item in intData)
                        if (item.key.Equals(key))
                            return item.value;

                    break;
                }
                case float:
                {
                    foreach (var item in floatData)
                        if (item.key.Equals(key))
                            return item.value;

                    break;
                }
                case bool:
                {
                    foreach (var item in boolData)
                        if (item.key.Equals(key))
                            return item.value;

                    break;
                }
            }

            return defaultValue;
        }

        public void UpdateOrAddData(string key, object value)
        {
            if (HasKeyFromObject(key, value))
                SetValueForExistingKey(key, value);
            else
                SetValueForNewKey(key, value);
        }

        private void SetValueForNewKey(string key, object value)
        {
            switch (value)
            {
                case string s:
                {
                    var dataAsList = stringData.ToList();
                    dataAsList.Add(new StringItem(key, s));
                    stringData = dataAsList.ToArray();
                    break;
                }
                case int i:
                {
                    var dataAsList = intData.ToList();
                    dataAsList.Add(new IntItem(key, i));
                    intData = dataAsList.ToArray();
                    break;
                }
                case float f:
                {
                    var dataAsList = floatData.ToList();
                    dataAsList.Add(new FloatItem(key, f));
                    floatData = dataAsList.ToArray();
                    break;
                }
                case bool b:
                {
                    var dataAsList = boolData.ToList();
                    dataAsList.Add(new BoolItem(key, b));
                    boolData = dataAsList.ToArray();
                    break;
                }
            }
        }

        private void SetValueForExistingKey(string key, object value)
        {
            switch (value)
            {
                case string s:
                {
                    foreach (var item in stringData)
                        if (item.key.Equals(key))
                            item.value = s;

                    break;
                }
                case int i:
                {
                    foreach (var item in intData)
                        if (item.key.Equals(key))
                            item.value = i;

                    break;
                }
                case float f:
                {
                    foreach (var item in floatData)
                        if (item.key.Equals(key))
                            item.value = f;

                    break;
                }
                case bool b:
                {
                    foreach (var item in boolData)
                        if (item.key.Equals(key))
                            item.value = b;

                    break;
                }
            }
        }

        public bool HasKeyFromObject(string key, object value)
        {
            switch (value)
            {
                case string:
                {
                    if (stringData.Any(item => item.key.Equals(key))) return true;

                    break;
                }
                case int:
                {
                    if (intData.Any(t => t.key.Equals(key))) return true;

                    break;
                }
                case float:
                {
                    if (floatData.Any(t => t.key.Equals(key))) return true;

                    break;
                }
                case bool:
                {
                    if (boolData.Any(t => t.key.Equals(key))) return true;

                    break;
                }
            }

            return false;
        }

        public void DeleteKey(string key)
        {
            for (var i = 0; i < stringData.Length; i++)
                if (stringData[i].key.Equals(key))
                {
                    var dataAsList = stringData.ToList();
                    dataAsList.RemoveAt(i);
                    stringData = dataAsList.ToArray();
                }

            for (var i = 0; i < intData.Length; i++)
                if (intData[i].key.Equals(key))
                {
                    var dataAsList = intData.ToList();
                    dataAsList.RemoveAt(i);
                    intData = dataAsList.ToArray();
                }

            for (var i = 0; i < floatData.Length; i++)
                if (floatData[i].key.Equals(key))
                {
                    var dataAsList = floatData.ToList();
                    dataAsList.RemoveAt(i);
                    floatData = dataAsList.ToArray();
                }

            for (var i = 0; i < boolData.Length; i++)
                if (boolData[i].key.Equals(key))
                {
                    var dataAsList = boolData.ToList();
                    dataAsList.RemoveAt(i);
                    boolData = dataAsList.ToArray();
                }
        }

        public void DeleteString(string key)
        {
            for (var i = 0; i < stringData.Length; i++)
                if (stringData[i].key.Equals(key))
                {
                    var dataAsList = stringData.ToList();
                    dataAsList.RemoveAt(i);
                    stringData = dataAsList.ToArray();
                }
        }

        public void DeleteInt(string key)
        {
            for (var i = 0; i < intData.Length; i++)
                if (intData[i].key.Equals(key))
                {
                    var dataAsList = intData.ToList();
                    dataAsList.RemoveAt(i);
                    intData = dataAsList.ToArray();
                }
        }

        public void DeleteFloat(string key)
        {
            for (var i = 0; i < floatData.Length; i++)
                if (floatData[i].key.Equals(key))
                {
                    var dataAsList = floatData.ToList();
                    dataAsList.RemoveAt(i);
                    floatData = dataAsList.ToArray();
                }
        }

        public void DeleteBool(string key)
        {
            for (var i = 0; i < boolData.Length; i++)
                if (boolData[i].key.Equals(key))
                {
                    var dataAsList = boolData.ToList();
                    dataAsList.RemoveAt(i);
                    boolData = dataAsList.ToArray();
                }
        }

        public bool HasKey(string key)
        {
            if (stringData.Any(t => t.key.Equals(key))) return true;

            if (intData.Any(t => t.key.Equals(key))) return true;

            if (floatData.Any(t => t.key.Equals(key))) return true;

            if (boolData.Any(t => t.key.Equals(key))) return true;

            return false;
        }

        [Serializable]
        public class StringItem
        {
            public string key;
            public string value;

            public StringItem(string k, string v)
            {
                key = k;
                value = v;
            }
        }

        [Serializable]
        public class IntItem
        {
            public string key;
            public int value;

            public IntItem(string k, int v)
            {
                key = k;
                value = v;
            }
        }

        [Serializable]
        public class FloatItem
        {
            public string key;
            public float value;

            public FloatItem(string k, float v)
            {
                key = k;
                value = v;
            }
        }

        [Serializable]
        public class BoolItem
        {
            public string key;
            public bool value;

            public BoolItem(string k, bool v)
            {
                key = k;
                value = v;
            }
        }
    }
}