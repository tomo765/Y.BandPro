using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewPurchase
{
    private Image m_FiewImage;

    private FiewType m_Fiew1;
    private FiewType m_Fiew2;

    public FiewType FiewType1 => m_Fiew1;
    public FiewType FiewType2 => m_Fiew2;

    public FiewPurchase(Image fiewImage)
    {
        m_FiewImage = fiewImage;
        m_Fiew1 = FiewType.White;
        m_Fiew2 = FiewType.White;
    }

    public void SetNewtFiew(FiewType newFiew)
    {
        if(m_Fiew1 == FiewType.White) { m_Fiew1 = newFiew; }
        else if(m_Fiew2 == FiewType.White) {  m_Fiew2 = newFiew; }

        var newType = ScriptablesManager.Instance.GetTypeWithTwo(m_Fiew1, m_Fiew2);
        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[newType];
    }
}

public enum FiewType
{
    White,
    Yellow,
    Magenta,
    Cyan,
    Red,
    Green,
    Blue
}