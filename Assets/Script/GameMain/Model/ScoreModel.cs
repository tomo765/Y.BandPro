using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreModel
{
    private int m_Score;
    private RankStatus m_RankStatus = RankStatus.D;

    public RankStatus RankStatus => m_RankStatus;
    public string Rank => m_RankStatus.ToString().Replace("_Plus", "+");
    public int Score => m_Score;

    private const int FiewsBaseScore = 10;
    private const int CustomersBaseScore = 5;

    public void UpdateScore(FiewsModel fiewsModel, CustomersModel customersModel)
    {
        int fiewsScore = FiewsBaseScore + CalcFiewsMmberPoint(fiewsModel) + CalcFiewsGenrePoint(fiewsModel);
        int customerCountScore = CustomersBaseScore * CalcCustomersCountPoint(customersModel);
        int customersColorScore = CalcCustomersColorPoint(fiewsModel, customersModel) * customersModel.CustomerCount;

        m_Score = fiewsScore * customerCountScore + customersColorScore;
    }
    public void UpdateRank()
    {
        m_RankStatus = GetRank();

        RankStatus GetRank()
        {
            if     (Score < 200000)   { return RankStatus.D; }
            else if(Score < 450000)   { return RankStatus.D_Plus; }
            else if(Score < 800000)   { return RankStatus.C; }
            else if(Score < 1350000)  { return RankStatus.C_Plus; }
            else if(Score < 1850000)  { return RankStatus.B_Plus; }
            else if(Score < 2400000)  { return RankStatus.B_Plus; }
            else if(Score < 2800000)  { return RankStatus.A; }
            else                      { return RankStatus.S; }
        }
    }

    private int CalcFiewsMmberPoint(FiewsModel fiewsModel)
    {
        int point = 0;
        point += GetPoint(fiewsModel.FiewPurchase1.FiewType1);
        point += GetPoint(fiewsModel.FiewPurchase1.FiewType2);
        point += GetPoint(fiewsModel.FiewPurchase2.FiewType1);
        point += GetPoint(fiewsModel.FiewPurchase2.FiewType2);
        point += GetPoint(fiewsModel.FiewPurchase3.FiewType1);
        point += GetPoint(fiewsModel.FiewPurchase3.FiewType2);

        return point;

        int GetPoint(ColorType type) => type != ColorType.White ? 10 : 0;
    }
    private int CalcFiewsGenrePoint(FiewsModel fiewsModel)
    {
        return GetPoint(fiewsModel.FiewPurchase1.MixedColor, fiewsModel.FiewPurchase2.MixedColor, fiewsModel.FiewPurchase3.MixedColor);

        int GetPoint(ColorType mixedType1, ColorType mixedType2, ColorType mixedType3)
        {
            if(mixedType1 == ColorType.White && mixedType2 == ColorType.White && mixedType3 == ColorType.White) { return 0; }
            if(mixedType1 != mixedType2 && mixedType1 != mixedType3) { return 0; }

            if(mixedType1 == mixedType2 && mixedType1 == mixedType3) { return 50; }
            
            return 20;
        }

    }
    private int CalcCustomersCountPoint(CustomersModel customersModel)
    {
        return Mathf.FloorToInt(customersModel.CustomerCount * 0.1f) + 1;
    }
    private int CalcCustomersColorPoint(FiewsModel fiewsModel, CustomersModel customersModel)
    {
        int point = 0;

        for (int i = 0; i < customersModel.CustomerCount; i++)
        {
            var node = FiewPurchaseModel.ColorTransitionChain.Find(customersModel.AllCustomerColor[i]);

            List<ColorType> findColors = new List<ColorType>();
            findColors.Add(node.Previous.Value);
            findColors.Add(node.Value);
            findColors.Add(node.Next != null ? node.Next.Value : FiewPurchaseModel.ColorTransitionChain.First.Value);

            if (fiewsModel.AllFiewColor.Contains(findColors[0]) || 
                fiewsModel.AllFiewColor.Contains(findColors[1]) || 
                fiewsModel.AllFiewColor.Contains(findColors[2]))
            {
                point += 10;
            }
        }

        return point;
    }
}

public enum RankStatus
{
    D,
    D_Plus,
    C,
    C_Plus,
    B,
    B_Plus,
    A,
    S
}