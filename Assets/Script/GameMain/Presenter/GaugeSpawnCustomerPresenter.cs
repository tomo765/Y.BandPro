using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeSpawnCustomerPresenter : CustomersPresenterBase<CustomerGaugeUI>
{
    private GaugeCustomerModel m_GaugeCustomerModel;

    public GaugeSpawnCustomerPresenter(CustomerGaugeUI customerUI) : base(customerUI)
    {
        m_GaugeCustomerModel = new GaugeCustomerModel();
        m_GaugeCustomerModel.SetNextFullTime(ColorType.Red, m_GaugeCustomerModel.DefaultGaugeFullTime);
        m_GaugeCustomerModel.SetNextFullTime(ColorType.Green, m_GaugeCustomerModel.DefaultGaugeFullTime);
        m_GaugeCustomerModel.SetNextFullTime(ColorType.Blue, m_GaugeCustomerModel.DefaultGaugeFullTime);
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
        GameDataManager.Instance.CustomerGaugeModel.UpdateGauge(type, m_GaugeCustomerModel.GetGaugePercent(type, SoundManager.Instance.MainSoundTime));
        UpdateGaugeUI(type);

        if (!GameDataManager.Instance.CustomerGaugeModel.GetIsFullGauge(type)) { return; }

        m_CustomerUI.GetGaugeUI(type).OnFullGauge();
        m_GaugeCustomerModel.SetNextFullTime(type, m_GaugeCustomerModel.GetNextFullTime(type) + m_GaugeCustomerModel.DefaultGaugeFullTime);

        GameDataManager.Instance.CustomersModel.AddCustomer(GetCustomerObjAsColor(type));
        GameDataManager.Instance.CustomerGaugeModel.ResetGauge(type);
        GameDataManager.Instance.UpdateScore();
        UpdateCountText(type);
    }
}

public class GaugeCustomerModel
{
    //必要ならそれぞれの色の客が増えるスピードをここで管理する (変数必要ないかも)
    public readonly float DefaultGaugeFullTime = 15f;

    private float m_PrevRedFull = 0;
    private float m_PrevGreenFull = 0;
    private float m_PrevBlueFull = 0;
    private float m_NextRedFull = 0;
    private float m_NextGreenFull = 0;
    private float m_NextBlueFull = 0;

    private float GetPercent(float elapseTime, float nextFull)
        => 1 - (Mathf.Max(0, nextFull - elapseTime) / DefaultGaugeFullTime);

    /// <summary> 0 ～ 1 の間の値を取得する </summary>
    /// <remarks> デバッグ時に巻き戻しでマイナスの値が返ってくる可能性があるから、0未満の時は0を返す。</remarks>
    public float GetGaugePercent(ColorType type, float elapsedTime)
    {
        return (type) switch
        {
            ColorType.Red => GetPercent(elapsedTime, m_NextRedFull),
            ColorType.Green => GetPercent(elapsedTime, m_NextGreenFull),
            ColorType.Blue => GetPercent(elapsedTime, m_NextBlueFull),
            _ => 0,
        };
    }

    public float GetNextFullTime(ColorType type)
    {
        return (type) switch
        {
            ColorType.Red => m_NextRedFull,
            ColorType.Green => m_NextGreenFull,
            ColorType.Blue => m_NextBlueFull,
            _ => 0,
        };
    }

    public void SetNextFullTime(ColorType type, float nextTime)
    {
        switch (type)
        {
            case ColorType.Red:
                m_PrevRedFull = m_NextRedFull;
                m_NextRedFull = nextTime;
                break;
            case ColorType.Green:
                m_PrevGreenFull = m_NextGreenFull;
                m_NextGreenFull = nextTime;
                break;
            case ColorType.Blue:
                m_PrevBlueFull = m_NextBlueFull;
                m_NextBlueFull = nextTime;
                break;
        }
    }
}