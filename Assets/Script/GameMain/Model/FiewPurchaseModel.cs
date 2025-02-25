using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FiewPurchaseModel
{
    private FiewObject m_FiewObject;
    private Image m_FiewImage;
    private int m_Index;


    private Tween m_Tween;
    private ColorType m_Fiew1;
    private ColorType m_Fiew2;


    public int Index => m_Index;
    public ColorType FiewType1 => m_Fiew1;
    public ColorType FiewType2 => m_Fiew2;
    /// <summary> ”’‚ª‚ ‚Á‚½‚É”’‚ğ•Ô‚· </summary>
    public ColorType MixedColor => GetMixedColor(m_Fiew1, m_Fiew2);
    /// <summary> ”’ˆÈŠO‚ÌF‚ğ¬‚º‚½‚ÌF‚ğ•Ô‚· </summary>
    public ColorType AnyMixedColor => GetAnyMixedColor(m_Fiew1, m_Fiew2);

    public FiewPurchaseModel(FiewObject fiewObject, Image fiewImage, int index)
    {
        m_FiewObject = fiewObject;
        m_FiewImage = fiewImage;
        m_Index = index;
        m_Fiew1 = ColorType.White;
        m_Fiew2 = ColorType.White;
    }

    public void SetNewtFiew(ColorType newFiew)
    {
        if(m_Fiew1 == ColorType.White) { m_Fiew1 = newFiew; }
        else if(m_Fiew2 == ColorType.White) {  m_Fiew2 = newFiew; }

        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[AnyMixedColor];


        MoveAt(m_FiewObject.InComePos, false);
    }

    public void DeleteFiew()
    {
        m_Fiew1 = ColorType.White;
        m_Fiew2 = ColorType.White;
        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[ColorType.White];

        MoveAt(m_FiewObject.OutComePos, true);
    }

    private void MoveAt(Vector3 target, bool flip)
    {
        float time = Mathf.Abs(m_FiewObject.transform.position.x - target.x) / m_FiewObject.MoveSpeed;

        m_Tween?.Kill();
        m_FiewObject.SetFlip(flip);
        m_Tween = m_FiewObject.transform.DOMove(target, time)
                                        .SetEase(Ease.Linear)
                                        .OnComplete(() => { m_Tween = null; });
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
        if (type2 == ColorType.White) { return ColorType.White; }  
        if (type1 == type2) { return type1; }

        int[] values = new int[] { GetColorIndex(type1), GetColorIndex(type2) };

        //Yellow ‚Æ Cyan ‚¾‚Á‚½‚É Green ‚ğ•Ô‚·
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

    private static ColorType GetAnyMixedColor(ColorType type1, ColorType type2)
    {
        if (type2 == ColorType.White) { return GetColorWithWhite(type1); }
        if (type1 == type2) { return type1; }

        int[] values = new int[] { GetColorIndex(type1), GetColorIndex(type2) };

        //Yellow ‚Æ Cyan ‚¾‚Á‚½‚É Green ‚ğ•Ô‚·
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

        ColorType GetColorWithWhite(ColorType colorWithoutWhite)
        {
            return colorWithoutWhite switch
            {
                ColorType.Yellow => ColorType.White_Yellow,
                ColorType.Magenta => ColorType.White_Magenta,
                ColorType.Cyan => ColorType.White_Cyan,
                _ => colorWithoutWhite
            };
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
    Blue,
    White_Yellow,
    White_Magenta,
    White_Cyan,
}