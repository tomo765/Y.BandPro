using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewSellModel
{
    private Image m_FiewImage;
    private ColorType m_CullentFiew = 0;
    private System.Func<ColorType> ChangeFiew;

    public ColorType CullentFiew => m_CullentFiew;

    public FiewSellModel(Image fiewImage, System.Func<ColorType> changeFiew)
    {
        m_FiewImage = fiewImage;
        ChangeFiew = changeFiew;
    }

    public void SetNewFiew()
    {
        m_CullentFiew = ChangeFiew();
        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[m_CullentFiew];
    }
}
