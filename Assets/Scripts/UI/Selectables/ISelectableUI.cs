using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nakaya.UI
{
    public interface ISelectableUI
    {
        bool Enable { get; }
        RectTransform RectTransform { get; }

        void Select();
        void Deselect();

        void Press();
        void Release();

        void Disable();
        void SetEnable(bool b);
    }
}