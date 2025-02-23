using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGaugeUI : MonoBehaviour
{
    private CustomerGaugePresenter m_CustomerGaugePresenter;

    [SerializeField] private GaugeUI m_RedGauge;
    [SerializeField] private GaugeUI m_GreenGauge;
    [SerializeField] private GaugeUI m_BlueGauge;

    public GaugeUI RedGauge => m_RedGauge;
    public GaugeUI GreenGauge => m_GreenGauge;
    public GaugeUI BlueGauge => m_BlueGauge;

    private void Awake()
    {
        m_CustomerGaugePresenter = new CustomerGaugePresenter(this);
    }

    private void Start()
    {
        GameDataManager.Instance.InitCustomerGaugeModel();
    }

    private void Update()
    {
        m_CustomerGaugePresenter.Update();
    }
    private void FixedUpdate()
    {
        m_CustomerGaugePresenter.FixedUpdate();
    }
}
