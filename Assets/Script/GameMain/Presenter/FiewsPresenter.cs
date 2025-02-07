using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiewsPresenter
{
    private FiewsUI m_FiewsUI;

    public FiewsPresenter(FiewsUI fiewsUI)
    {
        m_FiewsUI = fiewsUI;
    }

    public void Start()
    {
        var fiewSell = new FiewSellModel(m_FiewsUI.FiewSellImage, () =>
        {
            ColorType newType;
            while (true)
            {
                newType = (ColorType)Random.Range((int)ColorType.Yellow, (int)ColorType.Red);
                if (newType == ColorType.White) { continue; }
                if (GameDataManager.Instance.FiewsModel.FiewSell.CullentFiew != newType) { break; }
            }
            return newType;
        });
        GameDataManager.Instance.FiewsModel.SetFiewSell(fiewSell);
        fiewSell.SetNewFiew();
        m_FiewsUI.ChangeFierw.onClick = () =>
        {
            GameDataManager.Instance.FiewsModel.FiewSell.SetNewFiew();
            GameDataManager.Instance.UpdateScore();
        };

        m_FiewsUI.Fiew1Button.onClick = () => OnFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase1);
        m_FiewsUI.Fiew2Button.onClick = () => OnFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase2);
        m_FiewsUI.Fiew3Button.onClick = () => OnFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase3);

        m_FiewsUI.Fiew1DeleteButton.onClick = () => OnDeleteFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase1);
        m_FiewsUI.Fiew2DeleteButton.onClick = () => OnDeleteFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase2);
        m_FiewsUI.Fiew3DeleteButton.onClick = () => OnDeleteFiewButtonClicked(GameDataManager.Instance.FiewsModel.FiewPurchase3);
    }

    private void OnFiewButtonClicked(FiewPurchaseModel fiewPurchase)
    {
        if(fiewPurchase.FiewType1 != ColorType.White && fiewPurchase.FiewType2 != ColorType.White) { return; }

        fiewPurchase.SetNewtFiew(GameDataManager.Instance.FiewsModel.FiewSell.CullentFiew);
        GameDataManager.Instance.FiewsModel.FiewSell.SetNewFiew();
        SoundManager.Instance.PlaySound(ScriptablesManager.Instance.GetGenreClips(fiewPurchase.MixedColor), fiewPurchase.Index);

        GameDataManager.Instance.UpdateScore();
        GameDataManager.Instance.UpdateRank();
    }

    private void OnDeleteFiewButtonClicked(FiewPurchaseModel fiewPurchase)
    {
        fiewPurchase.DeleteFiew();
        SoundManager.Instance.StopSound(fiewPurchase.Index);

        GameDataManager.Instance.UpdateScore();
        GameDataManager.Instance.UpdateRank();
    }
}

public class FiewsModel
{
    private FiewSellModel m_FiewSell;
    private FiewPurchaseModel m_FiewPurchase1;
    private FiewPurchaseModel m_FiewPurchase2;
    private FiewPurchaseModel m_FiewPurchase3;

    public FiewSellModel FiewSell => m_FiewSell;
    public FiewPurchaseModel FiewPurchase1 => m_FiewPurchase1;
    public FiewPurchaseModel FiewPurchase2 => m_FiewPurchase2;
    public FiewPurchaseModel FiewPurchase3 => m_FiewPurchase3;

    public ColorType[] AllFiewColor => new ColorType[] { m_FiewPurchase1.MixedColor, m_FiewPurchase2.MixedColor, m_FiewPurchase3.MixedColor };

    public FiewsModel(FiewPurchaseModel fp1, FiewPurchaseModel fp2, FiewPurchaseModel fp3)
    {
        m_FiewPurchase1 = fp1;
        m_FiewPurchase2 = fp2;
        m_FiewPurchase3 = fp3;
    }

    public void SetFiewSell(FiewSellModel fiewSell) => m_FiewSell = fiewSell;
}