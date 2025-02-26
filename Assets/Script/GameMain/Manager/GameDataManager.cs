using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : SingletonBehaviour<GameDataManager>
{
    [SerializeField] private Transform m_CustomerUnifyObject;

    private FiewsModel m_FiewsModel;
    private ScoreModel m_ScoreModel;
    private GameInfoModel m_GameInfoModel;
    private CustomersModel m_CustomersModel;
    private CustomerGaugeModel m_CustomerGaugeModel;
    private ExpansionModel m_ExpansionModel;

    public bool IsSuccessTurn => GameInfoModel.TargetRank <= ScoreModel.RankStatus;
    public bool IsDoableNextTuen => GameInfoModel.CullentTurn < 3;

    public void InitFiewsModel(FiewPurchaseModel fp1, FiewPurchaseModel fp2, FiewPurchaseModel fp3) => m_FiewsModel = new FiewsModel(fp1, fp2, fp3);
    public void InitScoreModel() => m_ScoreModel = new ScoreModel();
    public void InitGameInfoModel(GameInfoUI gameInfoUI) => m_GameInfoModel = new GameInfoModel(gameInfoUI, ScriptablesManager.Instance.MainClips.GetAudioClipAsType(MusicType.Mus1).length);
    public void InitCustomersModel(int maxCustomerCount) => m_CustomersModel = new CustomersModel(maxCustomerCount, m_CustomerUnifyObject);
    public void InitCustomerGaugeModel() => m_CustomerGaugeModel = new CustomerGaugeModel();
    public void InitExpansionModel() => m_ExpansionModel = new ExpansionModel();

    public void UpdateScore() => m_ScoreModel.UpdateScore(m_FiewsModel, m_CustomersModel);
    public void UpdateRank() => m_ScoreModel.UpdateRank();

    public FiewsModel FiewsModel => m_FiewsModel;
    public ScoreModel ScoreModel => m_ScoreModel;
    public GameInfoModel GameInfoModel => m_GameInfoModel;
    public CustomersModel CustomersModel => m_CustomersModel;
    public CustomerGaugeModel CustomerGaugeModel => m_CustomerGaugeModel;
    public ExpansionModel ExpansionModel => m_ExpansionModel;
}
