using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewsPresenter
{
    private FiewsUI m_FiewsUI;
    private FiewsModel m_FiewsModel;

    public FiewsPresenter(FiewsUI fiewsUI)
    {
        m_FiewsUI = fiewsUI;
        m_FiewsModel = new FiewsModel(new FiewPurchase(m_FiewsUI.Fiew1Image, 1),
                                      new FiewPurchase(m_FiewsUI.Fiew2Image, 2),
                                      new FiewPurchase(m_FiewsUI.Fiew3Image, 3));
    }

    public void Start()
    {
        var fiewSell = new FiewSell(m_FiewsUI.FiewSellImage, () =>
        {
            ColorType newType;
            while (true)
            {
                newType = (ColorType)Random.Range((int)ColorType.Yellow, (int)ColorType.Red);
                if (newType == ColorType.White) { continue; }
                if (m_FiewsModel.FiewSell.CullentFiew != newType) { break; }
            }
            return newType;
        });
        m_FiewsModel.SetFiewSell(fiewSell);
        m_FiewsModel.FiewSell.SetNewFiew();


        m_FiewsUI.Fiew1Button.onClick = () =>
        {
            m_FiewsModel.FiewPurchase1.SetNewtFiew(m_FiewsModel.FiewSell.CullentFiew);
            m_FiewsModel.FiewSell.SetNewFiew();

            var type = ScriptablesManager.Instance.GetMixedColor(m_FiewsModel.FiewPurchase1.FiewType1, m_FiewsModel.FiewPurchase1.FiewType2);
            SoundManager.Instance.PlaySound(ScriptablesManager.Instance.GetGenreClips(type), m_FiewsModel.FiewPurchase1.Index);
        };
        m_FiewsUI.Fiew2Button.onClick = () =>
        {
            m_FiewsModel.FiewPurchase2.SetNewtFiew(m_FiewsModel.FiewSell.CullentFiew);
            m_FiewsModel.FiewSell.SetNewFiew();

            var type = ScriptablesManager.Instance.GetMixedColor(m_FiewsModel.FiewPurchase2.FiewType1, m_FiewsModel.FiewPurchase2.FiewType2);
            SoundManager.Instance.PlaySound(ScriptablesManager.Instance.GetGenreClips(type), m_FiewsModel.FiewPurchase2.Index);
        };
        m_FiewsUI.Fiew3Button.onClick = () =>
        {
            m_FiewsModel.FiewPurchase3.SetNewtFiew(m_FiewsModel.FiewSell.CullentFiew);
            m_FiewsModel.FiewSell.SetNewFiew();

            var type = ScriptablesManager.Instance.GetMixedColor(m_FiewsModel.FiewPurchase3.FiewType1, m_FiewsModel.FiewPurchase3.FiewType2);
            SoundManager.Instance.PlaySound(ScriptablesManager.Instance.GetGenreClips(type), m_FiewsModel.FiewPurchase3.Index);
        };
    }
}

public class FiewsModel
{
    private FiewSell m_FiewSell;
    private FiewPurchase m_FiewPurchase1;
    private FiewPurchase m_FiewPurchase2;
    private FiewPurchase m_FiewPurchase3;

    public FiewSell FiewSell => m_FiewSell;
    public FiewPurchase FiewPurchase1 => m_FiewPurchase1;
    public FiewPurchase FiewPurchase2 => m_FiewPurchase2;
    public FiewPurchase FiewPurchase3 => m_FiewPurchase3;

    public FiewsModel(FiewPurchase fp1, FiewPurchase fp2, FiewPurchase fp3)
    {
        m_FiewPurchase1 = fp1;
        m_FiewPurchase2 = fp2;
        m_FiewPurchase3 = fp3;
    }

    public void SetFiewSell(FiewSell fiewSell) => m_FiewSell = fiewSell;
}