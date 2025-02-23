using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeSpawnCustomerPresenter : CustomersPresenterBase<CustomerGaugeUI>
{


    public GaugeSpawnCustomerPresenter(CustomerGaugeUI customerUI) : base(customerUI)
    {
    }

    protected override void AddCustomer(ColorType type)
    {

    }

    public override void Start()
    {
        UpdateCountText(ColorType.Red);
        UpdateCountText(ColorType.Green);
        UpdateCountText(ColorType.Blue);
    }

    public override void FixedUpdate()
    {
        UpdateGaugeModel();
    }

    private void UpdateCountText(ColorType type) 
        => m_CustomerUI.UpdateGaugeText(type, GameDataManager.Instance.CustomersModel.GetCustomerCountCount(type));

    private void UpdateGaugeUI(ColorType type)
         => m_CustomerUI.GetGaugeUI(type).UpdateGaugeFill(GameDataManager.Instance.CustomerGaugeModel.GetGauge(type));


    private void UpdateGaugeModel()
    {
        UpdateGauge(ColorType.Red, 0.01f);
        UpdateGauge(ColorType.Green, 0.01f);
        UpdateGauge(ColorType.Blue, 0.01f);
    }



    private void UpdateGauge(ColorType type, float gaugeSpeed)
    {
        GameDataManager.Instance.CustomerGaugeModel.AddGauge(type, gaugeSpeed);
        UpdateGaugeUI(type);

        if (!GameDataManager.Instance.CustomerGaugeModel.GetIsFullGauge(type)) { return; }

        m_CustomerUI.GetGaugeUI(type).OnFullGauge();
        GameDataManager.Instance.CustomersModel.AddCustomer(GetCustomerObjAsColor(type));
        GameDataManager.Instance.CustomerGaugeModel.ResetGauge(type);
        GameDataManager.Instance.UpdateScore();
        UpdateCountText(type);
    }
}

public class GaugeCustomerModel
{
    //必要ならそれぞれの色の客が増えるスピードをここで管理する (変数必要ないかも)
}