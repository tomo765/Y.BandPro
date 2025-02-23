using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGaugePresenter
{
    private CustomerGaugeUI m_CustomerGaugeUI;

    private CustomerGaugePresenter() { }
    public CustomerGaugePresenter(CustomerGaugeUI customerGaugeUI)
    {
        m_CustomerGaugeUI = customerGaugeUI;
    }

    //一定時間経過で CustomerGaugeModel.Add○○Gaugeを呼び出す。
    //その後、UI の更新を行う。


    public void Start()
    {
        
    }

    public void Update()
    {
        UpdateGaugeUI();
    }

    public void FixedUpdate()
    {
        UpdateGaugeModel();
    }

    private void UpdateGaugeModel()
    {
        GameDataManager.Instance.CustomerGaugeModel.AddRedGauge(0.01f);
        GameDataManager.Instance.CustomerGaugeModel.AddGreenGauge(0.01f);
        GameDataManager.Instance.CustomerGaugeModel.AddBlueGauge(0.01f);

        if (GameDataManager.Instance.CustomerGaugeModel.IsFullRedGauge)
        {
            m_CustomerGaugeUI.RedGauge.OnFullGauge();
            GameDataManager.Instance.CustomerGaugeModel.ResetRedGauge();
        }
        if (GameDataManager.Instance.CustomerGaugeModel.IsFullGreenGauge)
        {
            m_CustomerGaugeUI.GreenGauge.OnFullGauge();
            GameDataManager.Instance.CustomerGaugeModel.ResetGreenGauge();
        }
        if (GameDataManager.Instance.CustomerGaugeModel.IsFullBlueGauge)
        {
            m_CustomerGaugeUI.BlueGauge.OnFullGauge();
            GameDataManager.Instance.CustomerGaugeModel.ResetBlueGauge();
        }
    }

    // UpdateGaugeFill() の引数には、CustomerGaugeModel の それぞれのゲージの値が入る
    private void UpdateGaugeUI()
    {
        m_CustomerGaugeUI.RedGauge.UpdateGaugeFill(GameDataManager.Instance.CustomerGaugeModel.RedGauge);
        m_CustomerGaugeUI.GreenGauge.UpdateGaugeFill(GameDataManager.Instance.CustomerGaugeModel.GreenGauge);
        m_CustomerGaugeUI.BlueGauge.UpdateGaugeFill(GameDataManager.Instance.CustomerGaugeModel.BlueGauge);
    }
}
