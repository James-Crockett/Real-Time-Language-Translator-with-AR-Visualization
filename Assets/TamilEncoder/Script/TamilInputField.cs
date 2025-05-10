using UnityEngine;
using UnityEngine.UI;
using TamilEncoder;
using TMPro;

namespace TamilUI
{
    public class TamilInputField : MonoBehaviour
    {
        [SerializeField] InputField inputField;
        [SerializeField] TMP_InputField inputFieldTMP;
        [SerializeField] TamilFontEncoding m_Encoding = TamilFontEncoding.TSCII;
        public TamilFontEncoding Encoding
        {
            get => m_Encoding;
            set => m_Encoding = value;
        }

        private void Awake()
        {
            if (inputField == null && inputFieldTMP == null)
            {
                if (TryGetComponent(out inputField))
                {
                    return;
                }
                if (TryGetComponent(out inputFieldTMP))
                {
                    return;
                }
                Debug.LogWarning($"In {gameObject.name} Input Field or Input Field TMP component not found");
            }
        }

        public void RenderTextOnValueChanged()
        {
            string unicode = TamilEncoding.Convert
                (m_Encoding, TamilFontEncoding.Unicode_ISCII, inputField.text);
            inputField.text = TamilEncoding.ConvertFromUnicode(unicode, m_Encoding);
        }

        public void RenderTextOnEndEdit()
        {
            inputField.text = TamilEncoding.ConvertFromUnicode(inputField.text, m_Encoding);
        }

        public void RenderTextOnValueChangedTMP()
        {
            string unicode = TamilEncoding.Convert
                (m_Encoding, TamilFontEncoding.Unicode_ISCII, inputFieldTMP.text);
            inputFieldTMP.text = TamilEncoding.ConvertFromUnicode(unicode, m_Encoding);
        }

        public void RenderTextOnEndEditTMP()
        {
            inputFieldTMP.text = TamilEncoding.ConvertFromUnicode(inputFieldTMP.text, m_Encoding);
        }
    }
}