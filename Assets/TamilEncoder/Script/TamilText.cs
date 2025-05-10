using UnityEngine;
using UnityEngine.UI;
using TamilEncoder;

namespace TamilUI
{
    [RequireComponent(typeof(Text))]
    public class TamilText : MonoBehaviour
    {
        [TextArea(3, 10)][SerializeField] protected string m_Text = defaultText;
        [SerializeField] Font m_TSCII_TamilFont;
        [SerializeField] Font m_TACE16_TamilFont;
        [SerializeField] TamilFontEncoding m_Encoding = TamilFontEncoding.TSCII;
        [SerializeField] int fontSize = 0;
        [SerializeField] float lineSpacing = 1;

        const string defaultText = "Your Tamil Text Here...";
        Text attachedText;

        public string Text
        {
            get
            {
                return m_Text;
            }
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

        public Font TACE16_TamilFont { get => m_TACE16_TamilFont; set => m_TACE16_TamilFont = value; }
        public Font TSCII_TamilFont { get => m_TSCII_TamilFont; set => m_TSCII_TamilFont = value; }

        protected virtual void Awake()
        {
            attachedText = GetComponent<Text>();
            if (m_Text == defaultText)
                m_Text = null;
        }

        protected virtual void Start()
        {
            if (string.IsNullOrEmpty(m_Text))
                return;

            UpdateText();
        }

        void UpdateText()
        {
            attachedText.text = TamilEncoding.ConvertFromUnicode(m_Text, m_Encoding);
            attachedText.font = UpdateFont();
            attachedText.lineSpacing = lineSpacing;

            if (fontSize == 0)
                return;

            attachedText.fontSize = fontSize;
            if (attachedText.resizeTextForBestFit)
                attachedText.resizeTextMaxSize = fontSize;
        }


        public void RenderText()
        {
            if (string.IsNullOrEmpty(m_Text))
                return;

            attachedText = GetComponent<Text>();
            attachedText.text = TamilEncoding.ConvertFromUnicode(m_Text, m_Encoding);
            attachedText.font = UpdateFont();
        }

        Font UpdateFont()
        {
            attachedText = GetComponent<Text>();
            return m_Encoding switch
            {
                TamilFontEncoding.TSCII => m_TSCII_TamilFont,
                TamilFontEncoding.TACE16 => m_TACE16_TamilFont,
                _ => attachedText.font
            };
        }
    }
}
