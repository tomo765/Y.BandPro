using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TText = TMPro.TextMeshProUGUI;

public class CustomerGaugeUI : CustomerUIBase
{
    private GaugeSpawnCustomerPresenter m_GaugeSpawnCustomerPresenter;

    [SerializeField, Space(10)] private GaugeUI m_RedGauge;
    [SerializeField] private TText m_RedGaugeText;
    [SerializeField] private GaugeUI m_GreenGauge;
    [SerializeField] private TText m_GreenGaugeText;
    [SerializeField] private GaugeUI m_BlueGauge;
    [SerializeField] private TText m_BlueGaugeText;

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_GaugeSpawnCustomerPresenter = new GaugeSpawnCustomerPresenter(this);

        GameDataManager.Instance.InitCustomerGaugeModel();
        m_GaugeSpawnCustomerPresenter.Start();
    }

    private void Update()
    {
        m_GaugeSpawnCustomerPresenter.Update();
    }
    private void FixedUpdate()
    {
        m_GaugeSpawnCustomerPresenter.FixedUpdate();
    }

    public GaugeUI GetGaugeUI(ColorType type)
    {
        return (type) switch
        {
            ColorType.Red => m_RedGauge,
            ColorType.Green => m_GreenGauge,
            ColorType.Blue => m_BlueGauge,
            _ => null,
        };
    }
    public void UpdateGaugeText(ColorType type , int count)
    {
        switch (type)
        {
            case ColorType.Red:
                m_RedGaugeText.text = $"x {count}";
                break;
            case ColorType.Green:
                m_GreenGaugeText.text = $"x {count}";
                break;
            case ColorType.Blue:
                m_BlueGaugeText.text = $"x {count}";
                break;
        }
    }
}
