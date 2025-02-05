using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI m_CustomerCountText;

    private CustomersManagerBase m_CustomerManager;

    public TMPro.TextMeshProUGUI CustomerCountText => m_CustomerCountText;


    private void Awake()
    {
    }


    void Start()
    {
        m_CustomerManager = new RandomIncreaseCustomer(this);
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
