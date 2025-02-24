using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (!GameDataManager.Instance.GameInfoModel.TryUseMoney(FiewSellModel.ChangeFiewPrice)) { return; }

            GameDataManager.Instance.FiewsModel.FiewSell.SetNewFiew();
            GameDataManager.Instance.UpdateScore();
            GameDataManager.Instance.UpdateRank();
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
        if (!GameDataManager.Instance.GameInfoModel.TryUseMoney(FiewSellModel.FiewPrice)) { return; }
        if (fiewPurchase.FiewType1 != ColorType.White && fiewPurchase.FiewType2 != ColorType.White) { return; }

        fiewPurchase.SetNewtFiew(GameDataManager.Instance.FiewsModel.FiewSell.CullentFiew);
        UpdateRGBColors();
        GameDataManager.Instance.FiewsModel.FiewSell.SetNewFiew();
        SoundManager.Instance.PlaySound(ScriptablesManager.Instance.GetGenreClips(fiewPurchase.AnyMixedColor), fiewPurchase.Index);

        GameDataManager.Instance.UpdateScore();
        GameDataManager.Instance.UpdateRank();
    }


    private void OnDeleteFiewButtonClicked(FiewPurchaseModel fiewPurchase)
    {
        fiewPurchase.DeleteFiew();
        UpdateRGBColors();
        SoundManager.Instance.StopSound(fiewPurchase.Index);

        GameDataManager.Instance.UpdateScore();
        GameDataManager.Instance.UpdateRank();
    }

    private void UpdateRGBColors()
    {
        var cols = GameDataManager.Instance.FiewsModel.AllFiewColor;
        var rgbs = new List<ColorType>(6);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i] == ColorType.White) { continue; }
            var rgb = ToRGB(cols[i]);
            rgbs.AddRange(rgb);
        }
        GameDataManager.Instance.FiewsModel.SetRGBColors(rgbs.ToArray());
    }

    private ColorType[] ToRGB(ColorType type)
    {
        return (type) switch
        {
            ColorType.Yellow => new ColorType[] { ColorType.Red, ColorType.Green },
            ColorType.Red => new ColorType[] { ColorType.Red },
            ColorType.Magenta => new ColorType[] { ColorType.Red, ColorType.Blue },
            ColorType.Blue => new ColorType[] { ColorType.Blue },
            ColorType.Cyan => new ColorType[] { ColorType.Blue, ColorType.Green },
            ColorType.Green => new ColorType[] { ColorType.Green },
            _ => new ColorType[0]
        };
    }
}

public class FiewsModel
{
    private FiewSellModel m_FiewSell;
    private FiewPurchaseModel m_FiewPurchase1;
    private FiewPurchaseModel m_FiewPurchase2;
    private FiewPurchaseModel m_FiewPurchase3;
    private ColorType[] m_RGBColors = new ColorType[0];

    public FiewSellModel FiewSell => m_FiewSell;
    public FiewPurchaseModel FiewPurchase1 => m_FiewPurchase1;
    public FiewPurchaseModel FiewPurchase2 => m_FiewPurchase2;
    public FiewPurchaseModel FiewPurchase3 => m_FiewPurchase3;
    public ColorType[] RGBColors => m_RGBColors;


    public ColorType[] AllFiewColor => new ColorType[] { m_FiewPurchase1.MixedColor, m_FiewPurchase2.MixedColor, m_FiewPurchase3.MixedColor };

    public FiewsModel(FiewPurchaseModel fp1, FiewPurchaseModel fp2, FiewPurchaseModel fp3)
    {
        m_FiewPurchase1 = fp1;
        m_FiewPurchase2 = fp2;
        m_FiewPurchase3 = fp3;
    }

    public void SetFiewSell(FiewSellModel fiewSell) => m_FiewSell = fiewSell;

    public void SetRGBColors(ColorType[] types) => m_RGBColors = types;

    public int GetRGBColorCount(ColorType type)
    {
        return type switch
        {
            ColorType.Red => m_RGBColors.Where(col => col == ColorType.Red).Count(),
            ColorType.Green => m_RGBColors.Where(col => col == ColorType.Green).Count(),
            ColorType.Blue => m_RGBColors.Where(col => col == ColorType.Blue).Count(),
            _ => 0
        };
    }
}