using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class FiewPurchase
{
    private Image m_FiewImage;
    private int m_Index;

    private ColorType m_Fiew1;
    private ColorType m_Fiew2;


    public int Index => m_Index;
    public ColorType FiewType1 => m_Fiew1;
    public ColorType FiewType2 => m_Fiew2;
    public ColorType MixedColor => GetMixedColor(m_Fiew1, m_Fiew2);

    public FiewPurchase(Image fiewImage, int index)
    {
        m_FiewImage = fiewImage;
        m_Index = index;
        m_Fiew1 = ColorType.White;
        m_Fiew2 = ColorType.White;
    }

    public void SetNewtFiew(ColorType newFiew)
    {
        if(m_Fiew1 == ColorType.White) { m_Fiew1 = newFiew; }
        else if(m_Fiew2 == ColorType.White) {  m_Fiew2 = newFiew; }

        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[MixedColor];
    }



    public static readonly LinkedList<ColorType> ColorTransitionChain = new LinkedList<ColorType>(new List<ColorType>
    {
        ColorType.Yellow,
        ColorType.Red,
        ColorType.Magenta,
        ColorType.Blue,
        ColorType.Cyan,
        ColorType.Green,
    });
    private static ColorType GetMixedColor(ColorType type1, ColorType type2)
    {
        if (type2 == ColorType.White) { return type1; }
        if (type1 == type2) { return type1; }

        int[] values = new int[] { GetColorIndex(type1), GetColorIndex(type2) };

        //Yellow ‚Æ Cyan ‚¾‚Á‚½Žž‚É Green ‚ð•Ô‚·
        if (values[0] == 0 && values[1] == 4 || values[0] == 4 && values[1] == 0)
        { return ColorTransitionChain.ElementAt(5); }

        return ColorTransitionChain.ElementAt((values[0] + values[1]) / 2);

        int GetColorIndex(ColorType type)
        {
            int i = 0;
            for (; i < ColorTransitionChain.Count; i++)
            {
                if (ColorTransitionChain.ElementAt(i) == type) { break; }
            }
            return i;
        }
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