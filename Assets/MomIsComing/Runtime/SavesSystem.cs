using System;
using System.IO;
using UnityEngine;

namespace MomIsComing.Scripts
{
    public class SavesSystem : MonoBehaviour
    {
        private DataContainer _dataContainer;

        private void Load()
        {
            string dataString = "";
            if (File.Exists(GetDataPath()))
            {
                dataString = File.ReadAllText(GetDataPath());
            }

            if (String.IsNullOrEmpty(dataString))
            {
                _dataContainer = new DataContainer();
            }
            else
            {
                _dataContainer = JsonUtility.FromJson<DataContainer>(dataString);
            }
        }
        
        private void Save()
        {
            if (_dataContainer == null)
            {
                Debug.LogWarning("DataContainer is null, create default instance");
                _dataContainer = new DataContainer();
            }
            var dataString = JsonUtility.ToJson(_dataContainer);
            File.WriteAllText(GetDataPath(), dataString);
        }

        private string GetDataPath() => Path.Combine(Application.persistentDataPath, "/saves.json");
    }

    [Serializable]
    public class DataContainer
    {
        public int currentMoney;
        public int currentExpirience;
    }
}