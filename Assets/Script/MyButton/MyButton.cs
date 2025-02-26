using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [System.Serializable]
    protected struct ButtonInteraction
    {
        [SerializeField] private Color m_Color;
        [SerializeField] private Sprite m_Sprite;
        public Color Color => m_Color;
        public Sprite Sprite => m_Sprite;

        public ButtonInteraction(Sprite sprite = null)
        {
            m_Color = Color.white;
            m_Sprite = sprite;
        }
    }


    public Action onClick {  get; set; }

    [SerializeField] private Image m_Image;
    [SerializeField] private bool m_IsEnabled = true;

    [SerializeField] private ButtonInteraction m_Default;
    [SerializeField] private ButtonInteraction m_Hover;
    [SerializeField] private ButtonInteraction m_Push;
    [SerializeField] private ButtonInteraction m_Disable;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!m_IsEnabled) { return; }
        m_Image.color = m_Hover.Color;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (!m_IsEnabled) { return; }
        m_Image.color = m_Push.Color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (!m_IsEnabled) { return; }
        if (!eventData.hovered.Contains(gameObject)) { return; }
        m_Image.color = m_Hover.Color;

        onClick?.Invoke();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!m_IsEnabled) { return; }
        m_Image.color = m_Default.Color;
    }


    protected void PointerEnter()
    {

    }
    protected void PointerDown()
    {

    }
    protected void PointerUp()
    {

    }
    protected void PointerExit()
    {

    }

    public void SetEnabled(bool enabled)
    {
        m_IsEnabled = enabled;
        m_Image.color = m_IsEnabled ? m_Default.Color : m_Disable.Color;
    }
}