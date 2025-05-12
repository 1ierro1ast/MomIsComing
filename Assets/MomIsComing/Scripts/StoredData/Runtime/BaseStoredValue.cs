using System;
using MomIsComing.Scripts.UsefulExtensions.Runtime;
using UnityEngine;

namespace MomIsComing.Scripts.StoredData.Runtime
{
    [Serializable]
    public abstract class BaseStoredValue<TValue>
    {
        private bool _isLoaded;
        protected TValue CurrentValue;
        protected readonly string SaveKey;
        public event Action<TValue> ValueChanged;

        public TValue Value
        {
            get
            {
                if (!_isLoaded)
                {
                    Load();
                    _isLoaded = true;
                }
                return CurrentValue;
            }
            set
            {
                if (!_isLoaded)
                {
                    Load();
                    _isLoaded = true;
                }
                
                if (Equals(CurrentValue, value)) return;
                
                CurrentValue = value;
                InvokeValueChanged(CurrentValue);
                Save();
            }
        }

        public BaseStoredValue(string saveKey, TValue defaultValue)
        {
            SaveKey = saveKey;
            CurrentValue = defaultValue;
            _isLoaded = false;
        }

        protected abstract void Save();
        protected abstract void Load();

        protected virtual void InvokeValueChanged(TValue obj)
        {
            ValueChanged?.Invoke(obj);
        }
    }

    [Serializable]
    public class StoredInt : BaseStoredValue<int>
    {
        public StoredInt(string saveKey, int defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetInt(SaveKey, CurrentValue);
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetInt(SaveKey, CurrentValue);
        }
    }
    [Serializable]
    public class StoredFloat : BaseStoredValue<float>
    {
        public StoredFloat(string saveKey, float defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetFloat(SaveKey, CurrentValue);
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetFloat(SaveKey, CurrentValue);
        }
    }
    [Serializable]
    public class StoredDouble : BaseStoredValue<double>
    {
        public StoredDouble(string saveKey, double defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentValue.ToString());
        }

        protected override void Load()
        {
            CurrentValue = double.Parse(PlayerPrefs.GetString(SaveKey, CurrentValue.ToString()));
        }
    }
    [Serializable]
    public class StoredString : BaseStoredValue<string>
    {
        public StoredString(string saveKey, string defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentValue);
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetString(SaveKey, CurrentValue);
        }
    }
    [Serializable]
    public class StoredVector3 : BaseStoredValue<Vector3>
    {
        public StoredVector3(string saveKey, Vector3 defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentValue.ToString());
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetString(SaveKey, CurrentValue.ToString()).TryConvertToVector3();
        }
    }
    [Serializable]
    public class StoredVector2 : BaseStoredValue<Vector2>
    {
        public StoredVector2(string saveKey, Vector2 defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentValue.ToString());
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetString(SaveKey, CurrentValue.ToString()).TryConvertToVector2();
        }
    }
    [Serializable]
    public class StoredChar : BaseStoredValue<char>
    {
        public StoredChar(string saveKey, char defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentValue.ToString());
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetString(SaveKey, CurrentValue.ToString()).ToCharArray()[0];
        }
    }
    [Serializable]
    public class StoredBool : BaseStoredValue<bool>
    {
        public StoredBool(string saveKey, bool defaultValue) : base(saveKey, defaultValue)
        {
        }

        protected override void Save()
        {
            PlayerPrefs.SetInt(SaveKey, CurrentValue ? 1 : 0);
        }

        protected override void Load()
        {
            CurrentValue = PlayerPrefs.GetInt(SaveKey, CurrentValue ? 1 : 0) == 1;
        }
    }
}