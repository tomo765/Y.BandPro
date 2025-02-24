using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GaugeSpawnCustomerPresenter : CustomersPresenterBase<CustomerGaugeUI>
{
    private GaugeCustomerModel m_GaugeCustomerModel;

    public GaugeSpawnCustomerPresenter(CustomerGaugeUI customerUI) : base(customerUI)
    {
        m_GaugeCustomerModel = new GaugeCustomerModel();
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
        UpdateGauge(Time.fixedDeltaTime);
        UpdateCustomersPay(Time.fixedDeltaTime);
    }

    private void UpdateCountText(ColorType type) 
        => m_CustomerUI.UpdateGaugeText(type, GameDataManager.Instance.CustomersModel.GetCustomerCount(type));

    private void UpdateGaugeUI(ColorType type)
         => m_CustomerUI.GetGaugeUI(type).UpdateGaugeFill(GameDataManager.Instance.CustomerGaugeModel.GetGauge(type));


    private void UpdateGauge(float elapsedTime)
    {
        if (!SoundManager.Instance.IsPlaySound) { return; }

        UpdateGauge(ColorType.Red, elapsedTime * Mathf.Max(1, GameDataManager.Instance.FiewsModel.GetRGBColorCount(ColorType.Red)));
        UpdateGauge(ColorType.Green, elapsedTime * Mathf.Max(1, GameDataManager.Instance.FiewsModel.GetRGBColorCount(ColorType.Green)));
        UpdateGauge(ColorType.Blue, elapsedTime * Mathf.Max(1, GameDataManager.Instance.FiewsModel.GetRGBColorCount(ColorType.Blue)));

        void UpdateGauge(ColorType type, float gaugeSpeed)
        {
            m_GaugeCustomerModel.AddGaugeProgress(type, gaugeSpeed);
            GameDataManager.Instance.CustomerGaugeModel.UpdateGauge(type, m_GaugeCustomerModel.GetGaugePercent(type));
            UpdateGaugeUI(type);
            if (!GameDataManager.Instance.CustomerGaugeModel.GetIsFullGauge(type)) { return; }

            m_CustomerUI.GetGaugeUI(type).OnFullGauge();
            m_GaugeCustomerModel.ResetGaugeProgress(type);

            GameDataManager.Instance.CustomersModel.AddCustomer(GetCustomerObjAsColor(type));
            GameDataManager.Instance.CustomerGaugeModel.ResetGauge(type);
            GameDataManager.Instance.UpdateScore();
            GameDataManager.Instance.UpdateRank();

            UpdateCountText(type);
        }
    }
}

public class GaugeCustomerModel
{
    public readonly float DefaultGaugeFullTime = 15f;

    private float m_RedGauge = 0;
    private float m_GreenGauge = 0;
    private float m_BlueGauge = 0;

    public float GetGaugePercent(ColorType type)
    {
        return (type) switch
        {
            ColorType.Red => GetPercent(ref m_RedGauge),
            ColorType.Green => GetPercent(ref m_GreenGauge),
            ColorType.Blue => GetPercent(ref m_BlueGauge),
            _ => 0
        };

        float GetPercent(ref float gauge) => gauge / DefaultGaugeFullTime;
    }

    public void AddGaugeProgress(ColorType type, float value)
    {
        switch(type)
        {
            case ColorType.Red: AddValue(ref m_RedGauge, value); break;
            case ColorType.Green: AddValue(ref m_GreenGauge, value); break;
            case ColorType.Blue: AddValue(ref m_BlueGauge, value); break;
        }


        void AddValue(ref float gauge, float value) => gauge += value;
    }

    public void ResetGaugeProgress(ColorType type)
    {
        switch (type)
        {
            case ColorType.Red: m_RedGauge = 0; break;
            case ColorType.Green: m_GreenGauge = 0; break;
            case ColorType.Blue: m_BlueGauge = 0; break;
        }
    }
}