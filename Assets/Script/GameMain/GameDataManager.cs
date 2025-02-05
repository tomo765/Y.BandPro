using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonBehaviour<GameDataManager>
{
    private FiewsModel m_FiewsModel;
    private ScoreModel m_ScoreModel;
    private CustomersModel m_CustomersModel;


    public void InitFiewsModel(FiewPurchase fp1, FiewPurchase fp2, FiewPurchase fp3) => m_FiewsModel = new FiewsModel(fp1, fp2, fp3);
    public void InitScoreModel() => m_ScoreModel = new ScoreModel();
    public void InitCustomersModel(int maxCustomerCount) => m_CustomersModel = new CustomersModel(maxCustomerCount);


    public FiewsModel FiewsModel => m_FiewsModel;
    public ScoreModel ScoreModel => m_ScoreModel;
    public CustomersModel CustomersModel => m_CustomersModel;
}
