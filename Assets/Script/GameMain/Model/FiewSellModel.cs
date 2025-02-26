using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiewSellModel
{
    private Image m_FiewImage;
    private ColorType m_CullentFiew = 0;
    private System.Func<ColorType> ChangeFiew;
    private int m_CullentChangeFiewPrice;

    public const int FiewPrice = 80;
    private const int InitChangeFiewPrice = 20;

    public ColorType CullentFiew => m_CullentFiew;
    public int ChangeFiewPrice => m_CullentChangeFiewPrice;

    public FiewSellModel(Image fiewImage, System.Func<ColorType> changeFiew)
    {
        m_FiewImage = fiewImage;
        ChangeFiew = changeFiew;
    }

    public void Start()
    {
        ResetChangeFiew();
    }

    public void SetNewFiew()
    {
        m_CullentFiew = ChangeFiew();
        m_FiewImage.sprite = ScriptablesManager.Instance.FiewSprites.TypeToSprite[m_CullentFiew];
    }

    public void OnChangeFiew() => m_CullentChangeFiewPrice *= 2;
    public void ResetChangeFiew() => m_CullentChangeFiewPrice = InitChangeFiewPrice;
}
