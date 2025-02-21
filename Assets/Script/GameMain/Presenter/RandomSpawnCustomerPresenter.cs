using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnCustomerPresenter : CustomersPresenterBase
{
    private RandomCustomerModel m_RCModel;

    public RandomCustomerModel RCModel => m_RCModel;

    public RandomSpawnCustomerPresenter(CustomerUI customerUI) : base(customerUI)
    {
        m_RCModel = new RandomCustomerModel();
    }

    private CustomerObject GetCustomerObjAsColor(ColorType type)
    {
        return type switch
        {
            ColorType.Red => m_CustomerUI.RedCustomer,
            ColorType.Green => m_CustomerUI.GreenCustomer,
            ColorType.Blue => m_CustomerUI.BlueCustomer,
            _ => null
        };
    }

    protected override void AddCustomer()
    {
        if(GameDataManager.Instance.CustomersModel.CustomerCount >= GameDataManager.Instance.CustomersModel.MaxCustomerCount) { return; }

        ColorType type = GameDataManager.Instance.CustomersModel.GetRandomColorType();
        GameDataManager.Instance.CustomersModel.AddCustomer(new CustomerModel(GetCustomerObjAsColor(type).Instantiate()));
    }


    public override void Start()
    {
        AddCustomer();
    }

    public override void FixedUpdate()
    {
        m_CustomerUI.UpdateCustomerCountText(GameDataManager.Instance.CustomersModel.CustomerCount + " / " + GameDataManager.Instance.CustomersModel.MaxCustomerCount);
    }

    public override void Update()
    {
        //1ターン目は1～10人, 2ターン目は11～20人、3ターン目は21～30人で増える
        //ターン中は7.5秒毎に1人客が増える
        int cullentCustomerCount = Mathf.FloorToInt(SoundManager.Instance.MainSoundTime / m_RCModel.DefaultIncreaseTime);
        cullentCustomerCount += (GameDataManager.Instance.GameInfoModel.CullentTurn - 1) * 10;

        if (cullentCustomerCount >= GameDataManager.Instance.CustomersModel.CustomerCount)
        {
            AddCustomer();
            GameDataManager.Instance.UpdateScore();
            GameDataManager.Instance.UpdateRank();
        }
    }
}

public class RandomCustomerModel
{
    private float m_DefaultIncreaseTime = 7.5f;
    private float m_IncreaseMultiplier = 1;

    public float DefaultIncreaseTime => m_DefaultIncreaseTime;
    public float IncreaseMultiplier => m_IncreaseMultiplier;

    public void SetIncreaseMultiplier(float mlt) => m_IncreaseMultiplier = mlt;
}