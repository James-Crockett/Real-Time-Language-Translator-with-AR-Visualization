using UnityEditor;
using UnityEngine;
using TamilUI;

namespace TamilUIEditor
{
    public class TamilMenuPrefabs : ScriptableObject
    {
        const string TamilMenuPrefabsFile = "Assets/TamilEncoder/Editor/Resources/TamilMenuPrefabs.asset";

        public GameObject inputField;
        public GameObject inputFieldTMP;
        public GameObject dropdown;
        public GameObject dropdownTMP;
        public GameObject button;
        public GameObject buttonTMP;

        public static TamilMenuPrefabs Instance
        {
            get
            {
                if (instance == null)
                {

                    instance = (TamilMenuPrefabs)
                        AssetDatabase.LoadAssetAtPath(TamilMenuPrefabsFile, typeof(TamilMenuPrefabs));

                    if (instance == null)
                    {
                        instance = CreateInstance<TamilMenuPrefabs>();
                        AssetDatabase.CreateAsset(instance, TamilMenuPrefabsFile);
                    }
                }
                return instance;
            }
        }

        static TamilMenuPrefabs instance;
    }
}