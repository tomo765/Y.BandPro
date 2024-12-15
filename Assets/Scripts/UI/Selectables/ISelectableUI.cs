using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nakaya.UI
{
    public interface ISelectableUI
    {
        RectTransform RectTransform { get; }

        void Select();
        void Deselect();

        void Press();
        void Release();
    }
}