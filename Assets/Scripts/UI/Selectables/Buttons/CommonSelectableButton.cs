using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Nakaya.UI
{
    [RequireComponent(typeof(Image)), AddComponentMenu("Scripts/CommonSelectableButton")]
    public class CommonSelectableButton : CommonSelectableUI, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData) { }/*=> Select();*/
        public void OnPointerDown(PointerEventData eventData) => Press();
        public void OnPointerUp(PointerEventData eventData) { }/*=> Release();*/
        public void OnPointerExit(PointerEventData eventData) { } /*=> Deselect();*/
    }
}