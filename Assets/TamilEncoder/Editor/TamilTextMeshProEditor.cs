using UnityEditor;
using UnityEngine;
using TMPro;
using TamilUI;

namespace TamilUIEditor
{
    [CustomEditor(typeof(TamilTextMeshPro), true)]
    public class TamilTextMeshProEditor : Editor
    {
        SerializedProperty textBox;
        SerializedProperty font;
        SerializedProperty fontTACE;
        SerializedProperty encoding;

        private void OnEnable()
        {
            textBox = serializedObject.FindProperty("m_Text");
            font = serializedObject.FindProperty("m_FontAsset_TSCII");
            fontTACE = serializedObject.FindProperty("m_FontAsset_TACE16");
            encoding = serializedObject.FindProperty("m_Encoding");
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            serializedObject.Update();

            EditorGUILayout.PropertyField(textBox, new GUIContent("Text Box", "Type your Tamil text here.It will Update automatical in play mode.leaving it empty to stop overriding text"));
            EditorGUILayout.PropertyField(font, new GUIContent("TSCII font", "Add TSCII Text Mesh Pro Font Asset"));
            EditorGUILayout.PropertyField(fontTACE, new GUIContent("TACE16 font", "Add TACE16 Text Mesh Pro Font Asset"));
            EditorGUILayout.PropertyField(encoding, new GUIContent("Encoding", "Select which encoding font need to be used"));

            TamilTextMeshPro tamilTextMeshPro = (TamilTextMeshPro)target;
            if (GUILayout.Button("Render Text"))
            {
                var text = tamilTextMeshPro.GetComponent<TextMeshProUGUI>();
                Undo.RecordObject(text, "text changed");
                tamilTextMeshPro.UpdateText();
                EditorUtility.SetDirty(text);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}