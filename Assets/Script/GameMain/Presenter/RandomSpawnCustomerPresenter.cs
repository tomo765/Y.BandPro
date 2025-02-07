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

    private void AddTime()
    {
        m_RCModel.SetCullentElapseTime(m_RCModel.CullentElapseTime + Time.deltaTime * m_RCModel.IncreaseMultiplier);
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
        AddTime();
        if (m_RCModel.CullentElapseTime >= m_RCModel.DefaultIncreaseTime)
        {
            AddCustomer();
            GameDataManager.Instance.UpdateScore();
            GameDataManager.Instance.UpdateRank();
            m_RCModel.SetCullentElapseTime(m_RCModel.CullentElapseTime - m_RCModel.DefaultIncreaseTime);
        }
    }
}

public class RandomCustomerModel
{
    private float m_DefaultIncreaseTime = 7.5f;
    private float m_CullentElapseTime = 0;
    private float m_IncreaseMultiplier = 1;

    public float DefaultIncreaseTime => m_DefaultIncreaseTime;
    public float CullentElapseTime => m_CullentElapseTime;
    public float IncreaseMultiplier => m_IncreaseMultiplier;

    public void SetCullentElapseTime(float time) => m_CullentElapseTime = time;
    public void SetIncreaseMultiplier(float mlt) => m_IncreaseMultiplier = mlt;
}