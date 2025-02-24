using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCustomerUI : CustomerUIBase
{
    [SerializeField] private TMPro.TextMeshProUGUI m_CustomerCountText;

    private RandomSpawnCustomerPresenter m_CustomerManager;

    public TMPro.TextMeshProUGUI CustomerCountText => m_CustomerCountText;


    private void Awake()
    {
    }


    void Start()
    {
        m_CustomerManager = new RandomSpawnCustomerPresenter(this);  //FixMe : GaugeSpawnCustomerPresenter ‚É‚·‚é
        m_CustomerManager.Start();
    }


    void Update()
    {
        m_CustomerManager?.Update();
    }

    private void FixedUpdate()
    {
        m_CustomerManager?.FixedUpdate();
    }

    public void UpdateCustomerCountText(string text) => m_CustomerCountText.text = text;
}
