using UnityEngine;
using TMPro;
using TamilEncoder;

namespace TamilUI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TamilTextMeshPro : MonoBehaviour
    {
        [TextArea(3, 10)][SerializeField] protected string m_Text = string.Empty;

        [SerializeField] TMP_FontAsset m_FontAsset_TSCII;
        [SerializeField] TMP_FontAsset m_FontAsset_TACE16;
        [SerializeField] TamilFontEncoding m_Encoding = TamilFontEncoding.TSCII;

        TextMeshProUGUI textMesh;

        public string Text
        {
            get { return m_Text; }
            set
            {
                m_Text = value;
                UpdateText();
            }
        }
        public TamilFontEncoding Encoding
        {
            get { return m_Encoding; }
            set
            {
                m_Encoding = value;
                UpdateText();
            }
        }

        public TMP_FontAsset TACE16_TMPFont { get => m_FontAsset_TACE16; set => m_FontAsset_TACE16 = value; }
        public TMP_FontAsset TSCII_TMPFont { get => m_FontAsset_TSCII; set => m_FontAsset_TSCII = value; }

        protected virtual void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        protected virtual void Start()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            if (string.IsNullOrEmpty(m_Text))
                return;

            textMesh = GetComponent<TextMeshProUGUI>();
            textMesh.SetText(TamilEncoding.ConvertFromUnicode(m_Text, Encoding));
            textMesh.font = UpdateFont();
        }

        TMP_FontAsset UpdateFont()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            return m_Encoding switch
            {
                TamilFontEncoding.TSCII => m_FontAsset_TSCII,
                TamilFontEncoding.TACE16 => m_FontAsset_TACE16,
                _ => textMesh.font
            };
        }
    }
}