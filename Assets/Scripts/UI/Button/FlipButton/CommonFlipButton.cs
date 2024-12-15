using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class CommonFlipButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Image m_Image;
    private bool m_IsOn = false;

    [Header("画像")]
    [SerializeField] private Sprite m_OffSplite;
    [SerializeField] private Sprite m_OnSplite;

    [Space(1), Header("色")]
    [SerializeField] private Color m_DefaultColor = Color.white;
    [SerializeField] private Color m_PointerEnterColor = Color.white;
    [SerializeField] private Color m_ClickColor = Color.white;

    /// <summary> カーソルがこのUIに入った時の処理 </summary>
    protected virtual void OnPointerEnter() { m_Image.color = m_PointerEnterColor; }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) { OnPointerEnter(); }

    protected virtual void OnPointerDown() { m_Image.color = m_ClickColor; }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) { OnPointerDown(); }

    protected virtual void OnPointerUp() { m_Image.color = m_PointerEnterColor; }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData) { OnPointerUp(); }

    /// <summary> カーソルがこのUIから外れた時の処理 </summary>
    protected virtual void OnPointerExit() { m_Image.color = m_DefaultColor; }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData) { OnPointerExit(); }


    void Start()
    {
        m_Image = GetComponent<Image>();

        m_Image.color = m_DefaultColor;
        m_Image.sprite = m_OffSplite;
    }
}
