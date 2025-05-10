using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using TamilUI;

namespace TamilUIEditor
{
    public class TamilUIEditor
    {
        [MenuItem("GameObject/UI/Tamil/Tamil Text")]
        static void CreateTamilText(MenuCommand command)
        {
            GameObject tamilText = new GameObject("TamilText", typeof(TamilText));

            Text text = tamilText.GetComponent<Text>();

            text.font = tamilText.GetComponent<TamilText>().TSCII_TamilFont;
            text.color = new Color(0.12549f, 0.12549f, 0.12549f);
            text.text = "Ò¾¢Â ¯¨Ã";
			text.fontSize = 16;
			var rect = text.GetComponent<RectTransform>();
			rect.sizeDelta = new Vector2(200,50);

            GameObjectUtility.SetParentAndAlign(tamilText, command.context as GameObject);
            Undo.RegisterCreatedObjectUndo(tamilText, $"Create {tamilText.name}");
            Selection.activeObject = tamilText;
        }

        [MenuItem("GameObject/UI/Tamil/Tamil Text - TextMeshPro")]
        static void CreateTamilTextTMP(MenuCommand command)
        {
            GameObject tamilText = new GameObject("TamilText (TMP)", typeof(TamilTextMeshPro));

            tamilText.GetComponent<TextMeshProUGUI>().font = tamilText.GetComponent<TamilTextMeshPro>().TSCII_TMPFont;

            GameObjectUtility.SetParentAndAlign(tamilText, command.context as GameObject);
            Undo.RegisterCreatedObjectUndo(tamilText, $"Create {tamilText.name}");
            Selection.activeObject = tamilText;
        }

        [MenuItem("GameObject/UI/Tamil/Tamil Dropdown")]
        static void CreateTamilDropdown(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.dropdown, "TamilDropdown");
        }

        [MenuItem("GameObject/UI/Tamil/Tamil Dropdown - TMP")]
        static void CreateTamilDropdownTMP(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.dropdownTMP, "TamilDropdown(TMP)");
        }

        [MenuItem("GameObject/UI/Tamil/Tamil Input Field")]
        static void CreateTamilInputField(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.inputField, "TamilInputField");
        }

        [MenuItem("GameObject/UI/Tamil/Tamil Input Field - TMP")]
        static void CreateTamilInputFieldTMP(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.inputFieldTMP, "TamilInputField(TMP)");
        }
		
		[MenuItem("GameObject/UI/Tamil/Tamil Button")]
        static void CreateTamilButton(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.button, "TamilButton");
        }
		
		[MenuItem("GameObject/UI/Tamil/Tamil Button - TMP")]
        static void CreateTamilButtonTMP(MenuCommand command)
        {
            CreateObject(command, TamilMenuPrefabs.Instance.buttonTMP, "TamilButton(TMP)");
        }

        static void CreateObject(MenuCommand command, Object prefab, string name)
        {
            var gameObject = PrefabUtility.InstantiateAttachedAsset(prefab);
            gameObject.name = name;
            GameObjectUtility.SetParentAndAlign((GameObject)gameObject, command.context as GameObject);
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");
            Selection.activeObject = gameObject;
        }
    }
}
