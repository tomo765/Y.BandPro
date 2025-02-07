using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private CustomerObject m_RedCustomer;
    [SerializeField] private CustomerObject m_GreenCustomer;
    [SerializeField] private CustomerObject m_BlueCustomer;

    [SerializeField] private TMPro.TextMeshProUGUI m_CustomerCountText;

    private CustomersManagerBase m_CustomerManager;

    public CustomerObject RedCustomer => m_RedCustomer;
    public CustomerObject GreenCustomer => m_GreenCustomer;
    public CustomerObject BlueCustomer => m_BlueCustomer;

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
