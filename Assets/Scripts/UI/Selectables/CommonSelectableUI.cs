using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nakaya.UI
{
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public abstract class CommonSelectableUI : MonoBehaviour, ISelectableUI
    {
        protected Action m_OnPress;

        [SerializeField] protected Image m_Image;
        [SerializeField] protected ImageSetting m_Default;
        [SerializeField] protected ImageSetting m_Select;
        [SerializeField] protected ImageSetting m_Press;

        public RectTransform RectTransform => GetComponent<RectTransform>();

        private void Awake() { m_Image = GetComponent<Image>(); }

        public void AddPressAction(Action action) => m_OnPress += action;
        public void ResetPressAction() => m_OnPress = null;

        public virtual void Select()
        {
            m_Image.sprite = m_Select.Sprite;
            m_Image.color = m_Select.Color;
        }
        public virtual void Deselect()
        {
            m_Image.sprite = m_Default.Sprite;
            m_Image.color = m_Default.Color;
        }
        public virtual void Press()
        {
            m_Image.sprite = m_Press.Sprite;
            m_Image.color = m_Press.Color;

            Deselect();
            m_OnPress?.Invoke();
        }
        public virtual void Release()
        {
            m_Image.sprite = m_Select.Sprite;
            m_Image.color = m_Select.Color;
        }
    }


    [System.Serializable]
    public class ImageSetting
    {
#if UNITY_EDITOR
        [SpritePreview]
#endif
        [SerializeField] private Sprite m_Sprite;

        [SerializeField] private Color m_Color = Color.white;

        public Sprite Sprite => m_Sprite;
        public Color Color => m_Color;
    }
}