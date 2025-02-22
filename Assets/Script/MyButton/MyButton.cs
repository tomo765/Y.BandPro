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

    [SerializeField] private ButtonInteraction m_Default;
    [SerializeField] private ButtonInteraction m_Hover;
    [SerializeField] private ButtonInteraction m_Push;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        m_Image.color = m_Hover.Color;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        m_Image.color = m_Push.Color;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if(!eventData.hovered.Contains(gameObject)) { return; }
        m_Image.color = m_Hover.Color;

        onClick?.Invoke();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
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


    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
