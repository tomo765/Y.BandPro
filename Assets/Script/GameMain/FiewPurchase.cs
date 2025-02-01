using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewPurchase
{
    private Image m_FiewImage;

    private ColorType m_Fiew1;
    private ColorType m_Fiew2;

    public ColorType FiewType1 => m_Fiew1;
    public ColorType FiewType2 => m_Fiew2;

    public FiewPurchase(Image fiewImage)
    {
        m_FiewImage = fiewImage;
        m_Fiew1 = ColorType.White;
        m_Fiew2 = ColorType.White;
    }

    public void SetNewtFiew(ColorType newFiew)
    {
        if(m_Fiew1 == ColorType.White) { m_Fiew1 = newFiew; }
        else if(m_Fiew2 == ColorType.White) {  m_Fiew2 = newFiew; }

        var newType = ScriptablesManager.Instance.GetTypeWithTwo(m_Fiew1, m_Fiew2);
        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[newType];
    }
}

public enum ColorType
{
    White,
    Yellow,
    Magenta,
    Cyan,
    Red,
    Green,
    Blue
}