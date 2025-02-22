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


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // UpdateGaugeFill() の引数には、CustomerGaugeModel の それぞれのゲージの値が入る
    private void UpdateGaugeUI()
    {
        m_CustomerGaugeUI.RedGauge.UpdateGaugeFill(1);
        m_CustomerGaugeUI.GreenGauge.UpdateGaugeFill(1);
        m_CustomerGaugeUI.BlueGauge.UpdateGaugeFill(1);
    }
}
