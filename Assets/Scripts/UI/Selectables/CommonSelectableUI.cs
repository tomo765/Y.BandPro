using System;
using UnityEngine;
using UnityEngine.UI;

namespace Nakaya.UI
{
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public abstract class CommonSelectableUI : MonoBehaviour, ISelectableUI
    {
        protected SelectableUIState m_State = SelectableUIState.Default;
        protected bool m_Enable = true;
        protected Func<bool> IsEnable;
        protected Action m_OnPress;

        [SerializeField] protected Image m_Image;
        [SerializeField] protected ImageSetting m_Default;
        [SerializeField] protected ImageSetting m_Disable;
        [SerializeField] protected ImageSetting m_Select;
        [SerializeField] protected ImageSetting m_Press;

        public bool Enable => m_Enable;
        public RectTransform RectTransform => GetComponent<RectTransform>();

        private void Awake() { m_Image = GetComponent<Image>(); }
        private void OnEnable()
        {
            SetEnable(IsEnable?.Invoke() ?? true);
        }

        public void AddPressAction(Action action) => m_OnPress += action;
        public void ResetPressAction() => m_OnPress = null;

        public virtual void Select()
        {
            if (!m_Enable) { return; }

            m_State = SelectableUIState.Select;
            m_Image.sprite = m_Select.Sprite;
            m_Image.color = m_Select.Color;
        }
        public virtual void Deselect()
        {
            if (!m_Enable) { return; }

            m_State = SelectableUIState.Deselect;
            m_Image.sprite = m_Default.Sprite;
            m_Image.color = m_Default.Color;
        }
        public virtual void Press()
        {
            if(!m_Enable) {  return; }

            m_State = SelectableUIState.Press;
            m_Image.sprite = m_Press.Sprite;
            m_Image.color = m_Press.Color;

            Deselect();
            m_OnPress?.Invoke();
        }
        public virtual void Release()
        {
            if (!m_Enable) { return; }

            m_State = SelectableUIState.Release;
            m_Image.sprite = m_Select.Sprite;
            m_Image.color = m_Select.Color;
        }

        public virtual void Disable()
        {
            if (m_Enable) { return; }

            m_State = SelectableUIState.Deselect;
            m_Image.sprite = m_Disable.Sprite;
            m_Image.color = m_Disable.Color;
        }
        public void SetEnable(bool b)
        {
            m_Enable = b;
            if (!m_Enable)
            {
                Disable();
                return;
            }

            switch (m_State)
            {
                case SelectableUIState.Default:
                case SelectableUIState.Deselect:
                    Deselect();
                    break;
                case SelectableUIState.Select:
                    Select();
                    break;
                case SelectableUIState.Press:
                    Press();
                    break;
                case SelectableUIState.Release:
                    Release();
                    break;
            }
        }
        public void SetEnableCondition(Func<bool> func) => IsEnable = func;
        public void CheckEnable() => SetEnable(IsEnable());
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

    public enum SelectableUIState
    {
        Default,
        Select,
        Deselect,
        Press,
        Release,
    }
}