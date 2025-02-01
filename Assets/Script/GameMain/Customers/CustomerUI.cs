using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI m_CustomerCountText;

    private CustomersManagerBase m_CustomerManager;

    void Start()
    {
        m_CustomerManager = new RandomIncreaseCustomer();
        m_CustomerManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        m_CustomerManager?.Update();
    }

    private void FixedUpdate()
    {
        m_CustomerCountText.text = m_CustomerManager.CustomerCount.ToString() + " / " + m_CustomerManager.MaxCustomerCount.ToString();
    }
}
